using InstaConnect.Common.Infrastructure.Tests.Features.Utilities;

namespace InstaConnect.Follows.Infrastructure.Tests.Integration.Features.Users.EventHandlers.v1;

public class UserUpdatedEventHandlerIntegrationTests : BaseUserInfrastructureEventHandlerIntegrationTest
{
	private readonly UserUpdatedEventRequestBuilderFactory _requestBuilderFactory;
	private readonly UserUpdatedEventRequestBuilder _requestBuilder;
	private readonly UserUpdatedEventRequest _request;

	private readonly UserUpdatedEventHandler _handler;

	public UserUpdatedEventHandlerIntegrationTests(FollowsWebApplicationFactory webApplicationFactory)
		: base(webApplicationFactory)
	{
		_requestBuilderFactory = new();
		_requestBuilder = _requestBuilderFactory.Create(User);
		_request = _requestBuilder.Build();

		_handler = ServiceScope.GetUserUpdatedEventHandler();
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
	public async Task Consume_ShouldThrowValidationException_WhenIdIsInvalid(
		IStringTransformer transformer, IStringMessageTransformer messageTransformer)
	{
		// Arrange
		var request = _requestBuilder.WithId(transformer).Build();

		// Assert
		await _handler.ShouldThrowInvalidValidationExceptionForIdAsync(request, messageTransformer, CancellationToken);
	}

	[Theory]
	[UserNameNullWithMessageData]
	[UserNameEmptyWithMessageData]
	[UserNameTooShortWithMessageData]
	[UserNameTooLongWithMessageData]
	public async Task Consume_ShouldThrowValidationException_WhenNameIsInvalid(
		IStringTransformer transformer, IStringMessageTransformer messageTransformer)
	{
		// Arrange
		var request = _requestBuilder.WithName(transformer).Build();

		// Assert
		await _handler.ShouldThrowInvalidValidationExceptionForNameAsync(request, messageTransformer, CancellationToken);
	}

	[Theory]
	[UserFirstNameNullWithMessageData]
	[UserFirstNameEmptyWithMessageData]
	[UserFirstNameTooShortWithMessageData]
	[UserFirstNameTooLongWithMessageData]
	public async Task Consume_ShouldThrowValidationException_WhenFirstNameIsInvalid(
		IStringTransformer transformer, IStringMessageTransformer messageTransformer)
	{
		// Arrange
		var request = _requestBuilder.WithFirstName(transformer).Build();

		// Assert
		await _handler.ShouldThrowInvalidValidationExceptionForFirstNameAsync(request, messageTransformer, CancellationToken);
	}

	[Theory]
	[UserLastNameNullWithMessageData]
	[UserLastNameEmptyWithMessageData]
	[UserLastNameTooShortWithMessageData]
	[UserLastNameTooLongWithMessageData]
	public async Task Consume_ShouldThrowValidationException_WhenLastNameIsInvalid(
		IStringTransformer transformer, IStringMessageTransformer messageTransformer)
	{
		// Arrange
		var request = _requestBuilder.WithLastName(transformer).Build();

		// Assert
		await _handler.ShouldThrowInvalidValidationExceptionForLastNameAsync(request, messageTransformer, CancellationToken);
	}

	[Theory]
	[UserEmailNullWithMessageData]
	[UserEmailEmptyWithMessageData]
	[UserEmailTooShortWithMessageData]
	[UserEmailTooLongWithMessageData]
	[UserEmailInvalidWithMessageData]
	public async Task Consume_ShouldThrowValidationException_WhenEmailIsInvalid(
		IStringTransformer transformer, IStringMessageTransformer messageTransformer)
	{
		// Arrange
		var request = _requestBuilder.WithEmail(transformer).Build();

		// Assert
		await _handler.ShouldThrowInvalidValidationExceptionForEmailAsync(request, messageTransformer, CancellationToken);
	}

	[Theory]
	[UserProfileImageTooLongWithMessageData]
	public async Task Consume_ShouldThrowValidationException_WhenProfileImageIsInvalid(
		IStringTransformer transformer, IStringMessageTransformer messageTransformer)
	{
		// Arrange
		var request = _requestBuilder.WithProfileImage(transformer).Build();

		// Assert
		await _handler.ShouldThrowInvalidValidationExceptionForProfileImageAsync(request, messageTransformer, CancellationToken);
	}

	[Theory]
	[UserUpdatedAtUtcEmptyWithMessageData]
	public async Task Consume_ShouldThrowValidationException_WhenUpdatedAtUtcIsInvalid(
		IDateTimeOffsetTransformer transformer, IDateTimeOffsetMessageTransformer messageTransformer)
	{
		// Arrange
		var request = _requestBuilder.WithUpdatedAtUtc(transformer).Build();

		// Assert
		await _handler.ShouldThrowInvalidValidationExceptionForUpdatedAtUtcAsync(request, messageTransformer, CancellationToken);
	}

	[Fact]
	public async Task Consume_ShouldThrowUserNotFoundException_WhenUserNotFound()
	{
		// Arrange
		await ServiceScope.DeleteAsync(User, CancellationToken);

		// Assert
		await _handler.ShouldThrowUserNotFoundExceptionAsync(_request, CancellationToken);
	}

	[Fact]
	public async Task Consume_ShouldThrowUserEmailAlreadyExistsException_WhenUserEmailAlreadyExists()
	{
		// Arrange
		var newUser = UserBuilderFactory.Create().Build();
		await ServiceScope.AddAsync(newUser, CancellationToken);
		var request = _requestBuilder.WithEmail(newUser.Email).Build();

		// Assert
		await _handler.ShouldThrowUserEmailAlreadyExistsExceptionAsync(request, CancellationToken);
	}

	[Theory]
	[UserEmailDifferentCaseData]
	public async Task Consume_ShouldThrowUserEmailAlreadyExistsException_WhenUserEmailAlreadyExistsAndEmailIsInvalid(
		IStringTransformer transformer)
	{
		// Arrange
		var newUser = UserBuilderFactory.Create().Build();
		await ServiceScope.AddAsync(newUser, CancellationToken);
		var request = _requestBuilder.WithEmail(newUser.Email, transformer).Build();

		// Assert
		await _handler.ShouldThrowUserEmailAlreadyExistsExceptionAsync(request, CancellationToken);
	}

	[Fact]
	public async Task Consume_ShouldThrowUserNameAlreadyExistsException_WhenUserNameAlreadyExists()
	{
		// Arrange
		var newUser = UserBuilderFactory.Create().Build();
		await ServiceScope.AddAsync(newUser, CancellationToken);
		var request = _requestBuilder.WithName(newUser.Name).Build();

		// Assert
		await _handler.ShouldThrowUserNameAlreadyExistsExceptionAsync(request, CancellationToken);
	}

	[Theory]
	[UserNameDifferentCaseData]
	public async Task Consume_ShouldThrowUserNameAlreadyExistsException_WhenUserNameAlreadyExistsAndNameIsInvalid(
		IStringTransformer transformer)
	{
		// Arrange
		var newUser = UserBuilderFactory.Create().Build();
		await ServiceScope.AddAsync(newUser, CancellationToken);
		var request = _requestBuilder.WithName(newUser.Name, transformer).Build();

		// Assert
		await _handler.ShouldThrowUserNameAlreadyExistsExceptionAsync(request, CancellationToken);
	}

	[Fact]
	public async Task Consume_ShouldUpdateUser_WhenRequestIsValid()
	{
		// Act
		await _handler.Consume(_request, CancellationToken);
		var user = await ServiceScope.GetByIdAsync(UserId, CancellationToken);

		// Assert
		user.ShouldSatisfy(_request);
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task Consume_ShouldUpdateUser_WhenRequestAndIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithId(transformer).Build();

		// Act
		await _handler.Consume(request, CancellationToken);
		var user = await ServiceScope.GetByIdAsync(UserId, CancellationToken);

		// Assert
		user.ShouldSatisfy(request);
	}

	[Theory]
	[UserNameDifferentCaseData]
	public async Task Consume_ShouldUpdateUser_WhenRequestAndNameAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithName(transformer).Build();

		// Act
		await _handler.Consume(request, CancellationToken);
		var user = await ServiceScope.GetByIdAsync(UserId, CancellationToken);

		// Assert
		user.ShouldSatisfy(request);
	}

	[Fact]
	public async Task Consume_ShouldUpdateUser_WhenNameHasNotChanged()
	{
		// Arrange
		var request = _requestBuilder.WithName(User.Name).Build();

		// Act
		await _handler.Consume(request, CancellationToken);
		var user = await ServiceScope.GetByIdAsync(UserId, CancellationToken);

		// Assert
		user.ShouldSatisfy(request);
	}

	[Theory]
	[UserNameDifferentCaseData]
	public async Task Consume_ShouldUpdateUser_WhenNameIsValidAndHasNotChanged(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithName(User.Name, transformer).Build();

		// Act
		await _handler.Consume(request, CancellationToken);
		var user = await ServiceScope.GetByIdAsync(UserId, CancellationToken);

		// Assert
		user.ShouldSatisfy(request);
	}

	[Theory]
	[UserEmailDifferentCaseData]
	public async Task Consume_ShouldUpdateUser_WhenRequestAndEmailAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithEmail(transformer).Build();

		// Act
		await _handler.Consume(request, CancellationToken);
		var user = await ServiceScope.GetByIdAsync(UserId, CancellationToken);

		// Assert
		user.ShouldSatisfy(request);
	}

	[Fact]
	public async Task Consume_ShouldUpdateUser_WhenEmailHasNotChanged()
	{
		// Arrange
		var request = _requestBuilder.WithEmail(User.Email).Build();

		// Act
		await _handler.Consume(request, CancellationToken);
		var user = await ServiceScope.GetByIdAsync(UserId, CancellationToken);

		// Assert
		user.ShouldSatisfy(request);
	}

	[Theory]
	[UserEmailDifferentCaseData]
	public async Task Consume_ShouldUpdateUser_WhenEmailIsValidAndHasNotChanged(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithEmail(User.Email, transformer).Build();

		// Act
		await _handler.Consume(request, CancellationToken);
		var user = await ServiceScope.GetByIdAsync(UserId, CancellationToken);

		// Assert
		user.ShouldSatisfy(request);
	}

	[Theory]
	[UserProfileImageNullData]
	[UserProfileImageEmptyData]
	public async Task Consume_ShouldUpdateUser_WhenRequestAndProfileImageAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithProfileImage(transformer).Build();

		// Act
		await _handler.Consume(request, CancellationToken);
		var user = await ServiceScope.GetByIdAsync(UserId, CancellationToken);

		// Assert
		user.ShouldSatisfy(request);
	}
}
