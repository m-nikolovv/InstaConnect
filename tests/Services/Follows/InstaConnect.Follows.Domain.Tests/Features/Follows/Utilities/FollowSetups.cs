using InstaConnect.Follows.Domain.Features.Follows.Models.Responses;

namespace InstaConnect.Follows.Domain.Tests.Features.Follows.Utilities;

public static class FollowDomainSetups
{
	extension(IServiceProvider serviceProvider)
	{
		public IFollowCommandService GetFollowCommandService()
		{
			return serviceProvider.GetRequiredService<IFollowCommandService>();
		}

		public IFollowQueryService GetFollowQueryService()
		{
			return serviceProvider.GetRequiredService<IFollowQueryService>();
		}
	}

	extension(IServiceScope serviceScope)
	{
		public IFollowCommandService GetFollowCommandService()
		{
			return serviceScope.ServiceProvider.GetFollowCommandService();
		}

		public IFollowQueryService GetFollowQueryService()
		{
			return serviceScope.ServiceProvider.GetFollowQueryService();
		}

		public async Task<FollowResponse?> GetFollowCacheByIdAsync(
			DeleteFollowCommand command,
			CancellationToken cancellationToken)
		{
			return await serviceScope.GetFollowCacheByIdAsync(command.Id, command.Id.FollowerId, cancellationToken);
		}

		public async Task<FollowResponse?> GetFollowCacheByIdAsync(
			GetFollowByIdQuery query,
			CancellationToken cancellationToken)
		{
			return await serviceScope.GetFollowCacheByIdAsync(query.Id, query.CurrentUser.Id, cancellationToken);
		}

		public async Task SetupAddAsync(
			AddFollowCommand command,
			User follower,
			User following,
			CancellationToken cancellationToken)
		{
			await serviceScope.SetupAddFollowAsync(follower, following, cancellationToken);
		}

		public async Task SetupDeleteAsync(
			DeleteFollowCommand command,
			User follower,
			User following,
			Follow follow,
			CancellationToken cancellationToken)
		{
			await serviceScope.SetupDeleteFollowAsync(follower, following, follow, command.Id.FollowerId, cancellationToken);
		}

		public async Task AddFollowCacheAsync(
			DeleteFollowCommand command,
			Follow follow,
			CancellationToken cancellationToken)
		{
			await serviceScope.AddFollowCacheAsync(follow, command.Id.FollowerId, cancellationToken);
		}

		public async Task SetupGetAllAsync(
			GetAllFollowsForFollowingQuery query,
			ICollection<User> followers,
			ICollection<User> followings,
			ICollection<Follow> follows,
			CancellationToken cancellationToken)
		{
			await serviceScope.SetupGetAllFollowsAsync(followers, followings, follows, cancellationToken);
		}

		public async Task SetupGetAllAsync(
			GetAllFollowsQuery query,
			ICollection<User> followers,
			ICollection<User> followings,
			ICollection<Follow> follows,
			CancellationToken cancellationToken)
		{
			await serviceScope.SetupGetAllFollowsAsync(followers, followings, follows, cancellationToken);
		}


		public async Task SetupGetByIdAsync(
			GetFollowByIdQuery query,
			User follower,
			User following,
			Follow follow,
			CancellationToken cancellationToken)
		{
			await serviceScope.SetupGetFollowByIdAsync(follower, following, follow, cancellationToken);
		}
	}
}
