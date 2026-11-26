using InstaConnect.Follows.Infrastructure.Tests.Features.Users.Utilities;

namespace InstaConnect.Follows.Infrastructure.Tests.Integration.Features.Users.Repositories;

public class DeleteUserCommandRepositoryIntegrationTests : BaseUserInfrastructureCommandIntegrationTest
{
	public DeleteUserCommandRepositoryIntegrationTests(FollowsWebApplicationFactory webApplicationFactory)
		: base(webApplicationFactory)
	{
	}

	public override async Task InitializeAsync()
	{
		await ServiceScope.SetupDeleteAsync(User, CurrentUserId, CancellationToken);
	}

	[Fact]
	public async Task DeleteAsync_ShouldDeleteUser_WhenCommandIsValid()
	{
		// Act
		await Repository.DeleteAsync(User, CancellationToken);
		var user = await ServiceScope.GetByIdAsync(UserId, CancellationToken);

		// Assert
		user.ShouldBeNull();
	}

	[Fact]
	public async Task DeleteAsync_ShouldDeleteCachedUser_WhenCommandIsValid()
	{
		// Act
		await Repository.DeleteAsync(User, CancellationToken);
		var cachedUser = await ServiceScope.GetUserCacheByIdAsync(User, CurrentUserId, CancellationToken);

		// Assert
		cachedUser.ShouldBeNull();
	}

	[Fact]
	public async Task DeleteAsync_ShouldDeleteUserFollowFollowers_WhenCommandIsValid()
	{
		// Act
		await Repository.DeleteAsync(User, CancellationToken);
		var userFollowFollowers = await ServiceScope.GetByIdRangeAsync(UserFollowFollowerIds, CancellationToken);

		// Assert
		userFollowFollowers.ShouldBeEmpty();
	}

	[Fact]
	public async Task DeleteAsync_ShouldDeleteUserFollowFollowings_WhenCommandIsValid()
	{
		// Act
		await Repository.DeleteAsync(User, CancellationToken);
		var userFollowFollowings = await ServiceScope.GetByIdRangeAsync(UserFollowFollowingIds, CancellationToken);

		// Assert
		userFollowFollowings.ShouldBeEmpty();
	}
}
