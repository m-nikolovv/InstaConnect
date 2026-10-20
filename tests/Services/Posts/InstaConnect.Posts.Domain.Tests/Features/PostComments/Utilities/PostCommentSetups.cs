namespace InstaConnect.Posts.Domain.Tests.Features.PostComments.Utilities;

public static class PostCommentSetups
{
	extension(IServiceProvider serviceProvider)
	{
		public IPostCommentCommandService GetPostCommentCommandService()
		{
			return serviceProvider.GetRequiredService<IPostCommentCommandService>();
		}

		public IPostCommentQueryService GetPostCommentQueryService()
		{
			return serviceProvider.GetRequiredService<IPostCommentQueryService>();
		}
	}

	extension(IServiceScope serviceScope)
	{
		public IPostCommentCommandService GetPostCommentCommandService()
		{
			return serviceScope.ServiceProvider.GetPostCommentCommandService();
		}

		public IPostCommentQueryService GetPostCommentQueryService()
		{
			return serviceScope.ServiceProvider.GetPostCommentQueryService();
		}
	}
}
