using InstaConnect.Posts.Domain.Features.PostLikes.Models.Responses;
using InstaConnect.Posts.Infrastructure.Features.PostLikes.Abstractions;
using InstaConnect.Posts.Infrastructure.Features.Posts.Abstractions;

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
	}

	extension(IPostLikeCacheHandler cacheHandler)
	{
		public async Task<PostLikeResponse?> GetByIdAsync(
			DeletePostLikeCommand command,
			CancellationToken cancellationToken)
		{
			return await cacheHandler.GetByIdAsync(command.Id, command.Id.UserId, cancellationToken);
		}

		public async Task<PostLikeResponse?> GetByIdAsync(
			GetPostLikeByIdQuery query,
			CancellationToken cancellationToken)
		{
			return await cacheHandler.GetByIdAsync(query.Id, query.CurrentUser.Id, cancellationToken);
		}
	}

	extension(IPostCacheHandler cacheHandler)
	{
		public async Task<PostResponse?> GetByIdAsync(
			AddPostLikeCommand command,
			CancellationToken cancellationToken)
		{
			return await cacheHandler.GetByIdAsync(command.Id, command.UserId, cancellationToken);
		}

		public async Task<PostResponse?> GetByIdAsync(
			DeletePostLikeCommand command,
			CancellationToken cancellationToken)
		{
			return await cacheHandler.GetByIdAsync(command.Id.Id, command.Id.UserId, cancellationToken);
		}
	}
}
