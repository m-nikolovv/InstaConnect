using InstaConnect.Posts.Domain.Features.PostComments.Models.Responses;
using InstaConnect.Posts.Domain.Features.Posts.Models.Responses;
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

		public async Task SetupAddAsync(
			AddPostCommentApiRequest request,
			PostComment postComment,
			CancellationToken cancellationToken)
		{
			await serviceScope.SetupAddAsync(postComment, request.UserId, cancellationToken);
		}

		public async Task SetupUpdateAsync(
			UpdatePostCommentApiRequest request,
			PostComment postComment,
			CancellationToken cancellationToken)
		{
			await serviceScope.SetupUpdateAsync(postComment, request.UserId, cancellationToken);
		}

		public async Task SetupDeleteAsync(
			DeletePostCommentApiRequest request,
			PostComment postComment,
			CancellationToken cancellationToken)
		{
			await serviceScope.SetupDeleteAsync(postComment, request.UserId, cancellationToken);
		}

		public async Task SetupGetByIdAsync(
			GetPostCommentByIdApiRequest request,
			PostComment postComment,
			CancellationToken cancellationToken)
		{
			await serviceScope.SetupGetByIdAsync(postComment, cancellationToken);
		}

		public async Task SetupGetAllAsync(
			GetAllPostCommentsApiRequest request,
			ICollection<PostComment> postComments,
			CancellationToken cancellationToken)
		{
			await serviceScope.SetupGetAllAsync(postComments, cancellationToken);
		}

		public async Task SetupGetAllForUserAsync(
			GetAllPostCommentsForUserApiRequest request,
			ICollection<PostComment> postComments,
			CancellationToken cancellationToken)
		{
			await serviceScope.SetupGetAllForUserAsync(postComments, cancellationToken);
		}

		public async Task<PostCommentResponse?> GetPostCommentCacheByIdAsync(
			UpdatePostCommentApiRequest request,
			CancellationToken cancellationToken)
		{
			return await serviceScope.GetPostCommentCacheByIdAsync(request.Id, request.CommentId, request.UserId, cancellationToken);
		}

		public async Task<PostCommentResponse?> GetPostCommentCacheByIdAsync(
			DeletePostCommentApiRequest request,
			CancellationToken cancellationToken)
		{
			return await serviceScope.GetPostCommentCacheByIdAsync(request.Id, request.CommentId, request.UserId, cancellationToken);
		}

		public async Task<PostCommentResponse?> GetPostCommentCacheByIdAsync(
			GetPostCommentByIdApiRequest request,
			CancellationToken cancellationToken)
		{
			return await serviceScope.GetPostCommentCacheByIdAsync(request.Id, request.CommentId, request.CurrentUserId, cancellationToken);
		}

		public async Task AddPostCommentCacheAsync(
			UpdatePostCommentApiRequest request,
			PostComment postComment,
			CancellationToken cancellationToken)
		{
			await serviceScope.AddPostCommentCacheAsync(postComment, request.UserId, cancellationToken);
		}

		public async Task AddPostCommentCacheAsync(
			DeletePostCommentApiRequest request,
			PostComment postComment,
			CancellationToken cancellationToken)
		{
			await serviceScope.AddPostCommentCacheAsync(postComment, request.UserId, cancellationToken);
		}

		public async Task<PostResponse?> GetPostCacheByIdAsync(
			AddPostCommentApiRequest request,
			CancellationToken cancellationToken)
		{
			return await serviceScope.GetPostCacheByIdAsync(request.Id, request.UserId, cancellationToken);
		}

		public async Task<PostResponse?> GetPostCacheByIdAsync(
			DeletePostCommentApiRequest request,
			CancellationToken cancellationToken)
		{
			return await serviceScope.GetPostCacheByIdAsync(request.Id, request.UserId, cancellationToken);
		}
	}
}
