namespace InstaConnect.Identity.Presentation.Tests.Functional.Features.EmailConfirmationTokens.Endpoints;

public class AddEmailConfirmationTokenFunctionalTests : BaseEmailConfirmationTokenPresentationCommandFunctionalTest
{
	private readonly AddEmailConfirmationTokenApiRequestBuilderFactory _requestBuilderFactory;
	private readonly AddEmailConfirmationTokenApiRequestBuilder _requestBuilder;
	private readonly AddEmailConfirmationTokenApiRequest _request;

	public AddEmailConfirmationTokenFunctionalTests(IdentityWebApplicationFactory webApplicationFactory)
		: base(webApplicationFactory)
	{
		_requestBuilderFactory = new();
		_requestBuilder = _requestBuilderFactory.Create(User);
		_request = _requestBuilder.Build();
	}

	[Theory]
	[UserNameTooShortData]
	[UserNameTooLongData]
	public async Task AddAsync_ShouldHaveBadRequestStatusCode_WhenNameIsInvalid(IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithName(transformer).Build();

		// Act
		var response = await EmailConfirmationTokenApiClient.AddStatusCodeAsync(request, CancellationToken);

		// Assert
		response.ShouldBeBadRequest();
	}

	[Theory]
	[UserNameTooShortWithMessageData]
	[UserNameTooLongWithMessageData]
	public async Task AddAsync_ShouldHaveBadRequestProblemDetails_WhenNameIsInvalid(
		IStringTransformer transformer,
		IStringMessageTransformer messageTransformer)
	{
		// Arrange
		var request = _requestBuilder.WithName(transformer).Build();

		// Act
		var response = await EmailConfirmationTokenApiClient.AddProblemDetailsAsync(request, CancellationToken);

		// Assert
		response.ShouldSatisfyInvalidValidationForName(request, messageTransformer);
	}

	[Fact]
	public async Task AddAsync_ShouldHaveNotFoundStatusCode_WhenUserNameNotFound()
	{
		// Arrange
		await ServiceScope.DeleteAsync(User, CancellationToken);

		// Act
		var response = await EmailConfirmationTokenApiClient.AddStatusCodeAsync(_request, CancellationToken);

		// Assert
		response.ShouldBeNotFound();
	}

	[Fact]
	public async Task AddAsync_ShouldHaveUserNameNotFoundProblemDetails_WhenUserNameNotFound()
	{
		// Arrange
		await ServiceScope.DeleteAsync(User, CancellationToken);

		// Act
		var response = await EmailConfirmationTokenApiClient.AddProblemDetailsAsync(_request, CancellationToken);

		// Assert
		response.ShouldSatisfyUserNameNotFound(_request);
	}

	[Fact]
	public async Task AddAsync_ShouldHaveBadRequestStatusCode_WhenUserNameEmailAlreadyConfirmed()
	{
		// Arrange
		var updatedUser = UserBuilder.WithConfirmedEmail().Build();
		await ServiceScope.UpdateAsync(updatedUser, CancellationToken);

		// Act
		var response = await EmailConfirmationTokenApiClient.AddStatusCodeAsync(_request, CancellationToken);

		// Assert
		response.ShouldBeBadRequest();
	}

	[Fact]
	public async Task AddAsync_ShouldHaveUserNameEmailAlreadyConfirmedProblemDetails_WhenUserNameEmailAlreadyConfirmed()
	{
		// Arrange
		var updatedUser = UserBuilder.WithConfirmedEmail().Build();
		await ServiceScope.UpdateAsync(updatedUser, CancellationToken);

		// Act
		var response = await EmailConfirmationTokenApiClient.AddProblemDetailsAsync(_request, CancellationToken);

		// Assert
		response.ShouldSatisfyUserNameEmailAlreadyConfirmed(_request);
	}

	[Fact]
	public async Task AddAsync_ShouldHaveOkStatusCode_WhenRequestIsValid()
	{
		// Act
		var response = await EmailConfirmationTokenApiClient.AddStatusCodeAsync(_request, CancellationToken);

		// Assert
		response.ShouldBeNoContent();
	}

	[Theory]
	[UserNameDifferentCaseData]
	public async Task AddAsync_ShouldHaveOkStatusCode_WhenRequestAndNameAreValid(IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithName(transformer).Build();

		// Act
		var response = await EmailConfirmationTokenApiClient.AddStatusCodeAsync(request, CancellationToken);

		// Assert
		response.ShouldBeNoContent();
	}

	[Fact]
	public async Task AddAsync_ShouldAddEmailConfirmationToken_WhenRequestIsValid()
	{
		// Act
		await EmailConfirmationTokenApiClient.AddAsync(_request, CancellationToken);
		var user = await ServiceScope.GetByIdAsync(UserId, CancellationToken);

		// Assert
		user.EmailConfirmationTokens.ShouldSatisfy(_request);
	}

	[Theory]
	[UserNameDifferentCaseData]
	public async Task AddAsync_ShouldAddEmailConfirmationToken_WhenRequestAndNameAreValid(IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithName(transformer).Build();

		// Act
		await EmailConfirmationTokenApiClient.AddAsync(request, CancellationToken);
		var user = await ServiceScope.GetByIdAsync(UserId, CancellationToken);

		// Assert
		user.EmailConfirmationTokens.ShouldSatisfy(request);
	}

	[Fact]
	public async Task AddAsync_ShouldPublishEmailConfirmationTokenAddedEvent_WhenRequestIsValid()
	{
		// Act
		await EmailConfirmationTokenApiClient.AddAsync(_request, CancellationToken);
		var user = await ServiceScope.GetByIdAsync(UserId, CancellationToken);
		var eventRequests = await EmailConfirmationTokenEventClient.PublishedAddedRangeAsync(CancellationToken);

		// Assert
		eventRequests.ShouldSatisfy(_request, user.EmailConfirmationTokens);
	}

	[Theory]
	[UserNameDifferentCaseData]
	public async Task AddAsync_ShouldPublishEmailConfirmationTokenAddedEvent_WhenRequestAndNameAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithName(transformer).Build();

		// Act
		await EmailConfirmationTokenApiClient.AddAsync(request, CancellationToken);
		var user = await ServiceScope.GetByIdAsync(UserId, CancellationToken);
		var eventRequests = await EmailConfirmationTokenEventClient.PublishedAddedRangeAsync(CancellationToken);

		// Assert
		eventRequests.ShouldSatisfy(request, user.EmailConfirmationTokens);
	}
}
