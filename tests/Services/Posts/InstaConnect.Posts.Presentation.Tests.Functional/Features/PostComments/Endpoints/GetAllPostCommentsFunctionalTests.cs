using InstaConnect.Common.Domain.Features.Requests.Models;
using InstaConnect.Common.Tests.Features.DataAttributes.Enums.Sort;
using InstaConnect.Posts.Domain.Features.PostComments.Models.Requests;

namespace InstaConnect.Posts.Presentation.Tests.Functional.Features.PostComments.Endpoints;

public class GetAllPostCommentsFunctionalTests : BasePostCommentPresentationQueryFunctionalTest
{
	private readonly GetAllPostCommentsApiRequestBuilderFactory _requestBuilderFactory;
	private readonly GetAllPostCommentsApiRequestBuilder _requestBuilder;
	private readonly GetAllPostCommentsApiRequest _request;

	public GetAllPostCommentsFunctionalTests(PostsWebApplicationFactory webApplicationFactory)
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
	[PostIdTooShortData]
	[PostIdTooLongData]
	public async Task GetAllAsync_ShouldHaveBadRequestStatusCode_WhenIdIsInvalid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithId(transformer).Build();

		// Act
		var response = await CommentApiClient.GetAllStatusCodeAsync(request, CancellationToken);

		// Assert
		response.ShouldBeBadRequest();
	}

	[Theory]
	[PostIdTooShortWithMessageData]
	[PostIdTooLongWithMessageData]
	public async Task GetAllAsync_ShouldHaveBadRequestProblemDetails_WhenIdIsInvalid(
		IStringTransformer transformer, IStringMessageTransformer messageTransformer)
	{
		// Arrange
		var request = _requestBuilder.WithId(transformer).Build();

		// Act
		var response = await CommentApiClient.GetAllProblemDetailsAsync(request, CancellationToken);

		// Assert
		response.ShouldSatisfyInvalidValidationForId(request, messageTransformer);
	}

	[Theory]
	[UserNameTooLongData]
	public async Task GetAllAsync_ShouldHaveBadRequestStatusCode_WhenUserNameIsInvalid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithUserName(transformer).Build();

		// Act
		var response = await CommentApiClient.GetAllStatusCodeAsync(request, CancellationToken);

		// Assert
		response.ShouldBeBadRequest();
	}

	[Theory]
	[UserNameTooLongWithMessageData]
	public async Task GetAllAsync_ShouldHaveBadRequestProblemDetails_WhenUserNameIsInvalid(
		IStringTransformer transformer, IStringMessageTransformer messageTransformer)
	{
		// Arrange
		var request = _requestBuilder.WithUserName(transformer).Build();

		// Act
		var response = await CommentApiClient.GetAllProblemDetailsAsync(request, CancellationToken);

		// Assert
		response.ShouldSatisfyInvalidValidationForUserName(request, messageTransformer);
	}

	[Theory]
	[UserIdTooLongData]
	public async Task GetAllAsync_ShouldHaveBadRequestStatusCode_WhenCurrentUserIdIsInvalid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithCurrentUserId(transformer).Build();

		// Act
		var response = await CommentApiClient.GetAllStatusCodeAsync(request, CancellationToken);

		// Assert
		response.ShouldBeBadRequest();
	}

	[Theory]
	[UserIdTooLongWithMessageData]
	public async Task GetAllAsync_ShouldHaveBadRequestProblemDetails_WhenCurrentUserIdIsInvalid(
		IStringTransformer transformer, IStringMessageTransformer messageTransformer)
	{
		// Arrange
		var request = _requestBuilder.WithCurrentUserId(transformer).Build();

		// Act
		var response = await CommentApiClient.GetAllProblemDetailsAsync(request, CancellationToken);

		// Assert
		response.ShouldSatisfyInvalidValidationForCurrentUserId(request, messageTransformer);
	}

	[Theory]
	[PostCommentsSortOrderEmptyData]
	public async Task GetAllAsync_ShouldHaveBadRequestStatusCode_WhenSortOrderIsInvalid(
		IEnumTransformer<CommonSortOrder> transformer)
	{
		// Arrange
		var request = _requestBuilder.WithSortOrder(transformer).Build();

		// Act
		var response = await CommentApiClient.GetAllStatusCodeAsync(request, CancellationToken);

		// Assert
		response.ShouldBeBadRequest();
	}

	[Theory]
	[PostCommentsSortOrderEmptyWithMessageData]
	public async Task GetAllAsync_ShouldHaveBadRequestProblemDetails_WhenSortOrderIsInvalid(
		IEnumTransformer<CommonSortOrder> transformer,
		IEnumMessageTransformer<CommonSortOrder> messageTransformer)
	{
		// Arrange
		var request = _requestBuilder.WithSortOrder(transformer).Build();

		// Act
		var response = await CommentApiClient.GetAllProblemDetailsAsync(request, CancellationToken);

		// Assert
		response.ShouldSatisfyInvalidValidationForSortOrder(request, messageTransformer);
	}

	[Theory]
	[PostCommentsSortTermEmptyData]
	public async Task GetAllAsync_ShouldHaveBadRequestStatusCode_WhenSortTermIsInvalid(
		IEnumTransformer<PostCommentsSortTerm> transformer)
	{
		// Arrange
		var request = _requestBuilder.WithSortTerm(transformer).Build();

		// Act
		var response = await CommentApiClient.GetAllStatusCodeAsync(request, CancellationToken);

		// Assert
		response.ShouldBeBadRequest();
	}

	[Theory]
	[PostCommentsSortTermEmptyWithMessageData]
	public async Task GetAllAsync_ShouldHaveBadRequestProblemDetails_WhenSortTermIsInvalid(
		IEnumTransformer<PostCommentsSortTerm> transformer,
		IEnumMessageTransformer<PostCommentsSortTerm> messageTransformer)
	{
		// Arrange
		var request = _requestBuilder.WithSortTerm(transformer).Build();

		// Act
		var response = await CommentApiClient.GetAllProblemDetailsAsync(request, CancellationToken);

		// Assert
		response.ShouldSatisfyInvalidValidationForSortTerm(request, messageTransformer);
	}

	[Theory]
	[PostCommentPageTooSmallData]
	[PostCommentPageTooLargeData]
	public async Task GetAllAsync_ShouldHaveBadRequestStatusCode_WhenPageIsInvalid(
		IIntTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithPage(transformer).Build();

		// Act
		var response = await CommentApiClient.GetAllStatusCodeAsync(request, CancellationToken);

		// Assert
		response.ShouldBeBadRequest();
	}

	[Theory]
	[PostCommentPageTooSmallWithMessageData]
	[PostCommentPageTooLargeWithMessageData]
	public async Task GetAllAsync_ShouldHaveBadRequestProblemDetails_WhenPageIsInvalid(
		IIntTransformer transformer, IIntMessageTransformer messageTransformer)
	{
		// Arrange
		var request = _requestBuilder.WithPage(transformer).Build();

		// Act
		var response = await CommentApiClient.GetAllProblemDetailsAsync(request, CancellationToken);

		// Assert
		response.ShouldSatisfyInvalidValidationForPage(request, messageTransformer);
	}

	[Theory]
	[PostCommentPageSizeTooSmallData]
	[PostCommentPageSizeTooLargeData]
	public async Task GetAllAsync_ShouldHaveBadRequestStatusCode_WhenPageSizeIsInvalid(
		IIntTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithPageSize(transformer).Build();

		// Act
		var response = await CommentApiClient.GetAllStatusCodeAsync(request, CancellationToken);

		// Assert
		response.ShouldBeBadRequest();
	}

	[Theory]
	[PostCommentPageSizeTooSmallWithMessageData]
	[PostCommentPageSizeTooLargeWithMessageData]
	public async Task GetAllAsync_ShouldHaveBadRequestProblemDetails_WhenPageSizeIsInvalid(
		IIntTransformer transformer, IIntMessageTransformer messageTransformer)
	{
		// Arrange
		var request = _requestBuilder.WithPageSize(transformer).Build();

		// Act
		var response = await CommentApiClient.GetAllProblemDetailsAsync(request, CancellationToken);

		// Assert
		response.ShouldSatisfyInvalidValidationForPageSize(request, messageTransformer);
	}

	[Fact]
	public async Task GetAllAsync_ShouldHaveNotFoundStatusCode_WhenPostNotFound()
	{
		// Arrange
		await ServiceScope.DeleteAsync(Post, CancellationToken);

		// Act
		var response = await CommentApiClient.GetAllStatusCodeAsync(_request, CancellationToken);

		// Assert
		response.ShouldBeNotFound();
	}

	[Fact]
	public async Task GetAllAsync_ShouldHaveOkStatusCode_WhenRequestIsValid()
	{
		// Act
		var response = await CommentApiClient.GetAllStatusCodeAsync(_request, CancellationToken);

		// Assert
		response.ShouldBeOk();
	}

	[Theory]
	[PostIdDifferentCaseData]
	public async Task GetAllAsync_ShouldHaveOkStatusCode_WhenRequestAndIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithId(transformer).Build();

		// Act
		var response = await CommentApiClient.GetAllStatusCodeAsync(request, CancellationToken);

		// Assert
		response.ShouldBeOk();
	}

	[Theory]
	[UserNameNullData]
	[UserNameEmptyData]
	[UserNameDifferentCaseData]
	public async Task GetAllAsync_ShouldHaveOkStatusCode_WhenRequestAndUserNameAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithUserName(transformer).Build();

		// Act
		var response = await CommentApiClient.GetAllStatusCodeAsync(request, CancellationToken);

		// Assert
		response.ShouldBeOk();
	}

	[Theory]
	[UserIdEmptyData]
	[UserIdDifferentCaseData]
	public async Task GetAllAsync_ShouldHaveOkStatusCode_WhenRequestAndCurrentUserIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithCurrentUserId(transformer).Build();

		// Act
		var response = await CommentApiClient.GetAllStatusCodeAsync(request, CancellationToken);

		// Assert
		response.ShouldBeOk();
	}

	[Theory]
	[PostCommentsSortOrderAscendingData]
	[PostCommentsSortOrderDescendingData]
	public async Task GetAllAsync_ShouldHaveOkStatusCode_WhenRequestAndSortOrderAreValid(
		IEnumTransformer<CommonSortOrder> transformer)
	{
		// Arrange
		var request = _requestBuilder.WithSortOrder(transformer).Build();

		// Act
		var response = await CommentApiClient.GetAllStatusCodeAsync(request, CancellationToken);

		// Assert
		response.ShouldBeOk();
	}

	[Theory]
	[PostCommentsSortTermCreatedAtData]
	[PostCommentsSortTermUserNameData]
	public async Task GetAllAsync_ShouldHaveOkStatusCode_WhenRequestAndSortTermAreValid(
		IEnumTransformer<PostCommentsSortTerm> transformer)
	{
		// Arrange
		var request = _requestBuilder.WithSortTerm(transformer).Build();

		// Act
		var response = await CommentApiClient.GetAllStatusCodeAsync(request, CancellationToken);

		// Assert
		response.ShouldBeOk();
	}

	[Fact]
	public async Task GetAllAsync_ShouldReturnResponse_WhenRequestIsValid()
	{
		// Act
		var response = await CommentApiClient.GetAllAsync(_request, CancellationToken);

		// Assert
		response.ShouldSatisfy(_request, Post, PostComments);
	}

	[Theory]
	[PostIdDifferentCaseData]
	public async Task GetAllAsync_ShouldReturnResponse_WhenRequestAndIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithId(transformer).Build();

		// Act
		var response = await CommentApiClient.GetAllAsync(request, CancellationToken);

		// Assert
		response.ShouldSatisfy(request, Post, PostComments);
	}

	[Theory]
	[UserNameNullData]
	[UserNameEmptyData]
	[UserNameDifferentCaseData]
	public async Task GetAllAsync_ShouldReturnResponse_WhenRequestAndUserNameAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithUserName(transformer).Build();

		// Act
		var response = await CommentApiClient.GetAllAsync(request, CancellationToken);

		// Assert
		response.ShouldSatisfy(request, Post, PostComments);
	}

	[Theory]
	[UserIdEmptyData]
	[UserIdDifferentCaseData]
	public async Task GetAllAsync_ShouldReturnResponse_WhenRequestAndCurrentUserIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithCurrentUserId(transformer).Build();

		// Act
		var response = await CommentApiClient.GetAllAsync(request, CancellationToken);

		// Assert
		response.ShouldSatisfy(request, Post, PostComments);
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
		var response = await CommentApiClient.GetAllAsync(request, CancellationToken);

		// Assert
		response.ShouldSatisfy(request, Post, PostComments, termTransformer);
	}

	[Theory]
	[PostCommentsSortTermWithCreatedAtTermData]
	[PostCommentsSortTermWithUserNameTermData]
	public async Task GetAllAsync_ShouldReturnResponse_WhenRequestAndSortTermAreValid(
		IEnumTransformer<PostCommentsSortTerm> transformer, ISortEnumTermTransformer<PostComment> termTransformer)
	{
		// Arrange
		var request = _requestBuilder.WithSortTerm(transformer).Build();

		// Act
		var response = await CommentApiClient.GetAllAsync(request, CancellationToken);

		// Assert
		response.ShouldSatisfy(request, Post, PostComments, termTransformer);
	}
}
