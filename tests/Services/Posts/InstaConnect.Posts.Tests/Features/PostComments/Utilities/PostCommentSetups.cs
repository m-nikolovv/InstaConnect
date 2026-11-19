using InstaConnect.Posts.Domain.Features.PostComments.Abstractions;
using InstaConnect.Posts.Infrastructure.Features.PostComments.Abstractions;
using InstaConnect.Posts.Infrastructure.Features.PostComments.Helpers.Repositories;

namespace InstaConnect.Posts.Tests.Features.PostComments.Utilities;

public static class PostCommentSetups
{
	extension(IServiceProvider serviceProvider)
	{
		public IPostCommentQueryRepository GetPostCommentQueryRepository()
		{
			return new PostCommentQueryRepository(
				serviceProvider.GetPostCommentCollection(),
				serviceProvider.GetPostIncludeBuilderFactory(),
				serviceProvider.GetPostCommentIncludeBuilderFactory());
		}

		public IPostCommentQueryRepository GetCachedPostCommentQueryRepository()
		{
			return serviceProvider.GetRequiredService<IPostCommentQueryRepository>();
		}

		public IPostCommentCommandRepository GetPostCommentCommandRepository()
		{
			return new PostCommentCommandRepository(
				serviceProvider.GetPostCommentCollection(),
				serviceProvider.GetPostCommentIncludeBuilderFactory());
		}

		public IPostCommentCommandRepository GetCachedPostCommentCommandRepository()
		{
			return serviceProvider.GetRequiredService<IPostCommentCommandRepository>();
		}

		public IPostCommentIncludeBuilderFactory GetPostCommentIncludeBuilderFactory()
		{
			return serviceProvider.GetRequiredService<IPostCommentIncludeBuilderFactory>();
		}

		public IPostCommentCollection GetPostCommentCollection()
		{
			return serviceProvider.GetRequiredService<IPostCommentCollection>();
		}

		public IPostCommentCacheHandler GetPostCommentCacheHandler()
		{
			return serviceProvider.GetRequiredService<IPostCommentCacheHandler>();
		}
	}

	extension(IServiceScope serviceScope)
	{
		public IPostCommentQueryRepository GetPostCommentQueryRepository()
		{
			return serviceScope.ServiceProvider.GetPostCommentQueryRepository();
		}

		public IPostCommentQueryRepository GetCachedPostCommentQueryRepository()
		{
			return serviceScope.ServiceProvider.GetCachedPostCommentQueryRepository();
		}

		public IPostCommentCommandRepository GetPostCommentCommandRepository()
		{
			return serviceScope.ServiceProvider.GetPostCommentCommandRepository();
		}

		public IPostCommentCommandRepository GetCachedPostCommentCommandRepository()
		{
			return serviceScope.ServiceProvider.GetCachedPostCommentCommandRepository();
		}

		public IPostCommentIncludeBuilderFactory GetPostCommentIncludeBuilderFactory()
		{
			return serviceScope.ServiceProvider.GetPostCommentIncludeBuilderFactory();
		}

		public IPostCommentCacheHandler GetPostCommentCacheHandler()
		{
			return serviceScope.ServiceProvider.GetPostCommentCacheHandler();
		}

		public async Task<PostComment?> GetByIdAsync(
			PostCommentId id,
			CancellationToken cancellationToken)
		{
			var include = serviceScope.GetPostIncludeBuilderFactory().Create().WithUser().Build();
			var commentInclude = serviceScope.GetPostCommentIncludeBuilderFactory().Create().WithUser().WithPost(include).WithPostCommentImages().Build();

			return (await serviceScope.GetPostCommentCommandRepository().GetByIdAsync(id, commentInclude, cancellationToken)).SetUser().SetPost().SetPostCommentImages();
		}

		public async Task<ICollection<PostComment>> GetByIdRangeAsync(
			IEnumerable<PostCommentId> ids,
			CancellationToken cancellationToken)
		{
			var include = serviceScope.GetPostIncludeBuilderFactory().Create().WithUser().Build();
			var commentInclude = serviceScope.GetPostCommentIncludeBuilderFactory().Create().WithUser().WithPost(include).WithPostCommentImages().Build();

			return (await serviceScope.GetPostCommentCommandRepository().GetByIdRangeAsync(ids, commentInclude, cancellationToken)).SetUser().SetPost();
		}

		public async Task AddAsync(
			PostComment postComment,
			UserId currentUserId,
			CancellationToken cancellationToken)
		{
			var commentCacheHandler = serviceScope.GetPostCommentCacheHandler();
			var postCommentRepository = serviceScope.GetPostCommentCommandRepository();

			await postCommentRepository.AddAsync(postComment, cancellationToken);
			await commentCacheHandler.AddAsync(postComment.ToFullResponse(currentUserId), currentUserId, cancellationToken);
		}

		public async Task AddRangeAsync(
			ICollection<PostComment> postComments,
			UserId currentUserId,
			CancellationToken cancellationToken)
		{
			var commentCacheHandler = serviceScope.GetPostCommentCacheHandler();
			var postCommentRepository = serviceScope.GetPostCommentCommandRepository();

			await postCommentRepository.AddRangeAsync(postComments, cancellationToken);
			await commentCacheHandler.AddRangeAsync(postComments.ToFullResponse(currentUserId), currentUserId, cancellationToken);
		}

		public async Task DeleteAsync(
			PostComment postComment,
			CancellationToken cancellationToken)
		{
			var cacheHandler = serviceScope.GetPostCacheHandler();
			var commentCacheHandler = serviceScope.GetPostCommentCacheHandler();
			var postCommentRepository = serviceScope.GetPostCommentCommandRepository();

			await postCommentRepository.DeleteAsync(postComment, cancellationToken);
			await cacheHandler.DeleteResponseAsync(postComment.Id.Id, cancellationToken);
			await commentCacheHandler.DeleteAsync(postComment.Id, cancellationToken);
		}

		public async Task DeleteRangeAsync(
			IEnumerable<PostComment> postComments,
			CancellationToken cancellationToken)
		{
			foreach (var postComment in postComments)
			{
				await serviceScope.DeleteAsync(postComment, cancellationToken);
			}
		}
	}
}
