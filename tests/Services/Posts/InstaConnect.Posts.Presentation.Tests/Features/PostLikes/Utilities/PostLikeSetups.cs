using InstaConnect.Posts.Domain.Features.PostImages.Models.Entities;
using InstaConnect.Posts.Domain.Features.PostLikes.Models.Responses;
using InstaConnect.Posts.Domain.Features.PostLikes.Models.ValueObjects;
using InstaConnect.Posts.Domain.Features.Posts.Models.Responses;
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

		public async Task<PostLikeResponse?> GetPostLikeCacheByIdAsync(
			DeletePostLikeApiRequest request,
			CancellationToken cancellationToken)
		{
			return await serviceScope.GetPostLikeCacheByIdAsync(request.Id, request.UserId, request.UserId, cancellationToken);
		}

		public async Task<PostLikeResponse?> GetPostLikeCacheByIdAsync(
			GetPostLikeByIdApiRequest request,
			CancellationToken cancellationToken)
		{
			return await serviceScope.GetPostLikeCacheByIdAsync(request.Id, request.UserId, request.CurrentUserId, cancellationToken);
		}

		public async Task<PostResponse?> GetPostCacheByIdAsync(
			AddPostLikeApiRequest request,
			CancellationToken cancellationToken)
		{
			return await serviceScope.GetPostCacheByIdAsync(request.Id, request.UserId, cancellationToken);
		}

		public async Task<PostResponse?> GetPostCacheByIdAsync(
			DeletePostLikeApiRequest request,
			CancellationToken cancellationToken)
		{
			return await serviceScope.GetPostCacheByIdAsync(request.Id, request.UserId, cancellationToken);
		}

		public async Task SetupAddAsync(
			AddPostLikeApiRequest request,
			User user,
			Post post,
			CancellationToken cancellationToken)
		{
			await serviceScope.SetupAddPostLikeAsync(user, post, request.UserId, cancellationToken);
		}

		public async Task AddPostCacheAsync(
			AddPostLikeApiRequest request,
			Post post,
			CancellationToken cancellationToken)
		{
			await serviceScope.AddPostCacheAsync(post, request.UserId, cancellationToken);
		}

		public async Task AddPostCacheAsync(
			DeletePostLikeApiRequest request,
			Post post,
			CancellationToken cancellationToken)
		{
			await serviceScope.AddPostCacheAsync(post, request.UserId, cancellationToken);
		}

		public async Task SetupDeleteAsync(
			DeletePostLikeApiRequest request,
			User user,
			Post post,
			PostLike postLike,
			CancellationToken cancellationToken)
		{
			await serviceScope.SetupDeletePostLikeAsync(user, post, postLike, request.UserId, cancellationToken);
		}

		public async Task AddPostLikeCacheAsync(
			DeletePostLikeApiRequest request,
			PostLike postLike,
			CancellationToken cancellationToken)
		{
			await serviceScope.AddPostLikeCacheAsync(postLike, request.UserId, cancellationToken);
		}

		public async Task SetupGetAllAsync(
			GetAllPostLikesApiRequest request,
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
			GetAllPostLikesForUserApiRequest request,
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
			GetPostLikeByIdApiRequest request,
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
