using InstaConnect.Identity.Application.Features.ForgotPasswordTokens.Commands.Add;
using InstaConnect.Identity.Application.Tests.Features.ForgotPasswordTokens.Builders;
using InstaConnect.Identity.Application.Tests.Unit.Features.ForgotPasswordTokens.Utilities;

namespace InstaConnect.Identity.Application.Tests.Unit.Features.ForgotPasswordTokens.Handlers.Add;

public class AddForgotPasswordTokenCommandRequestValidatorUnitTests : BaseForgotPasswordTokenApplicationCommandUnitTest
{
	private readonly AddForgotPasswordTokenCommandRequestBuilderFactory _requestBuilderFactory;
	private readonly AddForgotPasswordTokenCommandRequestBuilder _requestBuilder;
	private readonly AddForgotPasswordTokenCommandRequest _request;

	private readonly AddForgotPasswordTokenCommandRequestValidator _requestValidator;

	public AddForgotPasswordTokenCommandRequestValidatorUnitTests()
	{
		_requestBuilderFactory = new();
		_requestBuilder = _requestBuilderFactory.Create(User);
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

	[Fact]
	public void TestValidate_ShouldNotHaveAnyValidationErrors_WhenRequestIsValid()
	{
		// Act
		var response = _requestValidator.TestValidate(_request);

		// Assert
		response.ShouldNotHaveAnyValidationErrorProperties();
	}
}
