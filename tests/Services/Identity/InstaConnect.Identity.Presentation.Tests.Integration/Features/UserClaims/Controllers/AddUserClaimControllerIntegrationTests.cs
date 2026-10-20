using InstaConnect.Common.Events.Features.AccessTokens.Models;

namespace InstaConnect.Identity.Presentation.Tests.Integration.Features.UserClaims.Controllers;

public class AddUserClaimControllerIntegrationTests : BaseUserClaimPresentationCommandIntegrationTest
{
	private readonly AddUserClaimApiRequestBuilderFactory _requestBuilderFactory;
	private readonly AddUserClaimApiRequestBuilder _requestBuilder;
	private readonly AddUserClaimApiRequest _request;

	public AddUserClaimControllerIntegrationTests(IdentityWebApplicationFactory webApplicationFactory)
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
	public async Task AddAsync_ShouldThrowValidationException_WhenIdIsInvalid(
		IStringTransformer transformer, IStringMessageTransformer messageTransformer)
	{
		// Arrange
		var request = _requestBuilder.WithId(transformer).Build();

		// Assert
		await Controller.ShouldThrowInvalidValidationExceptionForIdAsync(
			request, messageTransformer, CancellationToken);
	}

	[Theory]
	[UserClaimClaimEmptyWithMessageData]
	public async Task AddAsync_ShouldThrowValidationException_WhenClaimIsInvalid(
		IEnumTransformer<ApplicationClaims> transformer, IEnumMessageTransformer<ApplicationClaims> messageTransformer)
	{
		// Arrange
		var request = _requestBuilder.WithClaim(transformer).Build();

		// Assert
		await Controller.ShouldThrowInvalidValidationExceptionForClaimAsync(
			request, messageTransformer, CancellationToken);
	}

	[Fact]
	public async Task AddAsync_ShouldThrowUserNotFoundException_WhenUserNotFound()
	{
		// Arrange
		await ServiceScope.DeleteAsync(User, CancellationToken);

		// Assert
		await Controller.ShouldThrowUserNotFoundExceptionAsync(_request, CancellationToken);
	}

	[Fact]
	public async Task AddAsync_ShouldThrowUserClaimAlreadyExistsException_WhenUserClaimAlreadyExists()
	{
		// Arrange
		await ServiceScope.AddAsync(UserClaim, CancellationToken);

		// Assert
		await Controller.ShouldThrowUserClaimAlreadyExistsExceptionAsync(_request, CancellationToken);
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task AddAsync_ShouldThrowUserClaimAlreadyExistsException_WhenUserClaimAlreadyExistsAndIdIsInvalid(
		IStringTransformer transformer)
	{
		// Arrange
		await ServiceScope.AddAsync(UserClaim, CancellationToken);
		var request = _requestBuilder.WithId(transformer).Build();

		// Assert
		await Controller.ShouldThrowUserClaimAlreadyExistsExceptionAsync(request, CancellationToken);
	}

	[Fact]
	public async Task AddAsync_ShouldReturnOkStatusCode_WhenRequestIsValid()
	{
		// Act
		var response = await Controller.AddAsync(_request, CancellationToken);

		// Assert
		response.ShouldBeActionResultWithOkStatusCode();
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task AddAsync_ShouldReturnOkStatusCode_WhenRequestAndIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithId(transformer).Build();

		// Act
		var response = await Controller.AddAsync(request, CancellationToken);

		// Assert
		response.ShouldBeActionResultWithOkStatusCode();
	}

	[Fact]
	public async Task AddAsync_ShouldReturnResponse_WhenRequestIsValid()
	{
		// Act
		var response = await Controller.AddAsync(_request, CancellationToken);
		var userClaim = await ServiceScope.GetByIdAsync(response, CancellationToken);

		// Assert
		response.ShouldSatisfy(_request, userClaim);
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task AddAsync_ShouldReturnResponse_WhenRequestAndIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithId(transformer).Build();

		// Act
		var response = await Controller.AddAsync(request, CancellationToken);
		var userClaim = await ServiceScope.GetByIdAsync(response, CancellationToken);

		// Assert
		response.ShouldSatisfy(request, userClaim);
	}

	[Fact]
	public async Task AddAsync_ShouldAddUserClaim_WhenRequestIsValid()
	{
		// Act
		var response = await Controller.AddAsync(_request, CancellationToken);
		var userClaim = await ServiceScope.GetByIdAsync(response, CancellationToken);

		// Assert
		userClaim.ShouldSatisfy(_request);
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task AddAsync_ShouldAddUserClaim_WhenRequestAndIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithId(transformer).Build();

		// Act
		var response = await Controller.AddAsync(request, CancellationToken);
		var userClaim = await ServiceScope.GetByIdAsync(response, CancellationToken);

		// Assert
		userClaim.ShouldSatisfy(request);
	}

	[Fact]
	public async Task AddAsync_ShouldPublishUserClaimAddedEvent_WhenRequestIsValid()
	{
		// Act
		var response = await Controller.AddAsync(_request, CancellationToken);
		var userClaim = await ServiceScope.GetByIdAsync(response, CancellationToken);
		var eventRequest = await ClaimEventClient.PublishedAddedAsync(CancellationToken);

		// Assert
		eventRequest.ShouldSatisfy(_request, userClaim);
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task AddAsync_ShouldPublishUserClaimAddedEvent_WhenRequestAndIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithId(transformer).Build();

		// Act
		var response = await Controller.AddAsync(request, CancellationToken);
		var userClaim = await ServiceScope.GetByIdAsync(response, CancellationToken);
		var eventRequest = await ClaimEventClient.PublishedAddedAsync(CancellationToken);

		// Assert
		eventRequest.ShouldSatisfy(request, userClaim);
	}
}
