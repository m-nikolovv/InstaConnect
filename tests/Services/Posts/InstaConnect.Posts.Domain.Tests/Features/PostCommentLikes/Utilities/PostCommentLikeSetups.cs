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

		public async Task InitializeAddAsync(
			AddPostCommentLikeCommand command,
			PostCommentLike postCommentLike,
			CancellationToken cancellationToken)
		{
			await serviceScope.InitializeAddAsync(postCommentLike, command.UserId, cancellationToken);
		}

		public async Task DisposeAddAsync(
			AddPostCommentLikeCommand command,
			PostCommentLike postCommentLike,
			CancellationToken cancellationToken)
		{
			await serviceScope.DisposeAddAsync(postCommentLike, cancellationToken);
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

		public async Task InitializeDeleteAsync(
			DeletePostCommentLikeCommand command,
			PostCommentLike postCommentLike,
			CancellationToken cancellationToken)
		{
			await serviceScope.InitializeDeleteAsync(postCommentLike, command.Id.UserId, cancellationToken);
		}

		public async Task DisposeDeleteAsync(
			DeletePostCommentLikeCommand command,
			PostCommentLike postCommentLike,
			CancellationToken cancellationToken)
		{
			await serviceScope.DisposeDeleteAsync(postCommentLike, cancellationToken);
		}

		public async Task AddPostCommentLikeCacheAsync(
			DeletePostCommentLikeCommand command,
			PostCommentLike postCommentLike,
			CancellationToken cancellationToken)
		{
			await serviceScope.AddPostCommentLikeCacheAsync(postCommentLike, command.Id.UserId, cancellationToken);
		}

		public async Task InitializeGetAllAsync(
			GetAllPostCommentLikesQuery query,
			ICollection<PostCommentLike> postCommentLikes,
			CancellationToken cancellationToken)
		{
			await serviceScope.InitializeGetAllAsync(postCommentLikes, cancellationToken);
		}

		public async Task DisposeGetAllAsync(
			GetAllPostCommentLikesQuery query,
			ICollection<PostCommentLike> postCommentLikes,
			CancellationToken cancellationToken)
		{
			await serviceScope.DisposeGetAllAsync(postCommentLikes, cancellationToken);
		}

		public async Task InitializeGetAllForUserAsync(
			GetAllPostCommentLikesForUserQuery query,
			ICollection<PostCommentLike> postCommentLikes,
			CancellationToken cancellationToken)
		{
			await serviceScope.InitializeGetAllForUserAsync(postCommentLikes, cancellationToken);
		}

		public async Task DisposeGetAllForUserAsync(
			GetAllPostCommentLikesForUserQuery query,
			ICollection<PostCommentLike> postCommentLikes,
			CancellationToken cancellationToken)
		{
			await serviceScope.DisposeGetAllForUserAsync(postCommentLikes, cancellationToken);
		}

		public async Task InitializeGetByIdAsync(
			GetPostCommentLikeByIdQuery query,
			PostCommentLike postCommentLike,
			CancellationToken cancellationToken)
		{
			await serviceScope.InitializeGetByIdAsync(postCommentLike, cancellationToken);
		}

		public async Task DisposeGetByIdAsync(
			GetPostCommentLikeByIdQuery query,
			PostCommentLike postCommentLike,
			CancellationToken cancellationToken)
		{
			await serviceScope.DisposeGetByIdAsync(postCommentLike, cancellationToken);
		}
	}
}
