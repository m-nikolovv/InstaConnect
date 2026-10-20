using InstaConnect.Posts.Presentation.Features.PostComments.Controllers.v1;

namespace InstaConnect.Posts.Presentation.Tests.Features.PostComments.Utilities;

public static class PostCommentSetups
{
	extension(IServiceProvider serviceProvider)
	{
		public PostCommentController GetPostCommentController()
		{
			return serviceProvider.GetRequiredService<PostCommentController>();
		}

		public UserPostCommentController GetUserPostCommentController()
		{
			return serviceProvider.GetRequiredService<UserPostCommentController>();
		}
	}

	extension(IServiceScope serviceScope)
	{
		public PostCommentController GetPostCommentController()
		{
			return serviceScope.ServiceProvider.GetPostCommentController();
		}

		public UserPostCommentController GetUserPostCommentController()
		{
			return serviceScope.ServiceProvider.GetUserPostCommentController();
		}

		internal async Task<PostComment?> GetByIdAsync(
		PostCommentIdApiResponse id,
		CancellationToken cancellationToken)
		{
			return await serviceScope.GetByIdAsync(
				new PostCommentId(
							   new(id.Id),
							   id.CommentId),
				cancellationToken);
		}

		public async Task<PostComment?> GetByIdAsync(
			AddPostCommentApiResponse response,
			CancellationToken cancellationToken)
		{
			return await serviceScope.GetByIdAsync(
				response.Response,
				cancellationToken);
		}

		public async Task<PostComment?> GetByIdAsync(
			UpdatePostCommentApiResponse response,
			CancellationToken cancellationToken)
		{
			return await serviceScope.GetByIdAsync(
				response.Response,
				cancellationToken);
		}

		public async Task<PostComment?> GetByIdAsync(
			ActionResult<AddPostCommentApiResponse> response,
			CancellationToken cancellationToken)
		{
			return await serviceScope.GetByIdAsync(
				response.GetValue(),
				cancellationToken);
		}

		public async Task<PostComment?> GetByIdAsync(
			ActionResult<UpdatePostCommentApiResponse> response,
			CancellationToken cancellationToken)
		{
			return await serviceScope.GetByIdAsync(
				response.GetValue(),
				cancellationToken);
		}
	}
}
