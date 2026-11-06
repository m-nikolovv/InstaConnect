namespace InstaConnect.Posts.Infrastructure.Tests.Integration.Features.PostImages.Repositories;

public class DeleteRangePostImagesCommandRepositoryIntegrationTests : BasePostImageInfrastructureCommandIntegrationTest
{
	public DeleteRangePostImagesCommandRepositoryIntegrationTests(PostsWebApplicationFactory webApplicationFactory)
		: base(webApplicationFactory)
	{
	}

	[Fact]
	public async Task DeleteRangeAsync_ShouldDeletePostImages_WhenCommandIsValid()
	{
		// Act
		await Repository.DeleteRangeAsync(PostPostImages, CancellationToken);
		var postImages = await ServiceScope.GetByIdRangeAsync(PostPostImageIds, CancellationToken);

		// Assert
		postImages.ShouldBeEmpty();
	}
}
