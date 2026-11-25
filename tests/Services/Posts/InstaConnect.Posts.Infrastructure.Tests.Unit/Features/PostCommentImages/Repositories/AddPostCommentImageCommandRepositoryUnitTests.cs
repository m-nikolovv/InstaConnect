using InstaConnect.Posts.Infrastructure.Tests.Features.PostCommentImages.Assertions;

namespace InstaConnect.Posts.Infrastructure.Tests.Unit.Features.PostCommentImages.Repositories;

public class AddPostCommentImageCommandRepositoryUnitTests : BasePostCommentImageInfrastructureCommandUnitTest
{
	private readonly PostCommentImageCommandRepository _repository;

	public AddPostCommentImageCommandRepositoryUnitTests()
	{
		_repository = new(Collection, CommentCacheHandler, CommentImageCacheHandler);
	}

	[Fact]
	public async Task AddAsync_ShouldCallTheCollectionAddAsync_WhenCommandIsValid()
	{
		// Act
		await _repository.AddAsync(PostCommentImage, CancellationToken);

		// Assert
		await Collection.ShouldHaveReceivedOneAddAsync(PostCommentImage, CancellationToken);
	}

	[Fact]
	public async Task AddAsync_ShouldCallTheCommentCacheHandlerDeleteResponseAsync_WhenCommandIsValid()
	{
		// Act
		await _repository.AddAsync(PostCommentImage, CancellationToken);

		// Assert
		await CommentCacheHandler.ShouldHaveReceivedOneDeleteResponseAsync(PostCommentImage, CancellationToken);
	}
}
