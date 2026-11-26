using InstaConnect.Posts.Application.Features.PostLikes.Models;
using InstaConnect.Posts.Domain.Features.PostLikes.Models.Responses;
using InstaConnect.Posts.Domain.Features.PostLikes.Models.ValueObjects;
using InstaConnect.Posts.Domain.Features.Posts.Models.Responses;

namespace InstaConnect.Posts.Application.Tests.Features.PostLikes.Utilities;

public static class PostLikeSetups
{
	extension(IServiceScope serviceScope)
	{
		internal async Task<PostLike?> GetByIdAsync(
		PostLikeIdCommandResponse id,
		CancellationToken cancellationToken)
		{
			return await serviceScope.GetByIdAsync(
				new PostLikeId(
							   new(id.Id),
							   new(id.UserId)),
				cancellationToken);
		}

		public async Task<PostLike?> GetByIdAsync(
			AddPostLikeCommandResponse response,
			CancellationToken cancellationToken)
		{
			return await serviceScope.GetByIdAsync(
				response.Response,
				cancellationToken);
		}

		public async Task<PostLikeResponse?> GetPostLikeCacheByIdAsync(
			DeletePostLikeCommandRequest request,
			CancellationToken cancellationToken)
		{
			return await serviceScope.GetPostLikeCacheByIdAsync(request.Id, request.UserId, request.UserId, cancellationToken);
		}

		public async Task<PostLikeResponse?> GetPostLikeCacheByIdAsync(
			GetPostLikeByIdQueryRequest request,
			CancellationToken cancellationToken)
		{
			return await serviceScope.GetPostLikeCacheByIdAsync(request.Id, request.UserId, request.CurrentUserId, cancellationToken);
		}

		public async Task<PostResponse?> GetPostCacheByIdAsync(
			AddPostLikeCommandRequest request,
			CancellationToken cancellationToken)
		{
			return await serviceScope.GetPostCacheByIdAsync(request.Id, request.UserId, cancellationToken);
		}

		public async Task<PostResponse?> GetPostCacheByIdAsync(
			DeletePostLikeCommandRequest request,
			CancellationToken cancellationToken)
		{
			return await serviceScope.GetPostCacheByIdAsync(request.Id, request.UserId, cancellationToken);
		}

		public async Task SetupAddAsync(
			AddPostLikeCommandRequest request,
			PostLike postLike,
			CancellationToken cancellationToken)
		{
			await serviceScope.SetupAddAsync(postLike, request.UserId, cancellationToken);
		}

		public async Task AddPostCacheAsync(
			AddPostLikeCommandRequest request,
			Post post,
			CancellationToken cancellationToken)
		{
			await serviceScope.AddPostCacheAsync(post, request.UserId, cancellationToken);
		}

		public async Task AddPostCacheAsync(
			DeletePostLikeCommandRequest request,
			Post post,
			CancellationToken cancellationToken)
		{
			await serviceScope.AddPostCacheAsync(post, request.UserId, cancellationToken);
		}

		public async Task SetupDeleteAsync(
			DeletePostLikeCommandRequest request,
			PostLike postLike,
			CancellationToken cancellationToken)
		{
			await serviceScope.SetupDeleteAsync(postLike, request.UserId, cancellationToken);
		}

		public async Task AddPostLikeCacheAsync(
			DeletePostLikeCommandRequest request,
			PostLike postLike,
			CancellationToken cancellationToken)
		{
			await serviceScope.AddPostLikeCacheAsync(postLike, request.UserId, cancellationToken);
		}

		public async Task SetupGetAllAsync(
			GetAllPostLikesQueryRequest request,
			ICollection<PostLike> postLikes,
			CancellationToken cancellationToken)
		{
			await serviceScope.SetupGetAllAsync(postLikes, cancellationToken);
		}

		public async Task SetupGetAllForUserAsync(
			GetAllPostLikesForUserQueryRequest request,
			ICollection<PostLike> postLikes,
			CancellationToken cancellationToken)
		{
			await serviceScope.SetupGetAllForUserAsync(postLikes, cancellationToken);
		}

		public async Task SetupGetByIdAsync(
			GetPostLikeByIdQueryRequest request,
			PostLike postLike,
			CancellationToken cancellationToken)
		{
			await serviceScope.SetupGetByIdAsync(postLike, cancellationToken);
		}
	}
}
