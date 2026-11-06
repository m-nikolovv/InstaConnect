using InstaConnect.Posts.Domain.Features.Posts.Abstractions;

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
			await serviceScope.GetPostCommandRepository().AddAsync(post, cancellationToken);
		}

		public async Task AddRangeAsync(
			IEnumerable<Post> posts,
			CancellationToken cancellationToken)
		{
			await serviceScope.GetPostCommandRepository().AddRangeAsync(posts, cancellationToken);
		}

		public async Task DeleteAsync(
			Post post,
			CancellationToken cancellationToken)
		{
			await serviceScope.GetPostCommandRepository().DeleteAsync(post, cancellationToken);
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
