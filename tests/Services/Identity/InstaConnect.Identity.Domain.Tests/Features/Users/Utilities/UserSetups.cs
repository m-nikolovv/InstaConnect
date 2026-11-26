
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

		public async Task SetupAddAsync(
			AddUserCommand command,
			User user,
			CancellationToken cancellationToken)
		{
			await serviceScope.SetupAddUserAsync(user, cancellationToken);
		}

		public async Task SetupDeleteAsync(
			DeleteUserCommand command,
			User user,
			ICollection<UserClaim> userClaims,
			ICollection<RefreshToken> refreshTokens,
			ICollection<ForgotPasswordToken> forgotPasswordTokens,
			ICollection<EmailConfirmationToken> emailConfirmationTokens,
			CancellationToken cancellationToken)
		{
			await serviceScope.SetupDeleteUserAsync(user, userClaims, refreshTokens, forgotPasswordTokens, emailConfirmationTokens, command.Id, cancellationToken);
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

		public async Task SetupGetAllAsync(
			GetAllUsersQuery query,
			ICollection<User> users,
			CancellationToken cancellationToken)
		{
			await serviceScope.SetupGetAllUsersAsync(users, cancellationToken);
		}

		public async Task SetupGetByIdAsync(
			GetUserByIdQuery query,
			User user,
			CancellationToken cancellationToken)
		{
			await serviceScope.SetupGetUserByIdAsync(user, cancellationToken);
		}

		public async Task SetupUpdateAsync(
			UpdateUserCommand command,
			User user,
			ICollection<EmailConfirmationToken> emailConfirmationTokens,
			CancellationToken cancellationToken)
		{
			await serviceScope.SetupUpdateUserAsync(user, emailConfirmationTokens, command.Id, cancellationToken);
		}
	}
}
