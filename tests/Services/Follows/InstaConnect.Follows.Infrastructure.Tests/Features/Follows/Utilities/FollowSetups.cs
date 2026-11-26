using InstaConnect.Follows.Domain.Features.Follows.Models.Responses;
using Microsoft.Extensions.DependencyInjection;

namespace InstaConnect.Follows.Infrastructure.Tests.Features.Follows.Utilities;

public static class FollowSetups
{
	extension(IServiceScope serviceScope)
	{
		public async Task<FollowResponse?> GetFollowCacheByIdAsync(
			Follow follow,
			UserId currentUserId,
			CancellationToken cancellationToken)
		{
			return await serviceScope.GetFollowCacheByIdAsync(follow.Id, currentUserId, cancellationToken);
		}

		public async Task<FollowResponse?> GetFollowCacheByIdAsync(
			FollowId id,
			CurrentUserQuery currentUserQuery,
			CancellationToken cancellationToken)
		{
			return await serviceScope.GetFollowCacheByIdAsync(id, currentUserQuery.Id, cancellationToken);
		}
	}

}
