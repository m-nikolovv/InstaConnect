using InstaConnect.Identity.Application.Features.RefreshTokens.Commands.DeleteCurrent;
using InstaConnect.Identity.Tests.Features.RefreshTokens.DataAttributes.Value;

namespace InstaConnect.Identity.Application.Tests.Unit.Features.RefreshTokens.Handlers.DeleteCurrent;

public class DeleteCurrentRefreshTokenCommandRequestValidatorUnitTests : BaseRefreshTokenApplicationCommandUnitTest
{
	private readonly DeleteCurrentRefreshTokenCommandRequestBuilderFactory _requestBuilderFactory;
	private readonly DeleteCurrentRefreshTokenCommandRequestBuilder _requestBuilder;
	private readonly DeleteCurrentRefreshTokenCommandRequest _request;

	private readonly DeleteCurrentRefreshTokenCommandRequestValidator _requestValidator;

	public DeleteCurrentRefreshTokenCommandRequestValidatorUnitTests()
	{
		_requestBuilderFactory = new();
		_requestBuilder = _requestBuilderFactory.Create(RefreshToken);
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
	[RefreshTokenValueNullWithMessageData]
	[RefreshTokenValueEmptyWithMessageData]
	[RefreshTokenValueTooShortWithMessageData]
	[RefreshTokenValueTooLongWithMessageData]
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

	[Fact]
	public void TestValidate_ShouldNotHaveAnyValidationErrors_WhenRequestIsValid()
	{
		// Act
		var response = _requestValidator.TestValidate(_request);

		// Assert
		response.ShouldNotHaveAnyValidationErrorProperties();
	}
}
