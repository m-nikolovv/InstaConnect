namespace InstaConnect.Posts.Infrastructure.Tests.Unit.Features.PostLikes.Repositories;

public class AddRangePostLikesCommandRepositoryUnitTests : BasePostLikeInfrastructureCommandUnitTest
{
	private readonly PostLikeCommandRepository _repository;

	public AddRangePostLikesCommandRepositoryUnitTests()
	{
		_repository = new(Collection, CacheHandler, LikeCacheHandler, IncludeBuilderFactory);
	}

	[Fact]
	public async Task AddRangeAsync_ShouldCallTheCollectionAddRangeAsync_WhenCommandIsValid()
	{
		// Act
		await _repository.AddRangeAsync(PostLikes, CancellationToken);

		// Assert
		await Collection.ShouldHaveReceivedOneAddRangeAsync(PostLikes, CancellationToken);
	}

	[Fact]
	public async Task AddRangeAsync_ShouldCallTheCacheHandlerDeleteResponseRangeAsync_WhenCommandIsValid()
	{
		// Act
		await _repository.AddRangeAsync(PostLikes, CancellationToken);

		// Assert
		await CacheHandler.ShouldHaveReceivedOneDeleteResponseRangeAsync(PostLikes, CancellationToken);
	}
}
