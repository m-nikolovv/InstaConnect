using InstaConnect.Posts.Domain.Features.PostCommentLikes.Abstractions;
using InstaConnect.Posts.Domain.Features.PostCommentLikes.Models.Responses;
using InstaConnect.Posts.Infrastructure.Features.PostCommentLikes.Abstractions;

namespace InstaConnect.Posts.Tests.Features.PostCommentLikes.Utilities;

public static class PostCommentLikeSetups
{
	extension(IServiceProvider serviceProvider)
	{
		public IPostCommentLikeQueryRepository GetPostCommentLikeQueryRepository()
		{
			return serviceProvider.GetRequiredService<IPostCommentLikeQueryRepository>();
		}

		public IPostCommentLikeCommandRepository GetPostCommentLikeCommandRepository()
		{
			return serviceProvider.GetRequiredService<IPostCommentLikeCommandRepository>();
		}

		public IPostCommentLikeIncludeBuilderFactory GetPostCommentLikeIncludeBuilderFactory()
		{
			return serviceProvider.GetRequiredService<IPostCommentLikeIncludeBuilderFactory>();
		}

		public IPostCommentLikeCollection GetPostCommentLikeCollection()
		{
			return serviceProvider.GetRequiredService<IPostCommentLikeCollection>();
		}

		public IPostCommentLikeCacheHandler GetPostCommentLikeCacheHandler()
		{
			return serviceProvider.GetRequiredService<IPostCommentLikeCacheHandler>();
		}
	}

	extension(IServiceScope serviceScope)
	{
		public IPostCommentLikeQueryRepository GetPostCommentLikeQueryRepository()
		{
			return serviceScope.ServiceProvider.GetPostCommentLikeQueryRepository();
		}

		public IPostCommentLikeCommandRepository GetPostCommentLikeCommandRepository()
		{
			return serviceScope.ServiceProvider.GetPostCommentLikeCommandRepository();
		}

		public IPostCommentLikeIncludeBuilderFactory GetPostCommentLikeIncludeBuilderFactory()
		{
			return serviceScope.ServiceProvider.GetPostCommentLikeIncludeBuilderFactory();
		}

		public IPostCommentLikeCacheHandler GetPostCommentLikeCacheHandler()
		{
			return serviceScope.ServiceProvider.GetPostCommentLikeCacheHandler();
		}

		public async Task<PostCommentLike?> GetByIdAsync(
			PostCommentLikeId id,
			CancellationToken cancellationToken)
		{
			var include = serviceScope.GetPostIncludeBuilderFactory().Create().WithUser().Build();
			var commentInclude = serviceScope.GetPostCommentIncludeBuilderFactory().Create().WithUser().WithPost(include).Build();
			var commentLikeInclude = serviceScope.GetPostCommentLikeIncludeBuilderFactory().Create().WithPostComment(commentInclude).WithUser().Build();

			return (await serviceScope.GetPostCommentLikeCommandRepository().GetByIdAsync(id, commentLikeInclude, cancellationToken)).SetUser().SetPostComment();
		}

		public async Task<ICollection<PostCommentLike>> GetByIdRangeAsync(
			IEnumerable<PostCommentLikeId> ids,
			CancellationToken cancellationToken)
		{
			var include = serviceScope.GetPostIncludeBuilderFactory().Create().WithUser().Build();
			var commentInclude = serviceScope.GetPostCommentIncludeBuilderFactory().Create().WithUser().WithPost(include).Build();
			var commentLikeInclude = serviceScope.GetPostCommentLikeIncludeBuilderFactory().Create().WithPostComment(commentInclude).WithUser().Build();

			return (await serviceScope.GetPostCommentLikeCommandRepository().GetByIdRangeAsync(ids, commentLikeInclude, cancellationToken)).SetUser().SetPostComment();
		}

		public async Task AddAsync(
			PostCommentLike postCommentLike,
			CancellationToken cancellationToken)
		{
			var postCommentLikeRepository = serviceScope.GetPostCommentLikeCommandRepository();

			await postCommentLikeRepository.AddAsync(postCommentLike, cancellationToken);
		}

		public async Task AddRangeAsync(
			ICollection<PostCommentLike> postCommentLikes,
			CancellationToken cancellationToken)
		{
			var postCommentLikeRepository = serviceScope.GetPostCommentLikeCommandRepository();

			await postCommentLikeRepository.AddRangeAsync(postCommentLikes, cancellationToken);
		}

		public async Task DeleteAsync(
			PostCommentLike postCommentLike,
			CancellationToken cancellationToken)
		{
			var commentCacheHandler = serviceScope.GetPostCommentCacheHandler();
			var commentLikeCacheHandler = serviceScope.GetPostCommentLikeCacheHandler();
			var postCommentLikeRepository = serviceScope.GetPostCommentLikeCommandRepository();

			await postCommentLikeRepository.DeleteAsync(postCommentLike, cancellationToken);
			await commentCacheHandler.DeleteResponseAsync(postCommentLike.Id.CommentId, cancellationToken);
			await commentLikeCacheHandler.DeleteAsync(postCommentLike.Id, cancellationToken);
		}

		public async Task DeleteRangeAsync(
			IEnumerable<PostCommentLike> postCommentLikes,
			CancellationToken cancellationToken)
		{
			foreach (var postCommentLike in postCommentLikes)
			{
				await serviceScope.DeleteAsync(postCommentLike, cancellationToken);
			}
		}

		public async Task<PostCommentLikeResponse?> GetPostCommentLikeCacheByIdAsync(
			string id,
			string commentId,
			string userId,
			string currentUserId,
			CancellationToken cancellationToken)
		{
			var cacheHandler = serviceScope.GetPostCommentLikeCacheHandler();

			return await cacheHandler.GetByIdAsync(new(new(new(id), commentId), new(userId)), new(currentUserId), cancellationToken);
		}

		public async Task<PostCommentLikeResponse?> GetPostCommentLikeCacheByIdAsync(
			PostCommentLikeId id,
			UserId currentUserId,
			CancellationToken cancellationToken)
		{
			var cacheHandler = serviceScope.GetPostCommentLikeCacheHandler();

			return await cacheHandler.GetByIdAsync(id, currentUserId, cancellationToken);
		}

		public async Task SetupAddPostCommentLikeAsync(
			User user,
			Post post,
			PostComment postComment,
			string currentUserId,
			CancellationToken cancellationToken)
		{
			await serviceScope.AddAsync(user, cancellationToken);
			await serviceScope.AddAsync(post, cancellationToken);
			await serviceScope.AddAsync(postComment, cancellationToken);
			await serviceScope.AddPostCommentCacheAsync(postComment, currentUserId, cancellationToken);
		}

		public async Task SetupAddPostCommentLikeAsync(
			User user,
			Post post,
			PostComment postComment,
			UserId currentUserId,
			CancellationToken cancellationToken)
		{
			await serviceScope.SetupAddPostCommentLikeAsync(user, post, postComment, currentUserId.Id, cancellationToken);
		}

		public async Task SetupDeletePostCommentLikeAsync(
			User user,
			Post post,
			PostComment postComment,
			PostCommentLike postCommentLike,
			string currentUserId,
			CancellationToken cancellationToken)
		{
			await serviceScope.AddAsync(user, cancellationToken);
			await serviceScope.AddAsync(post, cancellationToken);
			await serviceScope.AddAsync(postComment, cancellationToken);
			await serviceScope.AddAsync(postCommentLike, cancellationToken);
			await serviceScope.AddPostCommentCacheAsync(postComment, currentUserId, cancellationToken);
			await serviceScope.AddPostCommentLikeCacheAsync(postCommentLike, currentUserId, cancellationToken);
		}

		public async Task SetupDeletePostCommentLikeAsync(
			User user,
			Post post,
			PostComment postComment,
			PostCommentLike postCommentLike,
			UserId currentUserId,
			CancellationToken cancellationToken)
		{
			await serviceScope.SetupDeletePostCommentLikeAsync(user, post, postComment, postCommentLike, currentUserId.Id, cancellationToken);
		}

		public async Task SetupGetAllPostCommentLikesAsync(
			ICollection<User> users,
			ICollection<Post> posts,
			ICollection<PostLike> postLikes,
			ICollection<PostImage> postImages,
			ICollection<PostComment> postComments,
			ICollection<PostCommentLike> postCommentLikes,
			ICollection<PostCommentImage> postCommentImages,
			CancellationToken cancellationToken)
		{
			await serviceScope.AddRangeAsync(users, cancellationToken);
			await serviceScope.AddRangeAsync(posts, cancellationToken);
			await serviceScope.AddRangeAsync(postLikes, cancellationToken);
			await serviceScope.AddRangeAsync(postImages, cancellationToken);
			await serviceScope.AddRangeAsync(postComments, cancellationToken);
			await serviceScope.AddRangeAsync(postCommentLikes, cancellationToken);
			await serviceScope.AddRangeAsync(postCommentImages, cancellationToken);
		}

		public async Task SetupGetAllPostCommentLikesForUserAsync(
			ICollection<User> users,
			ICollection<Post> posts,
			ICollection<PostLike> postLikes,
			ICollection<PostImage> postImages,
			ICollection<PostComment> postComments,
			ICollection<PostCommentLike> postCommentLikes,
			ICollection<PostCommentImage> postCommentImages,
			CancellationToken cancellationToken)
		{
			await serviceScope.AddRangeAsync(users, cancellationToken);
			await serviceScope.AddRangeAsync(posts, cancellationToken);
			await serviceScope.AddRangeAsync(postLikes, cancellationToken);
			await serviceScope.AddRangeAsync(postImages, cancellationToken);
			await serviceScope.AddRangeAsync(postComments, cancellationToken);
			await serviceScope.AddRangeAsync(postCommentLikes, cancellationToken);
			await serviceScope.AddRangeAsync(postCommentImages, cancellationToken);
		}

		public async Task SetupGetPostCommentLikeByIdAsync(
			User user,
			Post post,
			PostComment postComment,
			PostCommentLike postCommentLike,
			ICollection<PostCommentImage> postCommentImages,
			CancellationToken cancellationToken)
		{
			await serviceScope.AddAsync(user, cancellationToken);
			await serviceScope.AddAsync(post, cancellationToken);
			await serviceScope.AddAsync(postComment, cancellationToken);
			await serviceScope.AddAsync(postCommentLike, cancellationToken);
			await serviceScope.AddRangeAsync(postCommentImages, cancellationToken);
		}

		public async Task AddPostCommentLikeCacheAsync(
			PostCommentLike postCommentLike,
			string currentUserId,
			CancellationToken cancellationToken)
		{
			var cacheHandler = serviceScope.GetPostCommentLikeCacheHandler();

			await cacheHandler.AddAsync(postCommentLike.ToFullResponse(currentUserId), new(currentUserId), cancellationToken);
		}

		public async Task AddPostCommentLikeCacheAsync(
			PostCommentLike postCommentLike,
			UserId currentUserId,
			CancellationToken cancellationToken)
		{
			await serviceScope.AddPostCommentLikeCacheAsync(postCommentLike, currentUserId.Id, cancellationToken);
		}
	}
}
