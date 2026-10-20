namespace InstaConnect.Identity.Domain.Tests.Features.RefreshTokens.Utilities;

public static class RefreshTokenDomainSetups
{
	extension(IServiceProvider serviceProvider)
	{
		public IRefreshTokenCommandService GetRefreshTokenCommandService()
		{
			return serviceProvider.GetRequiredService<IRefreshTokenCommandService>();
		}
	}

	extension(IServiceScope serviceScope)
	{
		public IRefreshTokenCommandService GetRefreshTokenCommandService()
		{
			return serviceScope.ServiceProvider.GetRefreshTokenCommandService();
		}
	}
}
