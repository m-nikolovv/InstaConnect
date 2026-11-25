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
			UserId currentUserId,
			CancellationToken cancellationToken)
		{
			var commentLikeCacheHandler = serviceScope.GetPostCommentLikeCacheHandler();
			var postCommentLikeRepository = serviceScope.GetPostCommentLikeCommandRepository();

			await postCommentLikeRepository.AddAsync(postCommentLike, cancellationToken);
			await commentLikeCacheHandler.AddAsync(postCommentLike.ToFullResponse(currentUserId), currentUserId, cancellationToken);
		}

		public async Task AddRangeAsync(
			ICollection<PostCommentLike> postCommentLikes,
			UserId currentUserId,
			CancellationToken cancellationToken)
		{
			var commentLikeCacheHandler = serviceScope.GetPostCommentLikeCacheHandler();
			var postCommentLikeRepository = serviceScope.GetPostCommentLikeCommandRepository();

			await postCommentLikeRepository.AddRangeAsync(postCommentLikes, cancellationToken);
			await commentLikeCacheHandler.AddRangeAsync(postCommentLikes.ToFullResponse(currentUserId), currentUserId, cancellationToken);
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
	}

	extension(IPostCommentLikeCacheHandler cacheHandler)
	{
		public async Task<PostCommentLikeResponse?> GetByIdAsync(
			string id,
			string commentId,
			string userId,
			string currentUserId,
			CancellationToken cancellationToken)
		{
			return await cacheHandler.GetByIdAsync(new(new(new(id), commentId), new(userId)), new(currentUserId), cancellationToken);
		}
	}
}
