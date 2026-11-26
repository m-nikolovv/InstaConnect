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

		public async Task InitializeAddAsync(
			AddPostLikeCommand command,
			PostLike postLike,
			CancellationToken cancellationToken)
		{
			await serviceScope.InitializeAddAsync(postLike, command.UserId, cancellationToken);
		}

		public async Task DisposeAddAsync(
			AddPostLikeCommand command,
			PostLike postLike,
			CancellationToken cancellationToken)
		{
			await serviceScope.DisposeAddAsync(postLike, cancellationToken);
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

		public async Task InitializeDeleteAsync(
			DeletePostLikeCommand command,
			PostLike postLike,
			CancellationToken cancellationToken)
		{
			await serviceScope.InitializeDeleteAsync(postLike, command.Id.UserId, cancellationToken);
		}

		public async Task DisposeDeleteAsync(
			DeletePostLikeCommand command,
			PostLike postLike,
			CancellationToken cancellationToken)
		{
			await serviceScope.DisposeDeleteAsync(postLike, cancellationToken);
		}

		public async Task AddPostLikeCacheAsync(
			DeletePostLikeCommand command,
			PostLike postLike,
			CancellationToken cancellationToken)
		{
			await serviceScope.AddPostLikeCacheAsync(postLike, command.Id.UserId, cancellationToken);
		}

		public async Task InitializeGetAllAsync(
			GetAllPostLikesQuery query,
			ICollection<PostLike> postLikes,
			CancellationToken cancellationToken)
		{
			await serviceScope.InitializeGetAllAsync(postLikes, cancellationToken);
		}

		public async Task DisposeGetAllAsync(
			GetAllPostLikesQuery query,
			ICollection<PostLike> postLikes,
			CancellationToken cancellationToken)
		{
			await serviceScope.DisposeGetAllAsync(postLikes, cancellationToken);
		}

		public async Task InitializeGetAllForUserAsync(
			GetAllPostLikesForUserQuery query,
			ICollection<PostLike> postLikes,
			CancellationToken cancellationToken)
		{
			await serviceScope.InitializeGetAllForUserAsync(postLikes, cancellationToken);
		}

		public async Task DisposeGetAllForUserAsync(
			GetAllPostLikesForUserQuery query,
			ICollection<PostLike> postLikes,
			CancellationToken cancellationToken)
		{
			await serviceScope.DisposeGetAllForUserAsync(postLikes, cancellationToken);
		}

		public async Task InitializeGetByIdAsync(
			GetPostLikeByIdQuery query,
			PostLike postLike,
			CancellationToken cancellationToken)
		{
			await serviceScope.InitializeGetByIdAsync(postLike, cancellationToken);
		}

		public async Task DisposeGetByIdAsync(
			GetPostLikeByIdQuery query,
			PostLike postLike,
			CancellationToken cancellationToken)
		{
			await serviceScope.DisposeGetByIdAsync(postLike, cancellationToken);
		}
	}
}
