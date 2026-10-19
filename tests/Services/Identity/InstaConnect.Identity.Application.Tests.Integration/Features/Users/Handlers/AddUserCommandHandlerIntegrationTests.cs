using InstaConnect.Identity.Domain.Tests.Features.Users.Assertions;

namespace InstaConnect.Identity.Application.Tests.Integration.Features.Users.Handlers;

public class AddUserCommandHandlerIntegrationTests : BaseUserApplicationCommandIntegrationTest
{
	private const string PasswordPropertyName = nameof(AddUserCommandRequest.Password);

	private readonly AddUserCommandRequestBuilderFactory _requestBuilderFactory;
	private readonly AddUserCommandRequestBuilder _requestBuilder;
	private readonly AddUserCommandRequest _request;

	public AddUserCommandHandlerIntegrationTests(IdentityWebApplicationFactory webApplicationFactory)
		: base(webApplicationFactory)
	{
		_requestBuilderFactory = new();
		_requestBuilder = _requestBuilderFactory.Create();
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

	[Theory]
	[UserFirstNameNullWithMessageData]
	[UserFirstNameEmptyWithMessageData]
	[UserFirstNameTooShortWithMessageData]
	[UserFirstNameTooLongWithMessageData]
	public async Task SendAsync_ShouldThrowValidationException_WhenFirstNameIsInvalid(
		IStringTransformer transformer, IStringMessageTransformer messageTransformer)
	{
		// Arrange
		var request = _requestBuilder.WithFirstName(transformer).Build();

		// Assert
		await Sender.ShouldThrowInvalidValidationExceptionForFirstNameAsync(request, messageTransformer, CancellationToken);
	}

	[Theory]
	[UserLastNameNullWithMessageData]
	[UserLastNameEmptyWithMessageData]
	[UserLastNameTooShortWithMessageData]
	[UserLastNameTooLongWithMessageData]
	public async Task SendAsync_ShouldThrowValidationException_WhenLastNameIsInvalid(
		IStringTransformer transformer, IStringMessageTransformer messageTransformer)
	{
		// Arrange
		var request = _requestBuilder.WithLastName(transformer).Build();

		// Assert
		await Sender.ShouldThrowInvalidValidationExceptionForLastNameAsync(request, messageTransformer, CancellationToken);
	}

	[Theory]
	[UserEmailNullWithMessageData]
	[UserEmailEmptyWithMessageData]
	[UserEmailTooShortWithMessageData]
	[UserEmailTooLongWithMessageData]
	[UserEmailInvalidWithMessageData]
	public async Task SendAsync_ShouldThrowValidationException_WhenEmailIsInvalid(
		IStringTransformer transformer, IStringMessageTransformer messageTransformer)
	{
		// Arrange
		var request = _requestBuilder.WithEmail(transformer).Build();

		// Assert
		await Sender.ShouldThrowInvalidValidationExceptionForEmailAsync(request, messageTransformer, CancellationToken);
	}

	[Theory]
	[UserPasswordNullWithMessageData]
	[UserPasswordEmptyWithMessageData]
	[UserPasswordTooShortWithMessageData]
	[UserPasswordTooLongWithMessageData]
	public async Task SendAsync_ShouldThrowValidationException_WhenPasswordIsInvalid(
		IStringTransformer transformer, IStringMessageTransformer messageTransformer)
	{
		// Arrange
		var request = _requestBuilder.WithPassword(transformer).Build();

		// Assert
		await Sender.ShouldThrowInvalidValidationExceptionForPasswordAsync(request, messageTransformer, CancellationToken);
	}

	[Theory]
	[UserConfirmPasswordNotEqualWithMessageData(PasswordPropertyName)]
	public async Task SendAsync_ShouldThrowValidationException_WhenConfirmPasswordIsInvalid(
		IStringTransformer transformer, IStringMessageTransformer messageTransformer)
	{
		// Arrange
		var request = _requestBuilder.WithConfirmPassword(transformer).Build();

		// Assert
		await Sender.ShouldThrowInvalidValidationExceptionForConfirmPasswordAsync(request, messageTransformer, CancellationToken);
	}

	[Fact]
	public async Task SendAsync_ShouldThrowUserEmailAlreadyTakenException_WhenUserEmailAlreadyTaken()
	{
		// Arrange
		await ServiceScope.AddAsync(User, CancellationToken);
		var request = _requestBuilder.WithEmail(User.Email).Build();

		// Assert
		await Sender.ShouldThrowUserEmailAlreadyTakenExceptionAsync(request, CancellationToken);
	}

	[Theory]
	[UserEmailDifferentCaseData]
	public async Task SendAsync_ShouldThrowUserEmailAlreadyTakenException_WhenUserEmailAlreadyTakenAndEmailIsInvalid(
		IStringTransformer transformer)
	{
		// Arrange
		await ServiceScope.AddAsync(User, CancellationToken);
		var request = _requestBuilder.WithEmail(User.Email, transformer).Build();

		// Assert
		await Sender.ShouldThrowUserEmailAlreadyTakenExceptionAsync(request, CancellationToken);
	}

	[Fact]
	public async Task SendAsync_ShouldThrowUserNameAlreadyTakenException_WhenUserNameAlreadyTaken()
	{
		// Arrange
		await ServiceScope.AddAsync(User, CancellationToken);
		var request = _requestBuilder.WithName(User.Name).Build();

		// Assert
		await Sender.ShouldThrowUserNameAlreadyTakenExceptionAsync(request, CancellationToken);
	}

	[Theory]
	[UserNameDifferentCaseData]
	public async Task SendAsync_ShouldThrowUserNameAlreadyTakenException_WhenUserNameAlreadyTakenAndNameIsInvalid(
		IStringTransformer transformer)
	{
		// Arrange
		await ServiceScope.AddAsync(User, CancellationToken);
		var request = _requestBuilder.WithName(User.Name, transformer).Build();

		// Assert
		await Sender.ShouldThrowUserNameAlreadyTakenExceptionAsync(request, CancellationToken);
	}

	[Fact]
	public async Task SendAsync_ShouldReturnResponse_WhenRequestIsValid()
	{
		// Act
		var response = await Sender.SendAsync(_request, CancellationToken);
		var user = await ServiceScope.GetByIdAsync(response, CancellationToken);

		// Assert
		response.ShouldSatisfy(_request, user);
	}

	[Theory]
	[UserProfileImageNullData]
	public async Task SendAsync_ShouldReturnResponse_WhenProfileImageIsValid(
		IFormFileTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithProfileImage(transformer).Build();

		// Act
		var response = await Sender.SendAsync(request, CancellationToken);
		var user = await ServiceScope.GetByIdAsync(response, CancellationToken);

		// Assert
		response.ShouldSatisfy(request, user);
	}

	[Fact]
	public async Task SendAsync_ShouldAddUser_WhenRequestIsValid()
	{
		// Act
		var response = await Sender.SendAsync(_request, CancellationToken);
		var user = await ServiceScope.GetByIdAsync(response, CancellationToken);

		// Assert
		user.ShouldSatisfy(_request, PasswordHasher);
	}

	[Theory]
	[UserProfileImageNullData]
	public async Task SendAsync_ShouldAddUser_WhenProfileImageIsValid(
		IFormFileTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithProfileImage(transformer).Build();

		// Act
		var response = await Sender.SendAsync(request, CancellationToken);
		var user = await ServiceScope.GetByIdAsync(response, CancellationToken);

		// Assert
		user.ShouldSatisfy(request, PasswordHasher);
	}

	[Fact]
	public async Task SendAsync_ShouldAddEmailConfirmationToken_WhenRequestIsValid()
	{
		// Act
		var response = await Sender.SendAsync(_request, CancellationToken);
		var user = await ServiceScope.GetByIdAsync(response, CancellationToken);

		// Assert
		user.EmailConfirmationTokens.ShouldSatisfy(_request);
	}

	[Theory]
	[UserProfileImageNullData]
	public async Task SendAsync_ShouldAddEmailConfirmationToken_WhenProfileImageIsValid(
		IFormFileTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithProfileImage(transformer).Build();

		// Act
		var response = await Sender.SendAsync(request, CancellationToken);
		var user = await ServiceScope.GetByIdAsync(response, CancellationToken);

		// Assert
		user.EmailConfirmationTokens.ShouldSatisfy(request);
	}

	[Fact]
	public async Task SendAsync_ShouldPublishUserAddedEvent_WhenRequestIsValid()
	{
		// Act
		var response = await Sender.SendAsync(_request, CancellationToken);
		var user = await ServiceScope.GetByIdAsync(response, CancellationToken);
		var eventRequest = await EventClient.PublishedAddedAsync(CancellationToken);

		// Assert
		eventRequest.ShouldSatisfy(_request, user);
	}

	[Theory]
	[UserProfileImageNullData]
	public async Task SendAsync_ShouldPublishUserAddedEvent_WhenRequestAndProfileImageAreValid(
		IFormFileTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithProfileImage(transformer).Build();

		// Act
		var response = await Sender.SendAsync(request, CancellationToken);
		var user = await ServiceScope.GetByIdAsync(response, CancellationToken);
		var eventRequest = await EventClient.PublishedAddedAsync(CancellationToken);

		// Assert
		eventRequest.ShouldSatisfy(request, user);
	}

	[Fact]
	public async Task SendAsync_ShouldPublishEmailConfirmationTokenAddedEvent_WhenRequestIsValid()
	{
		// Act
		var response = await Sender.SendAsync(_request, CancellationToken);
		var user = await ServiceScope.GetByIdAsync(response, CancellationToken);
		var eventRequests = await EmailConfirmationTokenEventClient.PublishedAddedRangeAsync(CancellationToken);

		// Assert
		eventRequests.ShouldSatisfy(_request, user.EmailConfirmationTokens);
	}

	[Theory]
	[UserProfileImageNullData]
	public async Task SendAsync_ShouldPublishEmailConfirmationTokenAddedEvent_WhenRequestAndProfileImageAreValid(
		IFormFileTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithProfileImage(transformer).Build();

		// Act
		var response = await Sender.SendAsync(request, CancellationToken);
		var user = await ServiceScope.GetByIdAsync(response, CancellationToken);
		var eventRequests = await EmailConfirmationTokenEventClient.PublishedAddedRangeAsync(CancellationToken);

		// Assert
		eventRequests.ShouldSatisfy(request, user.EmailConfirmationTokens);
	}
}
