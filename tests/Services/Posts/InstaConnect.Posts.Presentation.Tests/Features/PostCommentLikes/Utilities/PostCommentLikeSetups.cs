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

		public async Task InitializeAddAsync(
			AddPostCommentLikeApiRequest request,
			PostCommentLike postCommentLike,
			CancellationToken cancellationToken)
		{
			await serviceScope.InitializeAddAsync(postCommentLike, request.UserId, cancellationToken);
		}

		public async Task DisposeAddAsync(
			AddPostCommentLikeApiRequest request,
			PostCommentLike postCommentLike,
			CancellationToken cancellationToken)
		{
			await serviceScope.DisposeAddAsync(postCommentLike, cancellationToken);
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

		public async Task InitializeDeleteAsync(
			DeletePostCommentLikeApiRequest request,
			PostCommentLike postCommentLike,
			CancellationToken cancellationToken)
		{
			await serviceScope.InitializeDeleteAsync(postCommentLike, request.UserId, cancellationToken);
		}

		public async Task DisposeDeleteAsync(
			DeletePostCommentLikeApiRequest request,
			PostCommentLike postCommentLike,
			CancellationToken cancellationToken)
		{
			await serviceScope.DisposeDeleteAsync(postCommentLike, cancellationToken);
		}

		public async Task AddPostCommentLikeCacheAsync(
			DeletePostCommentLikeApiRequest request,
			PostCommentLike postCommentLike,
			CancellationToken cancellationToken)
		{
			await serviceScope.AddPostCommentLikeCacheAsync(postCommentLike, request.UserId, cancellationToken);
		}

		public async Task InitializeGetAllAsync(
			GetAllPostCommentLikesApiRequest request,
			ICollection<PostCommentLike> postCommentLikes,
			CancellationToken cancellationToken)
		{
			await serviceScope.InitializeGetAllAsync(postCommentLikes, cancellationToken);
		}

		public async Task DisposeGetAllAsync(
			GetAllPostCommentLikesApiRequest request,
			ICollection<PostCommentLike> postCommentLikes,
			CancellationToken cancellationToken)
		{
			await serviceScope.DisposeGetAllAsync(postCommentLikes, cancellationToken);
		}

		public async Task InitializeGetAllForUserAsync(
			GetAllPostCommentLikesForUserApiRequest request,
			ICollection<PostCommentLike> postCommentLikes,
			CancellationToken cancellationToken)
		{
			await serviceScope.InitializeGetAllForUserAsync(postCommentLikes, cancellationToken);
		}

		public async Task DisposeGetAllForUserAsync(
			GetAllPostCommentLikesForUserApiRequest request,
			ICollection<PostCommentLike> postCommentLikes,
			CancellationToken cancellationToken)
		{
			await serviceScope.DisposeGetAllForUserAsync(postCommentLikes, cancellationToken);
		}

		public async Task InitializeGetByIdAsync(
			GetPostCommentLikeByIdApiRequest request,
			PostCommentLike postCommentLike,
			CancellationToken cancellationToken)
		{
			await serviceScope.InitializeGetByIdAsync(postCommentLike, cancellationToken);
		}

		public async Task DisposeGetByIdAsync(
			GetPostCommentLikeByIdApiRequest request,
			PostCommentLike postCommentLike,
			CancellationToken cancellationToken)
		{
			await serviceScope.DisposeGetByIdAsync(postCommentLike, cancellationToken);
		}
	}
}
