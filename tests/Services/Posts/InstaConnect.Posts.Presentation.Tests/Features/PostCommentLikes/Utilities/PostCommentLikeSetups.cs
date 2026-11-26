using InstaConnect.Posts.Domain.Features.PostCommentLikes.Models.Responses;
using InstaConnect.Posts.Domain.Features.PostCommentLikes.Models.ValueObjects;
using InstaConnect.Posts.Domain.Features.PostComments.Models.Responses;
using InstaConnect.Posts.Presentation.Features.PostCommentLikes.Controllers.v1;

namespace InstaConnect.Posts.Presentation.Tests.Features.PostCommentLikes.Utilities;

public static class PostCommentLikeSetups
{
	extension(IServiceProvider serviceProvider)
	{
		public PostCommentLikeController GetPostCommentLikeController()
		{
			return serviceProvider.GetRequiredService<PostCommentLikeController>();
		}

		public UserPostCommentLikeController GetUserPostCommentLikeController()
		{
			return serviceProvider.GetRequiredService<UserPostCommentLikeController>();
		}
	}

	extension(IServiceScope serviceScope)
	{
		public PostCommentLikeController GetPostCommentLikeController()
		{
			return serviceScope.ServiceProvider.GetPostCommentLikeController();
		}

		public UserPostCommentLikeController GetUserPostCommentLikeController()
		{
			return serviceScope.ServiceProvider.GetUserPostCommentLikeController();
		}

		internal async Task<PostCommentLike?> GetByIdAsync(
		PostCommentLikeIdApiResponse id,
		CancellationToken cancellationToken)
		{
			return await serviceScope.GetByIdAsync(
				new PostCommentLikeId(
									  new(
										  new(id.Id),
										  id.CommentId),
									  new(id.UserId)),
				cancellationToken);
		}

		public async Task<PostCommentLike?> GetByIdAsync(
			AddPostCommentLikeApiResponse response,
			CancellationToken cancellationToken)
		{
			return await serviceScope.GetByIdAsync(
				response.Response,
				cancellationToken);
		}

		public async Task<PostCommentLike?> GetByIdAsync(
			ActionResult<AddPostCommentLikeApiResponse> response,
			CancellationToken cancellationToken)
		{
			return await serviceScope.GetByIdAsync(
				response.GetValue(),
				cancellationToken);
		}

		public async Task<PostCommentLikeResponse?> GetPostCommentLikeCacheByIdAsync(
			DeletePostCommentLikeApiRequest request,
			CancellationToken cancellationToken)
		{
			return await serviceScope.GetPostCommentLikeCacheByIdAsync(request.Id, request.CommentId, request.UserId, request.UserId, cancellationToken);
		}

		public async Task<PostCommentLikeResponse?> GetPostCommentLikeCacheByIdAsync(
			GetPostCommentLikeByIdApiRequest request,
			CancellationToken cancellationToken)
		{
			return await serviceScope.GetPostCommentLikeCacheByIdAsync(request.Id, request.CommentId, request.UserId, request.CurrentUserId, cancellationToken);
		}

		public async Task<PostCommentResponse?> GetPostCommentCacheByIdAsync(
			AddPostCommentLikeApiRequest request,
			CancellationToken cancellationToken)
		{
			return await serviceScope.GetPostCommentCacheByIdAsync(request.Id, request.CommentId, request.UserId, cancellationToken);
		}

		public async Task<PostCommentResponse?> GetPostCommentCacheByIdAsync(
			DeletePostCommentLikeApiRequest request,
			CancellationToken cancellationToken)
		{
			return await serviceScope.GetPostCommentCacheByIdAsync(request.Id, request.CommentId, request.UserId, cancellationToken);
		}

		public async Task SetupAddAsync(
			AddPostCommentLikeApiRequest request,
			PostCommentLike postCommentLike,
			CancellationToken cancellationToken)
		{
			await serviceScope.SetupAddAsync(postCommentLike, request.UserId, cancellationToken);
		}

		public async Task AddPostCommentCacheAsync(
			AddPostCommentLikeApiRequest request,
			PostComment postComment,
			CancellationToken cancellationToken)
		{
			await serviceScope.AddPostCommentCacheAsync(postComment, request.UserId, cancellationToken);
		}

		public async Task AddPostCommentCacheAsync(
			DeletePostCommentLikeApiRequest request,
			PostComment postComment,
			CancellationToken cancellationToken)
		{
			await serviceScope.AddPostCommentCacheAsync(postComment, request.UserId, cancellationToken);
		}

		public async Task SetupDeleteAsync(
			DeletePostCommentLikeApiRequest request,
			PostCommentLike postCommentLike,
			CancellationToken cancellationToken)
		{
			await serviceScope.SetupDeleteAsync(postCommentLike, request.UserId, cancellationToken);
		}

		public async Task AddPostCommentLikeCacheAsync(
			DeletePostCommentLikeApiRequest request,
			PostCommentLike postCommentLike,
			CancellationToken cancellationToken)
		{
			await serviceScope.AddPostCommentLikeCacheAsync(postCommentLike, request.UserId, cancellationToken);
		}

		public async Task SetupGetAllAsync(
			GetAllPostCommentLikesApiRequest request,
			ICollection<PostCommentLike> postCommentLikes,
			CancellationToken cancellationToken)
		{
			await serviceScope.SetupGetAllAsync(postCommentLikes, cancellationToken);
		}

		public async Task SetupGetAllForUserAsync(
			GetAllPostCommentLikesForUserApiRequest request,
			ICollection<PostCommentLike> postCommentLikes,
			CancellationToken cancellationToken)
		{
			await serviceScope.SetupGetAllForUserAsync(postCommentLikes, cancellationToken);
		}

		public async Task SetupGetByIdAsync(
			GetPostCommentLikeByIdApiRequest request,
			PostCommentLike postCommentLike,
			CancellationToken cancellationToken)
		{
			await serviceScope.SetupGetByIdAsync(postCommentLike, cancellationToken);
		}
	}
}
