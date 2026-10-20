using InstaConnect.Common.Events.Features.AccessTokens.Models;
using InstaConnect.Common.Tests.Features.DataAttributes.Enums.Base;
using InstaConnect.Identity.Application.Features.UserClaims.Commands.Add;
using InstaConnect.Identity.Application.Tests.Features.UserClaims.Builders;
using InstaConnect.Identity.Application.Tests.Integration.Features.UserClaims.Utilities;
using InstaConnect.Identity.Tests.Features.UserClaims.DataAttributes.Claim;

namespace InstaConnect.Identity.Application.Tests.Integration.Features.UserClaims.Handlers;

public class AddUserClaimCommandHandlerIntegrationTests : BaseUserClaimApplicationCommandIntegrationTest
{
	private readonly AddUserClaimCommandRequestBuilderFactory _requestBuilderFactory;
	private readonly AddUserClaimCommandRequestBuilder _requestBuilder;
	private readonly AddUserClaimCommandRequest _request;

	public AddUserClaimCommandHandlerIntegrationTests(IdentityWebApplicationFactory webApplicationFactory)
		: base(webApplicationFactory)
	{
		_requestBuilderFactory = new();
		_requestBuilder = _requestBuilderFactory.Create(User);
		_request = _requestBuilder.Build();
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
	public async Task SendAsync_ShouldThrowUserClaimAlreadyExistsException_WhenUserClaimAlreadyExists()
	{
		// Arrange
		await ServiceScope.AddAsync(UserClaim, CancellationToken);

		// Assert
		await Sender.ShouldThrowUserClaimAlreadyExistsExceptionAsync(_request, CancellationToken);
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task SendAsync_ShouldThrowUserClaimAlreadyExistsException_WhenUserClaimAlreadyExistsAndIdIsInvalid(
		IStringTransformer transformer)
	{
		// Arrange
		await ServiceScope.AddAsync(UserClaim, CancellationToken);
		var request = _requestBuilder.WithId(transformer).Build();

		// Assert
		await Sender.ShouldThrowUserClaimAlreadyExistsExceptionAsync(request, CancellationToken);
	}

	[Fact]
	public async Task SendAsync_ShouldReturnResponse_WhenRequestIsValid()
	{
		// Act
		var response = await Sender.SendAsync(_request, CancellationToken);
		var userClaim = await ServiceScope.GetByIdAsync(response, CancellationToken);

		// Assert
		response.ShouldSatisfy(_request, userClaim);
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task SendAsync_ShouldReturnResponse_WhenRequestAndIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithId(transformer).Build();

		// Act
		var response = await Sender.SendAsync(request, CancellationToken);
		var userClaim = await ServiceScope.GetByIdAsync(response, CancellationToken);

		// Assert
		response.ShouldSatisfy(request, userClaim);
	}

	[Fact]
	public async Task SendAsync_ShouldAddUserClaim_WhenRequestIsValid()
	{
		// Act
		var response = await Sender.SendAsync(_request, CancellationToken);
		var userClaim = await ServiceScope.GetByIdAsync(response, CancellationToken);

		// Assert
		userClaim.ShouldSatisfy(_request);
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task SendAsync_ShouldAddUserClaim_WhenRequestAndIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithId(transformer).Build();

		// Act
		var response = await Sender.SendAsync(request, CancellationToken);
		var userClaim = await ServiceScope.GetByIdAsync(response, CancellationToken);

		// Assert
		userClaim.ShouldSatisfy(_request);
	}

	[Fact]
	public async Task SendAsync_ShouldPublishUserClaimAddedEvent_WhenRequestIsValid()
	{
		// Act
		var response = await Sender.SendAsync(_request, CancellationToken);
		var userClaim = await ServiceScope.GetByIdAsync(response, CancellationToken);
		var eventRequest = await ClaimEventClient.PublishedAddedAsync(CancellationToken);

		// Assert
		eventRequest.ShouldSatisfy(_request, userClaim);
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task SendAsync_ShouldPublishUserClaimAddedEvent_WhenRequestAndIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithId(transformer).Build();

		// Act
		var response = await Sender.SendAsync(request, CancellationToken);
		var userClaim = await ServiceScope.GetByIdAsync(response, CancellationToken);
		var eventRequest = await ClaimEventClient.PublishedAddedAsync(CancellationToken);

		// Assert
		eventRequest.ShouldSatisfy(request, userClaim);
	}
}
