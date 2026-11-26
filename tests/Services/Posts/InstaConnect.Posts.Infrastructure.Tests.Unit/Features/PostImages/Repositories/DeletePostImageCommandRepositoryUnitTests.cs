using InstaConnect.Posts.Infrastructure.Tests.Features.PostImages.Assertions;

namespace InstaConnect.Posts.Infrastructure.Tests.Unit.Features.PostImages.Repositories;

public class DeletePostImageCommandRepositoryUnitTests : BasePostImageInfrastructureCommandUnitTest
{
	private readonly PostImageCommandRepository _repository;

	public DeletePostImageCommandRepositoryUnitTests()
	{
		_repository = new(CacheHandler, Collection, ImageCacheHandler);
	}

	[Fact]
	public async Task DeleteAsync_ShouldCallTheCollectionDeleteAsync_WhenCommandIsValid()
	{
		// Act
		await _repository.DeleteAsync(PostImage, CancellationToken);

		// Assert
		await Collection.ShouldHaveReceivedOneDeleteAsync(PostImage, CancellationToken);
	}

	[Fact]
	public async Task DeleteAsync_ShouldCallTheCacheHandlerDeleteResponseAsync_WhenCommandIsValid()
	{
		// Act
		await _repository.DeleteAsync(PostImage, CancellationToken);

		// Assert
		await CacheHandler.ShouldHaveReceivedOneDeleteResponseAsync(PostImage, CancellationToken);
	}

	[Fact]
	public async Task DeleteAsync_ShouldCallTheImageCacheHandlerDeleteAsync_WhenCommandIsValid()
	{
		// Act
		await _repository.DeleteAsync(PostImage, CancellationToken);

		// Assert
		await ImageCacheHandler.ShouldHaveReceivedOneDeleteAsync(PostImage, CancellationToken);
	}
}
