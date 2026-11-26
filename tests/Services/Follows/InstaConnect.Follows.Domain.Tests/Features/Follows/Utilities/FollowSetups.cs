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

		public async Task InitializeAddAsync(
			AddFollowCommand command,
			Follow follow,
			CancellationToken cancellationToken)
		{
			await serviceScope.InitializeAddAsync(follow, cancellationToken);
		}

		public async Task DisposeAddAsync(
			AddFollowCommand command,
			Follow follow,
			CancellationToken cancellationToken)
		{
			await serviceScope.DisposeAddAsync(follow, cancellationToken);
		}

		public async Task InitializeDeleteAsync(
			DeleteFollowCommand command,
			Follow follow,
			CancellationToken cancellationToken)
		{
			await serviceScope.InitializeDeleteAsync(follow, command.Id.FollowerId, cancellationToken);
		}

		public async Task DisposeDeleteAsync(
			DeleteFollowCommand command,
			Follow follow,
			CancellationToken cancellationToken)
		{
			await serviceScope.DisposeDeleteAsync(follow, cancellationToken);
		}

		public async Task AddFollowCacheAsync(
			DeleteFollowCommand command,
			Follow follow,
			CancellationToken cancellationToken)
		{
			await serviceScope.AddFollowCacheAsync(follow, command.Id.FollowerId, cancellationToken);
		}

		public async Task InitializeGetAllAsync(
			GetAllFollowsForFollowingQuery query,
			ICollection<Follow> follows,
			CancellationToken cancellationToken)
		{
			await serviceScope.InitializeGetAllAsync(follows, cancellationToken);
		}

		public async Task InitializeGetAllAsync(
			GetAllFollowsQuery query,
			ICollection<Follow> follows,
			CancellationToken cancellationToken)
		{
			await serviceScope.InitializeGetAllAsync(follows, cancellationToken);
		}

		public async Task DisposeGetAllAsync(
			GetAllFollowsForFollowingQuery query,
			ICollection<Follow> follows,
			CancellationToken cancellationToken)
		{
			await serviceScope.DisposeGetAllAsync(follows, cancellationToken);
		}

		public async Task DisposeGetAllAsync(
			GetAllFollowsQuery query,
			ICollection<Follow> follows,
			CancellationToken cancellationToken)
		{
			await serviceScope.DisposeGetAllAsync(follows, cancellationToken);
		}

		public async Task InitializeGetByIdAsync(
			GetFollowByIdQuery query,
			Follow follow,
			CancellationToken cancellationToken)
		{
			await serviceScope.InitializeGetByIdAsync(follow, cancellationToken);
		}

		public async Task DisposeGetByIdAsync(
			GetFollowByIdQuery query,
			Follow follow,
			CancellationToken cancellationToken)
		{
			await serviceScope.DisposeGetByIdAsync(follow, cancellationToken);
		}
	}
}
