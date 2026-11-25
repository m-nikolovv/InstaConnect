using InstaConnect.Follows.Infrastructure.Tests.Features.Users.Utilities;

namespace InstaConnect.Follows.Infrastructure.Tests.Integration.Features.Users.Repositories;

public class DeleteUserCommandRepositoryIntegrationTests : BaseUserInfrastructureCommandIntegrationTest
{
	public DeleteUserCommandRepositoryIntegrationTests(FollowsWebApplicationFactory webApplicationFactory)
		: base(webApplicationFactory)
	{
	}

	protected override async Task OnInitializeAsync()
	{
		await ServiceScope.AddAsync(User, CurrentUserId, CancellationToken);
		await ServiceScope.AddRangeAsync(Follows, CurrentUserId, CancellationToken);
		await ServiceScope.AddRangeAsync(UserFollowFollowers, CurrentUserId, CancellationToken);
		await ServiceScope.AddRangeAsync(UserFollowFollowings, CurrentUserId, CancellationToken);
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
		var cachedUser = await CacheHandler.GetByIdAsync(User, CurrentUserId, CancellationToken);

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
