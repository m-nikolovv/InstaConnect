namespace InstaConnect.Posts.Infrastructure.Tests.Unit.Features.Posts.Repositories;

public class UpdatePostCommandRepositoryUnitTests : BasePostInfrastructureCommandUnitTest
{
	private readonly PostCommandRepository _repository;

	public UpdatePostCommandRepositoryUnitTests()
	{
		_repository = new(Collection, CacheHandler, IncludeBuilderFactory);
	}

	[Fact]
	public async Task UpdateAsync_ShouldCallTheCollectionUpdateAsync_WhenCommandIsValid()
	{
		// Act
		await _repository.UpdateAsync(Post, CancellationToken);

		// Assert
		await Collection.ShouldHaveReceivedOneUpdateAsync(Post, CancellationToken);
	}

	[Fact]
	public async Task UpdateAsync_ShouldCallTheCacheHandlerDeleteAsync_WhenCommandIsValid()
	{
		// Act
		await _repository.UpdateAsync(Post, CancellationToken);

		// Assert
		await CacheHandler.ShouldHaveReceivedOneDeleteAsync(Post, CancellationToken);
	}
}
