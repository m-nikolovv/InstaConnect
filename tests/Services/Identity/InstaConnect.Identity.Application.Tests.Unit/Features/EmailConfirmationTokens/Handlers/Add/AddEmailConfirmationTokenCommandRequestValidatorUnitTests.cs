namespace InstaConnect.Identity.Application.Tests.Unit.Features.EmailConfirmationTokens.Handlers.Add;

public class AddEmailConfirmationTokenCommandRequestValidatorUnitTests : BaseEmailConfirmationTokenApplicationCommandUnitTest
{
	private readonly AddEmailConfirmationTokenCommandRequestBuilderFactory _requestBuilderFactory;
	private readonly AddEmailConfirmationTokenCommandRequestBuilder _requestBuilder;
	private readonly AddEmailConfirmationTokenCommandRequest _request;

	private readonly AddEmailConfirmationTokenCommandRequestValidator _requestValidator;

	public AddEmailConfirmationTokenCommandRequestValidatorUnitTests()
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
