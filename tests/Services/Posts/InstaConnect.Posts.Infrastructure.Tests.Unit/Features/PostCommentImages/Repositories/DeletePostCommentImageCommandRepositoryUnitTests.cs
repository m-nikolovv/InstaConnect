using InstaConnect.Posts.Infrastructure.Tests.Features.PostCommentImages.Assertions;

namespace InstaConnect.Posts.Infrastructure.Tests.Unit.Features.PostCommentImages.Repositories;

public class DeletePostCommentImageCommandRepositoryUnitTests : BasePostCommentImageInfrastructureCommandUnitTest
{
	private readonly PostCommentImageCommandRepository _repository;

	public DeletePostCommentImageCommandRepositoryUnitTests()
	{
		_repository = new(Collection, CommentCacheHandler, CommentImageCacheHandler);
	}

	[Fact]
	public async Task DeleteAsync_ShouldCallTheCollectionDeleteAsync_WhenCommandIsValid()
	{
		// Act
		await _repository.DeleteAsync(PostCommentImage, CancellationToken);

		// Assert
		await Collection.ShouldHaveReceivedOneDeleteAsync(PostCommentImage, CancellationToken);
	}

	[Fact]
	public async Task DeleteAsync_ShouldCallTheCommentCacheHandlerDeleteResponseAsync_WhenCommandIsValid()
	{
		// Act
		await _repository.DeleteAsync(PostCommentImage, CancellationToken);

		// Assert
		await CommentCacheHandler.ShouldHaveReceivedOneDeleteResponseAsync(PostCommentImage, CancellationToken);
	}

	[Fact]
	public async Task DeleteAsync_ShouldCallTheCommentImageCacheHandlerDeleteAsync_WhenCommandIsValid()
	{
		// Act
		await _repository.DeleteAsync(PostCommentImage, CancellationToken);

		// Assert
		await CommentImageCacheHandler.ShouldHaveReceivedOneDeleteAsync(PostCommentImage, CancellationToken);
	}
}
