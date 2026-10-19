using InstaConnect.Common.Domain.Features.Requests.Models;
using InstaConnect.Common.Tests.Features.DataAttributes.Enums.Sort;

using InstaConnect.Posts.Domain.Features.PostCommentLikes.Models.Requests;

namespace InstaConnect.Posts.Presentation.Tests.Integration.Features.PostCommentLikes.Controllers;

public class GetAllPostCommentLikesForUserControllerIntegrationTests : BasePostCommentLikePresentationQueryIntegrationTest
{
	private readonly GetAllPostCommentLikesForUserApiRequestBuilderFactory _requestBuilderFactory;
	private readonly GetAllPostCommentLikesForUserApiRequestBuilder _requestBuilder;
	private readonly GetAllPostCommentLikesForUserApiRequest _request;

	public GetAllPostCommentLikesForUserControllerIntegrationTests(PostsWebApplicationFactory webApplicationFactory)
		: base(webApplicationFactory)
	{
		_requestBuilderFactory = new();
		_requestBuilder = _requestBuilderFactory.Create(PostCommentLike);
		_request = _requestBuilder.Build();
	}

	protected override async Task OnInitializeAsync()
	{
		await ServiceScope.AddRangeAsync(PostCommentLikes, CancellationToken);
	}

	[Theory]
	[UserIdNullWithMessageData]
	[UserIdEmptyWithMessageData]
	[UserIdTooShortWithMessageData]
	[UserIdTooLongWithMessageData]
	public async Task GetAllAsync_ShouldThrowValidationException_WhenUserIdIsInvalid(
		IStringTransformer transformer, IStringMessageTransformer messageTransformer)
	{
		// Arrange
		var request = _requestBuilder.WithUserId(transformer).Build();

		// Assert
		await UserController.ShouldThrowInvalidValidationExceptionForUserIdAsync(
			request, messageTransformer, CancellationToken);
	}

	[Theory]
	[UserIdTooLongWithMessageData]
	public async Task GetAllAsync_ShouldThrowValidationException_WhenCurrentUserIdIsInvalid(
		IStringTransformer transformer, IStringMessageTransformer messageTransformer)
	{
		// Arrange
		var request = _requestBuilder.WithCurrentUserId(transformer).Build();

		// Assert
		await UserController.ShouldThrowInvalidValidationExceptionForCurrentUserIdAsync(
			request, messageTransformer, CancellationToken);
	}

	[Theory]
	[PostCommentLikesSortOrderEmptyWithMessageData]
	public async Task GetAllAsync_ShouldThrowValidationException_WhenSortOrderIsInvalid(
		IEnumTransformer<CommonSortOrder> transformer, IEnumMessageTransformer<CommonSortOrder> messageTransformer)
	{
		// Arrange
		var request = _requestBuilder.WithSortOrder(transformer).Build();

		// Assert
		await UserController.ShouldThrowInvalidValidationExceptionForSortOrderAsync(
			request, messageTransformer, CancellationToken);
	}

	[Theory]
	[PostCommentLikesForUserSortTermEmptyWithMessageData]
	public async Task GetAllAsync_ShouldThrowValidationException_WhenSortTermIsInvalid(
		IEnumTransformer<PostCommentLikesForUserSortTerm> transformer, IEnumMessageTransformer<PostCommentLikesForUserSortTerm> messageTransformer)
	{
		// Arrange
		var request = _requestBuilder.WithSortTerm(transformer).Build();

		// Assert
		await UserController.ShouldThrowInvalidValidationExceptionForSortTermAsync(
			request, messageTransformer, CancellationToken);
	}

	[Theory]
	[PostCommentLikePageTooSmallWithMessageData]
	[PostCommentLikePageTooLargeWithMessageData]
	public async Task GetAllAsync_ShouldThrowValidationException_WhenPageIsInvalid(
		IIntTransformer transformer, IIntMessageTransformer messageTransformer)
	{
		// Arrange
		var request = _requestBuilder.WithPage(transformer).Build();

		// Assert
		await UserController.ShouldThrowInvalidValidationExceptionForPageAsync(
			request, messageTransformer, CancellationToken);
	}

	[Theory]
	[PostCommentLikePageSizeTooSmallWithMessageData]
	[PostCommentLikePageSizeTooLargeWithMessageData]
	public async Task GetAllAsync_ShouldThrowValidationException_WhenPageSizeIsInvalid(
		IIntTransformer transformer, IIntMessageTransformer messageTransformer)
	{
		// Arrange
		var request = _requestBuilder.WithPageSize(transformer).Build();

		// Assert
		await UserController.ShouldThrowInvalidValidationExceptionForPageSizeAsync(
			request, messageTransformer, CancellationToken);
	}

	[Fact]
	public async Task GetAllAsync_ShouldThrowUserNotFoundException_WhenUserNotFound()
	{
		// Arrange
		await ServiceScope.DeleteAsync(User, CancellationToken);

		// Assert
		await UserController.ShouldThrowUserNotFoundExceptionAsync(_request, CancellationToken);
	}

	[Fact]
	public async Task GetAllAsync_ShouldReturnOkStatusCode_WhenRequestIsValid()
	{
		// Act
		var response = await UserController.GetAllAsync(_request, CancellationToken);

		// Assert
		response.ShouldBeActionResultWithOkStatusCode();
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task GetAllAsync_ShouldReturnOkStatusCode_WhenRequestAndUserIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithUserId(transformer).Build();

		// Act
		var response = await UserController.GetAllAsync(request, CancellationToken);

		// Assert
		response.ShouldBeActionResultWithOkStatusCode();
	}

	[Theory]
	[UserIdNullData]
	[UserIdEmptyData]
	[UserIdDifferentCaseData]
	public async Task GetAllAsync_ShouldReturnOkStatusCode_WhenRequestAndCurrentUserIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithCurrentUserId(transformer).Build();

		// Act
		var response = await UserController.GetAllAsync(request, CancellationToken);

		// Assert
		response.ShouldBeActionResultWithOkStatusCode();
	}

	[Theory]
	[PostCommentLikesSortOrderAscendingData]
	[PostCommentLikesSortOrderDescendingData]
	public async Task GetAllAsync_ShouldReturnOkStatusCode_WhenRequestAndSortOrderAreValid(
		IEnumTransformer<CommonSortOrder> transformer)
	{
		// Arrange
		var request = _requestBuilder.WithSortOrder(transformer).Build();

		// Act
		var response = await UserController.GetAllAsync(request, CancellationToken);

		// Assert
		response.ShouldBeActionResultWithOkStatusCode();
	}

	[Theory]
	[PostCommentLikesForUserSortTermCreatedAtData]
	[PostCommentLikesForUserSortTermUserNameData]
	public async Task GetAllAsync_ShouldReturnOkStatusCode_WhenRequestAndSortTermAreValid(
		IEnumTransformer<PostCommentLikesForUserSortTerm> transformer)
	{
		// Arrange
		var request = _requestBuilder.WithSortTerm(transformer).Build();

		// Act
		var response = await UserController.GetAllAsync(request, CancellationToken);

		// Assert
		response.ShouldBeActionResultWithOkStatusCode();
	}

	[Fact]
	public async Task GetAllAsync_ShouldReturnResponse_WhenRequestIsValid()
	{
		// Act
		var response = await UserController.GetAllAsync(_request, CancellationToken);

		// Assert
		response.ShouldSatisfy(_request, User, PostCommentLikes);
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task GetAllAsync_ShouldReturnResponse_WhenRequestAndUserIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithUserId(transformer).Build();

		// Act
		var response = await UserController.GetAllAsync(request, CancellationToken);

		// Assert
		response.ShouldSatisfy(request, User, PostCommentLikes);
	}

	[Theory]
	[UserIdNullData]
	[UserIdEmptyData]
	[UserIdDifferentCaseData]
	public async Task GetAllAsync_ShouldReturnResponse_WhenRequestAndCurrentUserIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithCurrentUserId(transformer).Build();

		// Act
		var response = await UserController.GetAllAsync(request, CancellationToken);

		// Assert
		response.ShouldSatisfy(request, User, PostCommentLikes);
	}

	[Theory]
	[PostCommentLikesSortOrderWithAscendingTermData]
	[PostCommentLikesSortOrderWithDescendingTermData]
	public async Task GetAllAsync_ShouldReturnResponse_WhenRequestAndSortOrderAreValid(
		IEnumTransformer<CommonSortOrder> transformer, ISortEnumTermTransformer<PostCommentLike> termTransformer)
	{
		// Arrange
		var request = _requestBuilder.WithSortOrder(transformer).Build();

		// Act
		var response = await UserController.GetAllAsync(request, CancellationToken);

		// Assert
		response.ShouldSatisfy(request, User, PostCommentLikes, termTransformer);
	}

	[Theory]
	[PostCommentLikesForUserSortTermWithCreatedAtTermData]
	[PostCommentLikesForUserSortTermWithUserNameTermData]
	public async Task GetAllAsync_ShouldReturnResponse_WhenRequestAndSortTermAreValid(
		IEnumTransformer<PostCommentLikesForUserSortTerm> transformer, ISortEnumTermTransformer<PostCommentLike> termTransformer)
	{
		// Arrange
		var request = _requestBuilder.WithSortTerm(transformer).Build();

		// Act
		var response = await UserController.GetAllAsync(request, CancellationToken);

		// Assert
		response.ShouldSatisfy(request, User, PostCommentLikes, termTransformer);
	}
}
