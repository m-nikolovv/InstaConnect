using InstaConnect.Chats.Domain.Features.Users.Models.Responses;
using InstaConnect.Chats.Infrastructure.Features.Users.EventHandlers;

using Microsoft.Extensions.DependencyInjection;

namespace InstaConnect.Chats.Infrastructure.Tests.Features.Users.Utilities;

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
