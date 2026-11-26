
namespace InstaConnect.Posts.Domain.Tests.Features.PostComments.Utilities;

public static class PostCommentSetups
{
	extension(IServiceProvider serviceProvider)
	{
		public IPostCommentCommandService GetPostCommentCommandService()
		{
			return serviceProvider.GetRequiredService<IPostCommentCommandService>();
		}

		public IPostCommentQueryService GetPostCommentQueryService()
		{
			return serviceProvider.GetRequiredService<IPostCommentQueryService>();
		}
	}

	extension(IServiceScope serviceScope)
	{
		public IPostCommentCommandService GetPostCommentCommandService()
		{
			return serviceScope.ServiceProvider.GetPostCommentCommandService();
		}

		public IPostCommentQueryService GetPostCommentQueryService()
		{
			return serviceScope.ServiceProvider.GetPostCommentQueryService();
		}

		public async Task SetupAddAsync(
			AddPostCommentCommand command,
			User user,
			Post post,
			CancellationToken cancellationToken)
		{
			await serviceScope.SetupAddPostCommentAsync(user, post, command.UserId, cancellationToken);
		}

		public async Task SetupUpdateAsync(
			UpdatePostCommentCommand command,
			User user,
			Post post,
			PostComment postComment,
			CancellationToken cancellationToken)
		{
			await serviceScope.SetupUpdatePostCommentAsync(user, post, postComment, command.UserId, cancellationToken);
		}

		public async Task SetupDeleteAsync(
			DeletePostCommentCommand command,
			ICollection<User> users,
			Post post,
			PostComment postComment,
			ICollection<PostCommentLike> postCommentLikes,
			ICollection<PostCommentImage> postCommentImages,
			CancellationToken cancellationToken)
		{
			await serviceScope.SetupDeletePostCommentAsync(users, post, postComment, postCommentLikes, postCommentImages, command.UserId, cancellationToken);
		}

		public async Task SetupGetByIdAsync(
			GetPostCommentByIdQuery query,
			ICollection<User> users,
			Post post,
			ICollection<PostLike> postLikes,
			ICollection<PostImage> postImages,
			PostComment postComment,
			ICollection<PostCommentLike> postCommentLikes,
			ICollection<PostCommentImage> postCommentImages,
			CancellationToken cancellationToken)
		{
			await serviceScope.SetupGetPostCommentByIdAsync(users, post, postLikes, postImages, postComment, postCommentLikes, postCommentImages, cancellationToken);
		}

		public async Task SetupGetAllAsync(
			GetAllPostCommentsQuery query,
			ICollection<User> users,
			ICollection<Post> posts,
			ICollection<PostLike> postLikes,
			ICollection<PostImage> postImages,
			ICollection<PostComment> postComments,
			ICollection<PostCommentLike> postCommentLikes,
			ICollection<PostCommentImage> postCommentImages,
			CancellationToken cancellationToken)
		{
			await serviceScope.SetupGetAllPostCommentsAsync(users, posts, postLikes, postImages, postComments, postCommentLikes, postCommentImages, cancellationToken);
		}

		public async Task SetupGetAllForUserAsync(
			GetAllPostCommentsForUserQuery query,
			ICollection<User> users,
			ICollection<Post> posts,
			ICollection<PostLike> postLikes,
			ICollection<PostImage> postImages,
			ICollection<PostComment> postComments,
			ICollection<PostCommentLike> postCommentLikes,
			ICollection<PostCommentImage> postCommentImages,
			CancellationToken cancellationToken)
		{
			await serviceScope.SetupGetAllPostCommentsForUserAsync(users, posts, postLikes, postImages, postComments, postCommentLikes, postCommentImages, cancellationToken);
		}

		public async Task<PostCommentResponse?> GetPostCommentCacheByIdAsync(
			UpdatePostCommentCommand command,
			CancellationToken cancellationToken)
		{
			return await serviceScope.GetPostCommentCacheByIdAsync(command.Id, command.UserId, cancellationToken);
		}

		public async Task<PostCommentResponse?> GetPostCommentCacheByIdAsync(
			DeletePostCommentCommand command,
			CancellationToken cancellationToken)
		{
			return await serviceScope.GetPostCommentCacheByIdAsync(command.Id, command.UserId, cancellationToken);
		}

		public async Task<PostCommentResponse?> GetPostCommentCacheByIdAsync(
			GetPostCommentByIdQuery query,
			CancellationToken cancellationToken)
		{
			return await serviceScope.GetPostCommentCacheByIdAsync(query.Id, query.CurrentUser.Id, cancellationToken);
		}

		public async Task AddPostCommentCacheAsync(
			UpdatePostCommentCommand command,
			PostComment postComment,
			CancellationToken cancellationToken)
		{
			await serviceScope.AddPostCommentCacheAsync(postComment, command.UserId, cancellationToken);
		}

		public async Task AddPostCommentCacheAsync(
			DeletePostCommentCommand command,
			PostComment postComment,
			CancellationToken cancellationToken)
		{
			await serviceScope.AddPostCommentCacheAsync(postComment, command.UserId, cancellationToken);
		}

		public async Task<PostResponse?> GetPostCacheByIdAsync(
			AddPostCommentCommand command,
			CancellationToken cancellationToken)
		{
			return await serviceScope.GetPostCacheByIdAsync(command.Id, command.UserId, cancellationToken);
		}

		public async Task<PostResponse?> GetPostCacheByIdAsync(
			DeletePostCommentCommand command,
			CancellationToken cancellationToken)
		{
			return await serviceScope.GetPostCacheByIdAsync(command.Id.Id, command.UserId, cancellationToken);
		}
	}
}
