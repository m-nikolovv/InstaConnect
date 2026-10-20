namespace InstaConnect.Posts.Domain.Tests.Features.Posts.Utilities;

public static class PostSetups
{
	extension(IServiceProvider serviceProvider)
	{
		public IPostCommandService GetPostCommandService()
		{
			return serviceProvider.GetRequiredService<IPostCommandService>();
		}

		public IPostQueryService GetPostQueryService()
		{
			return serviceProvider.GetRequiredService<IPostQueryService>();
		}
	}

	extension(IServiceScope serviceScope)
	{
		public IPostCommandService GetPostCommandService()
		{
			return serviceScope.ServiceProvider.GetPostCommandService();
		}

		public IPostQueryService GetPostQueryService()
		{
			return serviceScope.ServiceProvider.GetPostQueryService();
		}
	}
}
