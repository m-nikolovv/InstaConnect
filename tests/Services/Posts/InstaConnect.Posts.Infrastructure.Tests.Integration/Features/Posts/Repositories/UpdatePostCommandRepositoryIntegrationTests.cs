using InstaConnect.Posts.Infrastructure.Tests.Features.Posts.Utilities;

namespace InstaConnect.Posts.Infrastructure.Tests.Integration.Features.Posts.Repositories;

public class UpdatePostCommandRepositoryIntegrationTests : BasePostInfrastructureCommandIntegrationTest
{
	public UpdatePostCommandRepositoryIntegrationTests(PostsWebApplicationFactory webApplicationFactory)
		: base(webApplicationFactory)
	{
	}

	public override async Task InitializeAsync()
	{
		await ServiceScope.SetupUpdatePostAsync(
			User,
			Post,
			PostPostImages,
			CancellationToken);
	}

	[Fact]
	public async Task UpdateAsync_ShouldUpdatePost_WhenCommandIsValid()
	{
		var updatedPost = PostBuilderFactory.Create(User).WithId(PostId).Build();

		// Act
		await Repository.UpdateAsync(updatedPost, CancellationToken);
		var post = await ServiceScope.GetByIdAsync(PostId, CancellationToken);

		// Assert
		post.ShouldSatisfy(updatedPost);
	}

	[Fact]
	public async Task UpdateAsync_ShouldDeleteCachedPost_WhenCommandIsValid()
	{
		// Arrange
		var updatedPost = PostBuilderFactory.Create(User).WithId(PostId).Build();

		// Act
		await Repository.UpdateAsync(updatedPost, CancellationToken);
		var cachedPost = await ServiceScope.GetPostCacheByIdAsync(updatedPost, CancellationToken);

		// Assert
		cachedPost.ShouldBeNull();
	}
}
