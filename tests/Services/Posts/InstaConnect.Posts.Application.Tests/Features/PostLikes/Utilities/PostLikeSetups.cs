using InstaConnect.Posts.Application.Features.PostLikes.Models;
using InstaConnect.Posts.Domain.Features.PostImages.Models.Entities;
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
			User user,
			Post post,
			CancellationToken cancellationToken)
		{
			await serviceScope.SetupAddPostLikeAsync(user, post, request.UserId, cancellationToken);
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
			User user,
			Post post,
			PostLike postLike,
			CancellationToken cancellationToken)
		{
			await serviceScope.SetupDeletePostLikeAsync(user, post, postLike, request.UserId, cancellationToken);
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
			ICollection<User> users,
			ICollection<Post> posts,
			ICollection<PostLike> postLikes,
			ICollection<PostImage> postImages,
			ICollection<PostComment> postComments,
			CancellationToken cancellationToken)
		{
			await serviceScope.SetupGetAllPostLikesAsync(users, posts, postLikes, postImages, postComments, cancellationToken);
		}

		public async Task SetupGetAllForUserAsync(
			GetAllPostLikesForUserQueryRequest request,
			ICollection<User> users,
			ICollection<Post> posts,
			ICollection<PostLike> postLikes,
			ICollection<PostImage> postImages,
			ICollection<PostComment> postComments,
			CancellationToken cancellationToken)
		{
			await serviceScope.SetupGetAllPostLikesForUserAsync(users, posts, postLikes, postImages, postComments, cancellationToken);
		}

		public async Task SetupGetByIdAsync(
			GetPostLikeByIdQueryRequest request,
			ICollection<User> users,
			Post post,
			PostLike postLike,
			ICollection<PostImage> postImages,
			ICollection<PostComment> postComments,
			CancellationToken cancellationToken)
		{
			await serviceScope.SetupGetPostLikeByIdAsync(users, post, postLike, postImages, postComments, cancellationToken);
		}
	}
}
