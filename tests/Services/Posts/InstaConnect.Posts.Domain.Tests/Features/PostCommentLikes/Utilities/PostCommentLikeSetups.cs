namespace InstaConnect.Posts.Domain.Tests.Features.PostCommentLikes.Utilities;

public static class PostCommentLikeSetups
{
	extension(IServiceProvider serviceProvider)
	{
		public IPostCommentLikeCommandService GetPostCommentLikeCommandService()
		{
			return serviceProvider.GetRequiredService<IPostCommentLikeCommandService>();
		}

		public IPostCommentLikeQueryService GetPostCommentLikeQueryService()
		{
			return serviceProvider.GetRequiredService<IPostCommentLikeQueryService>();
		}
	}

	extension(IServiceScope serviceScope)
	{
		public IPostCommentLikeCommandService GetPostCommentLikeCommandService()
		{
			return serviceScope.ServiceProvider.GetPostCommentLikeCommandService();
		}

		public IPostCommentLikeQueryService GetPostCommentLikeQueryService()
		{
			return serviceScope.ServiceProvider.GetPostCommentLikeQueryService();
		}
	}
}
