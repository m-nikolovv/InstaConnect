using InstaConnect.Posts.Tests.Features.PostImages.Assertions;

namespace InstaConnect.Posts.Infrastructure.Tests.Integration.Features.PostImages.Repositories;

public class AddPostImageCommandRepositoryIntegrationTests : BasePostImageInfrastructureCommandIntegrationTest
{
	public AddPostImageCommandRepositoryIntegrationTests(PostsWebApplicationFactory webApplicationFactory)
		: base(webApplicationFactory)
	{
	}

	public override async Task InitializeAsync()
	{
		await ServiceScope.SetupAddAsync(PostImage, UserId, CancellationToken);
	}

	[Fact]
	public async Task AddAsync_ShouldAddPostImage_WhenCommandIsValid()
	{
		// Act
		await Repository.AddAsync(PostImage, CancellationToken);
		var postImage = await ServiceScope.GetByIdAsync(PostImageId, CancellationToken);

		// Assert
		postImage.ShouldSatisfy(PostImage);
	}

	[Fact]
	public async Task AddAsync_ShouldDeleteCachedPost_WhenCommandIsValid()
	{
		// Act
		await Repository.AddAsync(PostImage, CancellationToken);
		var cachedPost = await ServiceScope.GetPostCacheByIdAsync(Post, UserId, CancellationToken);

		// Assert
		cachedPost.ShouldBeNull();
	}
}
