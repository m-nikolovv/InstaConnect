using InstaConnect.Posts.Domain.Features.PostLikes.Abstractions;
using InstaConnect.Posts.Infrastructure.Features.PostLikes.Abstractions;
using InstaConnect.Posts.Infrastructure.Features.PostLikes.Helpers.Repositories;

namespace InstaConnect.Posts.Tests.Features.PostLikes.Utilities;

public static class PostLikeSetups
{
	extension(IServiceProvider serviceProvider)
	{
		public IPostLikeQueryRepository GetPostLikeQueryRepository()
		{
			return new PostLikeQueryRepository(
				serviceProvider.GetPostLikeCollection(),
				serviceProvider.GetPostIncludeBuilderFactory(),
				serviceProvider.GetPostLikeIncludeBuilderFactory());
		}

		public IPostLikeCommandRepository GetPostLikeCommandRepository()
		{
			return new PostLikeCommandRepository(
				serviceProvider.GetPostLikeCollection(),
				serviceProvider.GetPostLikeIncludeBuilderFactory());
		}

		public IPostLikeIncludeBuilderFactory GetPostLikeIncludeBuilderFactory()
		{
			return serviceProvider.GetRequiredService<IPostLikeIncludeBuilderFactory>();
		}

		public IPostLikeCollection GetPostLikeCollection()
		{
			return serviceProvider.GetRequiredService<IPostLikeCollection>();
		}

		public IPostLikeCacheHandler GetPostLikeCacheHandler()
		{
			return serviceProvider.GetRequiredService<IPostLikeCacheHandler>();
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

		public IPostLikeCacheHandler GetPostLikeCacheHandler()
		{
			return serviceScope.ServiceProvider.GetPostLikeCacheHandler();
		}

		public async Task<PostLike?> GetByIdAsync(
			PostLikeId id,
			CancellationToken cancellationToken)
		{
			var include = serviceScope.GetPostIncludeBuilderFactory().Create().WithUser().Build();
			var likeInclude = serviceScope.GetPostLikeIncludeBuilderFactory().Create().WithUser().WithPost(include).Build();

			return (await serviceScope.GetPostLikeCommandRepository().GetByIdAsync(id, likeInclude, cancellationToken)).SetUser().SetPost();
		}

		public async Task<ICollection<PostLike>> GetByIdRangeAsync(
			IEnumerable<PostLikeId> ids,
			CancellationToken cancellationToken)
		{
			var include = serviceScope.GetPostIncludeBuilderFactory().Create().WithUser().Build();
			var likeInclude = serviceScope.GetPostLikeIncludeBuilderFactory().Create().WithUser().WithPost(include).Build();

			return (await serviceScope.GetPostLikeCommandRepository().GetByIdRangeAsync(ids, likeInclude, cancellationToken)).SetUser().SetPost();
		}

		public async Task AddAsync(
			PostLike postLike,
			UserId currentUserId,
			CancellationToken cancellationToken)
		{
			var likeCacheHandler = serviceScope.GetPostLikeCacheHandler();
			var postLikeRepository = serviceScope.GetPostLikeCommandRepository();

			await postLikeRepository.AddAsync(postLike, cancellationToken);
			await likeCacheHandler.AddAsync(postLike.ToFullResponse(currentUserId), currentUserId, cancellationToken);
		}

		public async Task AddRangeAsync(
			ICollection<PostLike> postLikes,
			UserId currentUserId,
			CancellationToken cancellationToken)
		{
			var likeCacheHandler = serviceScope.GetPostLikeCacheHandler();
			var postLikeRepository = serviceScope.GetPostLikeCommandRepository();

			await postLikeRepository.AddRangeAsync(postLikes, cancellationToken);
			await likeCacheHandler.AddRangeAsync(postLikes.ToFullResponse(currentUserId), currentUserId, cancellationToken);
		}

		public async Task DeleteAsync(
			PostLike postLike,
			CancellationToken cancellationToken)
		{
			var cacheHandler = serviceScope.GetPostCacheHandler();
			var likeCacheHandler = serviceScope.GetPostLikeCacheHandler();
			var postLikeRepository = serviceScope.GetPostLikeCommandRepository();

			await postLikeRepository.DeleteAsync(postLike, cancellationToken);
			await cacheHandler.DeleteResponseAsync(postLike.Id.Id, cancellationToken);
			await likeCacheHandler.DeleteAsync(postLike.Id, cancellationToken);
		}

		public async Task DeleteRangeAsync(
			IEnumerable<PostLike> postLikes,
			CancellationToken cancellationToken)
		{
			foreach (var postLike in postLikes)
			{
				await serviceScope.DeleteAsync(postLike, cancellationToken);
			}
		}
	}
}
