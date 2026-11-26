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
			PostCommentLike postCommentLike,
			CancellationToken cancellationToken)
		{
			await serviceScope.SetupAddAsync(postCommentLike, command.UserId, cancellationToken);
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
			PostCommentLike postCommentLike,
			CancellationToken cancellationToken)
		{
			await serviceScope.SetupDeleteAsync(postCommentLike, command.Id.UserId, cancellationToken);
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
			ICollection<PostCommentLike> postCommentLikes,
			CancellationToken cancellationToken)
		{
			await serviceScope.SetupGetAllAsync(postCommentLikes, cancellationToken);
		}

		public async Task SetupGetAllForUserAsync(
			GetAllPostCommentLikesForUserQuery query,
			ICollection<PostCommentLike> postCommentLikes,
			CancellationToken cancellationToken)
		{
			await serviceScope.SetupGetAllForUserAsync(postCommentLikes, cancellationToken);
		}

		public async Task SetupGetByIdAsync(
			GetPostCommentLikeByIdQuery query,
			PostCommentLike postCommentLike,
			CancellationToken cancellationToken)
		{
			await serviceScope.SetupGetByIdAsync(postCommentLike, cancellationToken);
		}
	}
}
