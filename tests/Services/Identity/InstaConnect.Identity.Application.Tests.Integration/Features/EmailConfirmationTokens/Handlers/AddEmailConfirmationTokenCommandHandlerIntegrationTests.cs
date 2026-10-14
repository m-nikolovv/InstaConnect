namespace InstaConnect.Identity.Application.Tests.Integration.Features.EmailConfirmationTokens.Handlers;

public class AddEmailConfirmationTokenCommandHandlerIntegrationTests : BaseEmailConfirmationTokenApplicationCommandIntegrationTest
{
	private readonly AddEmailConfirmationTokenCommandRequestBuilderFactory _requestBuilderFactory;
	private readonly AddEmailConfirmationTokenCommandRequestBuilder _requestBuilder;
	private readonly AddEmailConfirmationTokenCommandRequest _request;

	public AddEmailConfirmationTokenCommandHandlerIntegrationTests(IdentityWebApplicationFactory webApplicationFactory)
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
	public async Task SendAsync_ShouldThrowUserNameNotFoundException_WhenUserNotFound()
	{
		// Arrange
		await ServiceScope.DeleteAsync(User, CancellationToken);

		// Assert
		await Sender.ShouldThrowUserNameNotFoundExceptionAsync(_request, CancellationToken);
	}

	[Fact]
	public async Task SendAsync_ShouldThrowUserNameEmailAlreadyConfirmedException_WhenEmailIsConfirmed()
	{
		// Arrange
		var updatedUser = UserBuilder.WithConfirmedEmail().Build();
		await ServiceScope.UpdateAsync(updatedUser, CancellationToken);

		// Assert
		await Sender.ShouldThrowUserNameEmailAlreadyConfirmedExceptionAsync(_request, CancellationToken);
	}

	[Fact]
	public async Task SendAsync_ShouldAddEmailConfirmationToken_WhenRequestIsValid()
	{
		// Act
		await Sender.SendAsync(_request, CancellationToken);
		var user = await ServiceScope.GetByIdAsync(User.Id, CancellationToken);

		// Assert
		user.EmailConfirmationTokens.ShouldSatisfy(_request);
	}

	[Theory]
	[UserNameDifferentCaseData]
	public async Task SendAsync_ShouldAddEmailConfirmationToken_WhenRequestAndNameAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithName(transformer).Build();

		// Act
		await Sender.SendAsync(request, CancellationToken);
		var user = await ServiceScope.GetByIdAsync(User.Id, CancellationToken);

		// Assert
		user.EmailConfirmationTokens.ShouldSatisfy(request);
	}

	[Fact]
	public async Task SendAsync_ShouldPublishEmailConfirmationTokenAddedEvent_WhenRequestIsValid()
	{
		// Act
		await Sender.SendAsync(_request, CancellationToken);
		var user = await ServiceScope.GetByIdAsync(User.Id, CancellationToken);
		var eventRequests = await EmailConfirmationTokenEventClient.PublishedAddedRangeAsync(CancellationToken);

		// Assert
		eventRequests.ShouldSatisfy(_request, user.EmailConfirmationTokens);
	}

	[Theory]
	[UserNameDifferentCaseData]
	public async Task SendAsync_ShouldPublishEmailConfirmationTokenAddedEvent_WhenRequestAndNameAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithName(transformer).Build();

		// Act
		await Sender.SendAsync(request, CancellationToken);
		var user = await ServiceScope.GetByIdAsync(User.Id, CancellationToken);
		var eventRequests = await EmailConfirmationTokenEventClient.PublishedAddedRangeAsync(CancellationToken);

		// Assert
		eventRequests.ShouldSatisfy(_request, user.EmailConfirmationTokens);
	}
}
