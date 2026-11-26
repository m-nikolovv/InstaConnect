using InstaConnect.Posts.Application.Features.PostCommentLikes.Commands.Delete;

namespace InstaConnect.Posts.Application.Tests.Integration.Features.PostCommentLikes.Handlers;

public class DeletePostCommentLikeCommandHandlerIntegrationTests : BasePostCommentLikeApplicationCommandIntegrationTest
{
	private readonly DeletePostCommentLikeCommandRequestBuilderFactory _requestBuilderFactory;
	private readonly DeletePostCommentLikeCommandRequestBuilder _requestBuilder;
	private readonly DeletePostCommentLikeCommandRequest _request;

	public DeletePostCommentLikeCommandHandlerIntegrationTests(PostsWebApplicationFactory webApplicationFactory)
		: base(webApplicationFactory)
	{
		_requestBuilderFactory = new();
		_requestBuilder = _requestBuilderFactory.Create(PostCommentLike);
		_request = _requestBuilder.Build();
	}

	public override async Task InitializeAsync()
	{
		await ServiceScope.InitializeDeleteAsync(_request, PostCommentLike, CancellationToken);
		await base.InitializeAsync();
	}

	public override async Task DisposeAsync()
	{
		await ServiceScope.DisposeDeleteAsync(_request, PostCommentLike, CancellationToken);
		await base.DisposeAsync();
	}

	[Theory]
	[PostIdNullWithMessageData]
	[PostIdEmptyWithMessageData]
	[PostIdTooShortWithMessageData]
	[PostIdTooLongWithMessageData]
	public async Task SendAsync_ShouldThrowValidationException_WhenIdIsInvalid(
		IStringTransformer transformer, IStringMessageTransformer messageTransformer)
	{
		// Arrange
		var request = _requestBuilder.WithId(transformer).Build();

		// Assert
		await Sender.ShouldThrowInvalidValidationExceptionForIdAsync(
			request, messageTransformer, CancellationToken);
	}

	[Theory]
	[PostCommentIdNullWithMessageData]
	[PostCommentIdEmptyWithMessageData]
	[PostCommentIdTooShortWithMessageData]
	[PostCommentIdTooLongWithMessageData]
	public async Task SendAsync_ShouldThrowValidationException_WhenCommentIdIsInvalid(
		IStringTransformer transformer, IStringMessageTransformer messageTransformer)
	{
		// Arrange
		var request = _requestBuilder.WithCommentId(transformer).Build();

		// Assert
		await Sender.ShouldThrowInvalidValidationExceptionForCommentIdAsync(
			request, messageTransformer, CancellationToken);
	}

	[Theory]
	[UserIdNullWithMessageData]
	[UserIdEmptyWithMessageData]
	[UserIdTooShortWithMessageData]
	[UserIdTooLongWithMessageData]
	public async Task SendAsync_ShouldThrowValidationException_WhenUserIdIsInvalid(
		IStringTransformer transformer, IStringMessageTransformer messageTransformer)
	{
		// Arrange
		var request = _requestBuilder.WithUserId(transformer).Build();

		// Assert
		await Sender.ShouldThrowInvalidValidationExceptionForUserIdAsync(
			request, messageTransformer, CancellationToken);
	}

	[Fact]
	public async Task SendAsync_ShouldThrowPostNotFoundException_WhenPostNotFound()
	{
		// Arrange
		await ServiceScope.DeleteAsync(Post, CancellationToken);

		// Assert
		await Sender.ShouldThrowPostNotFoundExceptionAsync(_request, CancellationToken);
	}

	[Fact]
	public async Task SendAsync_ShouldThrowPostCommentNotFoundException_WhenPostCommentNotFound()
	{
		// Arrange
		await ServiceScope.DeleteAsync(PostComment, CancellationToken);

		// Assert
		await Sender.ShouldThrowPostCommentNotFoundExceptionAsync(_request, CancellationToken);
	}

	[Fact]
	public async Task SendAsync_ShouldThrowPostCommentLikeNotFoundException_WhenPostCommentLikeNotFound()
	{
		// Arrange
		await ServiceScope.DeleteAsync(PostCommentLike, CancellationToken);

		// Assert
		await Sender.ShouldThrowPostCommentLikeNotFoundExceptionAsync(_request, CancellationToken);
	}

	[Fact]
	public async Task SendAsync_ShouldDeletePostCommentLike_WhenRequestIsValid()
	{
		// Act
		await Sender.SendAsync(_request, CancellationToken);
		var postCommentLike = await ServiceScope.GetByIdAsync(PostCommentLikeId, CancellationToken);

		// Assert
		postCommentLike.ShouldBeNull();
	}

	[Theory]
	[PostIdDifferentCaseData]
	public async Task SendAsync_ShouldDeletePostCommentLike_WhenRequestAndIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithId(transformer).Build();

		// Act
		await Sender.SendAsync(request, CancellationToken);
		var postCommentLike = await ServiceScope.GetByIdAsync(PostCommentLikeId, CancellationToken);

		// Assert
		postCommentLike.ShouldBeNull();
	}

	[Theory]
	[PostCommentIdDifferentCaseData]
	public async Task SendAsync_ShouldDeletePostCommentLike_WhenRequestAndCommentIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithCommentId(transformer).Build();

		// Act
		await Sender.SendAsync(request, CancellationToken);
		var postCommentLike = await ServiceScope.GetByIdAsync(PostCommentLikeId, CancellationToken);

		// Assert
		postCommentLike.ShouldBeNull();
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task SendAsync_ShouldDeletePostCommentLike_WhenRequestAndUserIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithUserId(transformer).Build();

		// Act
		await Sender.SendAsync(request, CancellationToken);
		var postCommentLike = await ServiceScope.GetByIdAsync(PostCommentLikeId, CancellationToken);

		// Assert
		postCommentLike.ShouldBeNull();
	}

	[Fact]
	public async Task SendAsync_ShouldDeleteCachedPostCommentLike_WhenRequestIsValid()
	{
		// Act
		await Sender.SendAsync(_request, CancellationToken);
		var cachedPostCommentLike = await ServiceScope.GetPostCommentLikeCacheByIdAsync(_request, CancellationToken);

		// Assert
		cachedPostCommentLike.ShouldBeNull();
	}

	[Theory]
	[PostIdDifferentCaseData]
	public async Task SendAsync_ShouldDeleteCachedPostCommentLike_WhenRequestAndIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithId(transformer).Build();
		await ServiceScope.AddPostCommentLikeCacheAsync(request, PostCommentLike, CancellationToken);

		// Act
		await Sender.SendAsync(request, CancellationToken);
		var cachedPostCommentLike = await ServiceScope.GetPostCommentLikeCacheByIdAsync(request, CancellationToken);

		// Assert
		cachedPostCommentLike.ShouldBeNull();
	}

	[Theory]
	[PostCommentIdDifferentCaseData]
	public async Task SendAsync_ShouldDeleteCachedPostCommentLike_WhenRequestAndCommentIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithCommentId(transformer).Build();
		await ServiceScope.AddPostCommentLikeCacheAsync(request, PostCommentLike, CancellationToken);

		// Act
		await Sender.SendAsync(request, CancellationToken);
		var cachedPostCommentLike = await ServiceScope.GetPostCommentLikeCacheByIdAsync(request, CancellationToken);

		// Assert
		cachedPostCommentLike.ShouldBeNull();
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task SendAsync_ShouldDeleteCachedPostCommentLike_WhenRequestAndUserIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithUserId(transformer).Build();
		await ServiceScope.AddPostCommentLikeCacheAsync(request, PostCommentLike, CancellationToken);

		// Act
		await Sender.SendAsync(request, CancellationToken);
		var cachedPostCommentLike = await ServiceScope.GetPostCommentLikeCacheByIdAsync(request, CancellationToken);

		// Assert
		cachedPostCommentLike.ShouldBeNull();
	}

	[Fact]
	public async Task SendAsync_ShouldDeleteCachedPostComment_WhenRequestIsValid()
	{
		// Act
		await Sender.SendAsync(_request, CancellationToken);
		var cachedPostComment = await ServiceScope.GetPostCommentCacheByIdAsync(_request, CancellationToken);

		// Assert
		cachedPostComment.ShouldBeNull();
	}

	[Theory]
	[PostIdDifferentCaseData]
	public async Task SendAsync_ShouldDeleteCachedPostComment_WhenRequestAndIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithId(transformer).Build();
		await ServiceScope.AddPostCommentCacheAsync(request, PostComment, CancellationToken);

		// Act
		await Sender.SendAsync(request, CancellationToken);
		var cachedPostComment = await ServiceScope.GetPostCommentCacheByIdAsync(request, CancellationToken);

		// Assert
		cachedPostComment.ShouldBeNull();
	}

	[Theory]
	[PostCommentIdDifferentCaseData]
	public async Task SendAsync_ShouldDeleteCachedPostComment_WhenRequestAndCommentIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithCommentId(transformer).Build();
		await ServiceScope.AddPostCommentCacheAsync(request, PostComment, CancellationToken);

		// Act
		await Sender.SendAsync(request, CancellationToken);
		var cachedPostComment = await ServiceScope.GetPostCommentCacheByIdAsync(request, CancellationToken);

		// Assert
		cachedPostComment.ShouldBeNull();
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task SendAsync_ShouldDeleteCachedPostComment_WhenRequestAndUserIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithUserId(transformer).Build();
		await ServiceScope.AddPostCommentCacheAsync(request, PostComment, CancellationToken);

		// Act
		await Sender.SendAsync(request, CancellationToken);
		var cachedPostComment = await ServiceScope.GetPostCommentCacheByIdAsync(request, CancellationToken);

		// Assert
		cachedPostComment.ShouldBeNull();
	}

	[Fact]
	public async Task SendAsync_ShouldPublishPostCommentLikeDeletedEvent_WhenRequestIsValid()
	{
		// Act
		await Sender.SendAsync(_request, CancellationToken);

		var eventRequest = await CommentLikeEventClient.PublishedDeletedAsync(CancellationToken);

		// Assert
		eventRequest.ShouldSatisfy(_request, PostCommentLike);
	}

	[Theory]
	[PostIdDifferentCaseData]
	public async Task SendAsync_ShouldPublishPostCommentLikeDeletedEvent_WhenRequestAndIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithId(transformer).Build();

		// Act
		await Sender.SendAsync(request, CancellationToken);

		var eventRequest = await CommentLikeEventClient.PublishedDeletedAsync(CancellationToken);

		// Assert
		eventRequest.ShouldSatisfy(request, PostCommentLike);
	}

	[Theory]
	[PostCommentIdDifferentCaseData]
	public async Task SendAsync_ShouldPublishPostCommentLikeDeletedEvent_WhenRequestAndCommentIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithCommentId(transformer).Build();

		// Act
		await Sender.SendAsync(request, CancellationToken);

		var eventRequest = await CommentLikeEventClient.PublishedDeletedAsync(CancellationToken);

		// Assert
		eventRequest.ShouldSatisfy(request, PostCommentLike);
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task SendAsync_ShouldPublishPostCommentLikeDeletedEvent_WhenRequestAndUserIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithUserId(transformer).Build();

		// Act
		await Sender.SendAsync(request, CancellationToken);

		var eventRequest = await CommentLikeEventClient.PublishedDeletedAsync(CancellationToken);

		// Assert
		eventRequest.ShouldSatisfy(request, PostCommentLike);
	}
}
