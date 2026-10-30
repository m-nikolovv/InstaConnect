using InstaConnect.Common.Tests.Features.DataAttributes.FormFiles.Base;
using InstaConnect.Identity.Presentation.Features.Users.Models.Forms;
using InstaConnect.Identity.Tests.Features.Users.DataAttributes.ConfirmPassword;
using InstaConnect.Identity.Tests.Features.Users.DataAttributes.Email;
using InstaConnect.Identity.Tests.Features.Users.DataAttributes.FirstName;
using InstaConnect.Identity.Tests.Features.Users.DataAttributes.LastName;
using InstaConnect.Identity.Tests.Features.Users.DataAttributes.Password;
using InstaConnect.Identity.Tests.Features.Users.DataAttributes.ProfileImage;

namespace InstaConnect.Identity.Presentation.Tests.Functional.Features.Users.Endpoints;

public class AddUserFunctionalTests : BaseUserPresentationCommandFunctionalTest
{
	private const string PasswordPropertyName = nameof(AddUserApiForm.Password);

	private readonly AddUserApiRequestBuilderFactory _requestBuilderFactory;
	private readonly AddUserApiRequestBuilder _requestBuilder;
	private readonly AddUserApiRequest _request;

	public AddUserFunctionalTests(IdentityWebApplicationFactory webApplicationFactory)
		: base(webApplicationFactory)
	{
		_requestBuilderFactory = new();
		_requestBuilder = _requestBuilderFactory.Create();
		_request = _requestBuilder.Build();
	}

	[Theory]
	[UserNameNullData]
	[UserNameEmptyData]
	[UserNameTooShortData]
	[UserNameTooLongData]
	public async Task AddAsync_ShouldHaveBadRequestStatusCode_WhenNameIsInvalid(IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithName(transformer).Build();

		// Act
		var response = await ApiClient.AddStatusCodeAsync(request, CancellationToken);

		// Assert
		response.ShouldBeBadRequest();
	}

	[Theory]
	[UserNameNullWithMessageData]
	[UserNameEmptyWithMessageData]
	[UserNameTooShortWithMessageData]
	[UserNameTooLongWithMessageData]
	public async Task AddAsync_ShouldHaveBadRequestProblemDetails_WhenNameIsInvalid(
		IStringTransformer transformer,
		IStringMessageTransformer messageTransformer)
	{
		// Arrange
		var request = _requestBuilder.WithName(transformer).Build();

		// Act
		var response = await ApiClient.AddProblemDetailsAsync(request, CancellationToken);

		// Assert
		response.ShouldSatisfyInvalidValidationForName(request, messageTransformer);
	}

	[Theory]
	[UserFirstNameNullData]
	[UserFirstNameEmptyData]
	[UserFirstNameTooShortData]
	[UserFirstNameTooLongData]
	public async Task AddAsync_ShouldHaveBadRequestStatusCode_WhenFirstNameIsInvalid(IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithFirstName(transformer).Build();

		// Act
		var response = await ApiClient.AddStatusCodeAsync(request, CancellationToken);

		// Assert
		response.ShouldBeBadRequest();
	}

	[Theory]
	[UserFirstNameNullWithMessageData]
	[UserFirstNameEmptyWithMessageData]
	[UserFirstNameTooShortWithMessageData]
	[UserFirstNameTooLongWithMessageData]
	public async Task AddAsync_ShouldHaveBadRequestProblemDetails_WhenFirstNameIsInvalid(
		IStringTransformer transformer,
		IStringMessageTransformer messageTransformer)
	{
		// Arrange
		var request = _requestBuilder.WithFirstName(transformer).Build();

		// Act
		var response = await ApiClient.AddProblemDetailsAsync(request, CancellationToken);

		// Assert
		response.ShouldSatisfyInvalidValidationForFirstName(request, messageTransformer);
	}

	[Theory]
	[UserLastNameNullData]
	[UserLastNameEmptyData]
	[UserLastNameTooShortData]
	[UserLastNameTooLongData]
	public async Task AddAsync_ShouldHaveBadRequestStatusCode_WhenLastNameIsInvalid(IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithLastName(transformer).Build();

		// Act
		var response = await ApiClient.AddStatusCodeAsync(request, CancellationToken);

		// Assert
		response.ShouldBeBadRequest();
	}

	[Theory]
	[UserLastNameNullWithMessageData]
	[UserLastNameEmptyWithMessageData]
	[UserLastNameTooShortWithMessageData]
	[UserLastNameTooLongWithMessageData]
	public async Task AddAsync_ShouldHaveBadRequestProblemDetails_WhenLastNameIsInvalid(
		IStringTransformer transformer,
		IStringMessageTransformer messageTransformer)
	{
		// Arrange
		var request = _requestBuilder.WithLastName(transformer).Build();

		// Act
		var response = await ApiClient.AddProblemDetailsAsync(request, CancellationToken);

		// Assert
		response.ShouldSatisfyInvalidValidationForLastName(request, messageTransformer);
	}

	[Theory]
	[UserEmailNullData]
	[UserEmailEmptyData]
	[UserEmailTooShortData]
	[UserEmailTooLongData]
	[UserEmailInvalidData]
	public async Task AddAsync_ShouldHaveBadRequestStatusCode_WhenEmailIsInvalid(IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithEmail(transformer).Build();

		// Act
		var response = await ApiClient.AddStatusCodeAsync(request, CancellationToken);

		// Assert
		response.ShouldBeBadRequest();
	}

	[Theory]
	[UserEmailNullWithMessageData]
	[UserEmailEmptyWithMessageData]
	[UserEmailTooShortWithMessageData]
	[UserEmailTooLongWithMessageData]
	[UserEmailInvalidWithMessageData]
	public async Task AddAsync_ShouldHaveBadRequestProblemDetails_WhenEmailIsInvalid(
		IStringTransformer transformer,
		IStringMessageTransformer messageTransformer)
	{
		// Arrange
		var request = _requestBuilder.WithEmail(transformer).Build();

		// Act
		var response = await ApiClient.AddProblemDetailsAsync(request, CancellationToken);

		// Assert
		response.ShouldSatisfyInvalidValidationForEmail(request, messageTransformer);
	}

	[Theory]
	[UserPasswordNullData]
	[UserPasswordEmptyData]
	[UserPasswordTooShortData]
	[UserPasswordTooLongData]
	public async Task AddAsync_ShouldHaveBadRequestStatusCode_WhenPasswordIsInvalid(IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithPassword(transformer).Build();

		// Act
		var response = await ApiClient.AddStatusCodeAsync(request, CancellationToken);

		// Assert
		response.ShouldBeBadRequest();
	}

	[Theory]
	[UserPasswordNullWithMessageData]
	[UserPasswordEmptyWithMessageData]
	[UserPasswordTooShortWithMessageData]
	[UserPasswordTooLongWithMessageData]
	public async Task AddAsync_ShouldHaveBadRequestProblemDetails_WhenPasswordIsInvalid(
		IStringTransformer transformer,
		IStringMessageTransformer messageTransformer)
	{
		// Arrange
		var request = _requestBuilder.WithPassword(transformer).Build();

		// Act
		var response = await ApiClient.AddProblemDetailsAsync(request, CancellationToken);

		// Assert
		response.ShouldSatisfyInvalidValidationForPassword(request, messageTransformer);
	}

	[Theory]
	[UserConfirmPasswordNotEqualData]
	public async Task AddAsync_ShouldHaveBadRequestStatusCode_WhenConfirmPasswordIsInvalid(IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithConfirmPassword(transformer).Build();

		// Act
		var response = await ApiClient.AddStatusCodeAsync(request, CancellationToken);

		// Assert
		response.ShouldBeBadRequest();
	}

	[Theory]
	[UserConfirmPasswordNotEqualWithMessageData(PasswordPropertyName)]
	public async Task AddAsync_ShouldHaveBadRequestProblemDetails_WhenConfirmPasswordIsInvalid(
		IStringTransformer transformer,
		IStringMessageTransformer messageTransformer)
	{
		// Arrange
		var request = _requestBuilder.WithConfirmPassword(transformer).Build();

		// Act
		var response = await ApiClient.AddProblemDetailsAsync(request, CancellationToken);

		// Assert
		response.ShouldSatisfyInvalidValidationForConfirmPassword(request, messageTransformer);
	}

	[Theory]
	[UserProfileImageTooLargeData]
	[UserProfileImageInvalidContentTypeData]
	public async Task AddAsync_ShouldHaveBadRequestStatusCode_WhenProfileImageIsInvalid(
		IFormFileTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithProfileImage(transformer).Build();

		// Act
		var response = await ApiClient.AddStatusCodeAsync(request, CancellationToken);

		// Assert
		response.ShouldBeBadRequest();
	}

	[Theory]
	[UserProfileImageTooLargeWithMessageData]
	[UserProfileImageInvalidContentTypeWithMessageData]
	public async Task AddAsync_ShouldHaveBadRequestProblemDetails_WhenProfileImageIsInvalid(
		IFormFileTransformer transformer, IFormFileMessageTransformer messageTransformer)
	{
		// Arrange
		var request = _requestBuilder.WithProfileImage(transformer).Build();

		// Act
		var response = await ApiClient.AddProblemDetailsAsync(request, CancellationToken);

		// Assert
		response.ShouldSatisfyInvalidValidationForProfileImage(request, messageTransformer);
	}

	[Fact]
	public async Task AddAsync_ShouldHaveBadRequestStatusCode_WhenUserEmailAlreadyTaken()
	{
		// Arrange
		await ServiceScope.AddAsync(User, CancellationToken);
		var request = _requestBuilder.WithEmail(User.Email).Build();

		// Act
		var response = await ApiClient.AddStatusCodeAsync(request, CancellationToken);

		// Assert
		response.ShouldBeBadRequest();
	}

	[Theory]
	[UserEmailDifferentCaseData]
	public async Task AddAsync_ShouldHaveBadRequestStatusCode_WhenUserEmailAlreadyTakenAndEmailIsInvalid(
		IStringTransformer transformer)
	{
		// Arrange
		await ServiceScope.AddAsync(User, CancellationToken);
		var request = _requestBuilder.WithEmail(User.Email, transformer).Build();

		// Act
		var response = await ApiClient.AddStatusCodeAsync(request, CancellationToken);

		// Assert
		response.ShouldBeBadRequest();
	}

	[Fact]
	public async Task AddAsync_ShouldHaveUserEmailAlreadyTakenProblemDetails_WhenUserEmailAlreadyTaken()
	{
		// Arrange
		await ServiceScope.AddAsync(User, CancellationToken);
		var request = _requestBuilder.WithEmail(User.Email).Build();

		// Act
		var response = await ApiClient.AddProblemDetailsAsync(request, CancellationToken);

		// Assert
		response.ShouldSatisfyUserEmailAlreadyTaken(request);
	}

	[Theory]
	[UserEmailDifferentCaseData]
	public async Task AddAsync_ShouldHaveUserEmailAlreadyTakenProblemDetails_WhenUserEmailAlreadyTakenAndEmailIsInvalid(
		IStringTransformer transformer)
	{
		// Arrange
		await ServiceScope.AddAsync(User, CancellationToken);
		var request = _requestBuilder.WithEmail(User.Email, transformer).Build();

		// Act
		var response = await ApiClient.AddProblemDetailsAsync(request, CancellationToken);

		// Assert
		response.ShouldSatisfyUserEmailAlreadyTaken(request);
	}

	[Fact]
	public async Task AddAsync_ShouldHaveBadRequestStatusCode_WhenUserNameAlreadyTaken()
	{
		// Arrange
		await ServiceScope.AddAsync(User, CancellationToken);
		var request = _requestBuilder.WithName(User.Name).Build();

		// Act
		var response = await ApiClient.AddStatusCodeAsync(request, CancellationToken);

		// Assert
		response.ShouldBeBadRequest();
	}

	[Theory]
	[UserNameDifferentCaseData]
	public async Task AddAsync_ShouldHaveBadRequestStatusCode_WhenUserNameAlreadyTakenAndNameIsInvalid(
		IStringTransformer transformer)
	{
		// Arrange
		await ServiceScope.AddAsync(User, CancellationToken);
		var request = _requestBuilder.WithName(User.Name, transformer).Build();

		// Act
		var response = await ApiClient.AddStatusCodeAsync(request, CancellationToken);

		// Assert
		response.ShouldBeBadRequest();
	}

	[Fact]
	public async Task AddAsync_ShouldHaveUserNameAlreadyTakenProblemDetails_WhenUserNameAlreadyTaken()
	{
		// Arrange
		await ServiceScope.AddAsync(User, CancellationToken);
		var request = _requestBuilder.WithName(User.Name).Build();

		// Act
		var response = await ApiClient.AddProblemDetailsAsync(request, CancellationToken);

		// Assert
		response.ShouldSatisfyUserNameAlreadyTaken(request);
	}

	[Theory]
	[UserNameDifferentCaseData]
	public async Task AddAsync_ShouldHaveUserNameAlreadyTakenProblemDetails_WhenUserNameAlreadyTakenAndNameIsInvalid(
		IStringTransformer transformer)
	{
		// Arrange
		await ServiceScope.AddAsync(User, CancellationToken);
		var request = _requestBuilder.WithName(User.Name, transformer).Build();

		// Act
		var response = await ApiClient.AddProblemDetailsAsync(request, CancellationToken);

		// Assert
		response.ShouldSatisfyUserNameAlreadyTaken(request);
	}

	[Fact]
	public async Task AddAsync_ShouldHaveOkStatusCode_WhenRequestIsValid()
	{
		// Act
		var response = await ApiClient.AddStatusCodeAsync(_request, CancellationToken);

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
	public async Task AddAsync_ShouldHaveOkStatusCode_WhenRequestAndProfileImageAreValid(IFormFileTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithProfileImage(transformer).Build();

		// Act
		var response = await ApiClient.AddStatusCodeAsync(request, CancellationToken);

		// Assert
		response.ShouldBeOk();
	}

	[Fact]
	public async Task AddAsync_ShouldReturnResponse_WhenRequestIsValid()
	{
		// Act
		var response = await ApiClient.AddAsync(_request, CancellationToken);
		var user = await ServiceScope.GetByIdAsync(response, CancellationToken);

		// Assert
		response.ShouldSatisfy(_request, user);
	}

	[Theory]
	[UserProfileImageNullData]
	[UserProfileImageJpegData]
	[UserProfileImagePngData]
	[UserProfileImageWebpData]
	[UserProfileImageJpegDifferentCaseData]
	[UserProfileImagePngDifferentCaseData]
	[UserProfileImageWebpDifferentCaseData]
	public async Task AddAsync_ShouldReturnResponse_WhenRequestAndProfileImageAreValid(IFormFileTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithProfileImage(transformer).Build();

		// Act
		var response = await ApiClient.AddAsync(request, CancellationToken);
		var user = await ServiceScope.GetByIdAsync(response, CancellationToken);

		// Assert
		response.ShouldSatisfy(request, user);
	}

	[Fact]
	public async Task AddAsync_ShouldAddUser_WhenRequestIsValid()
	{
		// Act
		var response = await ApiClient.AddAsync(_request, CancellationToken);
		var user = await ServiceScope.GetByIdAsync(response, CancellationToken);

		// Assert
		user.ShouldSatisfy(_request, PasswordHasher);
	}

	[Theory]
	[UserProfileImageNullData]
	[UserProfileImageJpegData]
	[UserProfileImagePngData]
	[UserProfileImageWebpData]
	[UserProfileImageJpegDifferentCaseData]
	[UserProfileImagePngDifferentCaseData]
	[UserProfileImageWebpDifferentCaseData]
	public async Task AddAsync_ShouldAddUser_WhenRequestAndProfileImageAreValid(IFormFileTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithProfileImage(transformer).Build();

		// Act
		var response = await ApiClient.AddAsync(request, CancellationToken);
		var user = await ServiceScope.GetByIdAsync(response, CancellationToken);

		// Assert
		user.ShouldSatisfy(request, PasswordHasher);
	}

	[Fact]
	public async Task AddAsync_ShouldAddEmailConfirmationToken_WhenRequestIsValid()
	{
		// Act
		var response = await ApiClient.AddAsync(_request, CancellationToken);
		var user = await ServiceScope.GetByIdAsync(response, CancellationToken);

		// Assert
		user.EmailConfirmationTokens.ShouldSatisfy(_request);
	}

	[Theory]
	[UserProfileImageNullData]
	[UserProfileImageJpegData]
	[UserProfileImagePngData]
	[UserProfileImageWebpData]
	[UserProfileImageJpegDifferentCaseData]
	[UserProfileImagePngDifferentCaseData]
	[UserProfileImageWebpDifferentCaseData]
	public async Task AddAsync_ShouldAddEmailConfirmationToken_WhenRequestAndProfileImageAreValid(IFormFileTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithProfileImage(transformer).Build();

		// Act
		var response = await ApiClient.AddAsync(request, CancellationToken);
		var user = await ServiceScope.GetByIdAsync(response, CancellationToken);

		// Assert
		user.EmailConfirmationTokens.ShouldSatisfy(request);
	}

	[Fact]
	public async Task AddAsync_ShouldPublishUserAddedEvent_WhenRequestIsValid()
	{
		// Act
		var response = await ApiClient.AddAsync(_request, CancellationToken);
		var user = await ServiceScope.GetByIdAsync(response, CancellationToken);
		var eventRequest = await EventClient.PublishedAddedAsync(CancellationToken);

		// Assert
		eventRequest.ShouldSatisfy(_request, user);
	}

	[Theory]
	[UserProfileImageNullData]
	[UserProfileImageJpegData]
	[UserProfileImagePngData]
	[UserProfileImageWebpData]
	[UserProfileImageJpegDifferentCaseData]
	[UserProfileImagePngDifferentCaseData]
	[UserProfileImageWebpDifferentCaseData]
	public async Task AddAsync_ShouldPublishUserAddedEvent_WhenRequestAndProfileImageAreValid(IFormFileTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithProfileImage(transformer).Build();

		// Act
		var response = await ApiClient.AddAsync(request, CancellationToken);
		var user = await ServiceScope.GetByIdAsync(response, CancellationToken);
		var eventRequest = await EventClient.PublishedAddedAsync(CancellationToken);

		// Assert
		eventRequest.ShouldSatisfy(request, user);
	}

	[Fact]
	public async Task AddAsync_ShouldPublishEmailConfirmationTokenAddedEvent_WhenRequestIsValid()
	{
		// Act
		var response = await ApiClient.AddAsync(_request, CancellationToken);
		var user = await ServiceScope.GetByIdAsync(response, CancellationToken);
		var eventRequests = await EmailConfirmationTokenEventClient.PublishedAddedRangeAsync(CancellationToken);

		// Assert
		eventRequests.ShouldSatisfy(_request, user.EmailConfirmationTokens);
	}

	[Theory]
	[UserProfileImageNullData]
	[UserProfileImageJpegData]
	[UserProfileImagePngData]
	[UserProfileImageWebpData]
	[UserProfileImageJpegDifferentCaseData]
	[UserProfileImagePngDifferentCaseData]
	[UserProfileImageWebpDifferentCaseData]
	public async Task AddAsync_ShouldPublishEmailConfirmationTokenAddedEvent_WhenRequestAndProfileImageAreValid(IFormFileTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithProfileImage(transformer).Build();

		// Act
		var response = await ApiClient.AddAsync(request, CancellationToken);
		var user = await ServiceScope.GetByIdAsync(response, CancellationToken);
		var eventRequests = await EmailConfirmationTokenEventClient.PublishedAddedRangeAsync(CancellationToken);

		// Assert
		eventRequests.ShouldSatisfy(request, user.EmailConfirmationTokens);
	}
}
