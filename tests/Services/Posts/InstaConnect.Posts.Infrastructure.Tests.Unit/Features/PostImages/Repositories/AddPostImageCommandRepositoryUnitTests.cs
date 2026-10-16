using InstaConnect.Posts.Infrastructure.Features.PostImages.Helpers.Repositories;
using InstaConnect.Posts.Infrastructure.Tests.Unit.Features.PostImages.Utilities;

namespace InstaConnect.Posts.Infrastructure.Tests.Unit.Features.PostImages.Repositories;

public class AddPostImageCommandRepositoryUnitTests : BasePostImageInfrastructureCommandUnitTest
{
	private readonly PostImageCommandRepository _repository;

	public AddPostImageCommandRepositoryUnitTests()
	{
		_repository = new(Collection);
	}

	[Fact]
	public async Task AddAsync_ShouldCallTheCollectionAddAsync_WhenRequestIsValid()
	{
		// Act
		await _repository.AddAsync(PostImage, CancellationToken);

		// Assert
		await Collection.ShouldHaveReceivedOneAddAsync(PostImage, CancellationToken);
	}
}
