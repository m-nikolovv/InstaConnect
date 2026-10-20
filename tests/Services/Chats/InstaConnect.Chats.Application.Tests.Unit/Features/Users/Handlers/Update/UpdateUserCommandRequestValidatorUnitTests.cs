using InstaConnect.Chats.Application.Features.Users.Commands.Update;
using InstaConnect.Chats.Tests.Features.Users.DataAttributes.Email;
using InstaConnect.Chats.Tests.Features.Users.DataAttributes.FirstName;
using InstaConnect.Chats.Tests.Features.Users.DataAttributes.LastName;
using InstaConnect.Chats.Tests.Features.Users.DataAttributes.Name;
using InstaConnect.Chats.Tests.Features.Users.DataAttributes.ProfileImage;
using InstaConnect.Chats.Tests.Features.Users.DataAttributes.UpdatedAtUtc;
using InstaConnect.Common.Tests.Features.DataAttributes.DateTimeOffsets.Base;

namespace InstaConnect.Chats.Application.Tests.Unit.Features.Users.Handlers.Update;

public class UpdateUserCommandRequestValidatorUnitTests : BaseUserApplicationCommandUnitTest
{
	private readonly UpdateUserCommandRequestBuilderFactory _requestBuilderFactory;
	private readonly UpdateUserCommandRequestBuilder _requestBuilder;
	private readonly UpdateUserCommandRequest _request;

	private readonly UpdateUserCommandRequestValidator _requestValidator;

	public UpdateUserCommandRequestValidatorUnitTests()
	{
		_requestBuilderFactory = new();
		_requestBuilder = _requestBuilderFactory.Create(User);
		_request = _requestBuilder.Build();

		_requestValidator = new();
	}

	[Theory]
	[UserIdNullWithMessageData]
	[UserIdEmptyWithMessageData]
	[UserIdTooShortWithMessageData]
	[UserIdTooLongWithMessageData]
	public void TestValidate_ShouldHaveAnError_WhenIdIsInvalid(
		IStringTransformer transformer, IStringMessageTransformer messageTransformer)
	{
		// Arrange
		var request = _requestBuilder.WithId(transformer).Build();

		// Act
		var response = _requestValidator.TestValidate(request);

		// Assert
		response.ShouldHaveValidationErrorForId(request, messageTransformer);
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
	[UserProfileImageTooLongWithMessageData]
	public void TestValidate_ShouldHaveAnError_WhenProfileImageIsInvalid(
		IStringTransformer transformer, IStringMessageTransformer messageTransformer)
	{
		// Arrange
		var request = _requestBuilder.WithProfileImage(transformer).Build();

		// Act
		var response = _requestValidator.TestValidate(request);

		// Assert
		response.ShouldHaveValidationErrorForProfileImage(request, messageTransformer);
	}

	[Theory]
	[UserUpdatedAtUtcEmptyWithMessageData]
	public void TestValidate_ShouldHaveAnError_WhenUpdatedAtUtcIsInvalid(
		IDateTimeOffsetTransformer transformer, IDateTimeOffsetMessageTransformer messageTransformer)
	{
		// Arrange
		var request = _requestBuilder.WithUpdatedAtUtc(transformer).Build();

		// Act
		var response = _requestValidator.TestValidate(request);

		// Assert
		response.ShouldHaveValidationErrorForUpdatedAtUtc(request, messageTransformer);
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
	[UserProfileImageEmptyData]
	public void TestValidate_ShouldNotHaveAnyValidationErrors_WhenRequestAndProfileImageAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithProfileImage(transformer).Build();

		// Act
		var response = _requestValidator.TestValidate(request);

		// Assert
		response.ShouldNotHaveAnyValidationErrorProperties();
	}
}
