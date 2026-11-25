using InstaConnect.Posts.Infrastructure.Tests.Features.PostLikes.Utilities;

namespace InstaConnect.Posts.Infrastructure.Tests.Integration.Features.PostLikes.Repositories;

public class DeletePostLikeCommandRepositoryIntegrationTests : BasePostLikeInfrastructureCommandIntegrationTest
{
	public DeletePostLikeCommandRepositoryIntegrationTests(PostsWebApplicationFactory webApplicationFactory)
		: base(webApplicationFactory)
	{
	}

	protected override async Task OnInitializeAsync()
	{
		await ServiceScope.AddAsync(PostLike, CancellationToken);
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
		var cachedPostLike = await LikeCacheHandler.GetByIdAsync(PostLike, CurrentUserId, CancellationToken);

		// Assert
		cachedPostLike.ShouldBeNull();
	}

	[Fact]
	public async Task DeleteAsync_ShouldDeleteCachedPost_WhenCommandIsValid()
	{
		// Act
		await Repository.DeleteAsync(PostLike, CancellationToken);
		var cachedPost = await CacheHandler.GetByIdAsync(PostLike, CurrentUserId, CancellationToken);

		// Assert
		cachedPost.ShouldBeNull();
	}
}
