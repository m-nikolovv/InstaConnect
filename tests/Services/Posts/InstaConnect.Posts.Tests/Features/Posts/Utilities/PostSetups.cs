using InstaConnect.Posts.Domain.Features.Posts.Abstractions;
using InstaConnect.Posts.Infrastructure.Features.Posts.Abstractions;
using InstaConnect.Posts.Infrastructure.Features.Posts.Helpers.Repositories;

namespace InstaConnect.Posts.Tests.Features.Posts.Utilities;

public static class PostSetups
{
	extension(IServiceProvider serviceProvider)
	{
		public IPostQueryRepository GetPostQueryRepository()
		{
			return new PostQueryRepository(
				serviceProvider.GetPostCollection(),
				serviceProvider.GetPostIncludeBuilderFactory());
		}

		public IPostQueryRepository GetCachedPostQueryRepository()
		{
			return serviceProvider.GetRequiredService<IPostQueryRepository>();
		}

		public IPostCommandRepository GetPostCommandRepository()
		{
			return new PostCommandRepository(
				serviceProvider.GetPostCollection(),
				serviceProvider.GetPostIncludeBuilderFactory());
		}

		public IPostCommandRepository GetCachedPostCommandRepository()
		{
			return serviceProvider.GetRequiredService<IPostCommandRepository>();
		}

		public IPostIncludeBuilderFactory GetPostIncludeBuilderFactory()
		{
			return serviceProvider.GetRequiredService<IPostIncludeBuilderFactory>();
		}

		public IPostCollection GetPostCollection()
		{
			return serviceProvider.GetRequiredService<IPostCollection>();
		}

		public IPostCacheHandler GetPostCacheHandler()
		{
			return serviceProvider.GetRequiredService<IPostCacheHandler>();
		}
	}

	extension(IServiceScope serviceScope)
	{
		public IPostQueryRepository GetPostQueryRepository()
		{
			return serviceScope.ServiceProvider.GetPostQueryRepository();
		}

		public IPostQueryRepository GetCachedPostQueryRepository()
		{
			return serviceScope.ServiceProvider.GetCachedPostQueryRepository();
		}

		public IPostCommandRepository GetPostCommandRepository()
		{
			return serviceScope.ServiceProvider.GetPostCommandRepository();
		}

		public IPostCommandRepository GetCachedPostCommandRepository()
		{
			return serviceScope.ServiceProvider.GetCachedPostCommandRepository();
		}

		public IPostIncludeBuilderFactory GetPostIncludeBuilderFactory()
		{
			return serviceScope.ServiceProvider.GetPostIncludeBuilderFactory();
		}

		public IPostCacheHandler GetPostCacheHandler()
		{
			return serviceScope.ServiceProvider.GetPostCacheHandler();
		}

		public async Task<Post?> GetByIdAsync(
			PostId id,
			CancellationToken cancellationToken)
		{
			var include = serviceScope.GetPostIncludeBuilderFactory().Create().WithUser().WithPostImages().Build();

			return (await serviceScope.GetPostCommandRepository().GetByIdAsync(id, include, cancellationToken)).SetUser().SetPostImages();
		}

		public async Task<ICollection<Post>> GetByIdRangeAsync(
			IEnumerable<PostId> ids,
			CancellationToken cancellationToken)
		{
			var include = serviceScope.GetPostIncludeBuilderFactory().Create().WithUser().WithPostImages().Build();

			return (await serviceScope.GetPostCommandRepository().GetByIdRangeAsync(ids, include, cancellationToken)).SetUser();
		}

		public async Task AddAsync(
			Post post,
			UserId currentUserId,
			CancellationToken cancellationToken)
		{
			var cacheHandler = serviceScope.GetPostCacheHandler();
			var postRepository = serviceScope.GetPostCommandRepository();

			await postRepository.AddAsync(post, cancellationToken);
			await cacheHandler.AddAsync(post.ToFullResponse(currentUserId), currentUserId, cancellationToken);
		}

		public async Task AddRangeAsync(
			ICollection<Post> posts,
			UserId currentUserId,
			CancellationToken cancellationToken)
		{
			var cacheHandler = serviceScope.GetPostCacheHandler();
			var postRepository = serviceScope.GetPostCommandRepository();

			await postRepository.AddRangeAsync(posts, cancellationToken);
			await cacheHandler.AddRangeAsync(posts.ToFullResponse(currentUserId), currentUserId, cancellationToken);
		}

		public async Task DeleteAsync(
			Post post,
			CancellationToken cancellationToken)
		{
			var cacheHandler = serviceScope.GetPostCacheHandler();
			var postRepository = serviceScope.GetPostCommandRepository();

			await postRepository.DeleteAsync(post, cancellationToken);
			await cacheHandler.DeleteAsync(post.Id, cancellationToken);
		}

		public async Task DeleteRangeAsync(
			IEnumerable<Post> posts,
			CancellationToken cancellationToken)
		{
			foreach (var post in posts)
			{
				await serviceScope.DeleteAsync(post, cancellationToken);
			}
		}
	}
}
