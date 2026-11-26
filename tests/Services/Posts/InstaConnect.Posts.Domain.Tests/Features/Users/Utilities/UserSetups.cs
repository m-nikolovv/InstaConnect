
namespace InstaConnect.Posts.Domain.Tests.Features.Users.Utilities;

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

		public async Task DisposeAddAsync(
			AddUserCommand command,
			User user,
			CancellationToken cancellationToken)
		{
			await serviceScope.DisposeAddAsync(user, cancellationToken);
		}

		public async Task InitializeDeleteAsync(
			DeleteUserCommand command,
			User user,
			CancellationToken cancellationToken)
		{
			await serviceScope.InitializeDeleteAsync(user, command.Id, cancellationToken);
		}

		public async Task DisposeDeleteAsync(
			DeleteUserCommand command,
			User user,
			CancellationToken cancellationToken)
		{
			await serviceScope.DisposeDeleteAsync(user, cancellationToken);
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

		public async Task InitializeUpdateAsync(
			UpdateUserCommand command,
			User user,
			CancellationToken cancellationToken)
		{
			await serviceScope.InitializeUpdateAsync(user, command.Id, cancellationToken);
		}

		public async Task DisposeUpdateAsync(
			UpdateUserCommand command,
			User user,
			CancellationToken cancellationToken)
		{
			await serviceScope.DisposeUpdateAsync(user, cancellationToken);
		}
	}
}
