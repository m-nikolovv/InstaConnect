namespace InstaConnect.Posts.Infrastructure.Tests.Unit.Features.PostLikes.Repositories;

public class AddPostLikeCommandRepositoryUnitTests : BasePostLikeInfrastructureCommandUnitTest
{
	private readonly PostLikeCommandRepository _repository;

	public AddPostLikeCommandRepositoryUnitTests()
	{
		_repository = new(Collection, CacheHandler, LikeCacheHandler, IncludeBuilderFactory);
	}

	[Fact]
	public async Task AddAsync_ShouldCallTheCollectionAddAsync_WhenCommandIsValid()
	{
		// Act
		await _repository.AddAsync(PostLike, CancellationToken);

		// Assert
		await Collection.ShouldHaveReceivedOneAddAsync(PostLike, CancellationToken);
	}

	[Fact]
	public async Task AddAsync_ShouldCallTheCacheHandlerDeleteResponseAsync_WhenCommandIsValid()
	{
		// Act
		await _repository.AddAsync(PostLike, CancellationToken);

		// Assert
		await CacheHandler.ShouldHaveReceivedOneDeleteResponseAsync(PostLike, CancellationToken);
	}
}
