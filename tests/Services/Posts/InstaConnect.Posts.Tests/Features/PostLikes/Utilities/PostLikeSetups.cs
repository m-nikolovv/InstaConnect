using InstaConnect.Posts.Domain.Features.PostLikes.Abstractions;
using InstaConnect.Posts.Domain.Features.PostLikes.Models.Responses;
using InstaConnect.Posts.Infrastructure.Features.PostLikes.Abstractions;

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
			CancellationToken cancellationToken)
		{
			var postLikeRepository = serviceScope.GetPostLikeCommandRepository();

			await postLikeRepository.AddAsync(postLike, cancellationToken);
		}

		public async Task AddRangeAsync(
			ICollection<PostLike> postLikes,
			CancellationToken cancellationToken)
		{
			var postLikeRepository = serviceScope.GetPostLikeCommandRepository();

			await postLikeRepository.AddRangeAsync(postLikes, cancellationToken);
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

		public async Task<PostLikeResponse?> GetPostLikeCacheByIdAsync(
			string id,
			string userId,
			string currentUserId,
			CancellationToken cancellationToken)
		{
			var cacheHandler = serviceScope.GetPostLikeCacheHandler();

			return await cacheHandler.GetByIdAsync(new(new(id), new(userId)), new(currentUserId), cancellationToken);
		}

		public async Task<PostLikeResponse?> GetPostLikeCacheByIdAsync(
			PostLikeId id,
			UserId currentUserId,
			CancellationToken cancellationToken)
		{
			var cacheHandler = serviceScope.GetPostLikeCacheHandler();

			return await cacheHandler.GetByIdAsync(id, currentUserId, cancellationToken);
		}

		public async Task SetupAddPostLikeAsync(
			User user,
			Post post,
			string currentUserId,
			CancellationToken cancellationToken)
		{
			await serviceScope.AddAsync(user, cancellationToken);
			await serviceScope.AddAsync(post, cancellationToken);
			await serviceScope.AddPostCacheAsync(post, currentUserId, cancellationToken);
		}

		public async Task SetupAddPostLikeAsync(
			User user,
			Post post,
			UserId currentUserId,
			CancellationToken cancellationToken)
		{
			await serviceScope.SetupAddPostLikeAsync(user, post, currentUserId.Id, cancellationToken);
		}

		public async Task SetupDeletePostLikeAsync(
			User user,
			Post post,
			PostLike postLike,
			string currentUserId,
			CancellationToken cancellationToken)
		{
			await serviceScope.AddAsync(user, cancellationToken);
			await serviceScope.AddAsync(post, cancellationToken);
			await serviceScope.AddAsync(postLike, cancellationToken);
			await serviceScope.AddPostCacheAsync(post, currentUserId, cancellationToken);
			await serviceScope.AddPostLikeCacheAsync(postLike, currentUserId, cancellationToken);
		}

		public async Task SetupDeletePostLikeAsync(
			User user,
			Post post,
			PostLike postLike,
			UserId currentUserId,
			CancellationToken cancellationToken)
		{
			await serviceScope.SetupDeletePostLikeAsync(user, post, postLike, currentUserId.Id, cancellationToken);
		}

		public async Task SetupGetAllPostLikesAsync(
			ICollection<User> users,
			ICollection<Post> posts,
			ICollection<PostLike> postLikes,
			ICollection<PostImage> postImages,
			ICollection<PostComment> postComments,
			CancellationToken cancellationToken)
		{
			await serviceScope.AddRangeAsync(users, cancellationToken);
			await serviceScope.AddRangeAsync(posts, cancellationToken);
			await serviceScope.AddRangeAsync(postLikes, cancellationToken);
			await serviceScope.AddRangeAsync(postImages, cancellationToken);
			await serviceScope.AddRangeAsync(postComments, cancellationToken);
		}

		public async Task SetupGetAllPostLikesForUserAsync(
			ICollection<User> users,
			ICollection<Post> posts,
			ICollection<PostLike> postLikes,
			ICollection<PostImage> postImages,
			ICollection<PostComment> postComments,
			CancellationToken cancellationToken)
		{
			await serviceScope.AddRangeAsync(users, cancellationToken);
			await serviceScope.AddRangeAsync(posts, cancellationToken);
			await serviceScope.AddRangeAsync(postLikes, cancellationToken);
			await serviceScope.AddRangeAsync(postImages, cancellationToken);
			await serviceScope.AddRangeAsync(postComments, cancellationToken);
		}

		public async Task SetupGetPostLikeByIdAsync(
			ICollection<User> users,
			Post post,
			PostLike postLike,
			ICollection<PostImage> postImages,
			ICollection<PostComment> postComments,
			CancellationToken cancellationToken)
		{
			await serviceScope.AddRangeAsync(users, cancellationToken);
			await serviceScope.AddAsync(post, cancellationToken);
			await serviceScope.AddAsync(postLike, cancellationToken);
			await serviceScope.AddRangeAsync(postImages, cancellationToken);
			await serviceScope.AddRangeAsync(postComments, cancellationToken);
		}

		public async Task AddPostLikeCacheAsync(
			PostLike postLike,
			string currentUserId,
			CancellationToken cancellationToken)
		{
			var cacheHandler = serviceScope.GetPostLikeCacheHandler();

			await cacheHandler.AddAsync(postLike.ToFullResponse(currentUserId), new(currentUserId), cancellationToken);
		}

		public async Task AddPostLikeCacheAsync(
			PostLike postLike,
			UserId currentUserId,
			CancellationToken cancellationToken)
		{
			await serviceScope.AddPostLikeCacheAsync(postLike, currentUserId.Id, cancellationToken);
		}
	}
}
