namespace InstaConnect.Posts.Infrastructure.Tests.Unit.Features.PostComments.Repositories;

public class AddPostCommentCommandRepositoryUnitTests : BasePostCommentInfrastructureCommandUnitTest
{
	private readonly PostCommentCommandRepository _repository;

	public AddPostCommentCommandRepositoryUnitTests()
	{
		_repository = new(CacheHandler, Collection, CommentCacheHandler, IncludeBuilderFactory);
	}

	[Fact]
	public async Task AddAsync_ShouldCallTheCollectionAddAsync_WhenCommandIsValid()
	{
		// Act
		await _repository.AddAsync(PostComment, CancellationToken);

		// Assert
		await Collection.ShouldHaveReceivedOneAddAsync(PostComment, CancellationToken);
	}

	[Fact]
	public async Task AddAsync_ShouldCallTheCacheHandlerDeleteResponseAsync_WhenCommandIsValid()
	{
		// Act
		await _repository.AddAsync(PostComment, CancellationToken);

		// Assert
		await CacheHandler.ShouldHaveReceivedOneDeleteResponseAsync(PostComment, CancellationToken);
	}
}
