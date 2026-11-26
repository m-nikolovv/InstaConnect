
namespace InstaConnect.Identity.Domain.Tests.Features.Users.Utilities;

public static class UserSetups
{
	extension(IServiceProvider serviceProvider)
	{
		public IUserCommandService GetCommandService()
		{
			return serviceProvider.GetRequiredService<IUserCommandService>();
		}

		public IUserQueryService GetQueryService()
		{
			return serviceProvider.GetRequiredService<IUserQueryService>();
		}
	}

	extension(IServiceScope serviceScope)
	{
		public IUserCommandService GetCommandService()
		{
			return serviceScope.ServiceProvider.GetCommandService();
		}

		public IUserQueryService GetQueryService()
		{
			return serviceScope.ServiceProvider.GetQueryService();
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

		public async Task<UserResponse?> GetUserCacheByIdAsync(
			GetUserByIdQuery query,
			CancellationToken cancellationToken)
		{
			return await serviceScope.GetUserCacheByIdAsync(query.Id, query.Current.Id, cancellationToken);
		}

		public async Task InitializeAddAsync(
			AddUserCommand command,
			User user,
			CancellationToken cancellationToken)
		{
			await serviceScope.InitializeAddAsync(user, cancellationToken);
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

		public async Task InitializeGetAllAsync(
			GetAllUsersQuery query,
			ICollection<User> users,
			CancellationToken cancellationToken)
		{
			await serviceScope.InitializeGetAllAsync(users, cancellationToken);
		}

		public async Task DisposeGetAllAsync(
			GetAllUsersQuery query,
			ICollection<User> users,
			CancellationToken cancellationToken)
		{
			await serviceScope.DisposeGetAllAsync(users, cancellationToken);
		}

		public async Task InitializeGetByIdAsync(
			GetUserByIdQuery query,
			User user,
			CancellationToken cancellationToken)
		{
			await serviceScope.InitializeGetByIdAsync(user, cancellationToken);
		}

		public async Task DisposeGetByIdAsync(
			GetUserByIdQuery query,
			User user,
			CancellationToken cancellationToken)
		{
			await serviceScope.DisposeGetByIdAsync(user, cancellationToken);
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
