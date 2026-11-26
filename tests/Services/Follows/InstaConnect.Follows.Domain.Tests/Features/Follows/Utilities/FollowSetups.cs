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
			Follow follow,
			CancellationToken cancellationToken)
		{
			await serviceScope.SetupAddAsync(follow, cancellationToken);
		}

		public async Task SetupDeleteAsync(
			DeleteFollowCommand command,
			Follow follow,
			CancellationToken cancellationToken)
		{
			await serviceScope.SetupDeleteAsync(follow, command.Id.FollowerId, cancellationToken);
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
			ICollection<Follow> follows,
			CancellationToken cancellationToken)
		{
			await serviceScope.SetupGetAllAsync(follows, cancellationToken);
		}

		public async Task SetupGetAllAsync(
			GetAllFollowsQuery query,
			ICollection<Follow> follows,
			CancellationToken cancellationToken)
		{
			await serviceScope.SetupGetAllAsync(follows, cancellationToken);
		}


		public async Task SetupGetByIdAsync(
			GetFollowByIdQuery query,
			Follow follow,
			CancellationToken cancellationToken)
		{
			await serviceScope.SetupGetByIdAsync(follow, cancellationToken);
		}
	}
}
