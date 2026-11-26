using InstaConnect.Follows.Domain.Features.Users.Models.Responses;

namespace InstaConnect.Follows.Domain.Tests.Features.Users.Utilities;

public static class UserSetups
{
	extension(IServiceProvider serviceProvider)
	{
		public IUserCommandService GetUserCommandService()
		{
			return serviceProvider.GetRequiredService<IUserCommandService>();
		}
	}

	extension(IServiceScope serviceScope)
	{
		public IUserCommandService GetUserCommandService()
		{
			return serviceScope.ServiceProvider.GetUserCommandService();
		}

		public async Task<UserResponse?> GetUserCacheByIdAsync(
			UpdateUserCommand command,
			CancellationToken cancellationToken)
		{
			return await serviceScope.GetUserCacheByIdAsync(command.Id, command.Id, cancellationToken);
		}

		public async Task<UserResponse?> GetUserCacheByIdAsync(
			DeleteUserCommand command,
			CancellationToken cancellationToken)
		{
			return await serviceScope.GetUserCacheByIdAsync(command.Id, command.Id, cancellationToken);
		}

		public async Task SetupDeleteAsync(
			DeleteUserCommand command,
			User user,
			User follower,
			User following,
			ICollection<Follow> followFollowers,
			ICollection<Follow> followFollowings,
			CancellationToken cancellationToken)
		{
			await serviceScope.SetupDeleteUserAsync(user, follower, following, followFollowers, followFollowings, command.Id, cancellationToken);
		}

		public async Task AddUserCacheAsync(
			DeleteUserCommand command,
			User user,
			CancellationToken cancellationToken)
		{
			await serviceScope.AddUserCacheAsync(user, command.Id, cancellationToken);
		}

		public async Task AddUserCacheAsync(
			UpdateUserCommand command,
			User user,
			CancellationToken cancellationToken)
		{
			await serviceScope.AddUserCacheAsync(user, command.Id, cancellationToken);
		}

		public async Task SetupUpdateAsync(
			UpdateUserCommand command,
			User user,
			CancellationToken cancellationToken)
		{
			await serviceScope.SetupUpdateUserAsync(user, command.Id, cancellationToken);
		}
	}
}
