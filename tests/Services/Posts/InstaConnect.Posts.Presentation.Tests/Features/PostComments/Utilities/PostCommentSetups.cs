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

		public async Task InitializeAddAsync(
			AddPostCommentApiRequest request,
			PostComment postComment,
			CancellationToken cancellationToken)
		{
			await serviceScope.InitializeAddAsync(postComment, request.UserId, cancellationToken);
		}

		public async Task DisposeAddAsync(
			AddPostCommentApiRequest request,
			PostComment postComment,
			CancellationToken cancellationToken)
		{
			await serviceScope.DisposeAddAsync(postComment, cancellationToken);
		}

		public async Task InitializeUpdateAsync(
			UpdatePostCommentApiRequest request,
			PostComment postComment,
			CancellationToken cancellationToken)
		{
			await serviceScope.InitializeUpdateAsync(postComment, request.UserId, cancellationToken);
		}

		public async Task DisposeUpdateAsync(
			UpdatePostCommentApiRequest request,
			PostComment postComment,
			CancellationToken cancellationToken)
		{
			await serviceScope.DisposeUpdateAsync(postComment, cancellationToken);
		}

		public async Task InitializeDeleteAsync(
			DeletePostCommentApiRequest request,
			PostComment postComment,
			CancellationToken cancellationToken)
		{
			await serviceScope.InitializeDeleteAsync(postComment, request.UserId, cancellationToken);
		}

		public async Task DisposeDeleteAsync(
			DeletePostCommentApiRequest request,
			PostComment postComment,
			CancellationToken cancellationToken)
		{
			await serviceScope.DisposeDeleteAsync(postComment, cancellationToken);
		}

		public async Task InitializeGetByIdAsync(
			GetPostCommentByIdApiRequest request,
			PostComment postComment,
			CancellationToken cancellationToken)
		{
			await serviceScope.InitializeGetByIdAsync(postComment, cancellationToken);
		}

		public async Task DisposeGetByIdAsync(
			GetPostCommentByIdApiRequest request,
			PostComment postComment,
			CancellationToken cancellationToken)
		{
			await serviceScope.DisposeGetByIdAsync(postComment, cancellationToken);
		}

		public async Task InitializeGetAllAsync(
			GetAllPostCommentsApiRequest request,
			ICollection<PostComment> postComments,
			CancellationToken cancellationToken)
		{
			await serviceScope.InitializeGetAllAsync(postComments, cancellationToken);
		}

		public async Task DisposeGetAllAsync(
			GetAllPostCommentsApiRequest request,
			ICollection<PostComment> postComments,
			CancellationToken cancellationToken)
		{
			await serviceScope.DisposeGetAllAsync(postComments, cancellationToken);
		}

		public async Task InitializeGetAllForUserAsync(
			GetAllPostCommentsForUserApiRequest request,
			ICollection<PostComment> postComments,
			CancellationToken cancellationToken)
		{
			await serviceScope.InitializeGetAllForUserAsync(postComments, cancellationToken);
		}

		public async Task DisposeGetAllForUserAsync(
			GetAllPostCommentsForUserApiRequest request,
			ICollection<PostComment> postComments,
			CancellationToken cancellationToken)
		{
			await serviceScope.DisposeGetAllForUserAsync(postComments, cancellationToken);
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
