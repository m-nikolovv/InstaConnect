namespace InstaConnect.Chats.Application.Tests.Integration.Features.Users.Handlers;

public class UpdateUserCommandHandlerIntegrationTests : BaseUserApplicationCommandIntegrationTest
{
	private readonly UpdateUserCommandRequestBuilderFactory _requestBuilderFactory;
	private readonly UpdateUserCommandRequestBuilder _requestBuilder;
	private readonly UpdateUserCommandRequest _request;

	public UpdateUserCommandHandlerIntegrationTests(ChatsWebApplicationFactory webApplicationFactory)
		: base(webApplicationFactory)
	{
		_requestBuilderFactory = new();
		_requestBuilder = _requestBuilderFactory.Create(User);
		_request = _requestBuilder.Build();
	}

	protected override async Task OnInitializeAsync()
	{
		await ServiceScope.AddAsync(User, CancellationToken);
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
		await Sender.ShouldThrowInvalidValidationExceptionForIdAsync(
			request, messageTransformer, CancellationToken);
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
		await Sender.ShouldThrowInvalidValidationExceptionForNameAsync(
			request, messageTransformer, CancellationToken);
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
		await Sender.ShouldThrowInvalidValidationExceptionForFirstNameAsync(
			request, messageTransformer, CancellationToken);
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
		await Sender.ShouldThrowInvalidValidationExceptionForLastNameAsync(
			request, messageTransformer, CancellationToken);
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
		await Sender.ShouldThrowInvalidValidationExceptionForEmailAsync(
			request, messageTransformer, CancellationToken);
	}

	[Theory]
	[UserProfileImageTooLongWithMessageData]
	public async Task SendAsync_ShouldThrowValidationException_WhenProfileImageIsInvalid(
		IStringTransformer transformer, IStringMessageTransformer messageTransformer)
	{
		// Arrange
		var request = _requestBuilder.WithProfileImage(transformer).Build();

		// Assert
		await Sender.ShouldThrowInvalidValidationExceptionForProfileImageAsync(
			request, messageTransformer, CancellationToken);
	}

	[Theory]
	[UserUpdatedAtUtcEmptyWithMessageData]
	public async Task SendAsync_ShouldThrowValidationException_WhenUpdatedAtUtcIsInvalid(
		IDateTimeOffsetTransformer transformer, IDateTimeOffsetMessageTransformer messageTransformer)
	{
		// Arrange
		var request = _requestBuilder.WithUpdatedAtUtc(transformer).Build();

		// Assert
		await Sender.ShouldThrowInvalidValidationExceptionForUpdatedAtUtcAsync(
			request, messageTransformer, CancellationToken);
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
	public async Task SendAsync_ShouldThrowUserEmailAlreadyExistsException_WhenUserEmailAlreadyExists()
	{
		// Arrange
		var user = UserBuilderFactory.Create().Build();
		await ServiceScope.AddAsync(user, CancellationToken);

		var request = _requestBuilder.WithEmail(user.Email).Build();

		// Assert
		await Sender.ShouldThrowUserEmailAlreadyExistsExceptionAsync(request, CancellationToken);
	}

	[Theory]
	[UserEmailDifferentCaseData]
	public async Task SendAsync_ShouldThrowUserEmailAlreadyExistsException_WhenUserEmailAlreadyExistsAndEmailIsInvalid(
		IStringTransformer transformer)
	{
		// Arrange
		var user = UserBuilderFactory.Create().Build();
		await ServiceScope.AddAsync(user, CancellationToken);

		var request = _requestBuilder.WithEmail(user.Email, transformer).Build();

		// Assert
		await Sender.ShouldThrowUserEmailAlreadyExistsExceptionAsync(request, CancellationToken);
	}

	[Fact]
	public async Task SendAsync_ShouldThrowUserNameAlreadyExistsException_WhenUserNameAlreadyExists()
	{
		// Arrange
		var user = UserBuilderFactory.Create().Build();
		await ServiceScope.AddAsync(user, CancellationToken);

		var request = _requestBuilder.WithName(user.Name).Build();

		// Assert
		await Sender.ShouldThrowUserNameAlreadyExistsExceptionAsync(request, CancellationToken);
	}

	[Theory]
	[UserNameDifferentCaseData]
	public async Task SendAsync_ShouldThrowUserNameAlreadyExistsException_WhenUserNameAlreadyExistsAndNameIsInvalid(
		IStringTransformer transformer)
	{
		// Arrange
		var user = UserBuilderFactory.Create().Build();
		await ServiceScope.AddAsync(user, CancellationToken);

		var request = _requestBuilder.WithName(user.Name, transformer).Build();

		// Assert
		await Sender.ShouldThrowUserNameAlreadyExistsExceptionAsync(request, CancellationToken);
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
	[UserIdDifferentCaseData]
	public async Task SendAsync_ShouldReturnResponse_WhenRequestAndIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithId(transformer).Build();

		// Act
		var response = await Sender.SendAsync(request, CancellationToken);
		var user = await ServiceScope.GetByIdAsync(response, CancellationToken);

		// Assert
		response.ShouldSatisfy(request, user);
	}

	[Theory]
	[UserNameDifferentCaseData]
	public async Task SendAsync_ShouldReturnResponse_WhenRequestAndNameAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithName(transformer).Build();

		// Act
		var response = await Sender.SendAsync(request, CancellationToken);
		var user = await ServiceScope.GetByIdAsync(response, CancellationToken);

		// Assert
		response.ShouldSatisfy(request, user);
	}

	[Fact]
	public async Task SendAsync_ShouldReturnResponse_WhenNameHasNotChanged()
	{
		// Arrange
		var request = _requestBuilder.WithName(User.Name).Build();

		// Act
		var response = await Sender.SendAsync(request, CancellationToken);
		var user = await ServiceScope.GetByIdAsync(response, CancellationToken);

		// Assert
		response.ShouldSatisfy(request, user);
	}

	[Theory]
	[UserNameDifferentCaseData]
	public async Task SendAsync_ShouldReturnResponse_WhenNameIsValidAndHasNotChanged(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithName(User.Name, transformer).Build();

		// Act
		var response = await Sender.SendAsync(request, CancellationToken);
		var user = await ServiceScope.GetByIdAsync(response, CancellationToken);

		// Assert
		response.ShouldSatisfy(request, user);
	}

	[Theory]
	[UserEmailDifferentCaseData]
	public async Task SendAsync_ShouldReturnResponse_WhenRequestAndEmailAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithEmail(transformer).Build();

		// Act
		var response = await Sender.SendAsync(request, CancellationToken);
		var user = await ServiceScope.GetByIdAsync(response, CancellationToken);

		// Assert
		response.ShouldSatisfy(request, user);
	}

	[Fact]
	public async Task SendAsync_ShouldReturnResponse_WhenEmailHasNotChanged()
	{
		// Arrange
		var request = _requestBuilder.WithEmail(User.Email).Build();

		// Act
		var response = await Sender.SendAsync(request, CancellationToken);
		var user = await ServiceScope.GetByIdAsync(response, CancellationToken);

		// Assert
		response.ShouldSatisfy(request, user);
	}

	[Theory]
	[UserEmailDifferentCaseData]
	public async Task SendAsync_ShouldReturnResponse_WhenEmailIsValidAndHasNotChanged(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithEmail(User.Email, transformer).Build();

		// Act
		var response = await Sender.SendAsync(request, CancellationToken);
		var user = await ServiceScope.GetByIdAsync(response, CancellationToken);

		// Assert
		response.ShouldSatisfy(request, user);
	}

	[Theory]
	[UserProfileImageNullData]
	[UserProfileImageEmptyData]
	public async Task SendAsync_ShouldReturnResponse_WhenRequestAndProfileImageAreValid(
		IStringTransformer transformer)
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
	public async Task SendAsync_ShouldUpdateUser_WhenRequestIsValid()
	{
		// Act
		var response = await Sender.SendAsync(_request, CancellationToken);
		var user = await ServiceScope.GetByIdAsync(response, CancellationToken);

		// Assert
		user.ShouldSatisfy(_request);
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task SendAsync_ShouldUpdateUser_WhenRequestAndIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithId(transformer).Build();

		// Act
		var response = await Sender.SendAsync(request, CancellationToken);
		var user = await ServiceScope.GetByIdAsync(response, CancellationToken);

		// Assert
		user.ShouldSatisfy(request);
	}

	[Theory]
	[UserNameDifferentCaseData]
	public async Task SendAsync_ShouldUpdateUser_WhenRequestAndNameAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithName(transformer).Build();

		// Act
		var response = await Sender.SendAsync(request, CancellationToken);
		var user = await ServiceScope.GetByIdAsync(response, CancellationToken);

		// Assert
		user.ShouldSatisfy(request);
	}

	[Fact]
	public async Task SendAsync_ShouldUpdateUser_WhenNameHasNotChanged()
	{
		// Arrange
		var request = _requestBuilder.WithName(User.Name).Build();

		// Act
		var response = await Sender.SendAsync(request, CancellationToken);
		var user = await ServiceScope.GetByIdAsync(response, CancellationToken);

		// Assert
		user.ShouldSatisfy(request);
	}

	[Theory]
	[UserNameDifferentCaseData]
	public async Task SendAsync_ShouldUpdateUser_WhenNameIsValidAndHasNotChanged(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithName(User.Name, transformer).Build();

		// Act
		var response = await Sender.SendAsync(request, CancellationToken);
		var user = await ServiceScope.GetByIdAsync(response, CancellationToken);

		// Assert
		user.ShouldSatisfy(request);
	}

	[Theory]
	[UserEmailDifferentCaseData]
	public async Task SendAsync_ShouldUpdateUser_WhenRequestAndEmailAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithEmail(transformer).Build();

		// Act
		var response = await Sender.SendAsync(request, CancellationToken);
		var user = await ServiceScope.GetByIdAsync(response, CancellationToken);

		// Assert
		user.ShouldSatisfy(request);
	}

	[Fact]
	public async Task SendAsync_ShouldUpdateUser_WhenEmailHasNotChanged()
	{
		// Arrange
		var request = _requestBuilder.WithEmail(User.Email).Build();

		// Act
		var response = await Sender.SendAsync(request, CancellationToken);
		var user = await ServiceScope.GetByIdAsync(response, CancellationToken);

		// Assert
		user.ShouldSatisfy(request);
	}

	[Theory]
	[UserEmailDifferentCaseData]
	public async Task SendAsync_ShouldUpdateUser_WhenEmailIsValidAndHasNotChanged(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithEmail(User.Email, transformer).Build();

		// Act
		var response = await Sender.SendAsync(request, CancellationToken);
		var user = await ServiceScope.GetByIdAsync(response, CancellationToken);

		// Assert
		user.ShouldSatisfy(request);
	}

	[Theory]
	[UserProfileImageNullData]
	[UserProfileImageEmptyData]
	public async Task SendAsync_ShouldUpdateUser_WhenRequestAndProfileImageAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithProfileImage(transformer).Build();

		// Act
		var response = await Sender.SendAsync(request, CancellationToken);
		var user = await ServiceScope.GetByIdAsync(response, CancellationToken);

		// Assert
		user.ShouldSatisfy(request);
	}
}
