using InstaConnect.Posts.Domain.Features.PostLikes.Models.Responses;
using InstaConnect.Posts.Domain.Features.PostLikes.Models.ValueObjects;
using InstaConnect.Posts.Domain.Features.Posts.Models.Responses;
using InstaConnect.Posts.Infrastructure.Features.PostLikes.Abstractions;
using InstaConnect.Posts.Infrastructure.Features.Posts.Abstractions;
using InstaConnect.Posts.Presentation.Features.PostLikes.Controllers.v1;

namespace InstaConnect.Posts.Presentation.Tests.Features.PostLikes.Utilities;

public static class PostLikeSetups
{
	extension(IServiceProvider serviceProvider)
	{
		public PostLikeController GetPostLikeController()
		{
			return serviceProvider.GetRequiredService<PostLikeController>();
		}

		public UserPostLikeController GetUserPostLikeController()
		{
			return serviceProvider.GetRequiredService<UserPostLikeController>();
		}
	}

	extension(IServiceScope serviceScope)
	{
		public PostLikeController GetPostLikeController()
		{
			return serviceScope.ServiceProvider.GetPostLikeController();
		}

		public UserPostLikeController GetUserPostLikeController()
		{
			return serviceScope.ServiceProvider.GetUserPostLikeController();
		}

		internal async Task<PostLike?> GetByIdAsync(
		PostLikeIdApiResponse id,
		CancellationToken cancellationToken)
		{
			return await serviceScope.GetByIdAsync(
				new PostLikeId(
							   new(id.Id),
							   new(id.UserId)),
				cancellationToken);
		}

		public async Task<PostLike?> GetByIdAsync(
			AddPostLikeApiResponse response,
			CancellationToken cancellationToken)
		{
			return await serviceScope.GetByIdAsync(
				response.Response,
				cancellationToken);
		}

		public async Task<PostLike?> GetByIdAsync(
			ActionResult<AddPostLikeApiResponse> response,
			CancellationToken cancellationToken)
		{
			return await serviceScope.GetByIdAsync(
				response.GetValue(),
				cancellationToken);
		}
	}

	extension(IPostLikeCacheHandler cacheHandler)
	{
		public async Task<PostLikeResponse?> GetByIdAsync(
			DeletePostLikeApiRequest request,
			CancellationToken cancellationToken)
		{
			return await cacheHandler.GetByIdAsync(request.Id, request.UserId, request.UserId, cancellationToken);
		}

		public async Task<PostLikeResponse?> GetByIdAsync(
			GetPostLikeByIdApiRequest request,
			CancellationToken cancellationToken)
		{
			return await cacheHandler.GetByIdAsync(request.Id, request.UserId, request.CurrentUserId, cancellationToken);
		}
	}

	extension(IPostCacheHandler cacheHandler)
	{
		public async Task<PostResponse?> GetByIdAsync(
			AddPostLikeApiRequest request,
			CancellationToken cancellationToken)
		{
			return await cacheHandler.GetByIdAsync(request.Id, request.UserId, cancellationToken);
		}

		public async Task<PostResponse?> GetByIdAsync(
			DeletePostLikeApiRequest request,
			CancellationToken cancellationToken)
		{
			return await cacheHandler.GetByIdAsync(request.Id, request.UserId, cancellationToken);
		}
	}
}
