using InstaConnect.Posts.Infrastructure.Tests.Features.PostCommentImages.Assertions;

namespace InstaConnect.Posts.Infrastructure.Tests.Unit.Features.PostCommentImages.Repositories;

public class DeleteRangePostCommentImagesCommandRepositoryUnitTests : BasePostCommentImageInfrastructureCommandUnitTest
{
	private readonly PostCommentImageCommandRepository _repository;

	public DeleteRangePostCommentImagesCommandRepositoryUnitTests()
	{
		_repository = new(Collection, CommentCacheHandler, CommentImageCacheHandler);
	}

	[Fact]
	public async Task DeleteRangeAsync_ShouldCallTheCollectionDeleteRangeAsync_WhenCommandIsValid()
	{
		// Act
		await _repository.DeleteRangeAsync(PostCommentImages, CancellationToken);

		// Assert
		await Collection.ShouldHaveReceivedOneDeleteRangeAsync(PostCommentImages, CancellationToken);
	}

	[Fact]
	public async Task DeleteRangeAsync_ShouldCallTheCommentCacheHandlerDeleteResponseRangeAsync_WhenCommandIsValid()
	{
		// Act
		await _repository.DeleteRangeAsync(PostCommentImages, CancellationToken);

		// Assert
		await CommentCacheHandler.ShouldHaveReceivedOneDeleteResponseRangeAsync(PostCommentImages, CancellationToken);
	}

	[Fact]
	public async Task DeleteRangeAsync_ShouldCallTheCommentImageCacheHandlerDeleteRangeAsync_WhenCommandIsValid()
	{
		// Act
		await _repository.DeleteRangeAsync(PostCommentImages, CancellationToken);

		// Assert
		await CommentImageCacheHandler.ShouldHaveReceivedOneDeleteRangeAsync(PostCommentImages, CancellationToken);
	}
}
