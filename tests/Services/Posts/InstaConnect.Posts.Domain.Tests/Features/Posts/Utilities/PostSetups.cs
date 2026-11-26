
namespace InstaConnect.Posts.Domain.Tests.Features.Posts.Utilities;

public static class PostSetups
{
	extension(IServiceProvider serviceProvider)
	{
		public IPostCommandService GetPostCommandService()
		{
			return serviceProvider.GetRequiredService<IPostCommandService>();
		}

		public IPostQueryService GetPostQueryService()
		{
			return serviceProvider.GetRequiredService<IPostQueryService>();
		}
	}

	extension(IServiceScope serviceScope)
	{
		public IPostCommandService GetPostCommandService()
		{
			return serviceScope.ServiceProvider.GetPostCommandService();
		}

		public IPostQueryService GetPostQueryService()
		{
			return serviceScope.ServiceProvider.GetPostQueryService();
		}

		public async Task SetupAddAsync(
			AddPostCommand command,
			User user,
			CancellationToken cancellationToken)
		{
			await serviceScope.SetupAddPostAsync(user, cancellationToken);
		}

		public async Task SetupUpdateAsync(
			UpdatePostCommand command,
			User user,
			Post post,
			ICollection<PostImage> postImages,
			CancellationToken cancellationToken)
		{
			await serviceScope.SetupUpdatePostAsync(user, post, postImages, command.UserId, cancellationToken);
		}

		public async Task SetupDeleteAsync(
			DeletePostCommand command,
			ICollection<User> users,
			Post post,
			ICollection<PostLike> postLikes,
			ICollection<PostImage> postImages,
			ICollection<PostComment> postComments,
			ICollection<PostCommentLike> postCommentLikes,
			ICollection<PostCommentImage> postCommentImages,
			CancellationToken cancellationToken)
		{
			await serviceScope.SetupDeletePostAsync(users, post, postLikes, postImages, postComments, postCommentLikes, postCommentImages, command.UserId, cancellationToken);
		}

		public async Task SetupGetByIdAsync(
			GetPostByIdQuery query,
			ICollection<User> users,
			Post post,
			ICollection<PostLike> postLikes,
			ICollection<PostImage> postImages,
			ICollection<PostComment> postComments,
			ICollection<PostCommentLike> postCommentLikes,
			ICollection<PostCommentImage> postCommentImages,
			CancellationToken cancellationToken)
		{
			await serviceScope.SetupGetPostByIdAsync(users, post, postLikes, postImages, postComments, postCommentLikes, postCommentImages, cancellationToken);
		}

		public async Task SetupGetAllAsync(
			GetAllPostsQuery query,
			ICollection<User> users,
			ICollection<Post> posts,
			ICollection<PostLike> postLikes,
			ICollection<PostImage> postImages,
			ICollection<PostComment> postComments,
			ICollection<PostCommentLike> postCommentLikes,
			ICollection<PostCommentImage> postCommentImages,
			CancellationToken cancellationToken)
		{
			await serviceScope.SetupGetAllPostsAsync(users, posts, postLikes, postImages, postComments, postCommentLikes, postCommentImages, cancellationToken);
		}

		public async Task SetupGetAllForUserAsync(
			GetAllPostsForUserQuery query,
			ICollection<User> users,
			ICollection<Post> posts,
			ICollection<PostLike> postLikes,
			ICollection<PostImage> postImages,
			ICollection<PostComment> postComments,
			ICollection<PostCommentLike> postCommentLikes,
			ICollection<PostCommentImage> postCommentImages,
			CancellationToken cancellationToken)
		{
			await serviceScope.SetupGetAllPostsForUserAsync(users, posts, postLikes, postImages, postComments, postCommentLikes, postCommentImages, cancellationToken);
		}






		public async Task<PostResponse?> GetPostCacheByIdAsync(
			UpdatePostCommand command,
			CancellationToken cancellationToken)
		{
			return await serviceScope.GetPostCacheByIdAsync(command.Id, command.UserId, cancellationToken);
		}

		public async Task<PostResponse?> GetPostCacheByIdAsync(
			DeletePostCommand command,
			CancellationToken cancellationToken)
		{
			return await serviceScope.GetPostCacheByIdAsync(command.Id, command.UserId, cancellationToken);
		}

		public async Task<PostResponse?> GetPostCacheByIdAsync(
			GetPostByIdQuery query,
			CancellationToken cancellationToken)
		{
			return await serviceScope.GetPostCacheByIdAsync(query.Id, query.CurrentUser.Id, cancellationToken);
		}

		public async Task AddPostCacheAsync(
			UpdatePostCommand command,
			Post post,
			CancellationToken cancellationToken)
		{
			await serviceScope.AddPostCacheAsync(post, command.UserId, cancellationToken);
		}

		public async Task AddPostCacheAsync(
			DeletePostCommand command,
			Post post,
			CancellationToken cancellationToken)
		{
			await serviceScope.AddPostCacheAsync(post, command.UserId, cancellationToken);
		}
	}
}
