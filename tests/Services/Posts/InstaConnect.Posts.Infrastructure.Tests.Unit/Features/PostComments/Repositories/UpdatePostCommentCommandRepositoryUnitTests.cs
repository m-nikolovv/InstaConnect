namespace InstaConnect.Posts.Infrastructure.Tests.Unit.Features.PostComments.Repositories;

public class UpdatePostCommentCommandRepositoryUnitTests : BasePostCommentInfrastructureCommandUnitTest
{
	private readonly PostCommentCommandRepository _repository;

	public UpdatePostCommentCommandRepositoryUnitTests()
	{
		_repository = new(CacheHandler, Collection, CommentCacheHandler, IncludeBuilderFactory);
	}

	[Fact]
	public async Task UpdateAsync_ShouldCallTheCollectionUpdateAsync_WhenCommandIsValid()
	{
		// Act
		await _repository.UpdateAsync(PostComment, CancellationToken);

		// Assert
		await Collection.ShouldHaveReceivedOneUpdateAsync(PostComment, CancellationToken);
	}

	[Fact]
	public async Task UpdateAsync_ShouldCallTheCommentCacheHandlerDeleteAsync_WhenCommandIsValid()
	{
		// Act
		await _repository.UpdateAsync(PostComment, CancellationToken);

		// Assert
		await CommentCacheHandler.ShouldHaveReceivedOneDeleteAsync(PostComment, CancellationToken);
	}
}
