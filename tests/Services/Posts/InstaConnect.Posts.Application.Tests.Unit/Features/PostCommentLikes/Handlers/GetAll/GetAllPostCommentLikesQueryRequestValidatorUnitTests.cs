using InstaConnect.Common.Domain.Features.Requests.Models;
using InstaConnect.Posts.Domain.Features.PostCommentLikes.Models.Requests;

namespace InstaConnect.Posts.Application.Tests.Unit.Features.PostCommentLikes.Handlers.GetAll;

public class GetAllPostCommentLikesQueryRequestValidatorUnitTests : BasePostCommentLikeApplicationQueryUnitTest
{
	private readonly GetAllPostCommentLikesQueryRequestBuilderFactory _requestBuilderFactory;
	private readonly GetAllPostCommentLikesQueryRequestBuilder _requestBuilder;
	private readonly GetAllPostCommentLikesQueryRequest _request;

	private readonly GetAllPostCommentLikesQueryRequestValidator _requestValidator;

	public GetAllPostCommentLikesQueryRequestValidatorUnitTests()
	{
		_requestBuilderFactory = new();
		_requestBuilder = _requestBuilderFactory.Create(PostCommentLike);
		_request = _requestBuilder.Build();

		_requestValidator = new();
	}

	[Theory]
	[PostIdNullWithMessageData]
	[PostIdEmptyWithMessageData]
	[PostIdTooShortWithMessageData]
	[PostIdTooLongWithMessageData]
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
	[PostCommentIdNullWithMessageData]
	[PostCommentIdEmptyWithMessageData]
	[PostCommentIdTooShortWithMessageData]
	[PostCommentIdTooLongWithMessageData]
	public void TestValidate_ShouldHaveAnError_WhenCommentIdIsInvalid(
		IStringTransformer transformer, IStringMessageTransformer messageTransformer)
	{
		// Arrange
		var request = _requestBuilder.WithCommentId(transformer).Build();

		// Act
		var response = _requestValidator.TestValidate(request);

		// Assert
		response.ShouldHaveValidationErrorForCommentId(request, messageTransformer);
	}

	[Theory]
	[UserNameTooLongWithMessageData]
	public void TestValidate_ShouldHaveAnError_WhenUserNameIsInvalid(
		IStringTransformer transformer, IStringMessageTransformer messageTransformer)
	{
		// Arrange
		var request = _requestBuilder.WithUserName(transformer).Build();

		// Act
		var response = _requestValidator.TestValidate(request);

		// Assert
		response.ShouldHaveValidationErrorForUserName(request, messageTransformer);
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
	[PostCommentLikesSortOrderEmptyWithMessageData]
	public void TestValidate_ShouldHaveAnError_WhenSortOrderIsInvalid(
		IEnumTransformer<CommonSortOrder> transformer,
		IEnumMessageTransformer<CommonSortOrder> messageTransformer)
	{
		// Arrange
		var request = _requestBuilder.WithSortOrder(transformer).Build();

		// Act
		var response = _requestValidator.TestValidate(request);

		// Assert
		response.ShouldHaveValidationErrorForSortOrder(request, messageTransformer);
	}

	[Theory]
	[PostCommentLikesSortTermEmptyWithMessageData]
	public void TestValidate_ShouldHaveAnError_WhenSortTermIsInvalid(
		IEnumTransformer<PostCommentLikesSortTerm> transformer,
		IEnumMessageTransformer<PostCommentLikesSortTerm> messageTransformer)
	{
		// Arrange
		var request = _requestBuilder.WithSortTerm(transformer).Build();

		// Act
		var response = _requestValidator.TestValidate(request);

		// Assert
		response.ShouldHaveValidationErrorForSortTerm(request, messageTransformer);
	}

	[Theory]
	[PostCommentLikePageTooSmallWithMessageData]
	[PostCommentLikePageTooLargeWithMessageData]
	public void TestValidate_ShouldHaveAnError_WhenPageIsInvalid(
		IIntTransformer transformer, IIntMessageTransformer messageTransformer)
	{
		// Arrange
		var request = _requestBuilder.WithPage(transformer).Build();

		// Act
		var response = _requestValidator.TestValidate(request);

		// Assert
		response.ShouldHaveValidationErrorForPage(request, messageTransformer);
	}

	[Theory]
	[PostCommentLikePageSizeTooSmallWithMessageData]
	[PostCommentLikePageSizeTooLargeWithMessageData]
	public void TestValidate_ShouldHaveAnError_WhenPageSizeIsInvalid(
		IIntTransformer transformer, IIntMessageTransformer messageTransformer)
	{
		// Arrange
		var request = _requestBuilder.WithPageSize(transformer).Build();

		// Act
		var response = _requestValidator.TestValidate(request);

		// Assert
		response.ShouldHaveValidationErrorForPageSize(request, messageTransformer);
	}

	[Theory]
	[UserNameEmptyData]
	[UserNameNullData]
	public void TestValidate_ShouldNotHaveAnyValidationErrors_WhenUserNameIsValid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithUserName(transformer).Build();

		// Act
		var response = _requestValidator.TestValidate(request);

		// Assert
		response.ShouldNotHaveAnyValidationErrorProperties();
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
