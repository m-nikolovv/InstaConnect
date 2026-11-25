using InstaConnect.Posts.Infrastructure.Features.Posts.Abstractions;

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
	}

	extension(IPostCacheHandler cacheHandler)
	{
		public async Task<PostResponse?> GetByIdAsync(
			UpdatePostCommand command,
			CancellationToken cancellationToken)
		{
			return await cacheHandler.GetByIdAsync(command.Id, command.UserId, cancellationToken);
		}

		public async Task<PostResponse?> GetByIdAsync(
			DeletePostCommand command,
			CancellationToken cancellationToken)
		{
			return await cacheHandler.GetByIdAsync(command.Id, command.UserId, cancellationToken);
		}

		public async Task<PostResponse?> GetByIdAsync(
			GetPostByIdQuery query,
			CancellationToken cancellationToken)
		{
			return await cacheHandler.GetByIdAsync(query.Id, query.CurrentUser.Id, cancellationToken);
		}
	}
}
