using InstaConnect.Identity.Infrastructure.Features.Users.Abstractions;

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
	}

	extension(IUserCacheHandler cacheHandler)
	{
		public async Task<UserResponse?> GetByIdAsync(
			VerifyEmailConfirmationTokenCommand command,
			CancellationToken cancellationToken)
		{
			return await cacheHandler.GetByIdAsync(command.Id.Id, command.Id.Id, cancellationToken);
		}
	}
}
