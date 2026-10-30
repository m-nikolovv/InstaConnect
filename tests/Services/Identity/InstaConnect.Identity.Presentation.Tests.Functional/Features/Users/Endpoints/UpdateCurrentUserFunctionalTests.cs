using InstaConnect.Common.Tests.Features.DataAttributes.FormFiles.Base;
using InstaConnect.Identity.Domain.Features.EmailConfirmationTokens.Extensions;
using InstaConnect.Identity.Tests.Features.Users.DataAttributes.Email;
using InstaConnect.Identity.Tests.Features.Users.DataAttributes.FirstName;
using InstaConnect.Identity.Tests.Features.Users.DataAttributes.LastName;
using InstaConnect.Identity.Tests.Features.Users.DataAttributes.ProfileImage;

namespace InstaConnect.Identity.Presentation.Tests.Functional.Features.Users.Endpoints;

public class UpdateCurrentUserFunctionalTests : BaseUserPresentationCommandFunctionalTest
{
	private readonly UpdateCurrentUserApiRequestBuilderFactory _requestBuilderFactory;
	private readonly UpdateCurrentUserApiRequestBuilder _requestBuilder;
	private readonly UpdateCurrentUserApiRequest _request;

	public UpdateCurrentUserFunctionalTests(IdentityWebApplicationFactory webApplicationFactory)
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

	[Fact]
	public async Task UpdateCurrentAsync_ShouldReturnUnauthorizedStatusCode_WhenRequestIsUnauthorized()
	{
		// Act
		var response = await ApiClient.UpdateCurrentUnauthorizedStatusCodeAsync(_request, CancellationToken);

		// Assert
		response.ShouldBeUnauthorized();
	}

	[Theory]
	[UserIdEmptyData]
	[UserIdTooShortData]
	[UserIdTooLongData]
	public async Task UpdateCurrentAsync_ShouldHaveBadRequestStatusCode_WhenIdIsInvalid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithId(transformer).Build();

		// Act
		var response = await ApiClient.UpdateCurrentStatusCodeAsync(request, CancellationToken);

		// Assert
		response.ShouldBeBadRequest();
	}

	[Theory]
	[UserIdEmptyWithMessageData]
	[UserIdTooShortWithMessageData]
	[UserIdTooLongWithMessageData]
	public async Task UpdateCurrentAsync_ShouldHaveBadRequestProblemDetails_WhenIdIsInvalid(
		IStringTransformer transformer,
		IStringMessageTransformer messageTransformer)
	{
		// Arrange
		var request = _requestBuilder.WithId(transformer).Build();

		// Act
		var response = await ApiClient.UpdateCurrentProblemDetailsAsync(request, CancellationToken);

		// Assert
		response.ShouldSatisfyInvalidValidationForId(request, messageTransformer);
	}

	[Theory]
	[UserNameNullData]
	[UserNameEmptyData]
	[UserNameTooShortData]
	[UserNameTooLongData]
	public async Task UpdateCurrentAsync_ShouldHaveBadRequestStatusCode_WhenNameIsInvalid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithName(transformer).Build();

		// Act
		var response = await ApiClient.UpdateCurrentStatusCodeAsync(request, CancellationToken);

		// Assert
		response.ShouldBeBadRequest();
	}

	[Theory]
	[UserNameNullWithMessageData]
	[UserNameEmptyWithMessageData]
	[UserNameTooShortWithMessageData]
	[UserNameTooLongWithMessageData]
	public async Task UpdateCurrentAsync_ShouldHaveBadRequestProblemDetails_WhenNameIsInvalid(
		IStringTransformer transformer,
		IStringMessageTransformer messageTransformer)
	{
		// Arrange
		var request = _requestBuilder.WithName(transformer).Build();

		// Act
		var response = await ApiClient.UpdateCurrentProblemDetailsAsync(request, CancellationToken);

		// Assert
		response.ShouldSatisfyInvalidValidationForName(request, messageTransformer);
	}

	[Theory]
	[UserFirstNameNullData]
	[UserFirstNameEmptyData]
	[UserFirstNameTooShortData]
	[UserFirstNameTooLongData]
	public async Task UpdateCurrentAsync_ShouldHaveBadRequestStatusCode_WhenFirstNameIsInvalid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithFirstName(transformer).Build();

		// Act
		var response = await ApiClient.UpdateCurrentStatusCodeAsync(request, CancellationToken);

		// Assert
		response.ShouldBeBadRequest();
	}

	[Theory]
	[UserFirstNameNullWithMessageData]
	[UserFirstNameEmptyWithMessageData]
	[UserFirstNameTooShortWithMessageData]
	[UserFirstNameTooLongWithMessageData]
	public async Task UpdateCurrentAsync_ShouldHaveBadRequestProblemDetails_WhenFirstNameIsInvalid(
		IStringTransformer transformer,
		IStringMessageTransformer messageTransformer)
	{
		// Arrange
		var request = _requestBuilder.WithFirstName(transformer).Build();

		// Act
		var response = await ApiClient.UpdateCurrentProblemDetailsAsync(request, CancellationToken);

		// Assert
		response.ShouldSatisfyInvalidValidationForFirstName(request, messageTransformer);
	}

	[Theory]
	[UserLastNameNullData]
	[UserLastNameEmptyData]
	[UserLastNameTooShortData]
	[UserLastNameTooLongData]
	public async Task UpdateCurrentAsync_ShouldHaveBadRequestStatusCode_WhenLastNameIsInvalid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithLastName(transformer).Build();

		// Act
		var response = await ApiClient.UpdateCurrentStatusCodeAsync(request, CancellationToken);

		// Assert
		response.ShouldBeBadRequest();
	}

	[Theory]
	[UserLastNameNullWithMessageData]
	[UserLastNameEmptyWithMessageData]
	[UserLastNameTooShortWithMessageData]
	[UserLastNameTooLongWithMessageData]
	public async Task UpdateCurrentAsync_ShouldHaveBadRequestProblemDetails_WhenLastNameIsInvalid(
		IStringTransformer transformer,
		IStringMessageTransformer messageTransformer)
	{
		// Arrange
		var request = _requestBuilder.WithLastName(transformer).Build();

		// Act
		var response = await ApiClient.UpdateCurrentProblemDetailsAsync(request, CancellationToken);

		// Assert
		response.ShouldSatisfyInvalidValidationForLastName(request, messageTransformer);
	}

	[Theory]
	[UserEmailNullData]
	[UserEmailEmptyData]
	[UserEmailTooShortData]
	[UserEmailTooLongData]
	[UserEmailInvalidData]
	public async Task UpdateCurrentAsync_ShouldHaveBadRequestStatusCode_WhenEmailIsInvalid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithEmail(transformer).Build();

		// Act
		var response = await ApiClient.UpdateCurrentStatusCodeAsync(request, CancellationToken);

		// Assert
		response.ShouldBeBadRequest();
	}

	[Theory]
	[UserEmailNullWithMessageData]
	[UserEmailEmptyWithMessageData]
	[UserEmailTooShortWithMessageData]
	[UserEmailTooLongWithMessageData]
	[UserEmailInvalidWithMessageData]
	public async Task UpdateCurrentAsync_ShouldHaveBadRequestProblemDetails_WhenEmailIsInvalid(
		IStringTransformer transformer,
		IStringMessageTransformer messageTransformer)
	{
		// Arrange
		var request = _requestBuilder.WithEmail(transformer).Build();

		// Act
		var response = await ApiClient.UpdateCurrentProblemDetailsAsync(request, CancellationToken);

		// Assert
		response.ShouldSatisfyInvalidValidationForEmail(request, messageTransformer);
	}

	[Theory]
	[UserProfileImageTooLargeData]
	[UserProfileImageInvalidContentTypeData]
	public async Task UpdateCurrentAsync_ShouldHaveBadRequestStatusCode_WhenProfileImageIsInvalid(
		IFormFileTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithProfileImage(transformer).Build();

		// Act
		var response = await ApiClient.UpdateCurrentStatusCodeAsync(request, CancellationToken);

		// Assert
		response.ShouldBeBadRequest();
	}

	[Theory]
	[UserProfileImageTooLargeWithMessageData]
	[UserProfileImageInvalidContentTypeWithMessageData]
	public async Task UpdateCurrentAsync_ShouldHaveBadRequestProblemDetails_WhenProfileImageIsInvalid(
		IFormFileTransformer transformer, IFormFileMessageTransformer messageTransformer)
	{
		// Arrange
		var request = _requestBuilder.WithProfileImage(transformer).Build();

		// Act
		var response = await ApiClient.UpdateCurrentProblemDetailsAsync(request, CancellationToken);

		// Assert
		response.ShouldSatisfyInvalidValidationForProfileImage(request, messageTransformer);
	}

	[Fact]
	public async Task UpdateCurrentAsync_ShouldHaveNotFoundStatusCode_WhenUserNotFound()
	{
		// Arrange
		await ServiceScope.DeleteAsync(User, CancellationToken);

		// Act
		var response = await ApiClient.UpdateCurrentStatusCodeAsync(_request, CancellationToken);

		// Assert
		response.ShouldBeNotFound();
	}

	[Fact]
	public async Task UpdateCurrentAsync_ShouldHaveUserNotFoundProblemDetails_WhenUserNotFound()
	{
		// Arrange
		await ServiceScope.DeleteAsync(User, CancellationToken);

		// Act
		var response = await ApiClient.UpdateCurrentProblemDetailsAsync(_request, CancellationToken);

		// Assert
		response.ShouldSatisfyUserNotFound(_request);
	}

	[Fact]
	public async Task UpdateCurrentAsync_ShouldHaveBadRequestStatusCode_WhenUserEmailAlreadyTaken()
	{
		// Arrange
		var user = UserBuilderFactory.Create(User.PasswordHash).Build();
		await ServiceScope.AddAsync(user, CancellationToken);
		var request = _requestBuilder.WithEmail(user.Email).Build();

		// Act
		var response = await ApiClient.UpdateCurrentStatusCodeAsync(request, CancellationToken);

		// Assert
		response.ShouldBeBadRequest();
	}

	[Theory]
	[UserEmailDifferentCaseData]
	public async Task UpdateCurrentAsync_ShouldHaveBadRequestStatusCode_WhenUserEmailAlreadyTakenAndEmailIsInvalid(
		IStringTransformer transformer)
	{
		// Arrange
		var user = UserBuilderFactory.Create(User.PasswordHash).Build();
		await ServiceScope.AddAsync(user, CancellationToken);
		var request = _requestBuilder.WithEmail(user.Email, transformer).Build();

		// Act
		var response = await ApiClient.UpdateCurrentStatusCodeAsync(request, CancellationToken);

		// Assert
		response.ShouldBeBadRequest();
	}

	[Fact]
	public async Task UpdateCurrentAsync_ShouldHaveUserEmailAlreadyTakenProblemDetails_WhenUserEmailAlreadyTaken()
	{
		// Arrange
		var user = UserBuilderFactory.Create(User.PasswordHash).Build();
		await ServiceScope.AddAsync(user, CancellationToken);
		var request = _requestBuilder.WithEmail(user.Email).Build();

		// Act
		var response = await ApiClient.UpdateCurrentProblemDetailsAsync(request, CancellationToken);

		// Assert
		response.ShouldSatisfyUserEmailAlreadyTaken(request);
	}

	[Theory]
	[UserEmailDifferentCaseData]
	public async Task UpdateCurrentAsync_ShouldHaveUserEmailAlreadyTakenProblemDetails_WhenUserEmailAlreadyTakenAndEmailIsInvalid(
		IStringTransformer transformer)
	{
		// Arrange
		var user = UserBuilderFactory.Create(User.PasswordHash).Build();
		await ServiceScope.AddAsync(user, CancellationToken);
		var request = _requestBuilder.WithEmail(user.Email, transformer).Build();

		// Act
		var response = await ApiClient.UpdateCurrentProblemDetailsAsync(request, CancellationToken);

		// Assert
		response.ShouldSatisfyUserEmailAlreadyTaken(request);
	}

	[Fact]
	public async Task UpdateCurrentAsync_ShouldHaveBadRequestStatusCode_WhenUserNameAlreadyTaken()
	{
		// Arrange
		var user = UserBuilderFactory.Create(User.PasswordHash).Build();
		await ServiceScope.AddAsync(user, CancellationToken);
		var request = _requestBuilder.WithName(user.Name).Build();

		// Act
		var response = await ApiClient.UpdateCurrentStatusCodeAsync(request, CancellationToken);

		// Assert
		response.ShouldBeBadRequest();
	}

	[Theory]
	[UserNameDifferentCaseData]
	public async Task UpdateCurrentAsync_ShouldHaveBadRequestStatusCode_WhenUserNameAlreadyTakenAndNameIsInvalid(
		IStringTransformer transformer)
	{
		// Arrange
		var user = UserBuilderFactory.Create(User.PasswordHash).Build();
		await ServiceScope.AddAsync(user, CancellationToken);
		var request = _requestBuilder.WithName(user.Name, transformer).Build();

		// Act
		var response = await ApiClient.UpdateCurrentStatusCodeAsync(request, CancellationToken);

		// Assert
		response.ShouldBeBadRequest();
	}

	[Fact]
	public async Task UpdateCurrentAsync_ShouldHaveUserNameAlreadyTakenProblemDetails_WhenUserNameAlreadyTaken()
	{
		// Arrange
		var user = UserBuilderFactory.Create(User.PasswordHash).Build();
		await ServiceScope.AddAsync(user, CancellationToken);
		var request = _requestBuilder.WithName(user.Name).Build();

		// Act
		var response = await ApiClient.UpdateCurrentProblemDetailsAsync(request, CancellationToken);

		// Assert
		response.ShouldSatisfyUserNameAlreadyTaken(request);
	}

	[Theory]
	[UserNameDifferentCaseData]
	public async Task UpdateCurrentAsync_ShouldHaveUserNameAlreadyTakenProblemDetails_WhenUserNameAlreadyTakenAndNameIsInvalid(
		IStringTransformer transformer)
	{
		// Arrange
		var user = UserBuilderFactory.Create(User.PasswordHash).Build();
		await ServiceScope.AddAsync(user, CancellationToken);
		var request = _requestBuilder.WithName(user.Name, transformer).Build();

		// Act
		var response = await ApiClient.UpdateCurrentProblemDetailsAsync(request, CancellationToken);

		// Assert
		response.ShouldSatisfyUserNameAlreadyTaken(request);
	}

	[Fact]
	public async Task UpdateCurrentAsync_ShouldHaveOkStatusCode_WhenRequestIsValid()
	{
		// Act
		var response = await ApiClient.UpdateCurrentStatusCodeAsync(_request, CancellationToken);

		// Assert
		response.ShouldBeOk();
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task UpdateCurrentAsync_ShouldHaveOkStatusCode_WhenRequestAndIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithId(transformer).Build();

		// Act
		var response = await ApiClient.UpdateCurrentStatusCodeAsync(request, CancellationToken);

		// Assert
		response.ShouldBeOk();
	}

	[Theory]
	[UserNameDifferentCaseData]
	public async Task UpdateCurrentAsync_ShouldHaveOkStatusCode_WhenRequestAndNameAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithName(transformer).Build();

		// Act
		var response = await ApiClient.UpdateCurrentStatusCodeAsync(request, CancellationToken);

		// Assert
		response.ShouldBeOk();
	}

	[Fact]
	public async Task UpdateCurrentAsync_ShouldHaveOkStatusCode_WhenRequestAndNameHasNotChanged()
	{
		// Arrange
		var request = _requestBuilder.WithName(User.Name).Build();

		// Act
		var response = await ApiClient.UpdateCurrentStatusCodeAsync(request, CancellationToken);

		// Assert
		response.ShouldBeOk();
	}

	[Theory]
	[UserNameDifferentCaseData]
	public async Task UpdateCurrentAsync_ShouldHaveOkStatusCode_WhenRequestAndNameIsValidAndHasNotChanged(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithName(User.Name, transformer).Build();

		// Act
		var response = await ApiClient.UpdateCurrentStatusCodeAsync(request, CancellationToken);

		// Assert
		response.ShouldBeOk();
	}

	[Theory]
	[UserEmailDifferentCaseData]
	public async Task UpdateCurrentAsync_ShouldHaveOkStatusCode_WhenRequestAndEmailAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithEmail(transformer).Build();

		// Act
		var response = await ApiClient.UpdateCurrentStatusCodeAsync(request, CancellationToken);

		// Assert
		response.ShouldBeOk();
	}

	[Fact]
	public async Task UpdateCurrentAsync_ShouldHaveOkStatusCode_WhenRequestAndEmailHasNotChanged()
	{
		// Arrange
		var request = _requestBuilder.WithEmail(User.Email).Build();

		// Act
		var response = await ApiClient.UpdateCurrentStatusCodeAsync(request, CancellationToken);

		// Assert
		response.ShouldBeOk();
	}

	[Theory]
	[UserEmailDifferentCaseData]
	public async Task UpdateCurrentAsync_ShouldHaveOkStatusCode_WhenRequestAndEmailIsValidAndHasNotChanged(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithEmail(User.Email, transformer).Build();

		// Act
		var response = await ApiClient.UpdateCurrentStatusCodeAsync(request, CancellationToken);

		// Assert
		response.ShouldBeOk();
	}

	[Theory]
	[UserProfileImageNullData]
	[UserProfileImageJpegData]
	[UserProfileImagePngData]
	[UserProfileImageWebpData]
	[UserProfileImageJpegDifferentCaseData]
	[UserProfileImagePngDifferentCaseData]
	[UserProfileImageWebpDifferentCaseData]
	public async Task UpdateCurrentAsync_ShouldHaveOkStatusCode_WhenRequestAndProfileImageAreValid(
		IFormFileTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithProfileImage(transformer).Build();

		// Act
		var response = await ApiClient.UpdateCurrentStatusCodeAsync(request, CancellationToken);

		// Assert
		response.ShouldBeOk();
	}

	[Fact]
	public async Task UpdateCurrentAsync_ShouldReturnResponse_WhenRequestIsValid()
	{
		// Act
		var response = await ApiClient.UpdateCurrentAsync(_request, CancellationToken);
		var user = await ServiceScope.GetByIdAsync(response, CancellationToken);

		// Assert
		response.ShouldSatisfy(_request, user);
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task UpdateCurrentAsync_ShouldReturnResponse_WhenRequestAndIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithId(transformer).Build();

		// Act
		var response = await ApiClient.UpdateCurrentAsync(request, CancellationToken);
		var user = await ServiceScope.GetByIdAsync(response, CancellationToken);

		// Assert
		response.ShouldSatisfy(request, user);
	}

	[Theory]
	[UserNameDifferentCaseData]
	public async Task UpdateCurrentAsync_ShouldReturnResponse_WhenRequestAndNameAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithName(transformer).Build();

		// Act
		var response = await ApiClient.UpdateCurrentAsync(request, CancellationToken);
		var user = await ServiceScope.GetByIdAsync(response, CancellationToken);

		// Assert
		response.ShouldSatisfy(request, user);
	}

	[Fact]
	public async Task UpdateCurrentAsync_ShouldReturnResponse_WhenNameHasNotChanged()
	{
		// Arrange
		var request = _requestBuilder.WithName(User.Name).Build();

		// Act
		var response = await ApiClient.UpdateCurrentAsync(request, CancellationToken);
		var user = await ServiceScope.GetByIdAsync(response, CancellationToken);

		// Assert
		response.ShouldSatisfy(request, user);
	}

	[Theory]
	[UserNameDifferentCaseData]
	public async Task UpdateCurrentAsync_ShouldReturnResponse_WhenNameIsValidAndHasNotChanged(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithName(User.Name, transformer).Build();

		// Act
		var response = await ApiClient.UpdateCurrentAsync(request, CancellationToken);
		var user = await ServiceScope.GetByIdAsync(response, CancellationToken);

		// Assert
		response.ShouldSatisfy(request, user);
	}

	[Theory]
	[UserEmailDifferentCaseData]
	public async Task UpdateCurrentAsync_ShouldReturnResponse_WhenRequestAndEmailAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithEmail(transformer).Build();

		// Act
		var response = await ApiClient.UpdateCurrentAsync(request, CancellationToken);
		var user = await ServiceScope.GetByIdAsync(response, CancellationToken);

		// Assert
		response.ShouldSatisfy(request, user);
	}

	[Fact]
	public async Task UpdateCurrentAsync_ShouldReturnResponse_WhenEmailHasNotChanged()
	{
		// Arrange
		var request = _requestBuilder.WithEmail(User.Email).Build();

		// Act
		var response = await ApiClient.UpdateCurrentAsync(request, CancellationToken);
		var user = await ServiceScope.GetByIdAsync(response, CancellationToken);

		// Assert
		response.ShouldSatisfy(request, user);
	}

	[Theory]
	[UserEmailDifferentCaseData]
	public async Task UpdateCurrentAsync_ShouldReturnResponse_WhenEmailIsValidAndHasNotChanged(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithEmail(User.Email, transformer).Build();

		// Act
		var response = await ApiClient.UpdateCurrentAsync(request, CancellationToken);
		var user = await ServiceScope.GetByIdAsync(response, CancellationToken);

		// Assert
		response.ShouldSatisfy(request, user);
	}

	[Theory]
	[UserProfileImageNullData]
	[UserProfileImageJpegData]
	[UserProfileImagePngData]
	[UserProfileImageWebpData]
	[UserProfileImageJpegDifferentCaseData]
	[UserProfileImagePngDifferentCaseData]
	[UserProfileImageWebpDifferentCaseData]
	public async Task UpdateCurrentAsync_ShouldReturnResponse_WhenRequestAndProfileImageAreValid(
		IFormFileTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithProfileImage(transformer).Build();

		// Act
		var response = await ApiClient.UpdateCurrentAsync(request, CancellationToken);
		var user = await ServiceScope.GetByIdAsync(response, CancellationToken);

		// Assert
		response.ShouldSatisfy(request, user);
	}

	[Fact]
	public async Task UpdateCurrentAsync_ShouldUpdateUser_WhenRequestIsValid()
	{
		// Act
		var response = await ApiClient.UpdateCurrentAsync(_request, CancellationToken);
		var user = await ServiceScope.GetByIdAsync(response, CancellationToken);

		// Assert
		user.ShouldSatisfy(_request);
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task UpdateCurrentAsync_ShouldUpdateUser_WhenRequestAndIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithId(transformer).Build();

		// Act
		var response = await ApiClient.UpdateCurrentAsync(request, CancellationToken);
		var user = await ServiceScope.GetByIdAsync(response, CancellationToken);

		// Assert
		user.ShouldSatisfy(request);
	}

	[Theory]
	[UserNameDifferentCaseData]
	public async Task UpdateCurrentAsync_ShouldUpdateUser_WhenRequestAndNameAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithName(transformer).Build();

		// Act
		var response = await ApiClient.UpdateCurrentAsync(request, CancellationToken);
		var user = await ServiceScope.GetByIdAsync(response, CancellationToken);

		// Assert
		user.ShouldSatisfy(request);
	}

	[Fact]
	public async Task UpdateCurrentAsync_ShouldUpdateUser_WhenNameHasNotChanged()
	{
		// Arrange
		var request = _requestBuilder.WithName(User.Name).Build();

		// Act
		var response = await ApiClient.UpdateCurrentAsync(request, CancellationToken);
		var user = await ServiceScope.GetByIdAsync(response, CancellationToken);

		// Assert
		user.ShouldSatisfy(request);
	}

	[Theory]
	[UserNameDifferentCaseData]
	public async Task UpdateCurrentAsync_ShouldUpdateUser_WhenNameIsValidAndHasNotChanged(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithName(User.Name, transformer).Build();

		// Act
		var response = await ApiClient.UpdateCurrentAsync(request, CancellationToken);
		var user = await ServiceScope.GetByIdAsync(response, CancellationToken);

		// Assert
		user.ShouldSatisfy(request);
	}

	[Theory]
	[UserEmailDifferentCaseData]
	public async Task UpdateCurrentAsync_ShouldUpdateUser_WhenRequestAndEmailAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithEmail(transformer).Build();

		// Act
		var response = await ApiClient.UpdateCurrentAsync(request, CancellationToken);
		var user = await ServiceScope.GetByIdAsync(response, CancellationToken);

		// Assert
		user.ShouldSatisfy(request);
	}

	[Fact]
	public async Task UpdateCurrentAsync_ShouldUpdateUser_WhenEmailHasNotChanged()
	{
		// Arrange
		var request = _requestBuilder.WithEmail(User.Email).Build();

		// Act
		var response = await ApiClient.UpdateCurrentAsync(request, CancellationToken);
		var user = await ServiceScope.GetByIdAsync(response, CancellationToken);

		// Assert
		user.ShouldSatisfy(request);
	}

	[Theory]
	[UserEmailDifferentCaseData]
	public async Task UpdateCurrentAsync_ShouldUpdateUser_WhenEmailIsValidAndHasNotChanged(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithEmail(User.Email, transformer).Build();

		// Act
		var response = await ApiClient.UpdateCurrentAsync(request, CancellationToken);
		var user = await ServiceScope.GetByIdAsync(response, CancellationToken);

		// Assert
		user.ShouldSatisfy(request);
	}

	[Theory]
	[UserProfileImageNullData]
	[UserProfileImageJpegData]
	[UserProfileImagePngData]
	[UserProfileImageWebpData]
	[UserProfileImageJpegDifferentCaseData]
	[UserProfileImagePngDifferentCaseData]
	[UserProfileImageWebpDifferentCaseData]
	public async Task UpdateCurrentAsync_ShouldUpdateUser_WhenRequestAndProfileImageAreValid(
		IFormFileTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithProfileImage(transformer).Build();

		// Act
		var response = await ApiClient.UpdateCurrentAsync(request, CancellationToken);
		var user = await ServiceScope.GetByIdAsync(response, CancellationToken);

		// Assert
		user.ShouldSatisfy(request);
	}

	[Fact]
	public async Task UpdateCurrentAsync_ShouldPublishUserUpdatedEvent_WhenRequestIsValid()
	{
		// Act
		var response = await ApiClient.UpdateCurrentAsync(_request, CancellationToken);
		var user = await ServiceScope.GetByIdAsync(response, CancellationToken);
		var eventRequest = await EventClient.PublishedUpdatedAsync(CancellationToken);

		// Assert
		eventRequest.ShouldSatisfy(_request, user);
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task UpdateCurrentAsync_ShouldPublishUserUpdatedEvent_WhenRequestAndIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithId(transformer).Build();

		// Act
		var response = await ApiClient.UpdateCurrentAsync(request, CancellationToken);
		var user = await ServiceScope.GetByIdAsync(response, CancellationToken);
		var eventRequest = await EventClient.PublishedUpdatedAsync(CancellationToken);

		// Assert
		eventRequest.ShouldSatisfy(request, user);
	}

	[Theory]
	[UserNameDifferentCaseData]
	public async Task UpdateCurrentAsync_ShouldPublishUserUpdatedEvent_WhenRequestAndNameAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithName(transformer).Build();

		// Act
		var response = await ApiClient.UpdateCurrentAsync(request, CancellationToken);
		var user = await ServiceScope.GetByIdAsync(response, CancellationToken);
		var eventRequest = await EventClient.PublishedUpdatedAsync(CancellationToken);

		// Assert
		eventRequest.ShouldSatisfy(request, user);
	}

	[Fact]
	public async Task UpdateCurrentAsync_ShouldPublishUserUpdatedEvent_WhenNameHasNotChanged()
	{
		// Arrange
		var request = _requestBuilder.WithName(User.Name).Build();

		// Act
		var response = await ApiClient.UpdateCurrentAsync(request, CancellationToken);
		var user = await ServiceScope.GetByIdAsync(response, CancellationToken);
		var eventRequest = await EventClient.PublishedUpdatedAsync(CancellationToken);

		// Assert
		eventRequest.ShouldSatisfy(request, user);
	}

	[Theory]
	[UserNameDifferentCaseData]
	public async Task UpdateCurrentAsync_ShouldPublishUserUpdatedEvent_WhenNameIsValidAndHasNotChanged(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithName(User.Name, transformer).Build();

		// Act
		var response = await ApiClient.UpdateCurrentAsync(request, CancellationToken);
		var user = await ServiceScope.GetByIdAsync(response, CancellationToken);
		var eventRequest = await EventClient.PublishedUpdatedAsync(CancellationToken);

		// Assert
		eventRequest.ShouldSatisfy(request, user);
	}

	[Theory]
	[UserEmailDifferentCaseData]
	public async Task UpdateCurrentAsync_ShouldPublishUserUpdatedEvent_WhenRequestAndEmailAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithEmail(transformer).Build();

		// Act
		var response = await ApiClient.UpdateCurrentAsync(request, CancellationToken);
		var user = await ServiceScope.GetByIdAsync(response, CancellationToken);
		var eventRequest = await EventClient.PublishedUpdatedAsync(CancellationToken);

		// Assert
		eventRequest.ShouldSatisfy(request, user);
	}

	[Fact]
	public async Task UpdateCurrentAsync_ShouldPublishUserUpdatedEvent_WhenEmailHasNotChanged()
	{
		// Arrange
		var request = _requestBuilder.WithEmail(User.Email).Build();

		// Act
		var response = await ApiClient.UpdateCurrentAsync(request, CancellationToken);
		var user = await ServiceScope.GetByIdAsync(response, CancellationToken);
		var eventRequest = await EventClient.PublishedUpdatedAsync(CancellationToken);

		// Assert
		eventRequest.ShouldSatisfy(request, user);
	}

	[Theory]
	[UserEmailDifferentCaseData]
	public async Task UpdateCurrentAsync_ShouldPublishUserUpdatedEvent_WhenEmailIsValidAndHasNotChanged(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithEmail(User.Email, transformer).Build();

		// Act
		var response = await ApiClient.UpdateCurrentAsync(request, CancellationToken);
		var user = await ServiceScope.GetByIdAsync(response, CancellationToken);
		var eventRequest = await EventClient.PublishedUpdatedAsync(CancellationToken);

		// Assert
		eventRequest.ShouldSatisfy(request, user);
	}

	[Theory]
	[UserProfileImageNullData]
	[UserProfileImageJpegData]
	[UserProfileImagePngData]
	[UserProfileImageWebpData]
	[UserProfileImageJpegDifferentCaseData]
	[UserProfileImagePngDifferentCaseData]
	[UserProfileImageWebpDifferentCaseData]
	public async Task UpdateCurrentAsync_ShouldPublishUserUpdatedEvent_WhenRequestAndProfileImageAreValid(
		IFormFileTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithProfileImage(transformer).Build();

		// Act
		var response = await ApiClient.UpdateCurrentAsync(request, CancellationToken);
		var user = await ServiceScope.GetByIdAsync(response, CancellationToken);
		var eventRequest = await EventClient.PublishedUpdatedAsync(CancellationToken);

		// Assert
		eventRequest.ShouldSatisfy(request, user);
	}

	[Fact]
	public async Task UpdateCurrentAsync_ShouldDeleteEmailConfirmationTokens_WhenRequestIsValid()
	{
		// Act
		var response = await ApiClient.UpdateCurrentAsync(_request, CancellationToken);
		var user = await ServiceScope.GetByIdAsync(response, CancellationToken);

		// Assert
		user.EmailConfirmationTokens.ShouldBeEmpty();
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task UpdateCurrentAsync_ShouldDeleteEmailConfirmationTokens_WhenRequestAndIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithId(transformer).Build();

		// Act
		var response = await ApiClient.UpdateCurrentAsync(request, CancellationToken);
		var user = await ServiceScope.GetByIdAsync(response, CancellationToken);

		// Assert
		user.EmailConfirmationTokens.ShouldBeEmpty();
	}

	[Theory]
	[UserNameDifferentCaseData]
	public async Task UpdateCurrentAsync_ShouldDeleteEmailConfirmationTokens_WhenRequestAndNameAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithName(transformer).Build();

		// Act
		var response = await ApiClient.UpdateCurrentAsync(request, CancellationToken);
		var user = await ServiceScope.GetByIdAsync(response, CancellationToken);

		// Assert
		user.EmailConfirmationTokens.ShouldBeEmpty();
	}

	[Fact]
	public async Task UpdateCurrentAsync_ShouldDeleteEmailConfirmationTokens_WhenNameHasNotChanged()
	{
		// Arrange
		var request = _requestBuilder.WithName(User.Name).Build();

		// Act
		var response = await ApiClient.UpdateCurrentAsync(request, CancellationToken);
		var user = await ServiceScope.GetByIdAsync(response, CancellationToken);

		// Assert
		user.EmailConfirmationTokens.ShouldBeEmpty();
	}

	[Theory]
	[UserNameDifferentCaseData]
	public async Task UpdateCurrentAsync_ShouldDeleteEmailConfirmationTokens_WhenNameIsValidAndHasNotChanged(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithName(User.Name, transformer).Build();

		// Act
		var response = await ApiClient.UpdateCurrentAsync(request, CancellationToken);
		var user = await ServiceScope.GetByIdAsync(response, CancellationToken);

		// Assert
		user.EmailConfirmationTokens.ShouldBeEmpty();
	}

	[Fact]
	public async Task UpdateCurrentAsync_ShouldNotDeleteEmailConfirmationTokens_WhenEmailHasNotChanged()
	{
		// Arrange
		var request = _requestBuilder.WithEmail(User.Email).Build();

		// Act
		var response = await ApiClient.UpdateCurrentAsync(request, CancellationToken);
		var user = await ServiceScope.GetByIdAsync(response, CancellationToken);

		// Assert
		user.EmailConfirmationTokens.ShouldSatisfy(request);
	}

	[Theory]
	[UserEmailDifferentCaseData]
	public async Task UpdateCurrentAsync_ShouldNotDeleteEmailConfirmationTokens_WhenEmailIsValidAndHasNotChanged(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithEmail(User.Email, transformer).Build();

		// Act
		var response = await ApiClient.UpdateCurrentAsync(request, CancellationToken);
		var user = await ServiceScope.GetByIdAsync(response, CancellationToken);

		// Assert
		user.EmailConfirmationTokens.ShouldSatisfy(request);
	}

	[Theory]
	[UserEmailDifferentCaseData]
	public async Task UpdateCurrentAsync_ShouldDeleteEmailConfirmationTokens_WhenRequestAndEmailAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithEmail(transformer).Build();

		// Act
		var response = await ApiClient.UpdateCurrentAsync(request, CancellationToken);
		var user = await ServiceScope.GetByIdAsync(response, CancellationToken);

		// Assert
		user.EmailConfirmationTokens.ShouldBeEmpty();
	}

	[Theory]
	[UserProfileImageNullData]
	[UserProfileImageJpegData]
	[UserProfileImagePngData]
	[UserProfileImageWebpData]
	[UserProfileImageJpegDifferentCaseData]
	[UserProfileImagePngDifferentCaseData]
	[UserProfileImageWebpDifferentCaseData]
	public async Task UpdateCurrentAsync_ShouldDeleteEmailConfirmationTokens_WhenRequestAndProfileImageAreValid(
		IFormFileTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithProfileImage(transformer).Build();

		// Act
		var response = await ApiClient.UpdateCurrentAsync(request, CancellationToken);
		var user = await ServiceScope.GetByIdAsync(response, CancellationToken);

		// Assert
		user.EmailConfirmationTokens.ShouldBeEmpty();
	}

	[Fact]
	public async Task UpdateCurrentAsync_ShouldPublishEmailConfirmationTokenDeletedEvents_WhenRequestIsValid()
	{
		// Act
		var response = await ApiClient.UpdateCurrentAsync(_request, CancellationToken);
		var user = await ServiceScope.GetByIdAsync(response, CancellationToken);
		var eventRequests = await EmailConfirmationTokenEventClient.PublishedDeletedRangeAsync(CancellationToken);

		// Assert
		eventRequests.ShouldSatisfy(_request, User.EmailConfirmationTokens.AddUser(user));
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task UpdateCurrentAsync_ShouldPublishEmailConfirmationTokenDeletedEvents_WhenRequestAndIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithId(transformer).Build();

		// Act
		var response = await ApiClient.UpdateCurrentAsync(request, CancellationToken);
		var user = await ServiceScope.GetByIdAsync(response, CancellationToken);
		var eventRequests = await EmailConfirmationTokenEventClient.PublishedDeletedRangeAsync(CancellationToken);

		// Assert
		eventRequests.ShouldSatisfy(request, User.EmailConfirmationTokens.AddUser(user));
	}

	[Theory]
	[UserNameDifferentCaseData]
	public async Task UpdateCurrentAsync_ShouldPublishEmailConfirmationTokenDeletedEvents_WhenRequestAndNameAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithName(transformer).Build();

		// Act
		var response = await ApiClient.UpdateCurrentAsync(request, CancellationToken);
		var user = await ServiceScope.GetByIdAsync(response, CancellationToken);
		var eventRequests = await EmailConfirmationTokenEventClient.PublishedDeletedRangeAsync(CancellationToken);

		// Assert
		eventRequests.ShouldSatisfy(request, User.EmailConfirmationTokens.AddUser(user));
	}

	[Fact]
	public async Task UpdateCurrentAsync_ShouldPublishEmailConfirmationTokenDeletedEvents_WhenNameHasNotChanged()
	{
		// Arrange
		var request = _requestBuilder.WithName(User.Name).Build();

		// Act
		var response = await ApiClient.UpdateCurrentAsync(request, CancellationToken);
		var user = await ServiceScope.GetByIdAsync(response, CancellationToken);
		var eventRequests = await EmailConfirmationTokenEventClient.PublishedDeletedRangeAsync(CancellationToken);

		// Assert
		eventRequests.ShouldSatisfy(request, User.EmailConfirmationTokens.AddUser(user));
	}

	[Theory]
	[UserNameDifferentCaseData]
	public async Task UpdateCurrentAsync_ShouldPublishEmailConfirmationTokenDeletedEvents_WhenNameIsValidAndHasNotChanged(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithName(User.Name, transformer).Build();

		// Act
		var response = await ApiClient.UpdateCurrentAsync(request, CancellationToken);
		var user = await ServiceScope.GetByIdAsync(response, CancellationToken);
		var eventRequests = await EmailConfirmationTokenEventClient.PublishedDeletedRangeAsync(CancellationToken);

		// Assert
		eventRequests.ShouldSatisfy(request, User.EmailConfirmationTokens.AddUser(user));
	}

	[Fact]
	public async Task UpdateCurrentAsync_ShouldNotPublishEmailConfirmationTokenDeletedEvents_WhenEmailHasNotChanged()
	{
		// Arrange
		var request = _requestBuilder.WithEmail(User.Email).Build();

		// Act
		await ApiClient.UpdateCurrentAsync(request, CancellationToken);
		var eventRequests = await EmailConfirmationTokenEventClient.PublishedDeletedRangeAsync(CancellationToken);

		// Assert
		eventRequests.ShouldBeEmpty();
	}

	[Theory]
	[UserEmailDifferentCaseData]
	public async Task UpdateCurrentAsync_ShouldNotPublishEmailConfirmationTokenDeletedEvents_WhenEmailIsValidAndHasNotChanged(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithEmail(User.Email, transformer).Build();

		// Act
		await ApiClient.UpdateCurrentAsync(request, CancellationToken);
		var eventRequests = await EmailConfirmationTokenEventClient.PublishedDeletedRangeAsync(CancellationToken);

		// Assert
		eventRequests.ShouldBeEmpty();
	}

	[Theory]
	[UserEmailDifferentCaseData]
	public async Task UpdateCurrentAsync_ShouldPublishEmailConfirmationTokenDeletedEvents_WhenRequestAndEmailAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithEmail(transformer).Build();

		// Act
		var response = await ApiClient.UpdateCurrentAsync(request, CancellationToken);
		var user = await ServiceScope.GetByIdAsync(response, CancellationToken);
		var eventRequests = await EmailConfirmationTokenEventClient.PublishedDeletedRangeAsync(CancellationToken);

		// Assert
		eventRequests.ShouldSatisfy(request, User.EmailConfirmationTokens.AddUser(user));
	}

	[Theory]
	[UserProfileImageNullData]
	[UserProfileImageJpegData]
	[UserProfileImagePngData]
	[UserProfileImageWebpData]
	[UserProfileImageJpegDifferentCaseData]
	[UserProfileImagePngDifferentCaseData]
	[UserProfileImageWebpDifferentCaseData]
	public async Task UpdateCurrentAsync_ShouldPublishEmailConfirmationTokenDeletedEvents_WhenRequestAndProfileImageAreValid(
		IFormFileTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithProfileImage(transformer).Build();

		// Act
		var response = await ApiClient.UpdateCurrentAsync(request, CancellationToken);
		var user = await ServiceScope.GetByIdAsync(response, CancellationToken);
		var eventRequests = await EmailConfirmationTokenEventClient.PublishedDeletedRangeAsync(CancellationToken);

		// Assert
		eventRequests.ShouldSatisfy(request, User.EmailConfirmationTokens.AddUser(user));
	}
}
