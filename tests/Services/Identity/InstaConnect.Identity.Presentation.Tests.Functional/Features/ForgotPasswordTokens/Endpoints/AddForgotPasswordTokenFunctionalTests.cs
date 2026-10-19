namespace InstaConnect.Identity.Presentation.Tests.Functional.Features.ForgotPasswordTokens.Endpoints;

public class AddForgotPasswordTokenFunctionalTests : BaseForgotPasswordTokenPresentationCommandFunctionalTest
{
	private readonly AddForgotPasswordTokenApiRequestBuilderFactory _requestBuilderFactory;
	private readonly AddForgotPasswordTokenApiRequestBuilder _requestBuilder;
	private readonly AddForgotPasswordTokenApiRequest _request;

	public AddForgotPasswordTokenFunctionalTests(IdentityWebApplicationFactory webApplicationFactory)
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
		var response = await ForgotPasswordTokenApiClient.AddStatusCodeAsync(request, CancellationToken);

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
		var response = await ForgotPasswordTokenApiClient.AddProblemDetailsAsync(request, CancellationToken);

		// Assert
		response.ShouldSatisfyInvalidValidationForName(request, messageTransformer);
	}

	[Fact]
	public async Task AddAsync_ShouldHaveNotFoundStatusCode_WhenUserNameNotFound()
	{
		// Arrange
		await ServiceScope.DeleteAsync(User, CancellationToken);

		// Act
		var response = await ForgotPasswordTokenApiClient.AddStatusCodeAsync(_request, CancellationToken);

		// Assert
		response.ShouldBeNotFound();
	}

	[Fact]
	public async Task AddAsync_ShouldHaveUserNameNotFoundProblemDetails_WhenUserNameNotFound()
	{
		// Arrange
		await ServiceScope.DeleteAsync(User, CancellationToken);

		// Act
		var response = await ForgotPasswordTokenApiClient.AddProblemDetailsAsync(_request, CancellationToken);

		// Assert
		response.ShouldSatisfyUserNameNotFound(_request);
	}

	[Fact]
	public async Task AddAsync_ShouldHaveOkStatusCode_WhenRequestIsValid()
	{
		// Act
		var response = await ForgotPasswordTokenApiClient.AddStatusCodeAsync(_request, CancellationToken);

		// Assert
		response.ShouldBeNoContent();
	}

	[Theory]
	[UserNameDifferentCaseData]
	public async Task AddAsync_ShouldHaveOkStatusCode_WhenNameIsValid(IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithName(transformer).Build();

		// Act
		var response = await ForgotPasswordTokenApiClient.AddStatusCodeAsync(request, CancellationToken);

		// Assert
		response.ShouldBeNoContent();
	}

	[Fact]
	public async Task AddAsync_ShouldAddForgotPasswordToken_WhenRequestIsValid()
	{
		// Act
		await ForgotPasswordTokenApiClient.AddAsync(_request, CancellationToken);
		var user = await ServiceScope.GetByIdAsync(UserId, CancellationToken);

		// Assert
		user.ForgotPasswordTokens.ShouldSatisfy(_request);
	}

	[Theory]
	[UserNameDifferentCaseData]
	public async Task AddAsync_ShouldAddForgotPasswordToken_WhenNameIsValid(IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithName(transformer).Build();

		// Act
		await ForgotPasswordTokenApiClient.AddAsync(request, CancellationToken);
		var user = await ServiceScope.GetByIdAsync(UserId, CancellationToken);

		// Assert
		user.ForgotPasswordTokens.ShouldSatisfy(request);
	}

	[Fact]
	public async Task AddAsync_ShouldPublishForgotPasswordTokenAddedEvent_WhenRequestIsValid()
	{
		// Act
		await ForgotPasswordTokenApiClient.AddAsync(_request, CancellationToken);
		var user = await ServiceScope.GetByIdAsync(UserId, CancellationToken);
		var eventRequests = await ForgotPasswordTokenEventClient.PublishedAddedRangeAsync(CancellationToken);

		// Assert
		eventRequests.ShouldSatisfy(_request, user.ForgotPasswordTokens);
	}

	[Theory]
	[UserNameDifferentCaseData]
	public async Task AddAsync_ShouldPublishForgotPasswordTokenAddedEvent_WhenRequestAndNameAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithName(transformer).Build();

		// Act
		await ForgotPasswordTokenApiClient.AddAsync(request, CancellationToken);
		var user = await ServiceScope.GetByIdAsync(UserId, CancellationToken);
		var eventRequests = await ForgotPasswordTokenEventClient.PublishedAddedRangeAsync(CancellationToken);

		// Assert
		eventRequests.ShouldSatisfy(request, user.ForgotPasswordTokens);
	}
}
