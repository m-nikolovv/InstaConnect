

namespace InstaConnect.Posts.Infrastructure.Tests.Integration.Features.PostImages.Repositories;

public class DeletePostImageCommandRepositoryIntegrationTests : BasePostImageInfrastructureCommandIntegrationTest
{
	public DeletePostImageCommandRepositoryIntegrationTests(PostsWebApplicationFactory webApplicationFactory)
		: base(webApplicationFactory)
	{
	}

	public override async Task InitializeAsync()
	{
		await ServiceScope.SetupDeleteAsync(PostImage, UserId, CancellationToken);
	}

	[Fact]
	public async Task DeleteAsync_ShouldDeletePostImage_WhenCommandIsValid()
	{
		// Act
		await Repository.DeleteAsync(PostImage, CancellationToken);
		var postImage = await ServiceScope.GetByIdAsync(PostImageId, CancellationToken);

		// Assert
		postImage.ShouldBeNull();
	}

	[Fact]
	public async Task DeleteAsync_ShouldDeleteCachedPost_WhenCommandIsValid()
	{
		// Act
		await Repository.DeleteAsync(PostImage, CancellationToken);
		var cachedPost = await ServiceScope.GetPostCacheByIdAsync(Post, UserId, CancellationToken);

		// Assert
		cachedPost.ShouldBeNull();
	}
}
