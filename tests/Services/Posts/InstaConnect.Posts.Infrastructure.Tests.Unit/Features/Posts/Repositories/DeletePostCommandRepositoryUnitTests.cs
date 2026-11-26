namespace InstaConnect.Posts.Infrastructure.Tests.Unit.Features.Posts.Repositories;

public class DeletePostCommandRepositoryUnitTests : BasePostInfrastructureCommandUnitTest
{
	private readonly PostCommandRepository _repository;

	public DeletePostCommandRepositoryUnitTests()
	{
		_repository = new(Collection, CacheHandler, IncludeBuilderFactory);
	}

	[Fact]
	public async Task DeleteAsync_ShouldCallTheCollectionDeleteAsync_WhenCommandIsValid()
	{
		// Act
		await _repository.DeleteAsync(Post, CancellationToken);

		// Assert
		await Collection.ShouldHaveReceivedOneDeleteAsync(Post, CancellationToken);
	}

	[Fact]
	public async Task DeleteAsync_ShouldCallTheCacheHandlerDeleteAsync_WhenCommandIsValid()
	{
		// Act
		await _repository.DeleteAsync(Post, CancellationToken);

		// Assert
		await CacheHandler.ShouldHaveReceivedOneDeleteAsync(Post, CancellationToken);
	}
}
