namespace InstaConnect.Identity.Presentation.Tests.Integration.Features.ForgotPasswordTokens.Controllers;

public class AddForgotPasswordTokenControllerIntegrationTests : BaseForgotPasswordTokenPresentationCommandIntegrationTest
{
	private readonly AddForgotPasswordTokenApiRequestBuilderFactory _requestBuilderFactory;
	private readonly AddForgotPasswordTokenApiRequestBuilder _requestBuilder;
	private readonly AddForgotPasswordTokenApiRequest _request;

	public AddForgotPasswordTokenControllerIntegrationTests(IdentityWebApplicationFactory webApplicationFactory)
		: base(webApplicationFactory)
	{
		_requestBuilderFactory = new();
		_requestBuilder = _requestBuilderFactory.Create(User);
		_request = _requestBuilder.Build();
	}

	[Theory]
	[UserNameNullWithMessageData]
	[UserNameEmptyWithMessageData]
	[UserNameTooShortWithMessageData]
	[UserNameTooLongWithMessageData]
	public async Task AddAsync_ShouldThrowValidationException_WhenNameIsInvalid(
		IStringTransformer transformer, IStringMessageTransformer messageTransformer)
	{
		// Arrange
		var request = _requestBuilder.WithName(transformer).Build();

		// Assert
		await Controller.ShouldThrowInvalidValidationExceptionForNameAsync(
			request, messageTransformer, CancellationToken);
	}

	[Fact]
	public async Task AddAsync_ShouldThrowUserNameNotFoundException_WhenUserNameNotFound()
	{
		// Arrange
		await ServiceScope.DeleteAsync(User, CancellationToken);

		// Assert
		await Controller.ShouldThrowUserNameNotFoundExceptionAsync(_request, CancellationToken);
	}

	[Fact]
	public async Task AddAsync_ShouldReturnNoContentStatusCode_WhenRequestIsValid()
	{
		// Act
		var response = await Controller.AddAsync(_request, CancellationToken);

		// Assert
		response.ShouldBeActionResultWithNoContentStatusCode();
	}

	[Theory]
	[UserNameDifferentCaseData]
	public async Task AddAsync_ShouldReturnNoContentStatusCode_WhenNameIsValid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithName(transformer).Build();

		// Act
		var response = await Controller.AddAsync(request, CancellationToken);

		// Assert
		response.ShouldBeActionResultWithNoContentStatusCode();
	}

	[Fact]
	public async Task AddAsync_ShouldAddForgotPasswordToken_WhenRequestIsValid()
	{
		// Act
		await Controller.AddAsync(_request, CancellationToken);
		var user = await ServiceScope.GetByIdAsync(UserId, CancellationToken);

		// Assert
		user.ForgotPasswordTokens.ShouldSatisfy(_request);
	}

	[Theory]
	[UserNameDifferentCaseData]
	public async Task AddAsync_ShouldAddForgotPasswordToken_WhenNameIsValid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithName(transformer).Build();

		// Act
		await Controller.AddAsync(request, CancellationToken);
		var user = await ServiceScope.GetByIdAsync(UserId, CancellationToken);

		// Assert
		user.ForgotPasswordTokens.ShouldSatisfy(request);
	}

	[Fact]
	public async Task AddAsync_ShouldPublishForgotPasswordTokenAddedEvent_WhenRequestIsValid()
	{
		// Act
		await Controller.AddAsync(_request, CancellationToken);
		var user = await ServiceScope.GetByIdAsync(UserId, CancellationToken);
		var eventRequests = await EventClient.PublishedAddedRangeAsync(CancellationToken);

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
		await Controller.AddAsync(request, CancellationToken);
		var user = await ServiceScope.GetByIdAsync(UserId, CancellationToken);
		var eventRequests = await EventClient.PublishedAddedRangeAsync(CancellationToken);

		// Assert
		eventRequests.ShouldSatisfy(request, user.ForgotPasswordTokens);
	}
}
