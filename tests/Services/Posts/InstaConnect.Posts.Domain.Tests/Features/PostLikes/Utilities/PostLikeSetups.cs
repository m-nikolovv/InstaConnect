namespace InstaConnect.Posts.Domain.Tests.Features.PostLikes.Utilities;

public static class PostLikeSetups
{
	extension(IServiceProvider serviceProvider)
	{
		public IPostLikeCommandService GetPostLikeCommandService()
		{
			return serviceProvider.GetRequiredService<IPostLikeCommandService>();
		}

		public IPostLikeQueryService GetPostLikeQueryService()
		{
			return serviceProvider.GetRequiredService<IPostLikeQueryService>();
		}
	}

	extension(IServiceScope serviceScope)
	{
		public IPostLikeCommandService GetPostLikeCommandService()
		{
			return serviceScope.ServiceProvider.GetPostLikeCommandService();
		}

		public IPostLikeQueryService GetPostLikeQueryService()
		{
			return serviceScope.ServiceProvider.GetPostLikeQueryService();
		}
	}
}
