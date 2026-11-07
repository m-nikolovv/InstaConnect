namespace InstaConnect.Posts.Infrastructure.Tests.Integration.Features.PostImages.Repositories;

public class DeleteRangePostImagesCommandRepositoryIntegrationTests : BasePostImageInfrastructureCommandIntegrationTest
{
	public DeleteRangePostImagesCommandRepositoryIntegrationTests(PostsWebApplicationFactory webApplicationFactory)
		: base(webApplicationFactory)
	{
	}

	protected override async Task OnInitializeAsync()
	{
		await ServiceScope.AddRangeAsync(PostImages, CancellationToken);
	}

	[Fact]
	public async Task DeleteRangeAsync_ShouldDeletePostImages_WhenCommandIsValid()
	{
		// Act
		await Repository.DeleteRangeAsync(PostImages, CancellationToken);
		var postImages = await ServiceScope.GetByIdRangeAsync(PostImageIds, CancellationToken);

		// Assert
		postImages.ShouldBeEmpty();
	}
}
