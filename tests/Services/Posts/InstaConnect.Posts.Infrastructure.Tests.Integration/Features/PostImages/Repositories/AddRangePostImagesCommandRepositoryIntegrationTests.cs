using InstaConnect.Posts.Tests.Features.PostImages.Assertions;

namespace InstaConnect.Posts.Infrastructure.Tests.Integration.Features.PostImages.Repositories;

public class AddRangePostImagesCommandRepositoryIntegrationTests : BasePostImageInfrastructureCommandIntegrationTest
{
	public AddRangePostImagesCommandRepositoryIntegrationTests(PostsWebApplicationFactory webApplicationFactory)
		: base(webApplicationFactory)
	{
	}

	protected override async Task OnInitializeAsync()
	{
		await ServiceScope.DeleteRangeAsync(PostPostImages, CancellationToken);
	}

	[Fact]
	public async Task AddRangeAsync_ShouldAddPostImages_WhenCommandIsValid()
	{
		// Act
		await Repository.AddRangeAsync(PostPostImages, CancellationToken);
		var postImages = await ServiceScope.GetByIdRangeAsync(PostPostImageIds, CancellationToken);

		// Assert
		postImages.ShouldSatisfy(PostPostImages);
	}
}
