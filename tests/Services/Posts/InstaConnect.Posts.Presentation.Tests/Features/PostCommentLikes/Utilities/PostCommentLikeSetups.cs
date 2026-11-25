using InstaConnect.Posts.Domain.Features.PostCommentLikes.Models.Responses;
using InstaConnect.Posts.Domain.Features.PostCommentLikes.Models.ValueObjects;
using InstaConnect.Posts.Domain.Features.PostComments.Models.Responses;
using InstaConnect.Posts.Infrastructure.Features.PostCommentLikes.Abstractions;
using InstaConnect.Posts.Infrastructure.Features.PostComments.Abstractions;
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
	}

	extension(IPostCommentLikeCacheHandler cacheHandler)
	{
		public async Task<PostCommentLikeResponse?> GetByIdAsync(
			DeletePostCommentLikeApiRequest request,
			CancellationToken cancellationToken)
		{
			return await cacheHandler.GetByIdAsync(request.Id, request.CommentId, request.UserId, request.UserId, cancellationToken);
		}

		public async Task<PostCommentLikeResponse?> GetByIdAsync(
			GetPostCommentLikeByIdApiRequest request,
			CancellationToken cancellationToken)
		{
			return await cacheHandler.GetByIdAsync(request.Id, request.CommentId, request.UserId, request.CurrentUserId, cancellationToken);
		}
	}

	extension(IPostCommentCacheHandler cacheHandler)
	{
		public async Task<PostCommentResponse?> GetByIdAsync(
			AddPostCommentLikeApiRequest request,
			CancellationToken cancellationToken)
		{
			return await cacheHandler.GetByIdAsync(request.Id, request.CommentId, request.UserId, cancellationToken);
		}

		public async Task<PostCommentResponse?> GetByIdAsync(
			DeletePostCommentLikeApiRequest request,
			CancellationToken cancellationToken)
		{
			return await cacheHandler.GetByIdAsync(request.Id, request.CommentId, request.UserId, cancellationToken);
		}
	}
}
