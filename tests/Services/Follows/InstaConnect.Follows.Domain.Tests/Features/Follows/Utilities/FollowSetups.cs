namespace InstaConnect.Follows.Domain.Tests.Features.Follows.Utilities;

public static class FollowDomainSetups
{
	extension(IServiceProvider serviceProvider)
	{
		public IFollowCommandService GetFollowCommandService()
		{
			return serviceProvider.GetRequiredService<IFollowCommandService>();
		}

		public IFollowQueryService GetFollowQueryService()
		{
			return serviceProvider.GetRequiredService<IFollowQueryService>();
		}
	}

	extension(IServiceScope serviceScope)
	{
		public IFollowCommandService GetFollowCommandService()
		{
			return serviceScope.ServiceProvider.GetFollowCommandService();
		}

		public IFollowQueryService GetFollowQueryService()
		{
			return serviceScope.ServiceProvider.GetFollowQueryService();
		}
	}
}
