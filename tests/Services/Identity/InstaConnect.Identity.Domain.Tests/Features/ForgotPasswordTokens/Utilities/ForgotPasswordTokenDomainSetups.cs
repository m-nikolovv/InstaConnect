namespace InstaConnect.Identity.Domain.Tests.Features.ForgotPasswordTokens.Utilities;

public static class ForgotPasswordTokenDomainSetups
{
	extension(IServiceProvider serviceProvider)
	{
		public IForgotPasswordTokenCommandService GetForgotPasswordTokenCommandService()
		{
			return serviceProvider.GetRequiredService<IForgotPasswordTokenCommandService>();
		}
	}

	extension(IServiceScope serviceScope)
	{
		public IForgotPasswordTokenCommandService GetForgotPasswordTokenCommandService()
		{
			return serviceScope.ServiceProvider.GetForgotPasswordTokenCommandService();
		}
	}
}
