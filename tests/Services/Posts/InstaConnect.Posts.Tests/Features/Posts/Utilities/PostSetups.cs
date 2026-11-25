using InstaConnect.Posts.Domain.Features.Posts.Abstractions;
using InstaConnect.Posts.Domain.Features.Posts.Models.Responses;
using InstaConnect.Posts.Infrastructure.Features.Posts.Abstractions;

namespace InstaConnect.Posts.Tests.Features.Posts.Utilities;

public static class PostSetups
{
	extension(IServiceProvider serviceProvider)
	{
		public IPostQueryRepository GetPostQueryRepository()
		{
			return serviceProvider.GetRequiredService<IPostQueryRepository>();
		}

		public IPostCommandRepository GetPostCommandRepository()
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

		public IPostCommandRepository GetPostCommandRepository()
		{
			return serviceScope.ServiceProvider.GetPostCommandRepository();
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
			CancellationToken cancellationToken)
		{
			var postRepository = serviceScope.GetPostCommandRepository();

			await postRepository.AddAsync(post, cancellationToken);
		}

		public async Task AddRangeAsync(
			ICollection<Post> posts,
			CancellationToken cancellationToken)
		{
			var postRepository = serviceScope.GetPostCommandRepository();

			await postRepository.AddRangeAsync(posts, cancellationToken);
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

	extension(IPostCacheHandler cacheHandler)
	{
		public async Task<PostResponse?> GetByIdAsync(
			string id,
			string currentUserId,
			CancellationToken cancellationToken)
		{
			return await cacheHandler.GetByIdAsync(new(id), new(currentUserId), cancellationToken);
		}
	}
}
