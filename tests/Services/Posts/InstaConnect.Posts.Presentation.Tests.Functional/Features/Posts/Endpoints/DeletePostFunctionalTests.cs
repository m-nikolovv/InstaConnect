using InstaConnect.Posts.Tests.Features.PostCommentImages.Utilities;
using InstaConnect.Posts.Tests.Features.Users.Builders;

namespace InstaConnect.Posts.Presentation.Tests.Functional.Features.Posts.Endpoints;

public class DeletePostFunctionalTests : BasePostPresentationCommandFunctionalTest
{
	private readonly DeletePostApiRequestBuilderFactory _requestBuilderFactory;
	private readonly DeletePostApiRequestBuilder _requestBuilder;
	private readonly DeletePostApiRequest _request;

	public DeletePostFunctionalTests(PostsWebApplicationFactory webApplicationFactory)
		: base(webApplicationFactory)
	{
		_requestBuilderFactory = new();
		_requestBuilder = _requestBuilderFactory.Create(Post);
		_request = _requestBuilder.Build();
	}

	protected override async Task OnInitializeAsync()
	{
		await ServiceScope.AddAsync(Post, CancellationToken);
		await ServiceScope.AddRangeAsync(PostImages, CancellationToken);
		await ServiceScope.AddRangeAsync(PostLikes, CancellationToken);
		await ServiceScope.AddRangeAsync(PostComments, CancellationToken);
		await ServiceScope.AddRangeAsync(PostCommentImages, CancellationToken);
		await ServiceScope.AddRangeAsync(PostCommentLikes, CancellationToken);
	}

	[Fact]
	public async Task DeleteAsync_ShouldReturnUnauthorizedStatusCode_WhenRequestIsUnauthorized()
	{
		// Act
		var response = await ApiClient.DeleteUnauthorizedStatusCodeAsync(_request, CancellationToken);

		// Assert
		response.ShouldBeUnauthorized();
	}

	[Theory]
	[PostIdTooShortData]
	[PostIdTooLongData]
	public async Task DeleteAsync_ShouldHaveBadRequestStatusCode_WhenIdIsInvalid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithId(transformer).Build();

		// Act
		var response = await ApiClient.DeleteStatusCodeAsync(request, CancellationToken);

		// Assert
		response.ShouldBeBadRequest();
	}

	[Theory]
	[PostIdTooShortWithMessageData]
	[PostIdTooLongWithMessageData]
	public async Task DeleteAsync_ShouldHaveBadRequestProblemDetails_WhenIdIsInvalid(
		IStringTransformer transformer, IStringMessageTransformer messageTransformer)
	{
		// Arrange
		var request = _requestBuilder.WithId(transformer).Build();

		// Act
		var response = await ApiClient.DeleteProblemDetailsAsync(request, CancellationToken);

		// Assert
		response.ShouldSatisfyInvalidValidationForId(request, messageTransformer);
	}

	[Theory]
	[UserIdEmptyData]
	[UserIdTooShortData]
	[UserIdTooLongData]
	public async Task DeleteAsync_ShouldHaveBadRequestStatusCode_WhenUserIdIsInvalid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithUserId(transformer).Build();

		// Act
		var response = await ApiClient.DeleteStatusCodeAsync(request, CancellationToken);

		// Assert
		response.ShouldBeBadRequest();
	}

	[Theory]
	[UserIdEmptyWithMessageData]
	[UserIdTooShortWithMessageData]
	[UserIdTooLongWithMessageData]
	public async Task DeleteAsync_ShouldHaveBadRequestProblemDetails_WhenUserIdIsInvalid(
		IStringTransformer transformer, IStringMessageTransformer messageTransformer)
	{
		// Arrange
		var request = _requestBuilder.WithUserId(transformer).Build();

		// Act
		var response = await ApiClient.DeleteProblemDetailsAsync(request, CancellationToken);

		// Assert
		response.ShouldSatisfyInvalidValidationForUserId(request, messageTransformer);
	}

	[Fact]
	public async Task DeleteAsync_ShouldHaveNotFoundStatusCode_WhenPostNotFound()
	{
		// Arrange
		await ServiceScope.DeleteAsync(Post, CancellationToken);

		// Act
		var response = await ApiClient.DeleteStatusCodeAsync(_request, CancellationToken);

		// Assert
		response.ShouldBeNotFound();
	}

	[Fact]
	public async Task DeleteAsync_ShouldHavePostNotFoundProblemDetails_WhenPostNotFound()
	{
		// Arrange
		await ServiceScope.DeleteAsync(Post, CancellationToken);

		// Act
		var response = await ApiClient.DeleteProblemDetailsAsync(_request, CancellationToken);

		// Assert
		response.ShouldSatisfyPostNotFound(_request);
	}

	[Fact]
	public async Task DeleteAsync_ShouldHaveForbiddenStatusCode_WhenPostForbidden()
	{
		// Arrange
		var user = UserBuilderFactory.Create().Build();
		await ServiceScope.AddAsync(user, CancellationToken);
		var request = _requestBuilder.WithUserId(user.Id).Build();

		// Act
		var response = await ApiClient.DeleteStatusCodeAsync(request, CancellationToken);

		// Assert
		response.ShouldBeForbidden();
	}

	[Fact]
	public async Task DeleteAsync_ShouldHavePostForbiddenProblemDetails_WhenPostForbidden()
	{
		// Arrange
		var user = UserBuilderFactory.Create().Build();
		await ServiceScope.AddAsync(user, CancellationToken);
		var request = _requestBuilder.WithUserId(user.Id).Build();

		// Act
		var response = await ApiClient.DeleteProblemDetailsAsync(request, CancellationToken);

		// Assert
		response.ShouldSatisfyPostForbidden(request);
	}

	[Fact]
	public async Task DeleteAsync_ShouldHaveNoContentStatusCode_WhenRequestIsValid()
	{
		// Act
		var response = await ApiClient.DeleteStatusCodeAsync(_request, CancellationToken);

		// Assert
		response.ShouldBeNoContent();
	}

	[Theory]
	[PostIdDifferentCaseData]
	public async Task DeleteAsync_ShouldHaveNoContentStatusCode_WhenRequestAndIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithId(transformer).Build();

		// Act
		var response = await ApiClient.DeleteStatusCodeAsync(request, CancellationToken);

		// Assert
		response.ShouldBeNoContent();
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task DeleteAsync_ShouldHaveNoContentStatusCode_WhenRequestAndUserIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithUserId(transformer).Build();

		// Act
		var response = await ApiClient.DeleteStatusCodeAsync(request, CancellationToken);

		// Assert
		response.ShouldBeNoContent();
	}

	[Fact]
	public async Task DeleteAsync_ShouldDeletePost_WhenRequestIsValid()
	{
		// Act
		await ApiClient.DeleteAsync(_request, CancellationToken);
		var post = await ServiceScope.GetByIdAsync(PostId, CancellationToken);

		// Assert
		post.ShouldBeNull();
	}

	[Theory]
	[PostIdDifferentCaseData]
	public async Task DeleteAsync_ShouldDeletePost_WhenRequestAndIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithId(transformer).Build();

		// Act
		await ApiClient.DeleteAsync(request, CancellationToken);
		var post = await ServiceScope.GetByIdAsync(PostId, CancellationToken);

		// Assert
		post.ShouldBeNull();
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task DeleteAsync_ShouldDeletePost_WhenRequestAndUserIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithUserId(transformer).Build();

		// Act
		await ApiClient.DeleteAsync(request, CancellationToken);
		var post = await ServiceScope.GetByIdAsync(PostId, CancellationToken);

		// Assert
		post.ShouldBeNull();
	}

	[Fact]
	public async Task DeleteAsync_ShouldDeletePostPostImages_WhenRequestIsValid()
	{
		// Act
		await ApiClient.DeleteAsync(_request, CancellationToken);
		var postPostImages = await ServiceScope.GetByIdRangeAsync(PostPostImageIds, CancellationToken);

		// Assert
		postPostImages.ShouldBeEmpty();
	}

	[Theory]
	[PostIdDifferentCaseData]
	public async Task DeleteAsync_ShouldDeletePostPostImages_WhenRequestAndIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithId(transformer).Build();

		// Act
		await ApiClient.DeleteAsync(request, CancellationToken);
		var postPostImages = await ServiceScope.GetByIdRangeAsync(PostPostImageIds, CancellationToken);

		// Assert
		postPostImages.ShouldBeEmpty();
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task DeleteAsync_ShouldDeletePostPostImages_WhenRequestAndUserIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithUserId(transformer).Build();

		// Act
		await ApiClient.DeleteAsync(request, CancellationToken);
		var postPostImages = await ServiceScope.GetByIdRangeAsync(PostPostImageIds, CancellationToken);

		// Assert
		postPostImages.ShouldBeEmpty();
	}

	[Fact]
	public async Task DeleteAsync_ShouldDeletePostPostLikes_WhenRequestIsValid()
	{
		// Act
		await ApiClient.DeleteAsync(_request, CancellationToken);
		var postPostLikes = await ServiceScope.GetByIdRangeAsync(PostPostLikeIds, CancellationToken);

		// Assert
		postPostLikes.ShouldBeEmpty();
	}

	[Theory]
	[PostIdDifferentCaseData]
	public async Task DeleteAsync_ShouldDeletePostPostLikes_WhenRequestAndIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithId(transformer).Build();

		// Act
		await ApiClient.DeleteAsync(request, CancellationToken);
		var postPostLikes = await ServiceScope.GetByIdRangeAsync(PostPostLikeIds, CancellationToken);

		// Assert
		postPostLikes.ShouldBeEmpty();
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task DeleteAsync_ShouldDeletePostPostLikes_WhenRequestAndUserIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithUserId(transformer).Build();

		// Act
		await ApiClient.DeleteAsync(request, CancellationToken);
		var postPostLikes = await ServiceScope.GetByIdRangeAsync(PostPostLikeIds, CancellationToken);

		// Assert
		postPostLikes.ShouldBeEmpty();
	}

	[Fact]
	public async Task DeleteAsync_ShouldDeletePostPostComments_WhenRequestIsValid()
	{
		// Act
		await ApiClient.DeleteAsync(_request, CancellationToken);
		var postPostComments = await ServiceScope.GetByIdRangeAsync(PostPostCommentIds, CancellationToken);

		// Assert
		postPostComments.ShouldBeEmpty();
	}

	[Theory]
	[PostIdDifferentCaseData]
	public async Task DeleteAsync_ShouldDeletePostPostComments_WhenRequestAndIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithId(transformer).Build();

		// Act
		await ApiClient.DeleteAsync(request, CancellationToken);
		var postPostComments = await ServiceScope.GetByIdRangeAsync(PostPostCommentIds, CancellationToken);

		// Assert
		postPostComments.ShouldBeEmpty();
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task DeleteAsync_ShouldDeletePostPostComments_WhenRequestAndUserIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithUserId(transformer).Build();

		// Act
		await ApiClient.DeleteAsync(request, CancellationToken);
		var postPostComments = await ServiceScope.GetByIdRangeAsync(PostPostCommentIds, CancellationToken);

		// Assert
		postPostComments.ShouldBeEmpty();
	}

	[Fact]
	public async Task DeleteAsync_ShouldDeletePostPostCommentsPostCommentImages_WhenRequestIsValid()
	{
		// Act
		await ApiClient.DeleteAsync(_request, CancellationToken);
		var postPostCommentsPostCommentImages = await ServiceScope.GetByIdRangeAsync(PostPostCommentsPostCommentImageIds, CancellationToken);

		// Assert
		postPostCommentsPostCommentImages.ShouldBeEmpty();
	}

	[Theory]
	[PostIdDifferentCaseData]
	public async Task DeleteAsync_ShouldDeletePostPostCommentsPostCommentImages_WhenRequestAndIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithId(transformer).Build();

		// Act
		await ApiClient.DeleteAsync(request, CancellationToken);
		var postPostCommentsPostCommentImages = await ServiceScope.GetByIdRangeAsync(PostPostCommentsPostCommentImageIds, CancellationToken);

		// Assert
		postPostCommentsPostCommentImages.ShouldBeEmpty();
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task DeleteAsync_ShouldDeletePostPostCommentsPostCommentImages_WhenRequestAndUserIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithUserId(transformer).Build();

		// Act
		await ApiClient.DeleteAsync(request, CancellationToken);
		var postPostCommentsPostCommentImages = await ServiceScope.GetByIdRangeAsync(PostPostCommentsPostCommentImageIds, CancellationToken);

		// Assert
		postPostCommentsPostCommentImages.ShouldBeEmpty();
	}

	[Fact]
	public async Task DeleteAsync_ShouldDeletePostPostCommentsPostCommentLikes_WhenRequestIsValid()
	{
		// Act
		await ApiClient.DeleteAsync(_request, CancellationToken);
		var postPostCommentsPostCommentLikes = await ServiceScope.GetByIdRangeAsync(PostPostCommentsPostCommentLikeIds, CancellationToken);

		// Assert
		postPostCommentsPostCommentLikes.ShouldBeEmpty();
	}

	[Theory]
	[PostIdDifferentCaseData]
	public async Task DeleteAsync_ShouldDeletePostPostCommentsPostCommentLikes_WhenRequestAndIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithId(transformer).Build();

		// Act
		await ApiClient.DeleteAsync(request, CancellationToken);
		var postPostCommentsPostCommentLikes = await ServiceScope.GetByIdRangeAsync(PostPostCommentsPostCommentLikeIds, CancellationToken);

		// Assert
		postPostCommentsPostCommentLikes.ShouldBeEmpty();
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task DeleteAsync_ShouldDeletePostPostCommentsPostCommentLikes_WhenRequestAndUserIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithUserId(transformer).Build();

		// Act
		await ApiClient.DeleteAsync(request, CancellationToken);
		var postPostCommentsPostCommentLikes = await ServiceScope.GetByIdRangeAsync(PostPostCommentsPostCommentLikeIds, CancellationToken);

		// Assert
		postPostCommentsPostCommentLikes.ShouldBeEmpty();
	}

	[Fact]
	public async Task DeleteAsync_ShouldPublishPostDeletedEvent_WhenRequestIsValid()
	{
		// Act
		await ApiClient.DeleteAsync(_request, CancellationToken);

		var eventRequest = await EventClient.PublishedDeletedAsync(CancellationToken);

		// Assert
		eventRequest.ShouldSatisfy(_request, Post);
	}

	[Theory]
	[PostIdDifferentCaseData]
	public async Task DeleteAsync_ShouldPublishPostDeletedEvent_WhenRequestAndIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithId(transformer).Build();

		// Act
		await ApiClient.DeleteAsync(request, CancellationToken);

		var eventRequest = await EventClient.PublishedDeletedAsync(CancellationToken);

		// Assert
		eventRequest.ShouldSatisfy(request, Post);
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task DeleteAsync_ShouldPublishPostDeletedEvent_WhenRequestAndUserIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithUserId(transformer).Build();

		// Act
		await ApiClient.DeleteAsync(request, CancellationToken);

		var eventRequest = await EventClient.PublishedDeletedAsync(CancellationToken);

		// Assert
		eventRequest.ShouldSatisfy(request, Post);
	}
}
