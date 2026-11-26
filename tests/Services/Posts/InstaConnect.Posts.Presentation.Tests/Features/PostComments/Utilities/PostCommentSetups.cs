using InstaConnect.Posts.Domain.Features.PostCommentImages.Models.Entities;
using InstaConnect.Posts.Domain.Features.PostComments.Models.Responses;
using InstaConnect.Posts.Domain.Features.PostImages.Models.Entities;
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
			User user,
			Post post,
			CancellationToken cancellationToken)
		{
			await serviceScope.SetupAddPostCommentAsync(user, post, request.UserId, cancellationToken);
		}

		public async Task SetupUpdateAsync(
			UpdatePostCommentApiRequest request,
			User user,
			Post post,
			PostComment postComment,
			CancellationToken cancellationToken)
		{
			await serviceScope.SetupUpdatePostCommentAsync(user, post, postComment, request.UserId, cancellationToken);
		}

		public async Task SetupDeleteAsync(
			DeletePostCommentApiRequest request,
			ICollection<User> users,
			Post post,
			PostComment postComment,
			ICollection<PostCommentLike> postCommentLikes,
			ICollection<PostCommentImage> postCommentImages,
			CancellationToken cancellationToken)
		{
			await serviceScope.SetupDeletePostCommentAsync(users, post, postComment, postCommentLikes, postCommentImages, request.UserId, cancellationToken);
		}

		public async Task SetupGetByIdAsync(
			GetPostCommentByIdApiRequest request,
			ICollection<User> users,
			Post post,
			ICollection<PostLike> postLikes,
			ICollection<PostImage> postImages,
			PostComment postComment,
			ICollection<PostCommentLike> postCommentLikes,
			ICollection<PostCommentImage> postCommentImages,
			CancellationToken cancellationToken)
		{
			await serviceScope.SetupGetPostCommentByIdAsync(users, post, postLikes, postImages, postComment, postCommentLikes, postCommentImages, cancellationToken);
		}

		public async Task SetupGetAllAsync(
			GetAllPostCommentsApiRequest request,
			ICollection<User> users,
			ICollection<Post> posts,
			ICollection<PostLike> postLikes,
			ICollection<PostImage> postImages,
			ICollection<PostComment> postComments,
			ICollection<PostCommentLike> postCommentLikes,
			ICollection<PostCommentImage> postCommentImages,
			CancellationToken cancellationToken)
		{
			await serviceScope.SetupGetAllPostCommentsAsync(users, posts, postLikes, postImages, postComments, postCommentLikes, postCommentImages, cancellationToken);
		}

		public async Task SetupGetAllForUserAsync(
			GetAllPostCommentsForUserApiRequest request,
			ICollection<User> users,
			ICollection<Post> posts,
			ICollection<PostLike> postLikes,
			ICollection<PostImage> postImages,
			ICollection<PostComment> postComments,
			ICollection<PostCommentLike> postCommentLikes,
			ICollection<PostCommentImage> postCommentImages,
			CancellationToken cancellationToken)
		{
			await serviceScope.SetupGetAllPostCommentsForUserAsync(users, posts, postLikes, postImages, postComments, postCommentLikes, postCommentImages, cancellationToken);
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
