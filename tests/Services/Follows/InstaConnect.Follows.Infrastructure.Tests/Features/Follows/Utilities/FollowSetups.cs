using InstaConnect.Follows.Domain.Features.Follows.Models.Responses;
using InstaConnect.Follows.Infrastructure.Features.Follows.Abstractions;

namespace InstaConnect.Follows.Infrastructure.Tests.Features.Follows.Utilities;

public static class FollowSetups
{
	extension(IFollowCacheHandler cacheHandler)
	{
		public async Task<FollowResponse?> GetByIdAsync(
			Follow follow,
			UserId currentUserId,
			CancellationToken cancellationToken)
		{
			return await cacheHandler.GetByIdAsync(follow.Id, currentUserId, cancellationToken);
		}

		public async Task<FollowResponse?> GetByIdAsync(
			FollowId id,
			CurrentUserQuery currentUserQuery,
			CancellationToken cancellationToken)
		{
			return await cacheHandler.GetByIdAsync(id, currentUserQuery.Id, cancellationToken);
		}
	}
}
