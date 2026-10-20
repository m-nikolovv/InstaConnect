using InstaConnect.Identity.Application.Features.Users.Queries.GetCurrentDetailsById;

namespace InstaConnect.Identity.Application.Tests.Unit.Features.Users.Handlers.GetCurrentDetailsById;

public class GetCurrentUserDetailsByIdQueryRequestValidatorUnitTests : BaseUserApplicationQueryUnitTest
{
	private readonly GetCurrentUserDetailsByIdQueryRequestBuilderFactory _requestBuilderFactory;
	private readonly GetCurrentUserDetailsByIdQueryRequestBuilder _requestBuilder;
	private readonly GetCurrentUserDetailsByIdQueryRequest _request;

	private readonly GetCurrentUserDetailsByIdQueryRequestValidator _requestValidator;

	public GetCurrentUserDetailsByIdQueryRequestValidatorUnitTests()
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
	public void TestValidate_ShouldHaveAnError_WhenCurrentIdIsInvalid(
		IStringTransformer transformer, IStringMessageTransformer messageTransformer)
	{
		// Arrange
		var request = _requestBuilder.WithCurrentId(transformer).Build();

		// Act
		var response = _requestValidator.TestValidate(request);

		// Assert
		response.ShouldHaveValidationErrorForCurrentId(request, messageTransformer);
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
