using InstaConnect.Posts.Infrastructure.Tests.Features.PostImages.Assertions;

namespace InstaConnect.Posts.Infrastructure.Tests.Unit.Features.PostImages.Repositories;

public class DeleteRangePostImagesCommandRepositoryUnitTests : BasePostImageInfrastructureCommandUnitTest
{
	private readonly PostImageCommandRepository _repository;

	public DeleteRangePostImagesCommandRepositoryUnitTests()
	{
		_repository = new(CacheHandler, Collection, ImageCacheHandler);
	}

	[Fact]
	public async Task DeleteRangeAsync_ShouldCallTheCollectionDeleteRangeAsync_WhenCommandIsValid()
	{
		// Act
		await _repository.DeleteRangeAsync(PostImages, CancellationToken);

		// Assert
		await Collection.ShouldHaveReceivedOneDeleteRangeAsync(PostImages, CancellationToken);
	}

	[Fact]
	public async Task DeleteRangeAsync_ShouldCallTheCacheHandlerDeleteResponseRangeAsync_WhenCommandIsValid()
	{
		// Act
		await _repository.DeleteRangeAsync(PostImages, CancellationToken);

		// Assert
		await CacheHandler.ShouldHaveReceivedOneDeleteResponseRangeAsync(PostImages, CancellationToken);
	}

	[Fact]
	public async Task DeleteRangeAsync_ShouldCallTheImageCacheHandlerDeleteRangeAsync_WhenCommandIsValid()
	{
		// Act
		await _repository.DeleteRangeAsync(PostImages, CancellationToken);

		// Assert
		await ImageCacheHandler.ShouldHaveReceivedOneDeleteRangeAsync(PostImages, CancellationToken);
	}
}
