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

		public async Task InitializeAddAsync(
			AddPostLikeCommandRequest request,
			PostLike postLike,
			CancellationToken cancellationToken)
		{
			await serviceScope.InitializeAddAsync(postLike, request.UserId, cancellationToken);
		}

		public async Task DisposeAddAsync(
			AddPostLikeCommandRequest request,
			PostLike postLike,
			CancellationToken cancellationToken)
		{
			await serviceScope.DisposeAddAsync(postLike, cancellationToken);
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

		public async Task InitializeDeleteAsync(
			DeletePostLikeCommandRequest request,
			PostLike postLike,
			CancellationToken cancellationToken)
		{
			await serviceScope.InitializeDeleteAsync(postLike, request.UserId, cancellationToken);
		}

		public async Task DisposeDeleteAsync(
			DeletePostLikeCommandRequest request,
			PostLike postLike,
			CancellationToken cancellationToken)
		{
			await serviceScope.DisposeDeleteAsync(postLike, cancellationToken);
		}

		public async Task AddPostLikeCacheAsync(
			DeletePostLikeCommandRequest request,
			PostLike postLike,
			CancellationToken cancellationToken)
		{
			await serviceScope.AddPostLikeCacheAsync(postLike, request.UserId, cancellationToken);
		}

		public async Task InitializeGetAllAsync(
			GetAllPostLikesQueryRequest request,
			ICollection<PostLike> postLikes,
			CancellationToken cancellationToken)
		{
			await serviceScope.InitializeGetAllAsync(postLikes, cancellationToken);
		}

		public async Task DisposeGetAllAsync(
			GetAllPostLikesQueryRequest request,
			ICollection<PostLike> postLikes,
			CancellationToken cancellationToken)
		{
			await serviceScope.DisposeGetAllAsync(postLikes, cancellationToken);
		}

		public async Task InitializeGetAllForUserAsync(
			GetAllPostLikesForUserQueryRequest request,
			ICollection<PostLike> postLikes,
			CancellationToken cancellationToken)
		{
			await serviceScope.InitializeGetAllForUserAsync(postLikes, cancellationToken);
		}

		public async Task DisposeGetAllForUserAsync(
			GetAllPostLikesForUserQueryRequest request,
			ICollection<PostLike> postLikes,
			CancellationToken cancellationToken)
		{
			await serviceScope.DisposeGetAllForUserAsync(postLikes, cancellationToken);
		}

		public async Task InitializeGetByIdAsync(
			GetPostLikeByIdQueryRequest request,
			PostLike postLike,
			CancellationToken cancellationToken)
		{
			await serviceScope.InitializeGetByIdAsync(postLike, cancellationToken);
		}

		public async Task DisposeGetByIdAsync(
			GetPostLikeByIdQueryRequest request,
			PostLike postLike,
			CancellationToken cancellationToken)
		{
			await serviceScope.DisposeGetByIdAsync(postLike, cancellationToken);
		}
	}
}
