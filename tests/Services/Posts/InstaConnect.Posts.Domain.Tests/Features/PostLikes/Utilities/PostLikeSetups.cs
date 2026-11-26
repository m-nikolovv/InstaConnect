using InstaConnect.Posts.Domain.Features.PostLikes.Models.Responses;

namespace InstaConnect.Posts.Domain.Tests.Features.PostLikes.Utilities;

public static class PostLikeSetups
{
	extension(IServiceProvider serviceProvider)
	{
		public IPostLikeCommandService GetPostLikeCommandService()
		{
			return serviceProvider.GetRequiredService<IPostLikeCommandService>();
		}

		public IPostLikeQueryService GetPostLikeQueryService()
		{
			return serviceProvider.GetRequiredService<IPostLikeQueryService>();
		}
	}

	extension(IServiceScope serviceScope)
	{
		public IPostLikeCommandService GetPostLikeCommandService()
		{
			return serviceScope.ServiceProvider.GetPostLikeCommandService();
		}

		public IPostLikeQueryService GetPostLikeQueryService()
		{
			return serviceScope.ServiceProvider.GetPostLikeQueryService();
		}

		public async Task<PostLikeResponse?> GetPostLikeCacheByIdAsync(
			DeletePostLikeCommand command,
			CancellationToken cancellationToken)
		{
			return await serviceScope.GetPostLikeCacheByIdAsync(command.Id, command.Id.UserId, cancellationToken);
		}

		public async Task<PostLikeResponse?> GetPostLikeCacheByIdAsync(
			GetPostLikeByIdQuery query,
			CancellationToken cancellationToken)
		{
			return await serviceScope.GetPostLikeCacheByIdAsync(query.Id, query.CurrentUser.Id, cancellationToken);
		}

		public async Task<PostResponse?> GetPostCacheByIdAsync(
			AddPostLikeCommand command,
			CancellationToken cancellationToken)
		{
			return await serviceScope.GetPostCacheByIdAsync(command.Id, command.UserId, cancellationToken);
		}

		public async Task<PostResponse?> GetPostCacheByIdAsync(
			DeletePostLikeCommand command,
			CancellationToken cancellationToken)
		{
			return await serviceScope.GetPostCacheByIdAsync(command.Id.Id, command.Id.UserId, cancellationToken);
		}

		public async Task SetupAddAsync(
			AddPostLikeCommand command,
			User user,
			Post post,
			CancellationToken cancellationToken)
		{
			await serviceScope.SetupAddPostLikeAsync(user, post, command.UserId, cancellationToken);
		}

		public async Task AddPostCacheAsync(
			AddPostLikeCommand command,
			Post post,
			CancellationToken cancellationToken)
		{
			await serviceScope.AddPostCacheAsync(post, command.UserId, cancellationToken);
		}

		public async Task AddPostCacheAsync(
			DeletePostLikeCommand command,
			Post post,
			CancellationToken cancellationToken)
		{
			await serviceScope.AddPostCacheAsync(post, command.Id.UserId, cancellationToken);
		}

		public async Task SetupDeleteAsync(
			DeletePostLikeCommand command,
			User user,
			Post post,
			PostLike postLike,
			CancellationToken cancellationToken)
		{
			await serviceScope.SetupDeletePostLikeAsync(user, post, postLike, command.Id.UserId, cancellationToken);
		}

		public async Task AddPostLikeCacheAsync(
			DeletePostLikeCommand command,
			PostLike postLike,
			CancellationToken cancellationToken)
		{
			await serviceScope.AddPostLikeCacheAsync(postLike, command.Id.UserId, cancellationToken);
		}

		public async Task SetupGetAllAsync(
			GetAllPostLikesQuery query,
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
			GetAllPostLikesForUserQuery query,
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
			GetPostLikeByIdQuery query,
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
