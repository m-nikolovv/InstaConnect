using InstaConnect.Identity.Domain.Features.Users.Models.Responses;
using Microsoft.Extensions.DependencyInjection;

namespace InstaConnect.Identity.Infrastructure.Tests.Features.Users.Utilities;

public static class UserSetups
{
	extension(IServiceScope serviceScope)
	{
		public async Task<UserResponse?> GetUserCacheByIdAsync(
			User user,
			UserId currentUserId,
			CancellationToken cancellationToken)
		{
			return await serviceScope.GetUserCacheByIdAsync(user.Id, currentUserId, cancellationToken);
		}

		public async Task<UserResponse?> GetUserCacheByIdAsync(
			UserId id,
			CurrentUserQuery currentUserQuery,
			CancellationToken cancellationToken)
		{
			return await serviceScope.GetUserCacheByIdAsync(id, currentUserQuery.Id, cancellationToken);
		}
	}

}
