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

		public async Task InitializeAddAsync(
			PostLike postLike,
			string currentUserId,
			CancellationToken cancellationToken)
		{
			var post = postLike.Post!;
			var users = new List<User> { postLike.User!, post.User! }.DistinctBy(p => p.Id).ToList();

			await serviceScope.AddRangeAsync(users, cancellationToken);
			await serviceScope.AddAsync(post, cancellationToken);
			await serviceScope.AddPostCacheAsync(post, currentUserId, cancellationToken);
		}

		public async Task InitializeAddAsync(
			PostLike postLike,
			UserId currentUserId,
			CancellationToken cancellationToken)
		{
			await serviceScope.InitializeAddAsync(postLike, currentUserId.Id, cancellationToken);
		}

		public async Task DisposeAddAsync(
			PostLike postLike,
			CancellationToken cancellationToken)
		{
			var post = postLike.Post!;
			var users = new List<User> { postLike.User!, post.User! }.DistinctBy(p => p.Id).ToList();

			await serviceScope.DeleteAsync(post, cancellationToken);

			foreach (var user in users)
			{
				await serviceScope.DeleteAsync(user, cancellationToken);
			}
		}

		public async Task InitializeDeleteAsync(
			PostLike postLike,
			string currentUserId,
			CancellationToken cancellationToken)
		{
			var post = postLike.Post!;
			var users = new List<User> { postLike.User!, post.User! }.DistinctBy(p => p.Id).ToList();

			await serviceScope.AddRangeAsync(users, cancellationToken);
			await serviceScope.AddAsync(post, cancellationToken);
			await serviceScope.AddAsync(postLike, cancellationToken);
			await serviceScope.AddPostCacheAsync(post, currentUserId, cancellationToken);
			await serviceScope.AddPostLikeCacheAsync(postLike, currentUserId, cancellationToken);
		}

		public async Task InitializeDeleteAsync(
			PostLike postLike,
			UserId currentUserId,
			CancellationToken cancellationToken)
		{
			await serviceScope.InitializeDeleteAsync(postLike, currentUserId.Id, cancellationToken);
		}

		public async Task DisposeDeleteAsync(
			PostLike postLike,
			CancellationToken cancellationToken)
		{
			var post = postLike.Post!;
			var users = new List<User> { postLike.User!, post.User! }.DistinctBy(p => p.Id).ToList();

			await serviceScope.DeleteAsync(postLike, cancellationToken);
			await serviceScope.DeleteAsync(post, cancellationToken);

			foreach (var user in users)
			{
				await serviceScope.DeleteAsync(user, cancellationToken);
			}
		}

		public async Task InitializeGetAllAsync(
			ICollection<PostLike> postLikes,
			CancellationToken cancellationToken)
		{
			var posts = postLikes.Select(p => p.Post!).DistinctBy(p => p.Id).ToList();
			var postImages = posts.SelectMany(p => p.PostImages).ToList();
			var postComments = posts.SelectMany(p => p.PostComments).ToList();
			var users = postLikes
				.Select(p => p.User!)
				.Concat(posts.Select(p => p.User!))
				.Concat(postComments.Select(p => p.User!))
				.DistinctBy(p => p.Id)
				.ToList();

			await serviceScope.AddRangeAsync(users, cancellationToken);
			await serviceScope.AddRangeAsync(posts, cancellationToken);
			await serviceScope.AddRangeAsync(postImages, cancellationToken);
			await serviceScope.AddRangeAsync(postComments, cancellationToken);
			await serviceScope.AddRangeAsync(postLikes, cancellationToken);
		}

		public async Task DisposeGetAllAsync(
			ICollection<PostLike> postLikes,
			CancellationToken cancellationToken)
		{
			var posts = postLikes.Select(p => p.Post!).DistinctBy(p => p.Id).ToList();
			var postImages = posts.SelectMany(p => p.PostImages).ToList();
			var postComments = posts.SelectMany(p => p.PostComments).ToList();
			var users = postLikes
				.Select(p => p.User!)
				.Concat(posts.Select(p => p.User!))
				.Concat(postComments.Select(p => p.User!))
				.DistinctBy(p => p.Id)
				.ToList();

			await serviceScope.DeleteRangeAsync(postLikes, cancellationToken);
			await serviceScope.DeleteRangeAsync(postComments, cancellationToken);
			await serviceScope.DeleteRangeAsync(postImages, cancellationToken);
			await serviceScope.DeleteRangeAsync(posts, cancellationToken);

			foreach (var user in users)
			{
				await serviceScope.DeleteAsync(user, cancellationToken);
			}
		}

		public async Task InitializeGetAllForUserAsync(
			ICollection<PostLike> postLikes,
			CancellationToken cancellationToken)
		{
			var posts = postLikes.Select(p => p.Post!).DistinctBy(p => p.Id).ToList();
			var postImages = posts.SelectMany(p => p.PostImages).ToList();
			var postComments = posts.SelectMany(p => p.PostComments).ToList();
			var users = postLikes
				.Select(p => p.User!)
				.Concat(posts.Select(p => p.User!))
				.Concat(postComments.Select(p => p.User!))
				.DistinctBy(p => p.Id)
				.ToList();

			await serviceScope.AddRangeAsync(users, cancellationToken);
			await serviceScope.AddRangeAsync(posts, cancellationToken);
			await serviceScope.AddRangeAsync(postImages, cancellationToken);
			await serviceScope.AddRangeAsync(postComments, cancellationToken);
			await serviceScope.AddRangeAsync(postLikes, cancellationToken);
		}

		public async Task DisposeGetAllForUserAsync(
			ICollection<PostLike> postLikes,
			CancellationToken cancellationToken)
		{
			var posts = postLikes.Select(p => p.Post!).DistinctBy(p => p.Id).ToList();
			var postImages = posts.SelectMany(p => p.PostImages).ToList();
			var postComments = posts.SelectMany(p => p.PostComments).ToList();
			var users = postLikes
				.Select(p => p.User!)
				.Concat(posts.Select(p => p.User!))
				.Concat(postComments.Select(p => p.User!))
				.DistinctBy(p => p.Id)
				.ToList();

			await serviceScope.DeleteRangeAsync(postLikes, cancellationToken);
			await serviceScope.DeleteRangeAsync(postComments, cancellationToken);
			await serviceScope.DeleteRangeAsync(postImages, cancellationToken);
			await serviceScope.DeleteRangeAsync(posts, cancellationToken);

			foreach (var user in users)
			{
				await serviceScope.DeleteAsync(user, cancellationToken);
			}
		}

		public async Task InitializeGetByIdAsync(
			PostLike postLike,
			CancellationToken cancellationToken)
		{
			var post = postLike.Post!;
			var postImages = post.PostImages;
			var postComments = post.PostComments;
			var users = postComments
				.Select(p => p.User!)
				.Prepend(post.User!)
				.Prepend(postLike.User!)
				.DistinctBy(p => p.Id)
				.ToList();

			await serviceScope.AddRangeAsync(users, cancellationToken);
			await serviceScope.AddAsync(post, cancellationToken);
			await serviceScope.AddRangeAsync(postImages, cancellationToken);
			await serviceScope.AddRangeAsync(postComments, cancellationToken);
			await serviceScope.AddAsync(postLike, cancellationToken);
		}

		public async Task DisposeGetByIdAsync(
			PostLike postLike,
			CancellationToken cancellationToken)
		{
			var post = postLike.Post!;
			var postImages = post.PostImages;
			var postComments = post.PostComments;
			var users = postComments
				.Select(p => p.User!)
				.Prepend(post.User!)
				.Prepend(postLike.User!)
				.DistinctBy(p => p.Id)
				.ToList();

			await serviceScope.DeleteAsync(postLike, cancellationToken);
			await serviceScope.DeleteRangeAsync(postComments, cancellationToken);
			await serviceScope.DeleteRangeAsync(postImages, cancellationToken);
			await serviceScope.DeleteAsync(post, cancellationToken);

			foreach (var user in users)
			{
				await serviceScope.DeleteAsync(user, cancellationToken);
			}
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
