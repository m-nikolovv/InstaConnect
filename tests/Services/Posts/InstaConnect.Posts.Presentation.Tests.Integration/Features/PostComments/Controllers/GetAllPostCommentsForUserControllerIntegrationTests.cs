using InstaConnect.Common.Domain.Features.Requests.Models;
using InstaConnect.Common.Tests.Features.DataAttributes.Enums.Sort;

using InstaConnect.Posts.Domain.Features.PostComments.Models.Requests;

namespace InstaConnect.Posts.Presentation.Tests.Integration.Features.PostComments.Controllers;

public class GetAllPostCommentsForUserControllerIntegrationTests : BasePostCommentPresentationQueryIntegrationTest
{
	private readonly GetAllPostCommentsForUserApiRequestBuilderFactory _requestBuilderFactory;
	private readonly GetAllPostCommentsForUserApiRequestBuilder _requestBuilder;
	private readonly GetAllPostCommentsForUserApiRequest _request;

	public GetAllPostCommentsForUserControllerIntegrationTests(PostsWebApplicationFactory webApplicationFactory)
		: base(webApplicationFactory)
	{
		_requestBuilderFactory = new();
		_requestBuilder = _requestBuilderFactory.Create(PostComment);
		_request = _requestBuilder.Build();
	}

	protected override async Task OnInitializeAsync()
	{
		await ServiceScope.AddRangeAsync(PostComments, CancellationToken);
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
	[PostCommentsSortOrderEmptyWithMessageData]
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
	[PostCommentsForUserSortTermEmptyWithMessageData]
	public async Task GetAllAsync_ShouldThrowValidationException_WhenSortTermIsInvalid(
		IEnumTransformer<PostCommentsForUserSortTerm> transformer, IEnumMessageTransformer<PostCommentsForUserSortTerm> messageTransformer)
	{
		// Arrange
		var request = _requestBuilder.WithSortTerm(transformer).Build();

		// Assert
		await UserController.ShouldThrowInvalidValidationExceptionForSortTermAsync(
			request, messageTransformer, CancellationToken);
	}

	[Theory]
	[PostCommentPageTooSmallWithMessageData]
	[PostCommentPageTooLargeWithMessageData]
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
	[PostCommentPageSizeTooSmallWithMessageData]
	[PostCommentPageSizeTooLargeWithMessageData]
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
	[PostCommentsSortOrderAscendingData]
	[PostCommentsSortOrderDescendingData]
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
	[PostCommentsForUserSortTermCreatedAtData]
	[PostCommentsForUserSortTermUserNameData]
	public async Task GetAllAsync_ShouldReturnOkStatusCode_WhenRequestAndSortTermAreValid(
		IEnumTransformer<PostCommentsForUserSortTerm> transformer)
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
		response.ShouldSatisfy(_request, User, PostComments);
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
		response.ShouldSatisfy(request, User, PostComments);
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
		response.ShouldSatisfy(request, User, PostComments);
	}

	[Theory]
	[PostCommentsSortOrderWithAscendingTermData]
	[PostCommentsSortOrderWithDescendingTermData]
	public async Task GetAllAsync_ShouldReturnResponse_WhenRequestAndSortOrderAreValid(
		IEnumTransformer<CommonSortOrder> transformer, ISortEnumTermTransformer<PostComment> termTransformer)
	{
		// Arrange
		var request = _requestBuilder.WithSortOrder(transformer).Build();

		// Act
		var response = await UserController.GetAllAsync(request, CancellationToken);

		// Assert
		response.ShouldSatisfy(request, User, PostComments, termTransformer);
	}

	[Theory]
	[PostCommentsForUserSortTermWithCreatedAtTermData]
	[PostCommentsForUserSortTermWithUserNameTermData]
	public async Task GetAllAsync_ShouldReturnResponse_WhenRequestAndSortTermAreValid(
		IEnumTransformer<PostCommentsForUserSortTerm> transformer, ISortEnumTermTransformer<PostComment> termTransformer)
	{
		// Arrange
		var request = _requestBuilder.WithSortTerm(transformer).Build();

		// Act
		var response = await UserController.GetAllAsync(request, CancellationToken);

		// Assert
		response.ShouldSatisfy(request, User, PostComments, termTransformer);
	}
}
