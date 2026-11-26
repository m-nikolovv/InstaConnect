using InstaConnect.Posts.Infrastructure.Tests.Features.PostImages.Assertions;

namespace InstaConnect.Posts.Infrastructure.Tests.Unit.Features.PostImages.Repositories;

public class AddRangePostImagesCommandRepositoryUnitTests : BasePostImageInfrastructureCommandUnitTest
{
	private readonly PostImageCommandRepository _repository;

	public AddRangePostImagesCommandRepositoryUnitTests()
	{
		_repository = new(CacheHandler, Collection, ImageCacheHandler);
	}

	[Fact]
	public async Task AddRangeAsync_ShouldCallTheCollectionAddRangeAsync_WhenCommandIsValid()
	{
		// Act
		await _repository.AddRangeAsync(PostImages, CancellationToken);

		// Assert
		await Collection.ShouldHaveReceivedOneAddRangeAsync(PostImages, CancellationToken);
	}

	[Fact]
	public async Task AddRangeAsync_ShouldCallTheCacheHandlerDeleteResponseRangeAsync_WhenCommandIsValid()
	{
		// Act
		await _repository.AddRangeAsync(PostImages, CancellationToken);

		// Assert
		await CacheHandler.ShouldHaveReceivedOneDeleteResponseRangeAsync(PostImages, CancellationToken);
	}
}
