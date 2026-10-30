using InstaConnect.Common.Tests.Features.DataAttributes.FormFiles.Base;
using InstaConnect.Identity.Application.Features.Users.Commands.Add;
using InstaConnect.Identity.Tests.Features.Users.DataAttributes.ConfirmPassword;
using InstaConnect.Identity.Tests.Features.Users.DataAttributes.Email;
using InstaConnect.Identity.Tests.Features.Users.DataAttributes.FirstName;
using InstaConnect.Identity.Tests.Features.Users.DataAttributes.LastName;
using InstaConnect.Identity.Tests.Features.Users.DataAttributes.Password;
using InstaConnect.Identity.Tests.Features.Users.DataAttributes.ProfileImage;

namespace InstaConnect.Identity.Application.Tests.Unit.Features.Users.Handlers.Add;

public class AddUserCommandRequestValidatorUnitTests : BaseUserApplicationCommandUnitTest
{
	private const string PasswordPropertyName = nameof(AddUserCommandRequest.Password);

	private readonly AddUserCommandRequestBuilderFactory _requestBuilderFactory;
	private readonly AddUserCommandRequestBuilder _requestBuilder;
	private readonly AddUserCommandRequest _request;

	private readonly AddUserCommandRequestValidator _requestValidator;

	public AddUserCommandRequestValidatorUnitTests()
	{
		_requestBuilderFactory = new();
		_requestBuilder = _requestBuilderFactory.Create();
		_request = _requestBuilder.Build();

		_requestValidator = new();
	}

	[Theory]
	[UserNameNullWithMessageData]
	[UserNameEmptyWithMessageData]
	[UserNameTooShortWithMessageData]
	[UserNameTooLongWithMessageData]
	public void TestValidate_ShouldHaveAnError_WhenNameIsInvalid(
		IStringTransformer transformer, IStringMessageTransformer messageTransformer)
	{
		// Arrange
		var request = _requestBuilder.WithName(transformer).Build();

		// Act
		var response = _requestValidator.TestValidate(request);

		// Assert
		response.ShouldHaveValidationErrorForName(request, messageTransformer);
	}

	[Theory]
	[UserFirstNameNullWithMessageData]
	[UserFirstNameEmptyWithMessageData]
	[UserFirstNameTooShortWithMessageData]
	[UserFirstNameTooLongWithMessageData]
	public void TestValidate_ShouldHaveAnError_WhenFirstNameIsInvalid(
		IStringTransformer transformer, IStringMessageTransformer messageTransformer)
	{
		// Arrange
		var request = _requestBuilder.WithFirstName(transformer).Build();

		// Act
		var response = _requestValidator.TestValidate(request);

		// Assert
		response.ShouldHaveValidationErrorForFirstName(request, messageTransformer);
	}

	[Theory]
	[UserLastNameNullWithMessageData]
	[UserLastNameEmptyWithMessageData]
	[UserLastNameTooShortWithMessageData]
	[UserLastNameTooLongWithMessageData]
	public void TestValidate_ShouldHaveAnError_WhenLastNameIsInvalid(
		IStringTransformer transformer, IStringMessageTransformer messageTransformer)
	{
		// Arrange
		var request = _requestBuilder.WithLastName(transformer).Build();

		// Act
		var response = _requestValidator.TestValidate(request);

		// Assert
		response.ShouldHaveValidationErrorForLastName(request, messageTransformer);
	}

	[Theory]
	[UserEmailNullWithMessageData]
	[UserEmailEmptyWithMessageData]
	[UserEmailTooShortWithMessageData]
	[UserEmailTooLongWithMessageData]
	[UserEmailInvalidWithMessageData]
	public void TestValidate_ShouldHaveAnError_WhenEmailIsInvalid(
		IStringTransformer transformer, IStringMessageTransformer messageTransformer)
	{
		// Arrange
		var request = _requestBuilder.WithEmail(transformer).Build();

		// Act
		var response = _requestValidator.TestValidate(request);

		// Assert
		response.ShouldHaveValidationErrorForEmail(request, messageTransformer);
	}

	[Theory]
	[UserPasswordNullWithMessageData]
	[UserPasswordEmptyWithMessageData]
	[UserPasswordTooShortWithMessageData]
	[UserPasswordTooLongWithMessageData]
	public void TestValidate_ShouldHaveAnError_WhenPasswordIsInvalid(
		IStringTransformer transformer, IStringMessageTransformer messageTransformer)
	{
		// Arrange
		var request = _requestBuilder.WithPassword(transformer).Build();

		// Act
		var response = _requestValidator.TestValidate(request);

		// Assert
		response.ShouldHaveValidationErrorForPassword(request, messageTransformer);
	}

	[Theory]
	[UserConfirmPasswordNotEqualWithMessageData(PasswordPropertyName)]
	public void TestValidate_ShouldHaveAnError_WhenConfirmPasswordIsInvalid(
		IStringTransformer transformer, IStringMessageTransformer messageTransformer)
	{
		// Arrange
		var request = _requestBuilder.WithConfirmPassword(transformer).Build();

		// Act
		var response = _requestValidator.TestValidate(request);

		// Assert
		response.ShouldHaveValidationErrorForConfirmPassword(request, messageTransformer);
	}

	[Theory]
	[UserProfileImageTooLargeWithMessageData]
	[UserProfileImageInvalidContentTypeWithMessageData]
	public void TestValidate_ShouldHaveAnError_WhenProfileImageIsInvalid(
		IFormFileTransformer transformer, IFormFileMessageTransformer messageTransformer)
	{
		// Arrange
		var request = _requestBuilder.WithProfileImage(transformer).Build();

		// Act
		var response = _requestValidator.TestValidate(request);

		// Assert
		response.ShouldHaveValidationErrorForProfileImage(request, messageTransformer);
	}

	[Fact]
	public void TestValidate_ShouldNotHaveAnyValidationErrors_WhenRequestIsValid()
	{
		// Act
		var response = _requestValidator.TestValidate(_request);

		// Assert
		response.ShouldNotHaveAnyValidationErrorProperties();
	}

	[Theory]
	[UserProfileImageNullData]
	[UserProfileImageJpegData]
	[UserProfileImagePngData]
	[UserProfileImageWebpData]
	[UserProfileImageJpegDifferentCaseData]
	[UserProfileImagePngDifferentCaseData]
	[UserProfileImageWebpDifferentCaseData]
	public void TestValidate_ShouldNotHaveAnyValidationErrors_WhenRequestAndProfileImageAreValid(
		IFormFileTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithProfileImage(transformer).Build();

		// Act
		var response = _requestValidator.TestValidate(request);

		// Assert
		response.ShouldNotHaveAnyValidationErrorProperties();
	}
}
