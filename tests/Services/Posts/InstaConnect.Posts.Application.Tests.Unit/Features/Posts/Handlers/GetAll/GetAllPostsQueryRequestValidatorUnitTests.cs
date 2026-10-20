using InstaConnect.Posts.Application.Features.Posts.Queries.GetAll;
using InstaConnect.Posts.Domain.Features.Posts.Models.Requests;
using InstaConnect.Posts.Tests.Features.Posts.DataAttributes.Page;
using InstaConnect.Posts.Tests.Features.Posts.DataAttributes.PageSize;
using InstaConnect.Posts.Tests.Features.Posts.DataAttributes.SortOrder;
using InstaConnect.Posts.Tests.Features.Posts.DataAttributes.SortTerm;
using InstaConnect.Posts.Tests.Features.Posts.DataAttributes.Title;

namespace InstaConnect.Posts.Application.Tests.Unit.Features.Posts.Handlers.GetAll;

public class GetAllPostsQueryRequestValidatorUnitTests : BasePostApplicationQueryUnitTest
{
	private readonly GetAllPostsQueryRequestBuilderFactory _requestBuilderFactory;
	private readonly GetAllPostsQueryRequestBuilder _requestBuilder;
	private readonly GetAllPostsQueryRequest _request;

	private readonly GetAllPostsQueryRequestValidator _requestValidator;

	public GetAllPostsQueryRequestValidatorUnitTests()
	{
		_requestBuilderFactory = new();
		_requestBuilder = _requestBuilderFactory.Create(Post);
		_request = _requestBuilder.Build();

		_requestValidator = new();
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
	[PostTitleTooLongWithMessageData]
	public void TestValidate_ShouldHaveAnError_WhenTitleIsInvalid(
		IStringTransformer transformer, IStringMessageTransformer messageTransformer)
	{
		// Arrange
		var request = _requestBuilder.WithTitle(transformer).Build();

		// Act
		var response = _requestValidator.TestValidate(request);

		// Assert
		response.ShouldHaveValidationErrorForTitle(request, messageTransformer);
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
	[PostsSortOrderEmptyWithMessageData]
	public void TestValidate_ShouldHaveAnError_WhenSortOrderIsInvalid(
		IEnumTransformer<CommonSortOrder> transformer, IEnumMessageTransformer<CommonSortOrder> messageTransformer)
	{
		// Arrange
		var request = _requestBuilder.WithSortOrder(transformer).Build();

		// Act
		var response = _requestValidator.TestValidate(request);

		// Assert
		response.ShouldHaveValidationErrorForSortOrder(request, messageTransformer);
	}

	[Theory]
	[PostsSortTermEmptyWithMessageData]
	public void TestValidate_ShouldHaveAnError_WhenSortTermIsInvalid(
		IEnumTransformer<PostsSortTerm> transformer, IEnumMessageTransformer<PostsSortTerm> messageTransformer)
	{
		// Arrange
		var request = _requestBuilder.WithSortTerm(transformer).Build();

		// Act
		var response = _requestValidator.TestValidate(request);

		// Assert
		response.ShouldHaveValidationErrorForSortTerm(request, messageTransformer);
	}

	[Theory]
	[PostPageTooSmallWithMessageData]
	[PostPageTooLargeWithMessageData]
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
	[PostPageSizeTooSmallWithMessageData]
	[PostPageSizeTooLargeWithMessageData]
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
	[PostTitleEmptyData]
	[PostTitleNullData]
	public void TestValidate_ShouldNotHaveAnyValidationErrors_WhenTitleIsValid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithTitle(transformer).Build();

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
