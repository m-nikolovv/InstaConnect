using InstaConnect.Identity.Application.Features.Users.Queries.GetById;

namespace InstaConnect.Identity.Application.Tests.Unit.Features.Users.Handlers.GetById;

public class GetUserByIdQueryRequestValidatorUnitTests : BaseUserApplicationQueryUnitTest
{
	private readonly GetUserByIdQueryRequestBuilderFactory _requestBuilderFactory;
	private readonly GetUserByIdQueryRequestBuilder _requestBuilder;
	private readonly GetUserByIdQueryRequest _request;

	private readonly GetUserByIdQueryRequestValidator _requestValidator;

	public GetUserByIdQueryRequestValidatorUnitTests()
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

	[Theory]
	[UserIdNullData]
	[UserIdEmptyData]
	public void TestValidate_ShouldNotHaveAnyValidationErrors_WhenCurrentIdIsValid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithCurrentId(transformer).Build();

		// Act
		var response = _requestValidator.TestValidate(request);

		// Assert
		response.ShouldNotHaveAnyValidationErrorProperties();
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
