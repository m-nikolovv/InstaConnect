using InstaConnect.Identity.Presentation.Features.EmailConfirmationTokens.Controllers.v1;

namespace InstaConnect.Identity.Presentation.Tests.Features.EmailConfirmationTokens.Utilities;

public static class EmailConfirmationTokenSetups
{
	extension(IServiceProvider serviceProvider)
	{
		public EmailConfirmationTokenController GetEmailConfirmationTokenController()
		{
			return serviceProvider.GetRequiredService<EmailConfirmationTokenController>();
		}
	}

	extension(IServiceScope serviceScope)
	{
		public EmailConfirmationTokenController GetEmailConfirmationTokenController()
		{
			return serviceScope.ServiceProvider.GetEmailConfirmationTokenController();
		}
	}
}
