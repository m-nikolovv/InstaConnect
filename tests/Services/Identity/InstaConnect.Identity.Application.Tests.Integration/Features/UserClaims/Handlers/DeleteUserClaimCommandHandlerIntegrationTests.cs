using InstaConnect.Common.Domain.Features.AccessTokens.Models;
using InstaConnect.Common.Tests.Features.DataAttributes.Enums.Base;
using InstaConnect.Identity.Application.Features.UserClaims.Commands.Delete;
using InstaConnect.Identity.Application.Tests.Features.UserClaims.Builders;
using InstaConnect.Identity.Application.Tests.Integration.Features.UserClaims.Utilities;
using InstaConnect.Identity.Tests.Features.UserClaims.DataAttributes.Claim;

namespace InstaConnect.Identity.Application.Tests.Integration.Features.UserClaims.Handlers;

public class DeleteUserClaimCommandHandlerIntegrationTests : BaseUserClaimApplicationCommandIntegrationTest
{
	private readonly DeleteUserClaimCommandRequestBuilderFactory _requestBuilderFactory;
	private readonly DeleteUserClaimCommandRequestBuilder _requestBuilder;
	private readonly DeleteUserClaimCommandRequest _request;

	public DeleteUserClaimCommandHandlerIntegrationTests(IdentityWebApplicationFactory webApplicationFactory)
		: base(webApplicationFactory)
	{
		_requestBuilderFactory = new();
		_requestBuilder = _requestBuilderFactory.Create(UserClaim);
		_request = _requestBuilder.Build();
	}

	protected override async Task OnInitializeAsync()
	{
		await ServiceScope.AddAsync(UserClaim, CancellationToken);
	}

	[Theory]
	[UserIdNullWithMessageData]
	[UserIdEmptyWithMessageData]
	[UserIdTooShortWithMessageData]
	[UserIdTooLongWithMessageData]
	public async Task SendAsync_ShouldThrowValidationException_WhenIdIsInvalid(
		IStringTransformer transformer, IStringMessageTransformer messageTransformer)
	{
		// Arrange
		var request = _requestBuilder.WithId(transformer).Build();

		// Assert
		await Sender.ShouldThrowInvalidValidationExceptionForIdAsync(request, messageTransformer, CancellationToken);
	}

	[Theory]
	[UserClaimClaimEmptyWithMessageData]
	public async Task SendAsync_ShouldThrowValidationException_WhenClaimIsInvalid(
		IEnumTransformer<ApplicationClaims> transformer, IEnumMessageTransformer<ApplicationClaims> messageTransformer)
	{
		// Arrange
		var request = _requestBuilder.WithClaim(transformer).Build();

		// Assert
		await Sender.ShouldThrowInvalidValidationExceptionForClaimAsync(request, messageTransformer, CancellationToken);
	}

	[Fact]
	public async Task SendAsync_ShouldThrowUserNotFoundException_WhenUserNotFound()
	{
		// Arrange
		await ServiceScope.DeleteAsync(User, CancellationToken);

		// Assert
		await Sender.ShouldThrowUserNotFoundExceptionAsync(_request, CancellationToken);
	}

	[Fact]
	public async Task SendAsync_ShouldThrowUserClaimNotFoundException_WhenUserClaimNotFound()
	{
		// Arrange
		await ServiceScope.DeleteAsync(UserClaim, CancellationToken);

		// Assert
		await Sender.ShouldThrowUserClaimNotFoundExceptionAsync(_request, CancellationToken);
	}

	[Fact]
	public async Task SendAsync_ShouldDeleteUserClaim_WhenRequestIsValid()
	{
		// Act
		await Sender.SendAsync(_request, CancellationToken);
		var userClaim = await ServiceScope.GetByIdAsync(UserClaimId, CancellationToken);

		// Assert
		userClaim.ShouldBeNull();
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task SendAsync_ShouldDeleteUserClaim_WhenRequestAndIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithId(transformer).Build();

		// Act
		await Sender.SendAsync(request, CancellationToken);
		var userClaim = await ServiceScope.GetByIdAsync(UserClaimId, CancellationToken);

		// Assert
		userClaim.ShouldBeNull();
	}

	[Fact]
	public async Task SendAsync_ShouldPublishUserClaimDeletedEvent_WhenRequestIsValid()
	{
		// Act
		await Sender.SendAsync(_request, CancellationToken);
		var eventRequest = await ClaimEventClient.PublishedDeletedAsync(CancellationToken);

		// Assert
		eventRequest.ShouldSatisfy(_request, UserClaim);
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task SendAsync_ShouldPublishUserClaimDeletedEvent_WhenRequestAndIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithId(transformer).Build();

		// Act
		await Sender.SendAsync(request, CancellationToken);
		var eventRequest = await ClaimEventClient.PublishedDeletedAsync(CancellationToken);

		// Assert
		eventRequest.ShouldSatisfy(request, UserClaim);
	}
}
