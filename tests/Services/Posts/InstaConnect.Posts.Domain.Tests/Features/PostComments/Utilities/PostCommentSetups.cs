using InstaConnect.Posts.Infrastructure.Features.PostComments.Abstractions;
using InstaConnect.Posts.Infrastructure.Features.Posts.Abstractions;

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
	}

	extension(IPostCommentCacheHandler cacheHandler)
	{
		public async Task<PostCommentResponse?> GetByIdAsync(
			UpdatePostCommentCommand command,
			CancellationToken cancellationToken)
		{
			return await cacheHandler.GetByIdAsync(command.Id, command.UserId, cancellationToken);
		}

		public async Task<PostCommentResponse?> GetByIdAsync(
			DeletePostCommentCommand command,
			CancellationToken cancellationToken)
		{
			return await cacheHandler.GetByIdAsync(command.Id, command.UserId, cancellationToken);
		}

		public async Task<PostCommentResponse?> GetByIdAsync(
			GetPostCommentByIdQuery query,
			CancellationToken cancellationToken)
		{
			return await cacheHandler.GetByIdAsync(query.Id, query.CurrentUser.Id, cancellationToken);
		}

		public async Task AddAsync(
			UpdatePostCommentCommand command,
			PostComment postComment,
			CancellationToken cancellationToken)
		{
			await cacheHandler.AddAsync(postComment, command.UserId, cancellationToken);
		}

		public async Task AddAsync(
			DeletePostCommentCommand command,
			PostComment postComment,
			CancellationToken cancellationToken)
		{
			await cacheHandler.AddAsync(postComment, command.UserId, cancellationToken);
		}
	}

	extension(IPostCacheHandler cacheHandler)
	{
		public async Task<PostResponse?> GetByIdAsync(
			AddPostCommentCommand command,
			CancellationToken cancellationToken)
		{
			return await cacheHandler.GetByIdAsync(command.Id, command.UserId, cancellationToken);
		}

		public async Task<PostResponse?> GetByIdAsync(
			DeletePostCommentCommand command,
			CancellationToken cancellationToken)
		{
			return await cacheHandler.GetByIdAsync(command.Id.Id, command.UserId, cancellationToken);
		}
	}
}
