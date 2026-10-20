using InstaConnect.Common.Domain.Features.AccessTokens.Models;
using InstaConnect.Identity.Presentation.Features.UserClaims.Models.Requests;
using InstaConnect.Identity.Presentation.Tests.Features.UserClaims.Builders;
using InstaConnect.Identity.Presentation.Tests.Functional.Features.UserClaims.Utilities;
using InstaConnect.Identity.Tests.Features.UserClaims.DataAttributes.Claim;

namespace InstaConnect.Identity.Presentation.Tests.Functional.Features.UserClaims.Endpoints;

public class AddUserClaimFunctionalTests : BaseUserClaimPresentationCommandFunctionalTest
{
	private readonly AddUserClaimApiRequestBuilderFactory _requestBuilderFactory;
	private readonly AddUserClaimApiRequestBuilder _requestBuilder;
	private readonly AddUserClaimApiRequest _request;

	public AddUserClaimFunctionalTests(IdentityWebApplicationFactory webApplicationFactory)
		: base(webApplicationFactory)
	{
		_requestBuilderFactory = new();
		_requestBuilder = _requestBuilderFactory.Create(User);
		_request = _requestBuilder.Build();
	}

	[Fact]
	public async Task AddAsync_ShouldReturnUnauthorizedStatusCode_WhenRequestIsUnauthorized()
	{
		// Act
		var response = await ClaimApiClient.AddUnauthorizedStatusCodeAsync(_request, CancellationToken);

		// Assert
		response.ShouldBeUnauthorized();
	}

	[Fact]
	public async Task AddAsync_ShouldReturnForbiddenStatusCode_WhenRequestIsForbidden()
	{
		// Act
		var response = await ClaimApiClient.AddForbiddenStatusCodeAsync(_request, CancellationToken);

		// Assert
		response.ShouldBeForbidden();
	}

	[Theory]
	[UserIdTooShortData]
	[UserIdTooLongData]
	public async Task AddAsync_ShouldHaveBadRequestStatusCode_WhenIdIsInvalid(IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithId(transformer).Build();

		// Act
		var response = await ClaimApiClient.AddStatusCodeAsync(request, CancellationToken);

		// Assert
		response.ShouldBeBadRequest();
	}

	[Theory]
	[UserIdTooShortWithMessageData]
	[UserIdTooLongWithMessageData]
	public async Task AddAsync_ShouldHaveBadRequestProblemDetails_WhenIdIsInvalid(
		IStringTransformer transformer,
		IStringMessageTransformer messageTransformer)
	{
		// Arrange
		var request = _requestBuilder.WithId(transformer).Build();

		// Act
		var response = await ClaimApiClient.AddProblemDetailsAsync(request, CancellationToken);

		// Assert
		response.ShouldSatisfyInvalidValidationForId(request, messageTransformer);
	}

	[Theory]
	[UserClaimClaimEmptyData]
	public async Task AddAsync_ShouldHaveBadRequestStatusCode_WhenClaimIsInvalid(IEnumTransformer<ApplicationClaims> transformer)
	{
		// Arrange
		var request = _requestBuilder.WithClaim(transformer).Build();

		// Act
		var response = await ClaimApiClient.AddStatusCodeAsync(request, CancellationToken);

		// Assert
		response.ShouldBeBadRequest();
	}

	[Theory]
	[UserClaimClaimEmptyWithMessageData]
	public async Task AddAsync_ShouldHaveBadRequestProblemDetails_WhenClaimIsInvalid(
		IEnumTransformer<ApplicationClaims> transformer,
		IEnumMessageTransformer<ApplicationClaims> messageTransformer)
	{
		// Arrange
		var request = _requestBuilder.WithClaim(transformer).Build();

		// Act
		var response = await ClaimApiClient.AddProblemDetailsAsync(request, CancellationToken);

		// Assert
		response.ShouldSatisfyInvalidValidationForClaim(request, messageTransformer);
	}

	[Fact]
	public async Task AddAsync_ShouldHaveNotFoundStatusCode_WhenUserNotFound()
	{
		// Arrange
		await ServiceScope.DeleteAsync(User, CancellationToken);

		// Act
		var response = await ClaimApiClient.AddStatusCodeAsync(_request, CancellationToken);

		// Assert
		response.ShouldBeNotFound();
	}

	[Fact]
	public async Task AddAsync_ShouldHaveUserNotFoundProblemDetails_WhenUserNotFound()
	{
		// Arrange
		await ServiceScope.DeleteAsync(User, CancellationToken);

		// Act
		var response = await ClaimApiClient.AddProblemDetailsAsync(_request, CancellationToken);

		// Assert
		response.ShouldSatisfyUserNotFound(_request);
	}

	[Fact]
	public async Task AddAsync_ShouldHaveBadRequestStatusCode_WhenUserClaimAlreadyExists()
	{
		// Arrange
		await ServiceScope.AddAsync(UserClaim, CancellationToken);

		// Act
		var response = await ClaimApiClient.AddStatusCodeAsync(_request, CancellationToken);

		// Assert
		response.ShouldBeBadRequest();
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task AddAsync_ShouldHaveBadRequestStatusCode_WhenUserClaimAlreadyExistsAndIdIsInvalid(
		IStringTransformer transformer)
	{
		// Arrange
		await ServiceScope.AddAsync(UserClaim, CancellationToken);
		var request = _requestBuilder.WithId(transformer).Build();

		// Act
		var response = await ClaimApiClient.AddStatusCodeAsync(request, CancellationToken);

		// Assert
		response.ShouldBeBadRequest();
	}

	[Fact]
	public async Task AddAsync_ShouldHaveUserClaimAlreadyExistsProblemDetails_WhenUserClaimAlreadyExists()
	{
		// Arrange
		await ServiceScope.AddAsync(UserClaim, CancellationToken);

		// Act
		var response = await ClaimApiClient.AddProblemDetailsAsync(_request, CancellationToken);

		// Assert
		response.ShouldSatisfyUserClaimAlreadyExists(_request);
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task AddAsync_ShouldHaveUserClaimAlreadyExistsProblemDetails_WhenUserClaimAlreadyExistsAndIdIsInvalid(
		IStringTransformer transformer)
	{
		// Arrange
		await ServiceScope.AddAsync(UserClaim, CancellationToken);
		var request = _requestBuilder.WithId(transformer).Build();

		// Act
		var response = await ClaimApiClient.AddProblemDetailsAsync(request, CancellationToken);

		// Assert
		response.ShouldSatisfyUserClaimAlreadyExists(request);
	}

	[Fact]
	public async Task AddAsync_ShouldHaveOkStatusCode_WhenRequestIsValid()
	{
		// Act
		var response = await ClaimApiClient.AddStatusCodeAsync(_request, CancellationToken);

		// Assert
		response.ShouldBeOk();
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task AddAsync_ShouldHaveOkStatusCode_WhenRequestAndIdAreValid(IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithId(transformer).Build();

		// Act
		var response = await ClaimApiClient.AddStatusCodeAsync(request, CancellationToken);

		// Assert
		response.ShouldBeOk();
	}

	[Fact]
	public async Task AddAsync_ShouldReturnResponse_WhenRequestIsValid()
	{
		// Act
		var response = await ClaimApiClient.AddAsync(_request, CancellationToken);
		var userClaim = await ServiceScope.GetByIdAsync(response, CancellationToken);

		// Assert
		response.ShouldSatisfy(_request, userClaim);
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task AddAsync_ShouldReturnResponse_WhenRequestAndIdAreValid(IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithId(transformer).Build();

		// Act
		var response = await ClaimApiClient.AddAsync(request, CancellationToken);
		var userClaim = await ServiceScope.GetByIdAsync(response, CancellationToken);

		// Assert
		response.ShouldSatisfy(request, userClaim);
	}

	[Fact]
	public async Task AddAsync_ShouldAddUserClaim_WhenRequestIsValid()
	{
		// Act
		var response = await ClaimApiClient.AddAsync(_request, CancellationToken);
		var userClaim = await ServiceScope.GetByIdAsync(response, CancellationToken);

		// Assert
		userClaim.ShouldSatisfy(_request);
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task AddAsync_ShouldAddUserClaim_WhenRequestAndIdAreValid(IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithId(transformer).Build();

		// Act
		var response = await ClaimApiClient.AddAsync(request, CancellationToken);
		var userClaim = await ServiceScope.GetByIdAsync(response, CancellationToken);

		// Assert
		userClaim.ShouldSatisfy(request);
	}

	[Fact]
	public async Task AddAsync_ShouldPublishUserClaimAddedEvent_WhenRequestIsValid()
	{
		// Act
		var response = await ClaimApiClient.AddAsync(_request, CancellationToken);
		var userClaim = await ServiceScope.GetByIdAsync(response, CancellationToken);
		var eventRequest = await ClaimEventClient.PublishedAddedAsync(CancellationToken);

		// Assert
		eventRequest.ShouldSatisfy(_request, userClaim);
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task AddAsync_ShouldPublishUserClaimAddedEvent_WhenRequestAndIdAreValid(IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithId(transformer).Build();

		// Act
		var response = await ClaimApiClient.AddAsync(request, CancellationToken);
		var userClaim = await ServiceScope.GetByIdAsync(response, CancellationToken);
		var eventRequest = await ClaimEventClient.PublishedAddedAsync(CancellationToken);

		// Assert
		eventRequest.ShouldSatisfy(request, userClaim);
	}
}
