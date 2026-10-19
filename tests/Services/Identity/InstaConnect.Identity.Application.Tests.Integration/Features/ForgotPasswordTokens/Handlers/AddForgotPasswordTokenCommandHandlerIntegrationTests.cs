namespace InstaConnect.Identity.Application.Tests.Integration.Features.ForgotPasswordTokens.Handlers;

public class AddForgotPasswordTokenCommandHandlerIntegrationTests : BaseForgotPasswordTokenApplicationCommandIntegrationTest
{
	private readonly AddForgotPasswordTokenCommandRequestBuilderFactory _requestBuilderFactory;
	private readonly AddForgotPasswordTokenCommandRequestBuilder _requestBuilder;
	private readonly AddForgotPasswordTokenCommandRequest _request;

	public AddForgotPasswordTokenCommandHandlerIntegrationTests(IdentityWebApplicationFactory webApplicationFactory)
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
	public async Task SendAsync_ShouldThrowValidationException_WhenNameIsInvalid(
		IStringTransformer transformer, IStringMessageTransformer messageTransformer)
	{
		// Arrange
		var request = _requestBuilder.WithName(transformer).Build();

		// Assert
		await Sender.ShouldThrowInvalidValidationExceptionForNameAsync(request, messageTransformer, CancellationToken);
	}

	[Fact]
	public async Task SendAsync_ShouldThrowUserNameNotFoundException_WhenUserNameNotFound()
	{
		// Arrange
		await ServiceScope.DeleteAsync(User, CancellationToken);

		// Assert
		await Sender.ShouldThrowUserNameNotFoundExceptionAsync(_request, CancellationToken);
	}

	[Fact]
	public async Task SendAsync_ShouldAddForgotPasswordToken_WhenRequestIsValid()
	{
		// Act
		await Sender.SendAsync(_request, CancellationToken);
		var user = await ServiceScope.GetByIdAsync(UserId, CancellationToken);

		// Assert
		user.ForgotPasswordTokens.ShouldSatisfy(_request);
	}

	[Theory]
	[UserNameDifferentCaseData]
	public async Task SendAsync_ShouldAddForgotPasswordToken_WhenRequestAndNameAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithName(transformer).Build();

		// Act
		await Sender.SendAsync(request, CancellationToken);
		var user = await ServiceScope.GetByIdAsync(UserId, CancellationToken);

		// Assert
		user.ForgotPasswordTokens.ShouldSatisfy(request);
	}

	[Fact]
	public async Task SendAsync_ShouldPublishForgotPasswordTokenAddedEvent_WhenRequestIsValid()
	{
		// Act
		await Sender.SendAsync(_request, CancellationToken);
		var user = await ServiceScope.GetByIdAsync(UserId, CancellationToken);
		var eventRequests = await ForgotPasswordTokenEventClient.PublishedAddedRangeAsync(CancellationToken);

		// Assert
		eventRequests.ShouldSatisfy(_request, user.ForgotPasswordTokens);
	}

	[Theory]
	[UserNameDifferentCaseData]
	public async Task SendAsync_ShouldPublishForgotPasswordTokenAddedEvent_WhenRequestAndNameAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithName(transformer).Build();

		// Act
		await Sender.SendAsync(request, CancellationToken);
		var user = await ServiceScope.GetByIdAsync(UserId, CancellationToken);
		var eventRequests = await ForgotPasswordTokenEventClient.PublishedAddedRangeAsync(CancellationToken);

		// Assert
		eventRequests.ShouldSatisfy(request, user.ForgotPasswordTokens);
	}
}
