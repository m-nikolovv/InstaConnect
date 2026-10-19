namespace InstaConnect.Follows.Application.Tests.Unit.Features.Follows.Handlers.GetById;

public class GetFollowByIdQueryRequestValidatorUnitTests : BaseFollowApplicationQueryUnitTest
{
	private readonly GetFollowByIdQueryRequestBuilderFactory _requestBuilderFactory;
	private readonly GetFollowByIdQueryRequestBuilder _requestBuilder;
	private readonly GetFollowByIdQueryRequest _request;

	private readonly GetFollowByIdQueryRequestValidator _requestValidator;

	public GetFollowByIdQueryRequestValidatorUnitTests()
	{
		_requestBuilderFactory = new();
		_requestBuilder = _requestBuilderFactory.Create(Follow);
		_request = _requestBuilder.Build();

		_requestValidator = new();
	}

	[Theory]
	[UserIdNullWithMessageData]
	[UserIdEmptyWithMessageData]
	[UserIdTooShortWithMessageData]
	[UserIdTooLongWithMessageData]
	public void TestValidate_ShouldHaveAnError_WhenFollowerIdIsInvalid(
		IStringTransformer transformer, IStringMessageTransformer messageTransformer)
	{
		// Arrange
		var request = _requestBuilder.WithFollowerId(transformer).Build();

		// Act
		var response = _requestValidator.TestValidate(request);

		// Assert
		response.ShouldHaveValidationErrorForFollowerId(request, messageTransformer);
	}

	[Theory]
	[UserIdNullWithMessageData]
	[UserIdEmptyWithMessageData]
	[UserIdTooShortWithMessageData]
	[UserIdTooLongWithMessageData]
	public void TestValidate_ShouldHaveAnError_WhenFollowingIdIsInvalid(
		IStringTransformer transformer, IStringMessageTransformer messageTransformer)
	{
		// Arrange
		var request = _requestBuilder.WithFollowingId(transformer).Build();

		// Act
		var response = _requestValidator.TestValidate(request);

		// Assert
		response.ShouldHaveValidationErrorForFollowingId(request, messageTransformer);
	}

	[Theory]
	[UserIdTooLongWithMessageData]
	public void TestValidate_ShouldHaveAnError_WhenCurrentUserIdIsInvalid(
		IStringTransformer transformer, IStringMessageTransformer messageTransformer)
	{
		// Arrange
		var request = _requestBuilder.WithCurrentUserId(transformer).Build();

		// Act
		var response = _requestValidator.TestValidate(request);

		// Assert
		response.ShouldHaveValidationErrorForCurrentUserId(request, messageTransformer);
	}

	[Theory]
	[UserIdNullData]
	[UserIdEmptyData]
	public void TestValidate_ShouldNotHaveAnyValidationErrors_WhenCurrentUserIdIsValid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithCurrentUserId(transformer).Build();

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
