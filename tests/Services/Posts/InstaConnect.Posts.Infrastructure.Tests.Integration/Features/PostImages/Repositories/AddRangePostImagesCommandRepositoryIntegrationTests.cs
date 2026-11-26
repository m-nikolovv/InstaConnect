using InstaConnect.Posts.Tests.Features.PostImages.Assertions;

namespace InstaConnect.Posts.Infrastructure.Tests.Integration.Features.PostImages.Repositories;

public class AddRangePostImagesCommandRepositoryIntegrationTests : BasePostImageInfrastructureCommandIntegrationTest
{
	public AddRangePostImagesCommandRepositoryIntegrationTests(PostsWebApplicationFactory webApplicationFactory)
		: base(webApplicationFactory)
	{
	}

	public override async Task InitializeAsync()
	{
		await ServiceScope.InitializeAddAsync(PostImage, UserId, CancellationToken);
	}

	public override async Task DisposeAsync()
	{
		await ServiceScope.DisposeAddAsync(PostImage, CancellationToken);
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
