namespace InstaConnect.Posts.Infrastructure.Tests.Unit.Features.PostCommentLikes.Repositories;

public class AddPostCommentLikeCommandRepositoryUnitTests : BasePostCommentLikeInfrastructureCommandUnitTest
{
	private readonly PostCommentLikeCommandRepository _repository;

	public AddPostCommentLikeCommandRepositoryUnitTests()
	{
		_repository = new(Collection, CommentCacheHandler, CommentLikeCacheHandler, IncludeBuilderFactory);
	}

	[Fact]
	public async Task AddAsync_ShouldCallTheCollectionAddAsync_WhenCommandIsValid()
	{
		// Act
		await _repository.AddAsync(PostCommentLike, CancellationToken);

		// Assert
		await Collection.ShouldHaveReceivedOneAddAsync(PostCommentLike, CancellationToken);
	}

	[Fact]
	public async Task AddAsync_ShouldCallTheCommentCacheHandlerDeleteResponseAsync_WhenCommandIsValid()
	{
		// Act
		await _repository.AddAsync(PostCommentLike, CancellationToken);

		// Assert
		await CommentCacheHandler.ShouldHaveReceivedOneDeleteResponseAsync(PostCommentLike, CancellationToken);
	}
}
