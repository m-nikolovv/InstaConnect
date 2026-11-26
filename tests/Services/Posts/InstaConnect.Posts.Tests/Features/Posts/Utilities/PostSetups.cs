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

		public async Task<PostResponse?> GetPostCacheByIdAsync(
			string id,
			string currentUserId,
			CancellationToken cancellationToken)
		{
			var cacheHandler = serviceScope.GetPostCacheHandler();

			return await cacheHandler.GetByIdAsync(new(id), new(currentUserId), cancellationToken);
		}

		public async Task<PostResponse?> GetPostCacheByIdAsync(
			PostId id,
			string currentUserId,
			CancellationToken cancellationToken)
		{
			return await serviceScope.GetPostCacheByIdAsync(id.Id, currentUserId, cancellationToken);
		}

		public async Task<PostResponse?> GetPostCacheByIdAsync(
			PostId id,
			UserId currentUserId,
			CancellationToken cancellationToken)
		{
			return await serviceScope.GetPostCacheByIdAsync(id, currentUserId.Id, cancellationToken);
		}

		public async Task<PostResponse?> GetPostCacheByIdAsync(
			Post post,
			string currentUserId,
			CancellationToken cancellationToken)
		{
			return await serviceScope.GetPostCacheByIdAsync(post.Id, currentUserId, cancellationToken);
		}

		public async Task<PostResponse?> GetPostCacheByIdAsync(
			Post post,
			UserId currentUserId,
			CancellationToken cancellationToken)
		{
			return await serviceScope.GetPostCacheByIdAsync(post, currentUserId.Id, cancellationToken);
		}

		public async Task AddPostCacheAsync(
			Post post,
			string currentUserId,
			CancellationToken cancellationToken)
		{
			var cacheHandler = serviceScope.GetPostCacheHandler();

			await cacheHandler.AddAsync(post.ToFullResponse(currentUserId), new(currentUserId), cancellationToken);
		}

		public async Task AddPostCacheAsync(
			Post post,
			UserId currentUserId,
			CancellationToken cancellationToken)
		{
			await serviceScope.AddPostCacheAsync(post, currentUserId.Id, cancellationToken);
		}

		public async Task AddPostCacheRangeAsync(
			ICollection<Post> posts,
			string currentUserId,
			CancellationToken cancellationToken)
		{
			var cacheHandler = serviceScope.GetPostCacheHandler();
			var responses = posts.ToFullResponse(currentUserId);

			await cacheHandler.AddRangeAsync(responses, new(currentUserId), cancellationToken);
		}

		public async Task AddPostCacheRangeAsync(
			ICollection<Post> posts,
			UserId currentUserId,
			CancellationToken cancellationToken)
		{
			await serviceScope.AddPostCacheRangeAsync(posts, currentUserId.Id, cancellationToken);
		}

		public async Task DeletePostCacheAsync(
			Post post,
			CancellationToken cancellationToken)
		{
			var cacheHandler = serviceScope.GetPostCacheHandler();

			await cacheHandler.DeleteAsync(post.Id, cancellationToken);
		}

		public async Task DeletePostCacheRangeAsync(
			IEnumerable<Post> posts,
			CancellationToken cancellationToken)
		{
			var cacheHandler = serviceScope.GetPostCacheHandler();

			await cacheHandler.DeleteRangeAsync(posts.Select(p => p.Id), cancellationToken);
		}

		public async Task SetupAddAsync(
			Post post,
			CancellationToken cancellationToken)
		{
			var user = post.User!;

			await serviceScope.AddAsync(user, cancellationToken);
		}

		public async Task SetupUpdateAsync(
			Post post,
			string currentUserId,
			CancellationToken cancellationToken)
		{
			var user = post.User!;
			var postImages = post.PostImages;

			await serviceScope.AddAsync(user, cancellationToken);
			await serviceScope.AddAsync(post, cancellationToken);
			await serviceScope.AddRangeAsync(postImages, cancellationToken);
			await serviceScope.AddPostCacheAsync(post, currentUserId, cancellationToken);
		}

		public async Task SetupUpdateAsync(
			Post post,
			UserId currentUserId,
			CancellationToken cancellationToken)
		{
			await serviceScope.SetupUpdateAsync(post, currentUserId.Id, cancellationToken);
		}

		public async Task SetupDeleteAsync(
			Post post,
			string currentUserId,
			CancellationToken cancellationToken)
		{
			var postLikes = post.PostLikes;
			var postImages = post.PostImages;
			var postComments = post.PostComments;
			var postCommentLikes = postComments.SelectMany(p => p.PostCommentLikes).ToList();
			var postCommentImages = postComments.SelectMany(p => p.PostCommentImages).ToList();
			var users = postLikes
				.Select(p => p.User!)
				.Concat(postComments.Select(p => p.User!))
				.Concat(postCommentLikes.Select(p => p.User!))
				.Prepend(post.User!)
				.DistinctBy(p => p.Id)
				.ToList();

			await serviceScope.AddRangeAsync(users, cancellationToken);
			await serviceScope.AddAsync(post, cancellationToken);
			await serviceScope.AddRangeAsync(postImages, cancellationToken);
			await serviceScope.AddRangeAsync(postLikes, cancellationToken);
			await serviceScope.AddRangeAsync(postComments, cancellationToken);
			await serviceScope.AddRangeAsync(postCommentImages, cancellationToken);
			await serviceScope.AddRangeAsync(postCommentLikes, cancellationToken);
			await serviceScope.AddPostCacheAsync(post, currentUserId, cancellationToken);
		}

		public async Task SetupDeleteAsync(
			Post post,
			UserId currentUserId,
			CancellationToken cancellationToken)
		{
			await serviceScope.SetupDeleteAsync(post, currentUserId.Id, cancellationToken);
		}

		public async Task SetupGetByIdAsync(
			Post post,
			CancellationToken cancellationToken)
		{
			var postLikes = post.PostLikes;
			var postImages = post.PostImages;
			var postComments = post.PostComments;
			var postCommentLikes = postComments.SelectMany(p => p.PostCommentLikes).ToList();
			var postCommentImages = postComments.SelectMany(p => p.PostCommentImages).ToList();
			var users = postLikes
				.Select(p => p.User!)
				.Concat(postComments.Select(p => p.User!))
				.Concat(postCommentLikes.Select(p => p.User!))
				.Prepend(post.User!)
				.DistinctBy(p => p.Id)
				.ToList();

			await serviceScope.AddRangeAsync(users, cancellationToken);
			await serviceScope.AddAsync(post, cancellationToken);
			await serviceScope.AddRangeAsync(postImages, cancellationToken);
			await serviceScope.AddRangeAsync(postLikes, cancellationToken);
			await serviceScope.AddRangeAsync(postComments, cancellationToken);
			await serviceScope.AddRangeAsync(postCommentImages, cancellationToken);
			await serviceScope.AddRangeAsync(postCommentLikes, cancellationToken);
		}

		public async Task SetupGetAllAsync(
			ICollection<Post> posts,
			CancellationToken cancellationToken)
		{
			var postLikes = posts.SelectMany(p => p.PostLikes).ToList();
			var postImages = posts.SelectMany(p => p.PostImages).ToList();
			var postComments = posts.SelectMany(p => p.PostComments).ToList();
			var postCommentLikes = postComments.SelectMany(p => p.PostCommentLikes).ToList();
			var postCommentImages = postComments.SelectMany(p => p.PostCommentImages).ToList();
			var users = posts
				.Select(p => p.User!)
				.Concat(postLikes.Select(p => p.User!))
				.Concat(postComments.Select(p => p.User!))
				.Concat(postCommentLikes.Select(p => p.User!))
				.DistinctBy(p => p.Id)
				.ToList();

			await serviceScope.AddRangeAsync(users, cancellationToken);
			await serviceScope.AddRangeAsync(posts, cancellationToken);
			await serviceScope.AddRangeAsync(postImages, cancellationToken);
			await serviceScope.AddRangeAsync(postLikes, cancellationToken);
			await serviceScope.AddRangeAsync(postComments, cancellationToken);
			await serviceScope.AddRangeAsync(postCommentImages, cancellationToken);
			await serviceScope.AddRangeAsync(postCommentLikes, cancellationToken);
		}

		public async Task SetupGetAllForUserAsync(
			ICollection<Post> posts,
			CancellationToken cancellationToken)
		{
			var postLikes = posts.SelectMany(p => p.PostLikes).ToList();
			var postImages = posts.SelectMany(p => p.PostImages).ToList();
			var postComments = posts.SelectMany(p => p.PostComments).ToList();
			var postCommentLikes = postComments.SelectMany(p => p.PostCommentLikes).ToList();
			var postCommentImages = postComments.SelectMany(p => p.PostCommentImages).ToList();
			var users = posts
				.Select(p => p.User!)
				.Concat(postLikes.Select(p => p.User!))
				.Concat(postComments.Select(p => p.User!))
				.Concat(postCommentLikes.Select(p => p.User!))
				.DistinctBy(p => p.Id)
				.ToList();

			await serviceScope.AddRangeAsync(users, cancellationToken);
			await serviceScope.AddRangeAsync(posts, cancellationToken);
			await serviceScope.AddRangeAsync(postImages, cancellationToken);
			await serviceScope.AddRangeAsync(postLikes, cancellationToken);
			await serviceScope.AddRangeAsync(postComments, cancellationToken);
			await serviceScope.AddRangeAsync(postCommentImages, cancellationToken);
			await serviceScope.AddRangeAsync(postCommentLikes, cancellationToken);
		}






		public async Task DeleteAsync(
			Post post,
			CancellationToken cancellationToken)
		{
			var postRepository = serviceScope.GetPostCommandRepository();

			await postRepository.DeleteAsync(post, cancellationToken);
			await serviceScope.DeletePostCacheAsync(post, cancellationToken);
		}

		public async Task DeleteRangeAsync(
			IEnumerable<Post> posts,
			CancellationToken cancellationToken)
		{
			var postRepository = serviceScope.GetPostCommandRepository();

			await postRepository.DeleteRangeAsync(posts, cancellationToken);
			await serviceScope.DeletePostCacheRangeAsync(posts, cancellationToken);
		}
	}
}
