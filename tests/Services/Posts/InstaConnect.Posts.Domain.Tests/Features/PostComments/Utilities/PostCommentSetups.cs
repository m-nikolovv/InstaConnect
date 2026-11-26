
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

		public async Task InitializeAddAsync(
			AddPostCommentCommand command,
			PostComment postComment,
			CancellationToken cancellationToken)
		{
			await serviceScope.InitializeAddAsync(postComment, command.UserId, cancellationToken);
		}

		public async Task DisposeAddAsync(
			AddPostCommentCommand command,
			PostComment postComment,
			CancellationToken cancellationToken)
		{
			await serviceScope.DisposeAddAsync(postComment, cancellationToken);
		}

		public async Task InitializeUpdateAsync(
			UpdatePostCommentCommand command,
			PostComment postComment,
			CancellationToken cancellationToken)
		{
			await serviceScope.InitializeUpdateAsync(postComment, command.UserId, cancellationToken);
		}

		public async Task DisposeUpdateAsync(
			UpdatePostCommentCommand command,
			PostComment postComment,
			CancellationToken cancellationToken)
		{
			await serviceScope.DisposeUpdateAsync(postComment, cancellationToken);
		}

		public async Task InitializeDeleteAsync(
			DeletePostCommentCommand command,
			PostComment postComment,
			CancellationToken cancellationToken)
		{
			await serviceScope.InitializeDeleteAsync(postComment, command.UserId, cancellationToken);
		}

		public async Task DisposeDeleteAsync(
			DeletePostCommentCommand command,
			PostComment postComment,
			CancellationToken cancellationToken)
		{
			await serviceScope.DisposeDeleteAsync(postComment, cancellationToken);
		}

		public async Task InitializeGetByIdAsync(
			GetPostCommentByIdQuery query,
			PostComment postComment,
			CancellationToken cancellationToken)
		{
			await serviceScope.InitializeGetByIdAsync(postComment, cancellationToken);
		}

		public async Task DisposeGetByIdAsync(
			GetPostCommentByIdQuery query,
			PostComment postComment,
			CancellationToken cancellationToken)
		{
			await serviceScope.DisposeGetByIdAsync(postComment, cancellationToken);
		}

		public async Task InitializeGetAllAsync(
			GetAllPostCommentsQuery query,
			ICollection<PostComment> postComments,
			CancellationToken cancellationToken)
		{
			await serviceScope.InitializeGetAllAsync(postComments, cancellationToken);
		}

		public async Task DisposeGetAllAsync(
			GetAllPostCommentsQuery query,
			ICollection<PostComment> postComments,
			CancellationToken cancellationToken)
		{
			await serviceScope.DisposeGetAllAsync(postComments, cancellationToken);
		}

		public async Task InitializeGetAllForUserAsync(
			GetAllPostCommentsForUserQuery query,
			ICollection<PostComment> postComments,
			CancellationToken cancellationToken)
		{
			await serviceScope.InitializeGetAllForUserAsync(postComments, cancellationToken);
		}

		public async Task DisposeGetAllForUserAsync(
			GetAllPostCommentsForUserQuery query,
			ICollection<PostComment> postComments,
			CancellationToken cancellationToken)
		{
			await serviceScope.DisposeGetAllForUserAsync(postComments, cancellationToken);
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
