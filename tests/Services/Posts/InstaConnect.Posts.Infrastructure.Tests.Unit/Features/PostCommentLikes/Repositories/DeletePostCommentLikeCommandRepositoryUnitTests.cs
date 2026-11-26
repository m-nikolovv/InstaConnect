namespace InstaConnect.Posts.Infrastructure.Tests.Unit.Features.PostCommentLikes.Repositories;

public class DeletePostCommentLikeCommandRepositoryUnitTests : BasePostCommentLikeInfrastructureCommandUnitTest
{
	private readonly PostCommentLikeCommandRepository _repository;

	public DeletePostCommentLikeCommandRepositoryUnitTests()
	{
		_repository = new(Collection, CommentCacheHandler, CommentLikeCacheHandler, IncludeBuilderFactory);
	}

	[Fact]
	public async Task DeleteAsync_ShouldCallTheCollectionDeleteAsync_WhenCommandIsValid()
	{
		// Act
		await _repository.DeleteAsync(PostCommentLike, CancellationToken);

		// Assert
		await Collection.ShouldHaveReceivedOneDeleteAsync(PostCommentLike, CancellationToken);
	}

	[Fact]
	public async Task DeleteAsync_ShouldCallTheCommentCacheHandlerDeleteResponseAsync_WhenCommandIsValid()
	{
		// Act
		await _repository.DeleteAsync(PostCommentLike, CancellationToken);

		// Assert
		await CommentCacheHandler.ShouldHaveReceivedOneDeleteResponseAsync(PostCommentLike, CancellationToken);
	}

	[Fact]
	public async Task DeleteAsync_ShouldCallTheCommentLikeCacheHandlerDeleteAsync_WhenCommandIsValid()
	{
		// Act
		await _repository.DeleteAsync(PostCommentLike, CancellationToken);

		// Assert
		await CommentLikeCacheHandler.ShouldHaveReceivedOneDeleteAsync(PostCommentLike, CancellationToken);
	}
}
