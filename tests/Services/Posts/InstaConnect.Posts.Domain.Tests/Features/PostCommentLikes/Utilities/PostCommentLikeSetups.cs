using InstaConnect.Posts.Domain.Features.PostCommentLikes.Models.Responses;

namespace InstaConnect.Posts.Domain.Tests.Features.PostCommentLikes.Utilities;

public static class PostCommentLikeSetups
{
	extension(IServiceProvider serviceProvider)
	{
		public IPostCommentLikeCommandService GetPostCommentLikeCommandService()
		{
			return serviceProvider.GetRequiredService<IPostCommentLikeCommandService>();
		}

		public IPostCommentLikeQueryService GetPostCommentLikeQueryService()
		{
			return serviceProvider.GetRequiredService<IPostCommentLikeQueryService>();
		}
	}

	extension(IServiceScope serviceScope)
	{
		public IPostCommentLikeCommandService GetPostCommentLikeCommandService()
		{
			return serviceScope.ServiceProvider.GetPostCommentLikeCommandService();
		}

		public IPostCommentLikeQueryService GetPostCommentLikeQueryService()
		{
			return serviceScope.ServiceProvider.GetPostCommentLikeQueryService();
		}

		public async Task<PostCommentLikeResponse?> GetPostCommentLikeCacheByIdAsync(
			DeletePostCommentLikeCommand command,
			CancellationToken cancellationToken)
		{
			return await serviceScope.GetPostCommentLikeCacheByIdAsync(command.Id, command.Id.UserId, cancellationToken);
		}

		public async Task<PostCommentLikeResponse?> GetPostCommentLikeCacheByIdAsync(
			GetPostCommentLikeByIdQuery query,
			CancellationToken cancellationToken)
		{
			return await serviceScope.GetPostCommentLikeCacheByIdAsync(query.Id, query.CurrentUser.Id, cancellationToken);
		}

		public async Task<PostCommentResponse?> GetPostCommentCacheByIdAsync(
			AddPostCommentLikeCommand command,
			CancellationToken cancellationToken)
		{
			return await serviceScope.GetPostCommentCacheByIdAsync(command.CommentId, command.UserId, cancellationToken);
		}

		public async Task<PostCommentResponse?> GetPostCommentCacheByIdAsync(
			DeletePostCommentLikeCommand command,
			CancellationToken cancellationToken)
		{
			return await serviceScope.GetPostCommentCacheByIdAsync(command.Id.CommentId, command.Id.UserId, cancellationToken);
		}

		public async Task SetupAddAsync(
			AddPostCommentLikeCommand command,
			User user,
			Post post,
			PostComment postComment,
			CancellationToken cancellationToken)
		{
			await serviceScope.SetupAddPostCommentLikeAsync(user, post, postComment, command.UserId, cancellationToken);
		}

		public async Task AddPostCommentCacheAsync(
			AddPostCommentLikeCommand command,
			PostComment postComment,
			CancellationToken cancellationToken)
		{
			await serviceScope.AddPostCommentCacheAsync(postComment, command.UserId, cancellationToken);
		}

		public async Task AddPostCommentCacheAsync(
			DeletePostCommentLikeCommand command,
			PostComment postComment,
			CancellationToken cancellationToken)
		{
			await serviceScope.AddPostCommentCacheAsync(postComment, command.Id.UserId, cancellationToken);
		}

		public async Task SetupDeleteAsync(
			DeletePostCommentLikeCommand command,
			User user,
			Post post,
			PostComment postComment,
			PostCommentLike postCommentLike,
			CancellationToken cancellationToken)
		{
			await serviceScope.SetupDeletePostCommentLikeAsync(user, post, postComment, postCommentLike, command.Id.UserId, cancellationToken);
		}

		public async Task AddPostCommentLikeCacheAsync(
			DeletePostCommentLikeCommand command,
			PostCommentLike postCommentLike,
			CancellationToken cancellationToken)
		{
			await serviceScope.AddPostCommentLikeCacheAsync(postCommentLike, command.Id.UserId, cancellationToken);
		}

		public async Task SetupGetAllAsync(
			GetAllPostCommentLikesQuery query,
			ICollection<User> users,
			ICollection<Post> posts,
			ICollection<PostLike> postLikes,
			ICollection<PostImage> postImages,
			ICollection<PostComment> postComments,
			ICollection<PostCommentLike> postCommentLikes,
			ICollection<PostCommentImage> postCommentImages,
			CancellationToken cancellationToken)
		{
			await serviceScope.SetupGetAllPostCommentLikesAsync(users, posts, postLikes, postImages, postComments, postCommentLikes, postCommentImages, cancellationToken);
		}

		public async Task SetupGetAllForUserAsync(
			GetAllPostCommentLikesForUserQuery query,
			ICollection<User> users,
			ICollection<Post> posts,
			ICollection<PostLike> postLikes,
			ICollection<PostImage> postImages,
			ICollection<PostComment> postComments,
			ICollection<PostCommentLike> postCommentLikes,
			ICollection<PostCommentImage> postCommentImages,
			CancellationToken cancellationToken)
		{
			await serviceScope.SetupGetAllPostCommentLikesForUserAsync(users, posts, postLikes, postImages, postComments, postCommentLikes, postCommentImages, cancellationToken);
		}

		public async Task SetupGetByIdAsync(
			GetPostCommentLikeByIdQuery query,
			User user,
			Post post,
			PostComment postComment,
			PostCommentLike postCommentLike,
			ICollection<PostCommentImage> postCommentImages,
			CancellationToken cancellationToken)
		{
			await serviceScope.SetupGetPostCommentLikeByIdAsync(user, post, postComment, postCommentLike, postCommentImages, cancellationToken);
		}
	}
}
