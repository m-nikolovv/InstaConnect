
namespace InstaConnect.Identity.Domain.Tests.Features.EmailConfirmationTokens.Utilities;

public static class EmailConfirmationTokenDomainSetups
{
	extension(IServiceProvider serviceProvider)
	{
		public IEmailConfirmationTokenCommandService GetEmailConfirmationTokenCommandService()
		{
			return serviceProvider.GetRequiredService<IEmailConfirmationTokenCommandService>();
		}
	}

	extension(IServiceScope serviceScope)
	{
		public IEmailConfirmationTokenCommandService GetEmailConfirmationTokenCommandService()
		{
			return serviceScope.ServiceProvider.GetEmailConfirmationTokenCommandService();
		}

		public async Task<UserResponse?> GetUserCacheByIdAsync(
			VerifyEmailConfirmationTokenCommand command,
			CancellationToken cancellationToken)
		{
			return await serviceScope.GetUserCacheByIdAsync(command.Id.Id, command.Id.Id, cancellationToken);
		}

		public async Task SetupAddAsync(
			AddEmailConfirmationTokenCommand command,
			User user,
			CancellationToken cancellationToken)
		{
			await serviceScope.SetupAddEmailConfirmationTokenAsync(user, cancellationToken);
		}

		public async Task SetupVerifyAsync(
			VerifyEmailConfirmationTokenCommand command,
			User user,
			ICollection<EmailConfirmationToken> emailConfirmationTokens,
			CancellationToken cancellationToken)
		{
			await serviceScope.SetupVerifyEmailConfirmationTokenAsync(user, emailConfirmationTokens, command.Id.Id, cancellationToken);
		}

		public async Task AddUserCacheAsync(
			VerifyEmailConfirmationTokenCommand command,
			User user,
			CancellationToken cancellationToken)
		{
			await serviceScope.AddUserCacheAsync(user, command.Id.Id, cancellationToken);
		}
	}
}
