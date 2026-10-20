using InstaConnect.Posts.Infrastructure.Tests.Features.PostCommentImages.Assertions;

namespace InstaConnect.Posts.Infrastructure.Tests.Unit.Features.PostCommentImages.Repositories;

public class DeletePostCommentImageCommandRepositoryUnitTests : BasePostCommentImageInfrastructureCommandUnitTest
{
	private readonly PostCommentImageCommandRepository _repository;

	public DeletePostCommentImageCommandRepositoryUnitTests()
	{
		_repository = new(Collection);
	}

	[Fact]
	public async Task DeleteAsync_ShouldCallTheCollectionDeleteAsync_WhenCommandIsValid()
	{
		// Act
		await _repository.DeleteAsync(PostCommentImage, CancellationToken);

		// Assert
		await Collection.ShouldHaveReceivedOneDeleteAsync(PostCommentImage, CancellationToken);
	}
}
