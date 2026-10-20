namespace InstaConnect.Identity.Domain.Tests.Features.UserClaims.Utilities;

public static class UserClaimDomainSetups
{
	extension(IServiceProvider serviceProvider)
	{
		public IUserClaimCommandService GetClaimCommandService()
		{
			return serviceProvider.GetRequiredService<IUserClaimCommandService>();
		}

		public IUserClaimQueryService GetClaimQueryService()
		{
			return serviceProvider.GetRequiredService<IUserClaimQueryService>();
		}
	}

	extension(IServiceScope serviceScope)
	{
		public IUserClaimCommandService GetClaimCommandService()
		{
			return serviceScope.ServiceProvider.GetClaimCommandService();
		}

		public IUserClaimQueryService GetClaimQueryService()
		{
			return serviceScope.ServiceProvider.GetClaimQueryService();
		}
	}
}
