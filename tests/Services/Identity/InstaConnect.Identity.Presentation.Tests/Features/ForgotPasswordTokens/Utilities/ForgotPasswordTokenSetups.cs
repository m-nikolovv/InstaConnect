using InstaConnect.Identity.Presentation.Features.ForgotPasswordTokens.Controllers.v1;

namespace InstaConnect.Identity.Presentation.Tests.Features.ForgotPasswordTokens.Utilities;

public static class ForgotPasswordTokenSetups
{
	extension(IServiceProvider serviceProvider)
	{
		public ForgotPasswordTokenController GetForgotPasswordTokenController()
		{
			return serviceProvider.GetRequiredService<ForgotPasswordTokenController>();
		}
	}

	extension(IServiceScope serviceScope)
	{
		public ForgotPasswordTokenController GetForgotPasswordTokenController()
		{
			return serviceScope.ServiceProvider.GetForgotPasswordTokenController();
		}
	}
}
