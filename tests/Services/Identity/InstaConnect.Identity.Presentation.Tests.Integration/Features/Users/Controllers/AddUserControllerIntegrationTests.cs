namespace InstaConnect.Identity.Presentation.Tests.Integration.Features.Users.Controllers;

public class AddUserControllerIntegrationTests : BaseUserPresentationCommandIntegrationTest
{
	private const string PasswordPropertyName = nameof(AddUserApiForm.Password);

	private readonly AddUserApiRequestBuilderFactory _requestBuilderFactory;
	private readonly AddUserApiRequestBuilder _requestBuilder;
	private readonly AddUserApiRequest _request;

	public AddUserControllerIntegrationTests(IdentityWebApplicationFactory webApplicationFactory)
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
	public async Task AddAsync_ShouldThrowValidationException_WhenNameIsInvalid(
		IStringTransformer transformer, IStringMessageTransformer messageTransformer)
	{
		// Arrange
		var request = _requestBuilder.WithName(transformer).Build();

		// Assert
		await Controller.ShouldThrowInvalidValidationExceptionForNameAsync(
			request, messageTransformer, CancellationToken);
	}

	[Theory]
	[UserFirstNameNullWithMessageData]
	[UserFirstNameEmptyWithMessageData]
	[UserFirstNameTooShortWithMessageData]
	[UserFirstNameTooLongWithMessageData]
	public async Task AddAsync_ShouldThrowValidationException_WhenFirstNameIsInvalid(
		IStringTransformer transformer, IStringMessageTransformer messageTransformer)
	{
		// Arrange
		var request = _requestBuilder.WithFirstName(transformer).Build();

		// Assert
		await Controller.ShouldThrowInvalidValidationExceptionForFirstNameAsync(
			request, messageTransformer, CancellationToken);
	}

	[Theory]
	[UserLastNameNullWithMessageData]
	[UserLastNameEmptyWithMessageData]
	[UserLastNameTooShortWithMessageData]
	[UserLastNameTooLongWithMessageData]
	public async Task AddAsync_ShouldThrowValidationException_WhenLastNameIsInvalid(
		IStringTransformer transformer, IStringMessageTransformer messageTransformer)
	{
		// Arrange
		var request = _requestBuilder.WithLastName(transformer).Build();

		// Assert
		await Controller.ShouldThrowInvalidValidationExceptionForLastNameAsync(
			request, messageTransformer, CancellationToken);
	}

	[Theory]
	[UserEmailNullWithMessageData]
	[UserEmailEmptyWithMessageData]
	[UserEmailTooShortWithMessageData]
	[UserEmailTooLongWithMessageData]
	[UserEmailInvalidWithMessageData]
	public async Task AddAsync_ShouldThrowValidationException_WhenEmailIsInvalid(
		IStringTransformer transformer, IStringMessageTransformer messageTransformer)
	{
		// Arrange
		var request = _requestBuilder.WithEmail(transformer).Build();

		// Assert
		await Controller.ShouldThrowInvalidValidationExceptionForEmailAsync(
			request, messageTransformer, CancellationToken);
	}

	[Theory]
	[UserPasswordNullWithMessageData]
	[UserPasswordEmptyWithMessageData]
	[UserPasswordTooShortWithMessageData]
	[UserPasswordTooLongWithMessageData]
	public async Task AddAsync_ShouldThrowValidationException_WhenPasswordIsInvalid(
		IStringTransformer transformer, IStringMessageTransformer messageTransformer)
	{
		// Arrange
		var request = _requestBuilder.WithPassword(transformer).Build();

		// Assert
		await Controller.ShouldThrowInvalidValidationExceptionForPasswordAsync(
			request, messageTransformer, CancellationToken);
	}

	[Theory]
	[UserConfirmPasswordNotEqualWithMessageData(PasswordPropertyName)]
	public async Task AddAsync_ShouldThrowValidationException_WhenConfirmPasswordIsInvalid(
		IStringTransformer transformer, IStringMessageTransformer messageTransformer)
	{
		// Arrange
		var request = _requestBuilder.WithConfirmPassword(transformer).Build();

		// Assert
		await Controller.ShouldThrowInvalidValidationExceptionForConfirmPasswordAsync(
			request, messageTransformer, CancellationToken);
	}

	[Fact]
	public async Task AddAsync_ShouldThrowUserEmailAlreadyTakenException_WhenUserEmailAlreadyTaken()
	{
		// Arrange
		await ServiceScope.AddAsync(User, CancellationToken);
		var request = _requestBuilder.WithEmail(User.Email).Build();

		// Assert
		await Controller.ShouldThrowUserEmailAlreadyTakenExceptionAsync(request, CancellationToken);
	}

	[Theory]
	[UserEmailDifferentCaseData]
	public async Task AddAsync_ShouldThrowUserEmailAlreadyTakenException_WhenUserEmailAlreadyTakenAndEmailIsInvalid(
		IStringTransformer transformer)
	{
		// Arrange
		await ServiceScope.AddAsync(User, CancellationToken);
		var request = _requestBuilder.WithEmail(User.Email, transformer).Build();

		// Assert
		await Controller.ShouldThrowUserEmailAlreadyTakenExceptionAsync(request, CancellationToken);
	}

	[Fact]
	public async Task AddAsync_ShouldThrowUserNameAlreadyTakenException_WhenUserNameAlreadyTaken()
	{
		// Arrange
		await ServiceScope.AddAsync(User, CancellationToken);
		var request = _requestBuilder.WithName(User.Name).Build();

		// Assert
		await Controller.ShouldThrowUserNameAlreadyTakenExceptionAsync(request, CancellationToken);
	}

	[Theory]
	[UserNameDifferentCaseData]
	public async Task AddAsync_ShouldThrowUserNameAlreadyTakenException_WhenUserNameAlreadyTakenAndNameIsInvalid(
		IStringTransformer transformer)
	{
		// Arrange
		await ServiceScope.AddAsync(User, CancellationToken);
		var request = _requestBuilder.WithName(User.Name, transformer).Build();

		// Assert
		await Controller.ShouldThrowUserNameAlreadyTakenExceptionAsync(request, CancellationToken);
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
	[UserProfileImageNullData]
	public async Task AddAsync_ShouldReturnOkStatusCode_WhenRequestAndProfileImageAreValid(
		IFormFileTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithProfileImage(transformer).Build();

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
		var user = await ServiceScope.GetByIdAsync(response, CancellationToken);

		// Assert
		response.ShouldSatisfy(_request, user);
	}

	[Theory]
	[UserProfileImageNullData]
	public async Task AddAsync_ShouldReturnResponse_WhenRequestAndProfileImageAreValid(
		IFormFileTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithProfileImage(transformer).Build();

		// Act
		var response = await Controller.AddAsync(request, CancellationToken);
		var user = await ServiceScope.GetByIdAsync(response, CancellationToken);

		// Assert
		response.ShouldSatisfy(request, user);
	}

	[Fact]
	public async Task AddAsync_ShouldAddUser_WhenRequestIsValid()
	{
		// Act
		var response = await Controller.AddAsync(_request, CancellationToken);
		var user = await ServiceScope.GetByIdAsync(response, CancellationToken);

		// Assert
		user.ShouldSatisfy(_request, PasswordHasher);
	}

	[Theory]
	[UserProfileImageNullData]
	public async Task AddAsync_ShouldAddUser_WhenRequestAndProfileImageAreValid(
		IFormFileTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithProfileImage(transformer).Build();

		// Act
		var response = await Controller.AddAsync(request, CancellationToken);
		var user = await ServiceScope.GetByIdAsync(response, CancellationToken);

		// Assert
		user.ShouldSatisfy(request, PasswordHasher);
	}

	[Fact]
	public async Task AddAsync_ShouldAddEmailConfirmationToken_WhenRequestIsValid()
	{
		// Act
		var response = await Controller.AddAsync(_request, CancellationToken);
		var user = await ServiceScope.GetByIdAsync(response, CancellationToken);

		// Assert
		user.EmailConfirmationTokens.ShouldSatisfy(_request);
	}

	[Theory]
	[UserProfileImageNullData]
	public async Task AddAsync_ShouldAddEmailConfirmationToken_WhenRequestAndProfileImageAreValid(
		IFormFileTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithProfileImage(transformer).Build();

		// Act
		var response = await Controller.AddAsync(request, CancellationToken);
		var user = await ServiceScope.GetByIdAsync(response, CancellationToken);

		// Assert
		user.EmailConfirmationTokens.ShouldSatisfy(request);
	}

	[Fact]
	public async Task AddAsync_ShouldPublishUserAddedEvent_WhenRequestIsValid()
	{
		// Act
		var response = await Controller.AddAsync(_request, CancellationToken);
		var user = await ServiceScope.GetByIdAsync(response, CancellationToken);
		var eventRequest = await EventClient.PublishedAddedAsync(CancellationToken);

		// Assert
		eventRequest.ShouldSatisfy(_request, user);
	}

	[Theory]
	[UserProfileImageNullData]
	public async Task AddAsync_ShouldPublishUserAddedEvent_WhenRequestAndProfileImageAreValid(
		IFormFileTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithProfileImage(transformer).Build();

		// Act
		var response = await Controller.AddAsync(request, CancellationToken);
		var user = await ServiceScope.GetByIdAsync(response, CancellationToken);
		var eventRequest = await EventClient.PublishedAddedAsync(CancellationToken);

		// Assert
		eventRequest.ShouldSatisfy(request, user);
	}

	[Fact]
	public async Task AddAsync_ShouldPublishEmailConfirmationTokenAddedEvent_WhenRequestIsValid()
	{
		// Act
		var response = await Controller.AddAsync(_request, CancellationToken);
		var user = await ServiceScope.GetByIdAsync(response, CancellationToken);
		var eventRequests = await EmailConfirmationTokenEventClient.PublishedAddedRangeAsync(CancellationToken);

		// Assert
		eventRequests.ShouldSatisfy(_request, user.EmailConfirmationTokens);
	}

	[Theory]
	[UserProfileImageNullData]
	public async Task AddAsync_ShouldPublishEmailConfirmationTokenAddedEvent_WhenRequestAndProfileImageAreValid(
		IFormFileTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithProfileImage(transformer).Build();

		// Act
		var response = await Controller.AddAsync(request, CancellationToken);
		var user = await ServiceScope.GetByIdAsync(response, CancellationToken);
		var eventRequests = await EmailConfirmationTokenEventClient.PublishedAddedRangeAsync(CancellationToken);

		// Assert
		eventRequests.ShouldSatisfy(request, user.EmailConfirmationTokens);
	}
}
