using InstaConnect.Posts.Domain.Features.PostLikes.Abstractions;

namespace InstaConnect.Posts.Tests.Features.PostLikes.Utilities;

public static class PostLikeSetups
{
	extension(IServiceProvider serviceProvider)
	{
		public IPostLikeQueryRepository GetPostLikeQueryRepository()
		{
			return serviceProvider.GetRequiredService<IPostLikeQueryRepository>();
		}

		public IPostLikeCommandRepository GetPostLikeCommandRepository()
		{
			return serviceProvider.GetRequiredService<IPostLikeCommandRepository>();
		}

		public IPostLikeIncludeBuilderFactory GetPostLikeIncludeBuilderFactory()
		{
			return serviceProvider.GetRequiredService<IPostLikeIncludeBuilderFactory>();
		}
	}

	extension(IServiceScope serviceScope)
	{
		public IPostLikeQueryRepository GetPostLikeQueryRepository()
		{
			return serviceScope.ServiceProvider.GetPostLikeQueryRepository();
		}

		public IPostLikeCommandRepository GetPostLikeCommandRepository()
		{
			return serviceScope.ServiceProvider.GetPostLikeCommandRepository();
		}

		public IPostLikeIncludeBuilderFactory GetPostLikeIncludeBuilderFactory()
		{
			return serviceScope.ServiceProvider.GetPostLikeIncludeBuilderFactory();
		}

		public async Task<PostLike?> GetByIdAsync(
			PostLikeId id,
			CancellationToken cancellationToken)
		{
			var include = serviceScope.GetPostIncludeBuilderFactory().Create().WithUser().Build();
			var likeInclude = serviceScope.GetPostLikeIncludeBuilderFactory().Create().WithUser().WithPost(include).Build();

			return (await serviceScope.GetPostLikeCommandRepository().GetByIdAsync(id, likeInclude, cancellationToken)).SetUser().SetPost();
		}

		public async Task AddAsync(
			PostLike postLike,
			CancellationToken cancellationToken)
		{
			await serviceScope.GetPostLikeCommandRepository().AddAsync(postLike, cancellationToken);
		}

		public async Task AddRangeAsync(
			IEnumerable<PostLike> postLikes,
			CancellationToken cancellationToken)
		{
			await serviceScope.GetPostLikeCommandRepository().AddRangeAsync(postLikes, cancellationToken);
		}

		public async Task DeleteAsync(
			PostLike postLike,
			CancellationToken cancellationToken)
		{
			await serviceScope.GetPostLikeCommandRepository().DeleteAsync(postLike, cancellationToken);
		}
	}
}
