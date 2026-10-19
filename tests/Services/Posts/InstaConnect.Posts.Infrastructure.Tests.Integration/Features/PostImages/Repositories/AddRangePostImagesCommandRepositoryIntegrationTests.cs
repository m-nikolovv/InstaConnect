using InstaConnect.Posts.Infrastructure.Tests.Integration.Features.PostImages.Utilities;
using InstaConnect.Posts.Tests.Features.PostImages.Assertions;
using InstaConnect.Posts.Tests.Features.PostImages.Utilities;

namespace InstaConnect.Posts.Infrastructure.Tests.Integration.Features.PostImages.Repositories;

public class AddRangePostImagesCommandRepositoryIntegrationTests : BasePostImageInfrastructureCommandIntegrationTest
{
	public AddRangePostImagesCommandRepositoryIntegrationTests(PostsWebApplicationFactory webApplicationFactory)
		: base(webApplicationFactory)
	{
	}

	[Fact]
	public async Task AddRangeAsync_ShouldAddPostImages_WhenCommandIsValid()
	{
		// Act
		await Repository.AddRangeAsync(PostImages, CancellationToken);
		var postImages = await ServiceScope.GetByIdRangeAsync(PostImageIds, CancellationToken);

		// Assert
		postImages.ShouldSatisfy(PostImages);
	}
}
