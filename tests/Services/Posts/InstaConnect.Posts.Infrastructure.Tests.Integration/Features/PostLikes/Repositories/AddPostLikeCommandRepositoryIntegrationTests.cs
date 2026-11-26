using InstaConnect.Posts.Infrastructure.Tests.Features.PostLikes.Utilities;
using InstaConnect.Posts.Tests.Features.PostLikes.Assertions;

namespace InstaConnect.Posts.Infrastructure.Tests.Integration.Features.PostLikes.Repositories;

public class AddPostLikeCommandRepositoryIntegrationTests : BasePostLikeInfrastructureCommandIntegrationTest
{
	public AddPostLikeCommandRepositoryIntegrationTests(PostsWebApplicationFactory webApplicationFactory)
		: base(webApplicationFactory)
	{
	}

	public override async Task InitializeAsync()
	{
		await ServiceScope.SetupAddAsync(PostLike, CancellationToken);
	}

	[Fact]
	public async Task AddAsync_ShouldAddPostLike_WhenCommandIsValid()
	{
		// Act
		await Repository.AddAsync(PostLike, CancellationToken);
		var postLike = await ServiceScope.GetByIdAsync(PostLikeId, CancellationToken);

		// Assert
		postLike.ShouldSatisfy(PostLike);
	}

	[Fact]
	public async Task AddAsync_ShouldDeleteCachedPost_WhenCommandIsValid()
	{
		// Act
		await Repository.AddAsync(PostLike, CancellationToken);
		var cachedPost = await ServiceScope.GetPostCacheByIdAsync(PostLike, CancellationToken);

		// Assert
		cachedPost.ShouldBeNull();
	}
}
