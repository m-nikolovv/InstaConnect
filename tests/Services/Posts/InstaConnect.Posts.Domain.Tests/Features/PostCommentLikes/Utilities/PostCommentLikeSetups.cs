using InstaConnect.Posts.Domain.Features.PostCommentLikes.Models.Responses;
using InstaConnect.Posts.Infrastructure.Features.PostCommentLikes.Abstractions;
using InstaConnect.Posts.Infrastructure.Features.PostComments.Abstractions;

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
	}

	extension(IPostCommentLikeCacheHandler cacheHandler)
	{
		public async Task<PostCommentLikeResponse?> GetByIdAsync(
			DeletePostCommentLikeCommand command,
			CancellationToken cancellationToken)
		{
			return await cacheHandler.GetByIdAsync(command.Id, command.Id.UserId, cancellationToken);
		}

		public async Task<PostCommentLikeResponse?> GetByIdAsync(
			GetPostCommentLikeByIdQuery query,
			CancellationToken cancellationToken)
		{
			return await cacheHandler.GetByIdAsync(query.Id, query.CurrentUser.Id, cancellationToken);
		}
	}

	extension(IPostCommentCacheHandler cacheHandler)
	{
		public async Task<PostCommentResponse?> GetByIdAsync(
			AddPostCommentLikeCommand command,
			CancellationToken cancellationToken)
		{
			return await cacheHandler.GetByIdAsync(command.CommentId, command.UserId, cancellationToken);
		}

		public async Task<PostCommentResponse?> GetByIdAsync(
			DeletePostCommentLikeCommand command,
			CancellationToken cancellationToken)
		{
			return await cacheHandler.GetByIdAsync(command.Id.CommentId, command.Id.UserId, cancellationToken);
		}
	}
}
