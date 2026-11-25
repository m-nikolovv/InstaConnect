namespace InstaConnect.Posts.Infrastructure.Tests.Unit.Features.PostCommentLikes.Repositories;

public class AddRangePostCommentLikesCommandRepositoryUnitTests : BasePostCommentLikeInfrastructureCommandUnitTest
{
	private readonly PostCommentLikeCommandRepository _repository;

	public AddRangePostCommentLikesCommandRepositoryUnitTests()
	{
		_repository = new(Collection, CommentCacheHandler, CommentLikeCacheHandler, IncludeBuilderFactory);
	}

	[Fact]
	public async Task AddRangeAsync_ShouldCallTheCollectionAddRangeAsync_WhenCommandIsValid()
	{
		// Act
		await _repository.AddRangeAsync(PostCommentLikes, CancellationToken);

		// Assert
		await Collection.ShouldHaveReceivedOneAddRangeAsync(PostCommentLikes, CancellationToken);
	}

	[Fact]
	public async Task AddRangeAsync_ShouldCallTheCommentCacheHandlerDeleteResponseRangeAsync_WhenCommandIsValid()
	{
		// Act
		await _repository.AddRangeAsync(PostCommentLikes, CancellationToken);

		// Assert
		await CommentCacheHandler.ShouldHaveReceivedOneDeleteResponseRangeAsync(PostCommentLikes, CancellationToken);
	}
}
