using InstaConnect.Common.Events.Features.AccessTokens.Models;

namespace InstaConnect.Identity.Application.Tests.Unit.Features.UserClaims.Handlers.Add;

public class AddUserClaimCommandRequestValidatorUnitTests : BaseUserClaimApplicationCommandUnitTest
{
	private readonly AddUserClaimCommandRequestBuilderFactory _requestBuilderFactory;
	private readonly AddUserClaimCommandRequestBuilder _requestBuilder;
	private readonly AddUserClaimCommandRequest _request;

	private readonly AddUserClaimCommandRequestValidator _requestValidator;

	public AddUserClaimCommandRequestValidatorUnitTests()
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
	[UserClaimClaimEmptyWithMessageData]
	public void TestValidate_ShouldHaveAnError_WhenClaimIsInvalid(
		IEnumTransformer<ApplicationClaims> transformer, IEnumMessageTransformer<ApplicationClaims> messageTransformer)
	{
		// Arrange
		var request = _requestBuilder.WithClaim(transformer).Build();

		// Act
		var response = _requestValidator.TestValidate(request);

		// Assert
		response.ShouldHaveValidationErrorForClaim(request, messageTransformer);
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
