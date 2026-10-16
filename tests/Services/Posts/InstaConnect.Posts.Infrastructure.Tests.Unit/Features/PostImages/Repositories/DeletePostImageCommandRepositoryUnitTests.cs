using InstaConnect.Posts.Infrastructure.Features.PostImages.Helpers.Repositories;
using InstaConnect.Posts.Infrastructure.Tests.Features.PostImages.Assertions;
using InstaConnect.Posts.Infrastructure.Tests.Unit.Features.PostImages.Utilities;

namespace InstaConnect.Posts.Infrastructure.Tests.Unit.Features.PostImages.Repositories;

public class DeletePostImageCommandRepositoryUnitTests : BasePostImageInfrastructureCommandUnitTest
{
	private readonly PostImageCommandRepository _repository;

	public DeletePostImageCommandRepositoryUnitTests()
	{
		_repository = new(Collection);
	}

	[Fact]
	public async Task DeleteAsync_ShouldCallTheCollectionDeleteAsync_WhenRequestIsValid()
	{
		// Act
		await _repository.DeleteAsync(PostImage, CancellationToken);

		// Assert
		await Collection.ShouldHaveReceivedOneDeleteAsync(PostImage, CancellationToken);
	}
}
