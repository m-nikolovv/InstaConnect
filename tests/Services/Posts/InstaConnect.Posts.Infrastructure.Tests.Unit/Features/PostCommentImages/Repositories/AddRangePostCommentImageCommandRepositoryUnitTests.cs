using InstaConnect.Posts.Infrastructure.Features.PostCommentImages.Helpers.Repositories;
using InstaConnect.Posts.Infrastructure.Tests.Unit.Features.PostCommentImages.Utilities;

namespace InstaConnect.Posts.Infrastructure.Tests.Unit.Features.PostCommentImages.Repositories;

public class AddRangePostCommentImageCommandRepositoryUnitTests : BasePostCommentImageInfrastructureCommandUnitTest
{
	private readonly PostCommentImageCommandRepository _repository;

	public AddRangePostCommentImageCommandRepositoryUnitTests()
	{
		_repository = new(Collection);
	}

	[Fact]
	public async Task AddRangeAsync_ShouldCallTheCollectionAddRangeAsync_WhenRequestIsValid()
	{
		// Act
		await _repository.AddRangeAsync(PostCommentImages, CancellationToken);

		// Assert
		await Collection.ShouldHaveReceivedOneAddRangeAsync(PostCommentImages, CancellationToken);
	}
}
