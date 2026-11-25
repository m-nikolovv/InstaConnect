using InstaConnect.Follows.Domain.Features.Follows.Models.Responses;
using InstaConnect.Follows.Infrastructure.Features.Follows.Abstractions;

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
	}

	extension(IFollowCacheHandler cacheHandler)
	{
		public async Task<FollowResponse?> GetByIdAsync(
			DeleteFollowCommand command,
			CancellationToken cancellationToken)
		{
			return await cacheHandler.GetByIdAsync(command.Id, command.Id.FollowerId, cancellationToken);
		}

		public async Task<FollowResponse?> GetByIdAsync(
			GetFollowByIdQuery query,
			CancellationToken cancellationToken)
		{
			return await cacheHandler.GetByIdAsync(query.Id, query.CurrentUser.Id, cancellationToken);
		}
	}
}
