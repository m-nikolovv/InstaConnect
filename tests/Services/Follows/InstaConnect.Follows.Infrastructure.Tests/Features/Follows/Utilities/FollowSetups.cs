using InstaConnect.Follows.Domain.Features.Follows.Models.Responses;
using Microsoft.Extensions.DependencyInjection;

namespace InstaConnect.Follows.Infrastructure.Tests.Features.Follows.Utilities;

public static class FollowSetups
{
	extension(IServiceScope serviceScope)
	{
		public async Task<FollowResponse?> GetFollowCacheByIdAsync(
			Follow follow,
			CancellationToken cancellationToken)
		{
			return await serviceScope.GetFollowCacheByIdAsync(follow.Id, follow.Id.FollowerId, cancellationToken);
		}

		public async Task<FollowResponse?> GetFollowCacheByIdAsync(
			FollowId id,
			CurrentUserQuery currentUserQuery,
			CancellationToken cancellationToken)
		{
			return await serviceScope.GetFollowCacheByIdAsync(id, currentUserQuery.Id, cancellationToken);
		}

		public async Task SetupDeleteAsync(
			Follow follow,
			CancellationToken cancellationToken)
		{
			await serviceScope.SetupDeleteAsync(follow, follow.Id.FollowerId, cancellationToken);
		}
	}

}
