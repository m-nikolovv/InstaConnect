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
	}
}
