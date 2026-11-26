using InstaConnect.Identity.Domain.Features.UserClaims.Models.Responses;
using Microsoft.Extensions.DependencyInjection;

namespace InstaConnect.Identity.Infrastructure.Tests.Features.UserClaims.Utilities;

public static class UserClaimSetups
{
	extension(IServiceScope serviceScope)
	{
		public async Task<UserClaimResponse?> GetUserClaimCacheByIdAsync(
			UserClaim userClaim,
			UserId currentUserId,
			CancellationToken cancellationToken)
		{
			return await serviceScope.GetUserClaimCacheByIdAsync(userClaim.Id, currentUserId, cancellationToken);
		}

		public async Task<UserClaimResponse?> GetUserClaimCacheByIdAsync(
			UserClaimId id,
			CurrentUserQuery currentUserQuery,
			CancellationToken cancellationToken)
		{
			return await serviceScope.GetUserClaimCacheByIdAsync(id, currentUserQuery.Id, cancellationToken);
		}
	}

}
