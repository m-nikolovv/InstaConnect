using InstaConnect.Follows.Domain.Features.Users.Models.Responses;
using InstaConnect.Follows.Infrastructure.Features.Users.EventHandlers;

using Microsoft.Extensions.DependencyInjection;

namespace InstaConnect.Follows.Infrastructure.Tests.Features.Users.Utilities;

public static class UserSetups
{
	extension(IServiceProvider serviceProvider)
	{
		public UserAddedEventHandler GetUserAddedEventHandler()
		{
			return serviceProvider.GetRequiredService<UserAddedEventHandler>();
		}

		public UserUpdatedEventHandler GetUserUpdatedEventHandler()
		{
			return serviceProvider.GetRequiredService<UserUpdatedEventHandler>();
		}

		public UserDeletedEventHandler GetUserDeletedEventHandler()
		{
			return serviceProvider.GetRequiredService<UserDeletedEventHandler>();
		}
	}

	extension(IServiceScope serviceScope)
	{
		public UserAddedEventHandler GetUserAddedEventHandler()
		{
			return serviceScope.ServiceProvider.GetUserAddedEventHandler();
		}

		public UserUpdatedEventHandler GetUserUpdatedEventHandler()
		{
			return serviceScope.ServiceProvider.GetUserUpdatedEventHandler();
		}

		public UserDeletedEventHandler GetUserDeletedEventHandler()
		{
			return serviceScope.ServiceProvider.GetUserDeletedEventHandler();
		}

		public async Task<UserResponse?> GetUserCacheByIdAsync(
			User user,
			CancellationToken cancellationToken)
		{
			return await serviceScope.GetUserCacheByIdAsync(user.Id, user.Id, cancellationToken);
		}

		public async Task<UserResponse?> GetUserCacheByIdAsync(
			UserId id,
			CurrentUserQuery currentUserQuery,
			CancellationToken cancellationToken)
		{
			return await serviceScope.GetUserCacheByIdAsync(id, currentUserQuery.Id, cancellationToken);
		}

		public async Task SetupUpdateUserAsync(
			User user,
			CancellationToken cancellationToken)
		{
			await serviceScope.SetupUpdateUserAsync(user, user.Id, cancellationToken);
		}

		public async Task SetupDeleteUserAsync(
			User user,
			User follower,
			User following,
			ICollection<Follow> followFollowers,
			ICollection<Follow> followFollowings,
			CancellationToken cancellationToken)
		{
			await serviceScope.SetupDeleteUserAsync(user, follower, following, followFollowers, followFollowings, user.Id, cancellationToken);
		}
	}
}
