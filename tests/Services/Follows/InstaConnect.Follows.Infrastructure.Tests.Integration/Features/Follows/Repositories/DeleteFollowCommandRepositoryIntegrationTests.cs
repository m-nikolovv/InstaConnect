using InstaConnect.Follows.Infrastructure.Tests.Features.Follows.Utilities;

namespace InstaConnect.Follows.Infrastructure.Tests.Integration.Features.Follows.Repositories;

public class DeleteFollowCommandRepositoryIntegrationTests : BaseFollowInfrastructureCommandIntegrationTest
{
	public DeleteFollowCommandRepositoryIntegrationTests(FollowsWebApplicationFactory webApplicationFactory)
		: base(webApplicationFactory)
	{
	}

	public override async Task InitializeAsync()
	{
		await ServiceScope.SetupDeleteFollowAsync(
			Follower,
			Following,
			Follow,
			CancellationToken);
	}

	[Fact]
	public async Task DeleteAsync_ShouldDeleteFollow_WhenCommandIsValid()
	{
		// Act
		await Repository.DeleteAsync(Follow, CancellationToken);
		var follow = await ServiceScope.GetByIdAsync(FollowId, CancellationToken);

		// Assert
		follow.ShouldBeNull();
	}

	[Fact]
	public async Task DeleteAsync_ShouldDeleteCachedFollow_WhenCommandIsValid()
	{
		// Act
		await Repository.DeleteAsync(Follow, CancellationToken);
		var cachedFollow = await ServiceScope.GetFollowCacheByIdAsync(Follow, CancellationToken);

		// Assert
		cachedFollow.ShouldBeNull();
	}
}
