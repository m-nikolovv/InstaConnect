using InstaConnect.Follows.Application.Features.Follows.Queries.GetAllForFollowing;
using InstaConnect.Follows.Domain.Features.Follows.Models.Requests;
using InstaConnect.Follows.Tests.Features.Follows.DataAttributes.Page;
using InstaConnect.Follows.Tests.Features.Follows.DataAttributes.PageSize;
using InstaConnect.Follows.Tests.Features.Follows.DataAttributes.SortOrder;
using InstaConnect.Follows.Tests.Features.Follows.DataAttributes.SortTerm.ForFollowing;
using InstaConnect.Follows.Tests.Features.Users.DataAttributes.Name;

namespace InstaConnect.Follows.Application.Tests.Unit.Features.Follows.Handlers.GetAllForFollowing;

public class GetAllFollowsForFollowingQueryRequestValidatorUnitTests : BaseFollowApplicationQueryUnitTest
{
	private readonly GetAllFollowsForFollowingQueryRequestBuilderFactory _requestBuilderFactory;
	private readonly GetAllFollowsForFollowingQueryRequestBuilder _requestBuilder;
	private readonly GetAllFollowsForFollowingQueryRequest _request;

	private readonly GetAllFollowsForFollowingQueryRequestValidator _requestValidator;

	public GetAllFollowsForFollowingQueryRequestValidatorUnitTests()
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
	[UserNameTooLongWithMessageData]
	public void TestValidate_ShouldHaveAnError_WhenFollowerNameIsInvalid(
		IStringTransformer transformer, IStringMessageTransformer messageTransformer)
	{
		// Arrange
		var request = _requestBuilder.WithFollowerName(transformer).Build();

		// Act
		var response = _requestValidator.TestValidate(request);

		// Assert
		response.ShouldHaveValidationErrorForFollowerName(request, messageTransformer);
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
	[FollowsSortOrderEmptyWithMessageData]
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
	[FollowsForFollowingSortTermEmptyWithMessageData]
	public void TestValidate_ShouldHaveAnError_WhenSortTermIsInvalid(
		IEnumTransformer<FollowsForFollowingSortTerm> transformer, IEnumMessageTransformer<FollowsForFollowingSortTerm> messageTransformer)
	{
		// Arrange
		var request = _requestBuilder.WithSortTerm(transformer).Build();

		// Act
		var response = _requestValidator.TestValidate(request);

		// Assert
		response.ShouldHaveValidationErrorForSortTerm(request, messageTransformer);
	}

	[Theory]
	[FollowPageTooSmallWithMessageData]
	[FollowPageTooLargeWithMessageData]
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
	[FollowPageSizeTooSmallWithMessageData]
	[FollowPageSizeTooLargeWithMessageData]
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
	public void TestValidate_ShouldNotHaveAnyValidationErrors_WhenFollowerNameIsValid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithFollowerName(transformer).Build();

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
