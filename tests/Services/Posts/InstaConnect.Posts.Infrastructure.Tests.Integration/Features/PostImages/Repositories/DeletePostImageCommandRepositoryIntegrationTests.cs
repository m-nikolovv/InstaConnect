using InstaConnect.Posts.Infrastructure.Tests.Features.Posts.Utilities;

namespace InstaConnect.Posts.Infrastructure.Tests.Integration.Features.PostImages.Repositories;

public class DeletePostImageCommandRepositoryIntegrationTests : BasePostImageInfrastructureCommandIntegrationTest
{
	public DeletePostImageCommandRepositoryIntegrationTests(PostsWebApplicationFactory webApplicationFactory)
		: base(webApplicationFactory)
	{
	}

	protected override async Task OnInitializeAsync()
	{
		await ServiceScope.AddAsync(PostImage, CancellationToken);
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
		var cachedPost = await CacheHandler.GetByIdAsync(Post, CurrentUserId, CancellationToken);

		// Assert
		cachedPost.ShouldBeNull();
	}
}
