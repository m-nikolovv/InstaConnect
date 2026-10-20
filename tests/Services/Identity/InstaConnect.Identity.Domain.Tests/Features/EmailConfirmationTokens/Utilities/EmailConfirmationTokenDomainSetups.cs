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
}
