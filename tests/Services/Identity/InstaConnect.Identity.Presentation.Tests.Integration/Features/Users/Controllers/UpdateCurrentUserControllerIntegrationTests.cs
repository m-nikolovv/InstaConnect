namespace InstaConnect.Identity.Presentation.Tests.Integration.Features.Users.Controllers;

public class UpdateCurrentUserControllerIntegrationTests : BaseUserPresentationCommandIntegrationTest
{
	private readonly UpdateCurrentUserApiRequestBuilderFactory _requestBuilderFactory;
	private readonly UpdateCurrentUserApiRequestBuilder _requestBuilder;
	private readonly UpdateCurrentUserApiRequest _request;

	public UpdateCurrentUserControllerIntegrationTests(IdentityWebApplicationFactory webApplicationFactory)
		: base(webApplicationFactory)
	{
		_requestBuilderFactory = new();
		_requestBuilder = _requestBuilderFactory.Create(User);
		_request = _requestBuilder.Build();
	}

	protected override async Task OnInitializeAsync()
	{
		await ServiceScope.AddAsync(User, CancellationToken);
		await ServiceScope.AddRangeAsync(User.EmailConfirmationTokens, CancellationToken);
	}

	[Theory]
	[UserIdNullWithMessageData]
	[UserIdEmptyWithMessageData]
	[UserIdTooShortWithMessageData]
	[UserIdTooLongWithMessageData]
	public async Task UpdateCurrentAsync_ShouldThrowValidationException_WhenIdIsInvalid(
		IStringTransformer transformer, IStringMessageTransformer messageTransformer)
	{
		// Arrange
		var request = _requestBuilder.WithId(transformer).Build();

		// Assert
		await Controller.ShouldThrowInvalidValidationExceptionForIdAsync(
			request, messageTransformer, CancellationToken);
	}

	[Theory]
	[UserNameNullWithMessageData]
	[UserNameEmptyWithMessageData]
	[UserNameTooShortWithMessageData]
	[UserNameTooLongWithMessageData]
	public async Task UpdateCurrentAsync_ShouldThrowValidationException_WhenNameIsInvalid(
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
	public async Task UpdateCurrentAsync_ShouldThrowValidationException_WhenFirstNameIsInvalid(
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
	public async Task UpdateCurrentAsync_ShouldThrowValidationException_WhenLastNameIsInvalid(
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
	public async Task UpdateCurrentAsync_ShouldThrowValidationException_WhenEmailIsInvalid(
		IStringTransformer transformer, IStringMessageTransformer messageTransformer)
	{
		// Arrange
		var request = _requestBuilder.WithEmail(transformer).Build();

		// Assert
		await Controller.ShouldThrowInvalidValidationExceptionForEmailAsync(
			request, messageTransformer, CancellationToken);
	}

	[Fact]
	public async Task UpdateCurrentAsync_ShouldThrowUserNotFoundException_WhenUserNotFound()
	{
		// Arrange
		await ServiceScope.DeleteAsync(User, CancellationToken);

		// Assert
		await Controller.ShouldThrowUserNotFoundExceptionAsync(_request, CancellationToken);
	}

	[Fact]
	public async Task UpdateCurrentAsync_ShouldThrowUserEmailAlreadyTakenException_WhenUserEmailAlreadyTaken()
	{
		// Arrange
		var user = UserBuilderFactory.Create(User.PasswordHash).Build();
		await ServiceScope.AddAsync(user, CancellationToken);
		var request = _requestBuilder.WithEmail(user.Email).Build();

		// Assert
		await Controller.ShouldThrowUserEmailAlreadyTakenExceptionAsync(request, CancellationToken);
	}

	[Theory]
	[UserEmailDifferentCaseData]
	public async Task UpdateCurrentAsync_ShouldThrowUserEmailAlreadyTakenException_WhenUserEmailAlreadyTakenAndEmailIsInvalid(
		IStringTransformer transformer)
	{
		// Arrange
		var user = UserBuilderFactory.Create(User.PasswordHash).Build();
		await ServiceScope.AddAsync(user, CancellationToken);
		var request = _requestBuilder.WithEmail(user.Email, transformer).Build();

		// Assert
		await Controller.ShouldThrowUserEmailAlreadyTakenExceptionAsync(request, CancellationToken);
	}

	[Fact]
	public async Task UpdateCurrentAsync_ShouldThrowUserNameAlreadyTakenException_WhenUserNameAlreadyTaken()
	{
		// Arrange
		var user = UserBuilderFactory.Create(User.PasswordHash).Build();
		await ServiceScope.AddAsync(user, CancellationToken);
		var request = _requestBuilder.WithName(user.Name).Build();

		// Assert
		await Controller.ShouldThrowUserNameAlreadyTakenExceptionAsync(request, CancellationToken);
	}

	[Theory]
	[UserNameDifferentCaseData]
	public async Task UpdateCurrentAsync_ShouldThrowUserNameAlreadyTakenException_WhenUserNameAlreadyTakenAndNameIsInvalid(
		IStringTransformer transformer)
	{
		// Arrange
		var user = UserBuilderFactory.Create(User.PasswordHash).Build();
		await ServiceScope.AddAsync(user, CancellationToken);
		var request = _requestBuilder.WithName(user.Name, transformer).Build();

		// Assert
		await Controller.ShouldThrowUserNameAlreadyTakenExceptionAsync(request, CancellationToken);
	}

	[Fact]
	public async Task UpdateCurrentAsync_ShouldReturnOkStatusCode_WhenRequestIsValid()
	{
		var response = await Controller.UpdateCurrentAsync(_request, CancellationToken);

		response.ShouldBeActionResultWithOkStatusCode();
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task UpdateCurrentAsync_ShouldReturnOkStatusCode_WhenRequestAndIdAreValid(
		IStringTransformer transformer)
	{
		var request = _requestBuilder.WithId(transformer).Build();

		var response = await Controller.UpdateCurrentAsync(request, CancellationToken);

		response.ShouldBeActionResultWithOkStatusCode();
	}

	[Theory]
	[UserNameDifferentCaseData]
	public async Task UpdateCurrentAsync_ShouldReturnOkStatusCode_WhenRequestAndNameAreValid(
		IStringTransformer transformer)
	{
		var request = _requestBuilder.WithName(transformer).Build();

		var response = await Controller.UpdateCurrentAsync(request, CancellationToken);

		response.ShouldBeActionResultWithOkStatusCode();
	}

	[Fact]
	public async Task UpdateCurrentAsync_ShouldReturnOkStatusCode_WhenRequestAndNameHasNotChanged()
	{
		var request = _requestBuilder.WithName(User.Name).Build();

		var response = await Controller.UpdateCurrentAsync(request, CancellationToken);

		response.ShouldBeActionResultWithOkStatusCode();
	}

	[Theory]
	[UserNameDifferentCaseData]
	public async Task UpdateCurrentAsync_ShouldReturnOkStatusCode_WhenRequestAndNameIsValidAndHasNotChanged(
		IStringTransformer transformer)
	{
		var request = _requestBuilder.WithName(User.Name, transformer).Build();

		var response = await Controller.UpdateCurrentAsync(request, CancellationToken);

		response.ShouldBeActionResultWithOkStatusCode();
	}

	[Theory]
	[UserEmailDifferentCaseData]
	public async Task UpdateCurrentAsync_ShouldReturnOkStatusCode_WhenRequestAndEmailAreValid(
		IStringTransformer transformer)
	{
		var request = _requestBuilder.WithEmail(transformer).Build();

		var response = await Controller.UpdateCurrentAsync(request, CancellationToken);

		response.ShouldBeActionResultWithOkStatusCode();
	}

	[Fact]
	public async Task UpdateCurrentAsync_ShouldReturnOkStatusCode_WhenRequestAndEmailHasNotChanged()
	{
		var request = _requestBuilder.WithEmail(User.Email).Build();

		var response = await Controller.UpdateCurrentAsync(request, CancellationToken);

		response.ShouldBeActionResultWithOkStatusCode();
	}

	[Theory]
	[UserEmailDifferentCaseData]
	public async Task UpdateCurrentAsync_ShouldReturnOkStatusCode_WhenRequestAndEmailIsValidAndHasNotChanged(
		IStringTransformer transformer)
	{
		var request = _requestBuilder.WithEmail(User.Email, transformer).Build();

		var response = await Controller.UpdateCurrentAsync(request, CancellationToken);

		response.ShouldBeActionResultWithOkStatusCode();
	}

	[Theory]
	[UserProfileImageNullData]
	public async Task UpdateCurrentAsync_ShouldReturnOkStatusCode_WhenRequestAndProfileImageAreValid(
		IFormFileTransformer transformer)
	{
		var request = _requestBuilder.WithProfileImage(transformer).Build();

		var response = await Controller.UpdateCurrentAsync(request, CancellationToken);

		response.ShouldBeActionResultWithOkStatusCode();
	}

	[Fact]
	public async Task UpdateCurrentAsync_ShouldReturnResponse_WhenRequestIsValid()
	{
		var response = await Controller.UpdateCurrentAsync(_request, CancellationToken);
		var user = await ServiceScope.GetByIdAsync(response, CancellationToken);

		response.ShouldSatisfy(_request, user);
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task UpdateCurrentAsync_ShouldReturnResponse_WhenIdIsValid(
		IStringTransformer transformer)
	{
		var request = _requestBuilder.WithId(transformer).Build();

		var response = await Controller.UpdateCurrentAsync(request, CancellationToken);
		var user = await ServiceScope.GetByIdAsync(response, CancellationToken);

		response.ShouldSatisfy(request, user);
	}

	[Theory]
	[UserNameDifferentCaseData]
	public async Task UpdateCurrentAsync_ShouldReturnResponse_WhenNameIsValid(
		IStringTransformer transformer)
	{
		var request = _requestBuilder.WithName(transformer).Build();

		var response = await Controller.UpdateCurrentAsync(request, CancellationToken);
		var user = await ServiceScope.GetByIdAsync(response, CancellationToken);

		response.ShouldSatisfy(request, user);
	}

	[Fact]
	public async Task UpdateCurrentAsync_ShouldReturnResponse_WhenNameHasNotChanged()
	{
		var request = _requestBuilder.WithName(User.Name).Build();

		var response = await Controller.UpdateCurrentAsync(request, CancellationToken);
		var user = await ServiceScope.GetByIdAsync(response, CancellationToken);

		response.ShouldSatisfy(request, user);
	}

	[Theory]
	[UserNameDifferentCaseData]
	public async Task UpdateCurrentAsync_ShouldReturnResponse_WhenNameIsValidAndHasNotChanged(
		IStringTransformer transformer)
	{
		var request = _requestBuilder.WithName(User.Name, transformer).Build();

		var response = await Controller.UpdateCurrentAsync(request, CancellationToken);
		var user = await ServiceScope.GetByIdAsync(response, CancellationToken);

		response.ShouldSatisfy(request, user);
	}

	[Theory]
	[UserEmailDifferentCaseData]
	public async Task UpdateCurrentAsync_ShouldReturnResponse_WhenEmailIsValid(
		IStringTransformer transformer)
	{
		var request = _requestBuilder.WithEmail(transformer).Build();

		var response = await Controller.UpdateCurrentAsync(request, CancellationToken);
		var user = await ServiceScope.GetByIdAsync(response, CancellationToken);

		response.ShouldSatisfy(request, user);
	}

	[Fact]
	public async Task UpdateCurrentAsync_ShouldReturnResponse_WhenEmailHasNotChanged()
	{
		var request = _requestBuilder.WithEmail(User.Email).Build();

		var response = await Controller.UpdateCurrentAsync(request, CancellationToken);
		var user = await ServiceScope.GetByIdAsync(response, CancellationToken);

		response.ShouldSatisfy(request, user);
	}

	[Theory]
	[UserEmailDifferentCaseData]
	public async Task UpdateCurrentAsync_ShouldReturnResponse_WhenEmailIsValidAndHasNotChanged(
		IStringTransformer transformer)
	{
		var request = _requestBuilder.WithEmail(User.Email, transformer).Build();

		var response = await Controller.UpdateCurrentAsync(request, CancellationToken);
		var user = await ServiceScope.GetByIdAsync(response, CancellationToken);

		response.ShouldSatisfy(request, user);
	}

	[Theory]
	[UserProfileImageNullData]
	public async Task UpdateCurrentAsync_ShouldReturnResponse_WhenRequestAndProfileImageAreValid(
		IFormFileTransformer transformer)
	{
		var request = _requestBuilder.WithProfileImage(transformer).Build();

		var response = await Controller.UpdateCurrentAsync(request, CancellationToken);
		var user = await ServiceScope.GetByIdAsync(response, CancellationToken);

		response.ShouldSatisfy(request, user);
	}

	[Fact]
	public async Task UpdateCurrentAsync_ShouldUpdateUser_WhenRequestIsValid()
	{
		var response = await Controller.UpdateCurrentAsync(_request, CancellationToken);
		var user = await ServiceScope.GetByIdAsync(response, CancellationToken);

		user.ShouldSatisfy(_request);
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task UpdateCurrentAsync_ShouldUpdateUser_WhenIdIsValid(
		IStringTransformer transformer)
	{
		var request = _requestBuilder.WithId(transformer).Build();

		var response = await Controller.UpdateCurrentAsync(request, CancellationToken);
		var user = await ServiceScope.GetByIdAsync(response, CancellationToken);

		user.ShouldSatisfy(request);
	}

	[Theory]
	[UserNameDifferentCaseData]
	public async Task UpdateCurrentAsync_ShouldUpdateUser_WhenNameIsValid(
		IStringTransformer transformer)
	{
		var request = _requestBuilder.WithName(transformer).Build();

		var response = await Controller.UpdateCurrentAsync(request, CancellationToken);
		var user = await ServiceScope.GetByIdAsync(response, CancellationToken);

		user.ShouldSatisfy(request);
	}

	[Fact]
	public async Task UpdateCurrentAsync_ShouldUpdateUser_WhenNameHasNotChanged()
	{
		var request = _requestBuilder.WithName(User.Name).Build();

		var response = await Controller.UpdateCurrentAsync(request, CancellationToken);
		var user = await ServiceScope.GetByIdAsync(response, CancellationToken);

		user.ShouldSatisfy(request);
	}

	[Theory]
	[UserNameDifferentCaseData]
	public async Task UpdateCurrentAsync_ShouldUpdateUser_WhenNameIsValidAndHasNotChanged(
		IStringTransformer transformer)
	{
		var request = _requestBuilder.WithName(User.Name, transformer).Build();

		var response = await Controller.UpdateCurrentAsync(request, CancellationToken);
		var user = await ServiceScope.GetByIdAsync(response, CancellationToken);

		user.ShouldSatisfy(request);
	}

	[Theory]
	[UserEmailDifferentCaseData]
	public async Task UpdateCurrentAsync_ShouldUpdateUser_WhenEmailIsValid(
		IStringTransformer transformer)
	{
		var request = _requestBuilder.WithEmail(transformer).Build();

		var response = await Controller.UpdateCurrentAsync(request, CancellationToken);
		var user = await ServiceScope.GetByIdAsync(response, CancellationToken);

		user.ShouldSatisfy(request);
	}

	[Fact]
	public async Task UpdateCurrentAsync_ShouldUpdateUser_WhenEmailHasNotChanged()
	{
		var request = _requestBuilder.WithEmail(User.Email).Build();

		var response = await Controller.UpdateCurrentAsync(request, CancellationToken);
		var user = await ServiceScope.GetByIdAsync(response, CancellationToken);

		user.ShouldSatisfy(request);
	}

	[Theory]
	[UserEmailDifferentCaseData]
	public async Task UpdateCurrentAsync_ShouldUpdateUser_WhenEmailIsValidAndHasNotChanged(
		IStringTransformer transformer)
	{
		var request = _requestBuilder.WithEmail(User.Email, transformer).Build();

		var response = await Controller.UpdateCurrentAsync(request, CancellationToken);
		var user = await ServiceScope.GetByIdAsync(response, CancellationToken);

		user.ShouldSatisfy(request);
	}

	[Theory]
	[UserProfileImageNullData]
	public async Task UpdateCurrentAsync_ShouldUpdateUser_WhenRequestAndProfileImageAreValid(
		IFormFileTransformer transformer)
	{
		var request = _requestBuilder.WithProfileImage(transformer).Build();

		var response = await Controller.UpdateCurrentAsync(request, CancellationToken);
		var user = await ServiceScope.GetByIdAsync(response, CancellationToken);

		user.ShouldSatisfy(request);
	}

	[Fact]
	public async Task UpdateCurrentAsync_ShouldPublishUserUpdatedEvent_WhenRequestIsValid()
	{
		var response = await Controller.UpdateCurrentAsync(_request, CancellationToken);
		var user = await ServiceScope.GetByIdAsync(response, CancellationToken);
		var eventRequest = await EventClient.PublishedUpdatedAsync(CancellationToken);

		eventRequest.ShouldSatisfy(_request, user);
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task UpdateCurrentAsync_ShouldPublishUserUpdatedEvent_WhenIdIsValid(
		IStringTransformer transformer)
	{
		var request = _requestBuilder.WithId(transformer).Build();

		var response = await Controller.UpdateCurrentAsync(request, CancellationToken);
		var user = await ServiceScope.GetByIdAsync(response, CancellationToken);
		var eventRequest = await EventClient.PublishedUpdatedAsync(CancellationToken);

		eventRequest.ShouldSatisfy(request, user);
	}

	[Theory]
	[UserNameDifferentCaseData]
	public async Task UpdateCurrentAsync_ShouldPublishUserUpdatedEvent_WhenNameIsValid(
		IStringTransformer transformer)
	{
		var request = _requestBuilder.WithName(transformer).Build();

		var response = await Controller.UpdateCurrentAsync(request, CancellationToken);
		var user = await ServiceScope.GetByIdAsync(response, CancellationToken);
		var eventRequest = await EventClient.PublishedUpdatedAsync(CancellationToken);

		eventRequest.ShouldSatisfy(request, user);
	}

	[Fact]
	public async Task UpdateCurrentAsync_ShouldPublishUserUpdatedEvent_WhenNameHasNotChanged()
	{
		var request = _requestBuilder.WithName(User.Name).Build();

		var response = await Controller.UpdateCurrentAsync(request, CancellationToken);
		var user = await ServiceScope.GetByIdAsync(response, CancellationToken);
		var eventRequest = await EventClient.PublishedUpdatedAsync(CancellationToken);

		eventRequest.ShouldSatisfy(request, user);
	}

	[Theory]
	[UserNameDifferentCaseData]
	public async Task UpdateCurrentAsync_ShouldPublishUserUpdatedEvent_WhenNameIsValidAndHasNotChanged(
		IStringTransformer transformer)
	{
		var request = _requestBuilder.WithName(User.Name, transformer).Build();

		var response = await Controller.UpdateCurrentAsync(request, CancellationToken);
		var user = await ServiceScope.GetByIdAsync(response, CancellationToken);
		var eventRequest = await EventClient.PublishedUpdatedAsync(CancellationToken);

		eventRequest.ShouldSatisfy(request, user);
	}

	[Theory]
	[UserEmailDifferentCaseData]
	public async Task UpdateCurrentAsync_ShouldPublishUserUpdatedEvent_WhenEmailIsValid(
		IStringTransformer transformer)
	{
		var request = _requestBuilder.WithEmail(transformer).Build();

		var response = await Controller.UpdateCurrentAsync(request, CancellationToken);
		var user = await ServiceScope.GetByIdAsync(response, CancellationToken);
		var eventRequest = await EventClient.PublishedUpdatedAsync(CancellationToken);

		eventRequest.ShouldSatisfy(request, user);
	}

	[Fact]
	public async Task UpdateCurrentAsync_ShouldPublishUserUpdatedEvent_WhenEmailHasNotChanged()
	{
		var request = _requestBuilder.WithEmail(User.Email).Build();

		var response = await Controller.UpdateCurrentAsync(request, CancellationToken);
		var user = await ServiceScope.GetByIdAsync(response, CancellationToken);
		var eventRequest = await EventClient.PublishedUpdatedAsync(CancellationToken);

		eventRequest.ShouldSatisfy(request, user);
	}

	[Theory]
	[UserEmailDifferentCaseData]
	public async Task UpdateCurrentAsync_ShouldPublishUserUpdatedEvent_WhenEmailIsValidAndHasNotChanged(
		IStringTransformer transformer)
	{
		var request = _requestBuilder.WithEmail(User.Email, transformer).Build();

		var response = await Controller.UpdateCurrentAsync(request, CancellationToken);
		var user = await ServiceScope.GetByIdAsync(response, CancellationToken);
		var eventRequest = await EventClient.PublishedUpdatedAsync(CancellationToken);

		eventRequest.ShouldSatisfy(request, user);
	}

	[Theory]
	[UserProfileImageNullData]
	public async Task UpdateCurrentAsync_ShouldPublishUserUpdatedEvent_WhenRequestAndProfileImageAreValid(
		IFormFileTransformer transformer)
	{
		var request = _requestBuilder.WithProfileImage(transformer).Build();

		var response = await Controller.UpdateCurrentAsync(request, CancellationToken);
		var user = await ServiceScope.GetByIdAsync(response, CancellationToken);
		var eventRequest = await EventClient.PublishedUpdatedAsync(CancellationToken);

		eventRequest.ShouldSatisfy(request, user);
	}

	[Fact]
	public async Task UpdateCurrentAsync_ShouldDeleteEmailConfirmationTokens_WhenRequestIsValid()
	{
		var response = await Controller.UpdateCurrentAsync(_request, CancellationToken);
		var user = await ServiceScope.GetByIdAsync(response, CancellationToken);

		user.EmailConfirmationTokens.ShouldBeEmpty();
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task UpdateCurrentAsync_ShouldDeleteEmailConfirmationTokens_WhenIdIsValid(
		IStringTransformer transformer)
	{
		var request = _requestBuilder.WithId(transformer).Build();

		var response = await Controller.UpdateCurrentAsync(request, CancellationToken);
		var user = await ServiceScope.GetByIdAsync(response, CancellationToken);

		user.EmailConfirmationTokens.ShouldBeEmpty();
	}

	[Theory]
	[UserNameDifferentCaseData]
	public async Task UpdateCurrentAsync_ShouldDeleteEmailConfirmationTokens_WhenNameIsValid(
		IStringTransformer transformer)
	{
		var request = _requestBuilder.WithName(transformer).Build();

		var response = await Controller.UpdateCurrentAsync(request, CancellationToken);
		var user = await ServiceScope.GetByIdAsync(response, CancellationToken);

		user.EmailConfirmationTokens.ShouldBeEmpty();
	}

	[Fact]
	public async Task UpdateCurrentAsync_ShouldDeleteEmailConfirmationTokens_WhenNameHasNotChanged()
	{
		var request = _requestBuilder.WithName(User.Name).Build();

		var response = await Controller.UpdateCurrentAsync(request, CancellationToken);
		var user = await ServiceScope.GetByIdAsync(response, CancellationToken);

		user.EmailConfirmationTokens.ShouldBeEmpty();
	}

	[Theory]
	[UserNameDifferentCaseData]
	public async Task UpdateCurrentAsync_ShouldDeleteEmailConfirmationTokens_WhenNameIsValidAndHasNotChanged(
		IStringTransformer transformer)
	{
		var request = _requestBuilder.WithName(User.Name, transformer).Build();

		var response = await Controller.UpdateCurrentAsync(request, CancellationToken);
		var user = await ServiceScope.GetByIdAsync(response, CancellationToken);

		user.EmailConfirmationTokens.ShouldBeEmpty();
	}

	[Theory]
	[UserEmailDifferentCaseData]
	public async Task UpdateCurrentAsync_ShouldDeleteEmailConfirmationTokens_WhenEmailIsValid(
		IStringTransformer transformer)
	{
		var request = _requestBuilder.WithEmail(transformer).Build();

		var response = await Controller.UpdateCurrentAsync(request, CancellationToken);
		var user = await ServiceScope.GetByIdAsync(response, CancellationToken);

		user.EmailConfirmationTokens.ShouldBeEmpty();
	}

	[Theory]
	[UserProfileImageNullData]
	public async Task UpdateCurrentAsync_ShouldDeleteEmailConfirmationTokens_WhenRequestAndProfileImageAreValid(
		IFormFileTransformer transformer)
	{
		var request = _requestBuilder.WithProfileImage(transformer).Build();

		var response = await Controller.UpdateCurrentAsync(request, CancellationToken);
		var user = await ServiceScope.GetByIdAsync(response, CancellationToken);

		user.EmailConfirmationTokens.ShouldBeEmpty();
	}

	[Fact]
	public async Task UpdateCurrentAsync_ShouldNotDeleteEmailConfirmationTokens_WhenEmailHasNotChanged()
	{
		var request = _requestBuilder.WithEmail(User.Email).Build();

		var response = await Controller.UpdateCurrentAsync(request, CancellationToken);
		var user = await ServiceScope.GetByIdAsync(response, CancellationToken);

		user.EmailConfirmationTokens.ShouldSatisfy(request);
	}

	[Theory]
	[UserEmailDifferentCaseData]
	public async Task UpdateCurrentAsync_ShouldNotDeleteEmailConfirmationTokens_WhenEmailIsValidAndHasNotChanged(
		IStringTransformer transformer)
	{
		var request = _requestBuilder.WithEmail(User.Email, transformer).Build();

		var response = await Controller.UpdateCurrentAsync(request, CancellationToken);
		var user = await ServiceScope.GetByIdAsync(response, CancellationToken);

		user.EmailConfirmationTokens.ShouldSatisfy(request);
	}

	[Fact]
	public async Task UpdateCurrentAsync_ShouldPublishEmailConfirmationTokenDeletedEvents_WhenRequestIsValid()
	{
		var response = await Controller.UpdateCurrentAsync(_request, CancellationToken);
		var user = await ServiceScope.GetByIdAsync(response, CancellationToken);
		var eventRequests = await EmailConfirmationTokenEventClient.PublishedDeletedRangeAsync(CancellationToken);

		eventRequests.ShouldSatisfy(_request, User.EmailConfirmationTokens.AddUser(user));
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task UpdateCurrentAsync_ShouldPublishEmailConfirmationTokenDeletedEvents_WhenIdIsValid(
		IStringTransformer transformer)
	{
		var request = _requestBuilder.WithId(transformer).Build();

		var response = await Controller.UpdateCurrentAsync(request, CancellationToken);
		var user = await ServiceScope.GetByIdAsync(response, CancellationToken);
		var eventRequests = await EmailConfirmationTokenEventClient.PublishedDeletedRangeAsync(CancellationToken);

		eventRequests.ShouldSatisfy(request, User.EmailConfirmationTokens.AddUser(user));
	}

	[Theory]
	[UserNameDifferentCaseData]
	public async Task UpdateCurrentAsync_ShouldPublishEmailConfirmationTokenDeletedEvents_WhenNameIsValid(
		IStringTransformer transformer)
	{
		var request = _requestBuilder.WithName(transformer).Build();

		var response = await Controller.UpdateCurrentAsync(request, CancellationToken);
		var user = await ServiceScope.GetByIdAsync(response, CancellationToken);
		var eventRequests = await EmailConfirmationTokenEventClient.PublishedDeletedRangeAsync(CancellationToken);

		eventRequests.ShouldSatisfy(request, User.EmailConfirmationTokens.AddUser(user));
	}

	[Fact]
	public async Task UpdateCurrentAsync_ShouldPublishEmailConfirmationTokenDeletedEvents_WhenNameHasNotChanged()
	{
		var request = _requestBuilder.WithName(User.Name).Build();

		var response = await Controller.UpdateCurrentAsync(request, CancellationToken);
		var user = await ServiceScope.GetByIdAsync(response, CancellationToken);
		var eventRequests = await EmailConfirmationTokenEventClient.PublishedDeletedRangeAsync(CancellationToken);

		eventRequests.ShouldSatisfy(request, User.EmailConfirmationTokens.AddUser(user));
	}

	[Theory]
	[UserNameDifferentCaseData]
	public async Task UpdateCurrentAsync_ShouldPublishEmailConfirmationTokenDeletedEvents_WhenNameIsValidAndHasNotChanged(
		IStringTransformer transformer)
	{
		var request = _requestBuilder.WithName(User.Name, transformer).Build();

		var response = await Controller.UpdateCurrentAsync(request, CancellationToken);
		var user = await ServiceScope.GetByIdAsync(response, CancellationToken);
		var eventRequests = await EmailConfirmationTokenEventClient.PublishedDeletedRangeAsync(CancellationToken);

		eventRequests.ShouldSatisfy(request, User.EmailConfirmationTokens.AddUser(user));
	}

	[Theory]
	[UserEmailDifferentCaseData]
	public async Task UpdateCurrentAsync_ShouldPublishEmailConfirmationTokenDeletedEvents_WhenEmailIsValid(
		IStringTransformer transformer)
	{
		var request = _requestBuilder.WithEmail(transformer).Build();

		var response = await Controller.UpdateCurrentAsync(request, CancellationToken);
		var user = await ServiceScope.GetByIdAsync(response, CancellationToken);
		var eventRequests = await EmailConfirmationTokenEventClient.PublishedDeletedRangeAsync(CancellationToken);

		eventRequests.ShouldSatisfy(request, User.EmailConfirmationTokens.AddUser(user));
	}

	[Theory]
	[UserProfileImageNullData]
	public async Task UpdateCurrentAsync_ShouldPublishEmailConfirmationTokenDeletedEvents_WhenRequestAndProfileImageAreValid(
		IFormFileTransformer transformer)
	{
		var request = _requestBuilder.WithProfileImage(transformer).Build();

		var response = await Controller.UpdateCurrentAsync(request, CancellationToken);
		var user = await ServiceScope.GetByIdAsync(response, CancellationToken);
		var eventRequests = await EmailConfirmationTokenEventClient.PublishedDeletedRangeAsync(CancellationToken);

		eventRequests.ShouldSatisfy(request, User.EmailConfirmationTokens.AddUser(user));
	}

	[Fact]
	public async Task UpdateCurrentAsync_ShouldNotPublishEmailConfirmationTokenDeletedEvents_WhenEmailHasNotChanged()
	{
		var request = _requestBuilder.WithEmail(User.Email).Build();

		await Controller.UpdateCurrentAsync(request, CancellationToken);
		var eventRequests = await EmailConfirmationTokenEventClient.PublishedDeletedRangeAsync(CancellationToken);

		eventRequests.ShouldBeEmpty();
	}

	[Theory]
	[UserEmailDifferentCaseData]
	public async Task UpdateCurrentAsync_ShouldNotPublishEmailConfirmationTokenDeletedEvents_WhenEmailIsValidAndHasNotChanged(
		IStringTransformer transformer)
	{
		var request = _requestBuilder.WithEmail(User.Email, transformer).Build();

		await Controller.UpdateCurrentAsync(request, CancellationToken);
		var eventRequests = await EmailConfirmationTokenEventClient.PublishedDeletedRangeAsync(CancellationToken);

		eventRequests.ShouldBeEmpty();
	}
}
