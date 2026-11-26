using InstaConnect.Posts.Infrastructure.Tests.Features.PostLikes.Utilities;

namespace InstaConnect.Posts.Infrastructure.Tests.Integration.Features.PostLikes.Repositories;

public class DeletePostLikeCommandRepositoryIntegrationTests : BasePostLikeInfrastructureCommandIntegrationTest
{
	public DeletePostLikeCommandRepositoryIntegrationTests(PostsWebApplicationFactory webApplicationFactory)
		: base(webApplicationFactory)
	{
	}

	public override async Task InitializeAsync()
	{
		await ServiceScope.SetupDeleteAsync(PostLike, CancellationToken);
	}

	[Fact]
	public async Task DeleteAsync_ShouldDeletePostLike_WhenCommandIsValid()
	{
		// Act
		await Repository.DeleteAsync(PostLike, CancellationToken);
		var postLike = await ServiceScope.GetByIdAsync(PostLikeId, CancellationToken);

		// Assert
		postLike.ShouldBeNull();
	}

	[Fact]
	public async Task DeleteAsync_ShouldDeleteCachedPostLike_WhenCommandIsValid()
	{
		// Act
		await Repository.DeleteAsync(PostLike, CancellationToken);
		var cachedPostLike = await ServiceScope.GetPostLikeCacheByIdAsync(PostLike, CancellationToken);

		// Assert
		cachedPostLike.ShouldBeNull();
	}

	[Fact]
	public async Task DeleteAsync_ShouldDeleteCachedPost_WhenCommandIsValid()
	{
		// Act
		await Repository.DeleteAsync(PostLike, CancellationToken);
		var cachedPost = await ServiceScope.GetPostCacheByIdAsync(PostLike, CancellationToken);

		// Assert
		cachedPost.ShouldBeNull();
	}
}
