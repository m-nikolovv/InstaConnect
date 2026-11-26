namespace InstaConnect.Posts.Infrastructure.Tests.Unit.Features.PostComments.Repositories;

public class DeletePostCommentCommandRepositoryUnitTests : BasePostCommentInfrastructureCommandUnitTest
{
	private readonly PostCommentCommandRepository _repository;

	public DeletePostCommentCommandRepositoryUnitTests()
	{
		_repository = new(CacheHandler, Collection, CommentCacheHandler, IncludeBuilderFactory);
	}

	[Fact]
	public async Task DeleteAsync_ShouldCallTheCollectionDeleteAsync_WhenCommandIsValid()
	{
		// Act
		await _repository.DeleteAsync(PostComment, CancellationToken);

		// Assert
		await Collection.ShouldHaveReceivedOneDeleteAsync(PostComment, CancellationToken);
	}

	[Fact]
	public async Task DeleteAsync_ShouldCallTheCacheHandlerDeleteResponseAsync_WhenCommandIsValid()
	{
		// Act
		await _repository.DeleteAsync(PostComment, CancellationToken);

		// Assert
		await CacheHandler.ShouldHaveReceivedOneDeleteResponseAsync(PostComment, CancellationToken);
	}

	[Fact]
	public async Task DeleteAsync_ShouldCallTheCommentCacheHandlerDeleteAsync_WhenCommandIsValid()
	{
		// Act
		await _repository.DeleteAsync(PostComment, CancellationToken);

		// Assert
		await CommentCacheHandler.ShouldHaveReceivedOneDeleteAsync(PostComment, CancellationToken);
	}
}
