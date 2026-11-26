namespace InstaConnect.Posts.Infrastructure.Tests.Unit.Features.PostComments.Repositories;

public class AddRangePostCommentsCommandRepositoryUnitTests : BasePostCommentInfrastructureCommandUnitTest
{
	private readonly PostCommentCommandRepository _repository;

	public AddRangePostCommentsCommandRepositoryUnitTests()
	{
		_repository = new(CacheHandler, Collection, CommentCacheHandler, IncludeBuilderFactory);
	}

	[Fact]
	public async Task AddRangeAsync_ShouldCallTheCollectionAddRangeAsync_WhenCommandIsValid()
	{
		// Act
		await _repository.AddRangeAsync(PostComments, CancellationToken);

		// Assert
		await Collection.ShouldHaveReceivedOneAddRangeAsync(PostComments, CancellationToken);
	}

	[Fact]
	public async Task AddRangeAsync_ShouldCallTheCacheHandlerDeleteResponseRangeAsync_WhenCommandIsValid()
	{
		// Act
		await _repository.AddRangeAsync(PostComments, CancellationToken);

		// Assert
		await CacheHandler.ShouldHaveReceivedOneDeleteResponseRangeAsync(PostComments, CancellationToken);
	}
}
