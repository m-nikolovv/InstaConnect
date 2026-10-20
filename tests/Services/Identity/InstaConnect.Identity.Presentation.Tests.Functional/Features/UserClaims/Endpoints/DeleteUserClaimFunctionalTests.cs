using InstaConnect.Common.Domain.Features.AccessTokens.Models;
using InstaConnect.Common.Tests.Features.DataAttributes.Enums.Base;
using InstaConnect.Identity.Presentation.Features.UserClaims.Models.Requests;
using InstaConnect.Identity.Presentation.Tests.Features.UserClaims.Builders;
using InstaConnect.Identity.Presentation.Tests.Functional.Features.UserClaims.Utilities;
using InstaConnect.Identity.Tests.Features.UserClaims.DataAttributes.Claim;

namespace InstaConnect.Identity.Presentation.Tests.Functional.Features.UserClaims.Endpoints;

public class DeleteUserClaimFunctionalTests : BaseUserClaimPresentationCommandFunctionalTest
{
	private readonly DeleteUserClaimApiRequestBuilderFactory _requestBuilderFactory;
	private readonly DeleteUserClaimApiRequestBuilder _requestBuilder;
	private readonly DeleteUserClaimApiRequest _request;

	public DeleteUserClaimFunctionalTests(IdentityWebApplicationFactory webApplicationFactory)
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

	[Fact]
	public async Task DeleteAsync_ShouldReturnUnauthorizedStatusCode_WhenRequestIsUnauthorized()
	{
		// Act
		var response = await ClaimApiClient.DeleteUnauthorizedStatusCodeAsync(_request, CancellationToken);

		// Assert
		response.ShouldBeUnauthorized();
	}

	[Fact]
	public async Task DeleteAsync_ShouldReturnForbiddenStatusCode_WhenRequestIsForbidden()
	{
		// Act
		var response = await ClaimApiClient.DeleteForbiddenStatusCodeAsync(_request, CancellationToken);

		// Assert
		response.ShouldBeForbidden();
	}

	[Theory]
	[UserIdTooShortData]
	[UserIdTooLongData]
	public async Task DeleteAsync_ShouldHaveBadRequestStatusCode_WhenIdIsInvalid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithId(transformer).Build();

		// Act
		var response = await ClaimApiClient.DeleteStatusCodeAsync(request, CancellationToken);

		// Assert
		response.ShouldBeBadRequest();
	}

	[Theory]
	[UserIdTooShortWithMessageData]
	[UserIdTooLongWithMessageData]
	public async Task DeleteAsync_ShouldHaveBadRequestProblemDetails_WhenIdIsInvalid(
		IStringTransformer transformer,
		IStringMessageTransformer messageTransformer)
	{
		// Arrange
		var request = _requestBuilder.WithId(transformer).Build();

		// Act
		var response = await ClaimApiClient.DeleteProblemDetailsAsync(request, CancellationToken);

		// Assert
		response.ShouldSatisfyInvalidValidationForId(request, messageTransformer);
	}

	[Theory]
	[UserClaimClaimEmptyData]
	public async Task DeleteAsync_ShouldHaveBadRequestStatusCode_WhenClaimIsInvalid(IEnumTransformer<ApplicationClaims> transformer)
	{
		// Arrange
		var request = _requestBuilder.WithClaim(transformer).Build();

		// Act
		var response = await ClaimApiClient.DeleteStatusCodeAsync(request, CancellationToken);

		// Assert
		response.ShouldBeBadRequest();
	}

	[Theory]
	[UserClaimClaimEmptyWithMessageData]
	public async Task DeleteAsync_ShouldHaveBadRequestProblemDetails_WhenClaimIsInvalid(
		IEnumTransformer<ApplicationClaims> transformer,
		IEnumMessageTransformer<ApplicationClaims> messageTransformer)
	{
		// Arrange
		var request = _requestBuilder.WithClaim(transformer).Build();

		// Act
		var response = await ClaimApiClient.DeleteProblemDetailsAsync(request, CancellationToken);

		// Assert
		response.ShouldSatisfyInvalidValidationForClaim(request, messageTransformer);
	}

	[Fact]
	public async Task DeleteAsync_ShouldHaveNotFoundStatusCode_WhenUserNotFound()
	{
		// Arrange
		await ServiceScope.DeleteAsync(User, CancellationToken);

		// Act
		var response = await ClaimApiClient.DeleteStatusCodeAsync(_request, CancellationToken);

		// Assert
		response.ShouldBeNotFound();
	}

	[Fact]
	public async Task DeleteAsync_ShouldHaveUserNotFoundProblemDetails_WhenUserNotFound()
	{
		// Arrange
		await ServiceScope.DeleteAsync(User, CancellationToken);

		// Act
		var response = await ClaimApiClient.DeleteProblemDetailsAsync(_request, CancellationToken);

		// Assert
		response.ShouldSatisfyUserNotFound(_request);
	}

	[Fact]
	public async Task DeleteAsync_ShouldHaveNotFoundStatusCode_WhenUserClaimNotFound()
	{
		// Arrange
		await ServiceScope.DeleteAsync(UserClaim, CancellationToken);

		// Act
		var response = await ClaimApiClient.DeleteStatusCodeAsync(_request, CancellationToken);

		// Assert
		response.ShouldBeNotFound();
	}

	[Fact]
	public async Task DeleteAsync_ShouldHaveUserClaimNotFoundProblemDetails_WhenUserClaimNotFound()
	{
		// Arrange
		await ServiceScope.DeleteAsync(UserClaim, CancellationToken);

		// Act
		var response = await ClaimApiClient.DeleteProblemDetailsAsync(_request, CancellationToken);

		// Assert
		response.ShouldSatisfyUserClaimNotFound(_request);
	}

	[Fact]
	public async Task DeleteAsync_ShouldHaveNoContentStatusCode_WhenRequestIsValid()
	{
		// Act
		var response = await ClaimApiClient.DeleteStatusCodeAsync(_request, CancellationToken);

		// Assert
		response.ShouldBeNoContent();
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task DeleteAsync_ShouldHaveNoContentStatusCode_WhenRequestAndIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithId(transformer).Build();

		// Act
		var response = await ClaimApiClient.DeleteStatusCodeAsync(request, CancellationToken);

		// Assert
		response.ShouldBeNoContent();
	}

	[Fact]
	public async Task DeleteAsync_ShouldDeleteUserClaim_WhenRequestIsValid()
	{
		// Act
		await ClaimApiClient.DeleteAsync(_request, CancellationToken);
		var userClaim = await ServiceScope.GetByIdAsync(UserClaimId, CancellationToken);

		// Assert
		userClaim.ShouldBeNull();
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task DeleteAsync_ShouldDeleteUserClaim_WhenRequestAndIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithId(transformer).Build();

		// Act
		await ClaimApiClient.DeleteAsync(request, CancellationToken);
		var userClaim = await ServiceScope.GetByIdAsync(UserClaimId, CancellationToken);

		// Assert
		userClaim.ShouldBeNull();
	}

	[Fact]
	public async Task DeleteAsync_ShouldPublishUserClaimDeletedEvent_WhenRequestIsValid()
	{
		// Act
		await ClaimApiClient.DeleteAsync(_request, CancellationToken);
		var eventRequest = await ClaimEventClient.PublishedDeletedAsync(CancellationToken);

		// Assert
		eventRequest.ShouldSatisfy(_request, UserClaim);
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task DeleteAsync_ShouldPublishUserClaimDeletedEvent_WhenRequestAndIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithId(transformer).Build();

		// Act
		await ClaimApiClient.DeleteAsync(request, CancellationToken);
		var eventRequest = await ClaimEventClient.PublishedDeletedAsync(CancellationToken);

		// Assert
		eventRequest.ShouldSatisfy(request, UserClaim);
	}
}
