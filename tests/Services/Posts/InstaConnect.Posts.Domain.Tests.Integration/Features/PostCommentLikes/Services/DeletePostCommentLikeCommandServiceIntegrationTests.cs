using InstaConnect.Posts.Domain.Tests.Features.PostCommentLikes.Utilities;
using InstaConnect.Posts.Tests.Features.PostCommentLikes.Assertions;

namespace InstaConnect.Posts.Domain.Tests.Integration.Features.PostCommentLikes.Services;

public class DeletePostCommentLikeCommandServiceIntegrationTests : BasePostCommentLikeDomainCommandIntegrationTest
{
	private readonly DeletePostCommentLikeCommandBuilderFactory _commandBuilderFactory;
	private readonly DeletePostCommentLikeCommandBuilder _commandBuilder;
	private readonly DeletePostCommentLikeCommand _command;

	public DeletePostCommentLikeCommandServiceIntegrationTests(PostsWebApplicationFactory webApplicationFactory)
		: base(webApplicationFactory)
	{
		_commandBuilderFactory = new();
		_commandBuilder = _commandBuilderFactory.Create(PostCommentLike);
		_command = _commandBuilder.Build();
	}

	public override async Task InitializeAsync()
	{
		await ServiceScope.InitializeDeleteAsync(_command, PostCommentLike, CancellationToken);
		await base.InitializeAsync();
	}

	public override async Task DisposeAsync()
	{
		await ServiceScope.DisposeDeleteAsync(_command, PostCommentLike, CancellationToken);
		await base.DisposeAsync();
	}

	[Fact]
	public async Task DeleteAsync_ShouldThrowPostNotFoundException_WhenPostNotFound()
	{
		// Arrange
		await ServiceScope.DeleteAsync(Post, CancellationToken);

		// Assert
		await Service.ShouldThrowPostNotFoundExceptionAsync(_command, CancellationToken);
	}

	[Fact]
	public async Task DeleteAsync_ShouldThrowPostCommentNotFoundException_WhenPostCommentNotFound()
	{
		// Arrange
		await ServiceScope.DeleteAsync(PostComment, CancellationToken);

		// Assert
		await Service.ShouldThrowPostCommentNotFoundExceptionAsync(_command, CancellationToken);
	}

	[Fact]
	public async Task DeleteAsync_ShouldThrowPostCommentLikeNotFoundException_WhenPostCommentLikeNotFound()
	{
		// Arrange
		await ServiceScope.DeleteAsync(PostCommentLike, CancellationToken);

		// Assert
		await Service.ShouldThrowPostCommentLikeNotFoundExceptionAsync(_command, CancellationToken);
	}

	[Fact]
	public async Task DeleteAsync_ShouldDeletePostCommentLike_WhenCommandIsValid()
	{
		// Act
		await Service.DeleteAsync(_command, CancellationToken);
		var postCommentLike = await ServiceScope.GetByIdAsync(PostCommentLikeId, CancellationToken);

		// Assert
		postCommentLike.ShouldBeNull();
	}

	[Theory]
	[PostIdDifferentCaseData]
	public async Task DeleteAsync_ShouldDeletePostCommentLike_WhenCommandAndIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var command = _commandBuilder.WithId(transformer).Build();

		// Act
		await Service.DeleteAsync(command, CancellationToken);
		var postCommentLike = await ServiceScope.GetByIdAsync(PostCommentLikeId, CancellationToken);

		// Assert
		postCommentLike.ShouldBeNull();
	}

	[Theory]
	[PostCommentIdDifferentCaseData]
	public async Task DeleteAsync_ShouldDeletePostCommentLike_WhenCommandAndCommentIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var command = _commandBuilder.WithCommentId(transformer).Build();

		// Act
		await Service.DeleteAsync(command, CancellationToken);
		var postCommentLike = await ServiceScope.GetByIdAsync(PostCommentLikeId, CancellationToken);

		// Assert
		postCommentLike.ShouldBeNull();
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task DeleteAsync_ShouldDeletePostCommentLike_WhenCommandAndUserIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var command = _commandBuilder.WithUserId(transformer).Build();

		// Act
		await Service.DeleteAsync(command, CancellationToken);
		var postCommentLike = await ServiceScope.GetByIdAsync(PostCommentLikeId, CancellationToken);

		// Assert
		postCommentLike.ShouldBeNull();
	}

	[Fact]
	public async Task DeleteAsync_ShouldDeleteCachedPostCommentLike_WhenCommandIsValid()
	{
		// Act
		await Service.DeleteAsync(_command, CancellationToken);
		var cachedPostCommentLike = await ServiceScope.GetPostCommentLikeCacheByIdAsync(_command, CancellationToken);

		// Assert
		cachedPostCommentLike.ShouldBeNull();
	}

	[Theory]
	[PostIdDifferentCaseData]
	public async Task DeleteAsync_ShouldDeleteCachedPostCommentLike_WhenCommandAndIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var command = _commandBuilder.WithId(transformer).Build();
		await ServiceScope.AddPostCommentLikeCacheAsync(command, PostCommentLike, CancellationToken);

		// Act
		await Service.DeleteAsync(command, CancellationToken);
		var cachedPostCommentLike = await ServiceScope.GetPostCommentLikeCacheByIdAsync(command, CancellationToken);

		// Assert
		cachedPostCommentLike.ShouldBeNull();
	}

	[Theory]
	[PostCommentIdDifferentCaseData]
	public async Task DeleteAsync_ShouldDeleteCachedPostCommentLike_WhenCommandAndCommentIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var command = _commandBuilder.WithCommentId(transformer).Build();
		await ServiceScope.AddPostCommentLikeCacheAsync(command, PostCommentLike, CancellationToken);

		// Act
		await Service.DeleteAsync(command, CancellationToken);
		var cachedPostCommentLike = await ServiceScope.GetPostCommentLikeCacheByIdAsync(command, CancellationToken);

		// Assert
		cachedPostCommentLike.ShouldBeNull();
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task DeleteAsync_ShouldDeleteCachedPostCommentLike_WhenCommandAndUserIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var command = _commandBuilder.WithUserId(transformer).Build();
		await ServiceScope.AddPostCommentLikeCacheAsync(command, PostCommentLike, CancellationToken);

		// Act
		await Service.DeleteAsync(command, CancellationToken);
		var cachedPostCommentLike = await ServiceScope.GetPostCommentLikeCacheByIdAsync(command, CancellationToken);

		// Assert
		cachedPostCommentLike.ShouldBeNull();
	}

	[Fact]
	public async Task DeleteAsync_ShouldDeleteCachedPostComment_WhenCommandIsValid()
	{
		// Act
		await Service.DeleteAsync(_command, CancellationToken);
		var cachedPostComment = await ServiceScope.GetPostCommentCacheByIdAsync(_command, CancellationToken);

		// Assert
		cachedPostComment.ShouldBeNull();
	}

	[Theory]
	[PostIdDifferentCaseData]
	public async Task DeleteAsync_ShouldDeleteCachedPostComment_WhenCommandAndIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var command = _commandBuilder.WithId(transformer).Build();
		await ServiceScope.AddPostCommentCacheAsync(command, PostComment, CancellationToken);

		// Act
		await Service.DeleteAsync(command, CancellationToken);
		var cachedPostComment = await ServiceScope.GetPostCommentCacheByIdAsync(command, CancellationToken);

		// Assert
		cachedPostComment.ShouldBeNull();
	}

	[Theory]
	[PostCommentIdDifferentCaseData]
	public async Task DeleteAsync_ShouldDeleteCachedPostComment_WhenCommandAndCommentIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var command = _commandBuilder.WithCommentId(transformer).Build();
		await ServiceScope.AddPostCommentCacheAsync(command, PostComment, CancellationToken);

		// Act
		await Service.DeleteAsync(command, CancellationToken);
		var cachedPostComment = await ServiceScope.GetPostCommentCacheByIdAsync(command, CancellationToken);

		// Assert
		cachedPostComment.ShouldBeNull();
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task DeleteAsync_ShouldDeleteCachedPostComment_WhenCommandAndUserIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var command = _commandBuilder.WithUserId(transformer).Build();
		await ServiceScope.AddPostCommentCacheAsync(command, PostComment, CancellationToken);

		// Act
		await Service.DeleteAsync(command, CancellationToken);
		var cachedPostComment = await ServiceScope.GetPostCommentCacheByIdAsync(command, CancellationToken);

		// Assert
		cachedPostComment.ShouldBeNull();
	}

	[Fact]
	public async Task DeleteAsync_ShouldPublishPostCommentLikeDeletedEvent_WhenCommandIsValid()
	{
		// Act
		await Service.DeleteAsync(_command, CancellationToken);

		var eventRequest = await CommentLikeEventClient.PublishedDeletedAsync(CancellationToken);

		// Assert
		eventRequest.ShouldSatisfy(_command, PostCommentLike);
	}

	[Theory]
	[PostIdDifferentCaseData]
	public async Task DeleteAsync_ShouldPublishPostCommentLikeDeletedEvent_WhenCommandAndIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var command = _commandBuilder.WithId(transformer).Build();

		// Act
		await Service.DeleteAsync(command, CancellationToken);

		var eventRequest = await CommentLikeEventClient.PublishedDeletedAsync(CancellationToken);

		// Assert
		eventRequest.ShouldSatisfy(command, PostCommentLike);
	}

	[Theory]
	[PostCommentIdDifferentCaseData]
	public async Task DeleteAsync_ShouldPublishPostCommentLikeDeletedEvent_WhenCommandAndCommentIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var command = _commandBuilder.WithCommentId(transformer).Build();

		// Act
		await Service.DeleteAsync(command, CancellationToken);

		var eventRequest = await CommentLikeEventClient.PublishedDeletedAsync(CancellationToken);

		// Assert
		eventRequest.ShouldSatisfy(command, PostCommentLike);
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task DeleteAsync_ShouldPublishPostCommentLikeDeletedEvent_WhenCommandAndUserIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var command = _commandBuilder.WithUserId(transformer).Build();

		// Act
		await Service.DeleteAsync(command, CancellationToken);

		var eventRequest = await CommentLikeEventClient.PublishedDeletedAsync(CancellationToken);

		// Assert
		eventRequest.ShouldSatisfy(command, PostCommentLike);
	}
}
