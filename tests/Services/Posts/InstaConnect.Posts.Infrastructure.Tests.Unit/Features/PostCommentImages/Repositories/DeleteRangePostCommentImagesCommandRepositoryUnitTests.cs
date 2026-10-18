using InstaConnect.Posts.Infrastructure.Features.PostCommentImages.Helpers.Repositories;
using InstaConnect.Posts.Infrastructure.Tests.Features.PostCommentImages.Assertions;
using InstaConnect.Posts.Infrastructure.Tests.Unit.Features.PostCommentImages.Utilities;

namespace InstaConnect.Posts.Infrastructure.Tests.Unit.Features.PostCommentImages.Repositories;

public class DeleteRangePostCommentImagesCommandRepositoryUnitTests : BasePostCommentImageInfrastructureCommandUnitTest
{
	private readonly PostCommentImageCommandRepository _repository;

	public DeleteRangePostCommentImagesCommandRepositoryUnitTests()
	{
		_repository = new(Collection);
	}

	[Fact]
	public async Task DeleteRangeAsync_ShouldCallTheCollectionDeleteRangeAsync_WhenRequestIsValid()
	{
		// Act
		await _repository.DeleteRangeAsync(PostCommentImages, CancellationToken);

		// Assert
		await Collection.ShouldHaveReceivedOneDeleteRangeAsync(PostCommentImages, CancellationToken);
	}
}
