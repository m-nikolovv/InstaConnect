using InstaConnect.Identity.Application.Features.ForgotPasswordTokens.Commands.Verify;
using InstaConnect.Identity.Application.Tests.Features.ForgotPasswordTokens.Builders;
using InstaConnect.Identity.Application.Tests.Unit.Features.ForgotPasswordTokens.Utilities;
using InstaConnect.Identity.Tests.Features.ForgotPasswordTokens.DataAttributes.Value;
using InstaConnect.Identity.Tests.Features.Users.DataAttributes.ConfirmPassword;
using InstaConnect.Identity.Tests.Features.Users.DataAttributes.Password;

namespace InstaConnect.Identity.Application.Tests.Unit.Features.ForgotPasswordTokens.Handlers.Verify;

public class VerifyForgotPasswordTokenCommandRequestValidatorUnitTests : BaseForgotPasswordTokenApplicationCommandUnitTest
{
	private const string PasswordPropertyName = nameof(VerifyForgotPasswordTokenCommandRequest.Password);

	private readonly VerifyForgotPasswordTokenCommandRequestBuilderFactory _requestBuilderFactory;
	private readonly VerifyForgotPasswordTokenCommandRequestBuilder _requestBuilder;
	private readonly VerifyForgotPasswordTokenCommandRequest _request;

	private readonly VerifyForgotPasswordTokenCommandRequestValidator _requestValidator;

	public VerifyForgotPasswordTokenCommandRequestValidatorUnitTests()
	{
		_requestBuilderFactory = new();
		_requestBuilder = _requestBuilderFactory.Create(ForgotPasswordToken);
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
	[ForgotPasswordTokenValueNullWithMessageData]
	[ForgotPasswordTokenValueEmptyWithMessageData]
	[ForgotPasswordTokenValueTooShortWithMessageData]
	[ForgotPasswordTokenValueTooLongWithMessageData]
	public void TestValidate_ShouldHaveAnError_WhenValueIsInvalid(
		IStringTransformer transformer, IStringMessageTransformer messageTransformer)
	{
		// Arrange
		var request = _requestBuilder.WithValue(transformer).Build();

		// Act
		var response = _requestValidator.TestValidate(request);

		// Assert
		response.ShouldHaveValidationErrorForValue(request, messageTransformer);
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

	[Fact]
	public void TestValidate_ShouldNotHaveAnyValidationErrors_WhenRequestIsValid()
	{
		// Act
		var response = _requestValidator.TestValidate(_request);

		// Assert
		response.ShouldNotHaveAnyValidationErrorProperties();
	}
}
