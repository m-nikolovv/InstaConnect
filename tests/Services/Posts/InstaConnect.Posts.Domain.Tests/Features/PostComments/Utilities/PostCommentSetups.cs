
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
			PostComment postComment,
			CancellationToken cancellationToken)
		{
			await serviceScope.SetupAddAsync(postComment, command.UserId, cancellationToken);
		}

		public async Task SetupUpdateAsync(
			UpdatePostCommentCommand command,
			PostComment postComment,
			CancellationToken cancellationToken)
		{
			await serviceScope.SetupUpdateAsync(postComment, command.UserId, cancellationToken);
		}

		public async Task SetupDeleteAsync(
			DeletePostCommentCommand command,
			PostComment postComment,
			CancellationToken cancellationToken)
		{
			await serviceScope.SetupDeleteAsync(postComment, command.UserId, cancellationToken);
		}

		public async Task SetupGetByIdAsync(
			GetPostCommentByIdQuery query,
			PostComment postComment,
			CancellationToken cancellationToken)
		{
			await serviceScope.SetupGetByIdAsync(postComment, cancellationToken);
		}

		public async Task SetupGetAllAsync(
			GetAllPostCommentsQuery query,
			ICollection<PostComment> postComments,
			CancellationToken cancellationToken)
		{
			await serviceScope.SetupGetAllAsync(postComments, cancellationToken);
		}

		public async Task SetupGetAllForUserAsync(
			GetAllPostCommentsForUserQuery query,
			ICollection<PostComment> postComments,
			CancellationToken cancellationToken)
		{
			await serviceScope.SetupGetAllForUserAsync(postComments, cancellationToken);
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
