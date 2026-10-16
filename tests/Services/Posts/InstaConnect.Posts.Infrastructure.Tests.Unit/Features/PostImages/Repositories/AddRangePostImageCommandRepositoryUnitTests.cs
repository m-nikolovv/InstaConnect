using InstaConnect.Posts.Infrastructure.Features.PostImages.Helpers.Repositories;
using InstaConnect.Posts.Infrastructure.Tests.Unit.Features.PostImages.Utilities;

namespace InstaConnect.Posts.Infrastructure.Tests.Unit.Features.PostImages.Repositories;

public class AddRangePostImageCommandRepositoryUnitTests : BasePostImageInfrastructureCommandUnitTest
{
	private readonly PostImageCommandRepository _repository;

	public AddRangePostImageCommandRepositoryUnitTests()
	{
		_repository = new(Collection);
	}

	[Fact]
	public async Task AddRangeAsync_ShouldCallTheCollectionAddRangeAsync_WhenRequestIsValid()
	{
		// Act
		await _repository.AddRangeAsync(PostImages, CancellationToken);

		// Assert
		await Collection.ShouldHaveReceivedOneAddRangeAsync(PostImages, CancellationToken);
	}
}
