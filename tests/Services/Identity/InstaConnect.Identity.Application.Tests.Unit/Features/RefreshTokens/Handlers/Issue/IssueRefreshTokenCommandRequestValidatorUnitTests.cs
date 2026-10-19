namespace InstaConnect.Identity.Application.Tests.Unit.Features.RefreshTokens.Handlers.Issue;

public class IssueRefreshTokenCommandRequestValidatorUnitTests : BaseRefreshTokenApplicationCommandUnitTest
{
	private readonly IssueRefreshTokenCommandRequestBuilderFactory _requestBuilderFactory;
	private readonly IssueRefreshTokenCommandRequestBuilder _requestBuilder;
	private readonly IssueRefreshTokenCommandRequest _request;

	private readonly IssueRefreshTokenCommandRequestValidator _requestValidator;

	public IssueRefreshTokenCommandRequestValidatorUnitTests()
	{
		_requestBuilderFactory = new();
		_requestBuilder = _requestBuilderFactory.Create(User, Password);
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

	[Fact]
	public void TestValidate_ShouldNotHaveAnyValidationErrors_WhenRequestIsValid()
	{
		// Act
		var response = _requestValidator.TestValidate(_request);

		// Assert
		response.ShouldNotHaveAnyValidationErrorProperties();
	}
}
