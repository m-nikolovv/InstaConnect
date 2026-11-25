using InstaConnect.Posts.Domain.Features.PostComments.Abstractions;
using InstaConnect.Posts.Domain.Features.PostComments.Models.Responses;
using InstaConnect.Posts.Infrastructure.Features.PostComments.Abstractions;

namespace InstaConnect.Posts.Tests.Features.PostComments.Utilities;

public static class PostCommentSetups
{
	extension(IServiceProvider serviceProvider)
	{
		public IPostCommentQueryRepository GetPostCommentQueryRepository()
		{
			return serviceProvider.GetRequiredService<IPostCommentQueryRepository>();
		}

		public IPostCommentCommandRepository GetPostCommentCommandRepository()
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

		public IPostCommentCommandRepository GetPostCommentCommandRepository()
		{
			return serviceScope.ServiceProvider.GetPostCommentCommandRepository();
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
			CancellationToken cancellationToken)
		{
			var postCommentRepository = serviceScope.GetPostCommentCommandRepository();

			await postCommentRepository.AddAsync(postComment, cancellationToken);
		}

		public async Task AddRangeAsync(
			ICollection<PostComment> postComments,
			CancellationToken cancellationToken)
		{
			var postCommentRepository = serviceScope.GetPostCommentCommandRepository();

			await postCommentRepository.AddRangeAsync(postComments, cancellationToken);
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

	extension(IPostCommentCacheHandler cacheHandler)
	{
		public async Task<PostCommentResponse?> GetByIdAsync(
			string id,
			string commentId,
			string currentUserId,
			CancellationToken cancellationToken)
		{
			return await cacheHandler.GetByIdAsync(new(new(id), commentId), new(currentUserId), cancellationToken);
		}

		public async Task<PostCommentResponse?> GetByIdAsync(
			PostComment postComment,
			string currentUserId,
			CancellationToken cancellationToken)
		{
			return await cacheHandler.GetByIdAsync(postComment.Id.Id.Id, postComment.Id.CommentId, currentUserId, cancellationToken);
		}

		public async Task<PostCommentResponse?> GetByIdAsync(
			PostComment postComment,
			UserId currentUserId,
			CancellationToken cancellationToken)
		{
			return await cacheHandler.GetByIdAsync(postComment, currentUserId.Id, cancellationToken);
		}

		public async Task AddAsync(
			PostCommentResponse response,
			string currentUserId,
			CancellationToken cancellationToken)
		{
			await cacheHandler.AddAsync(response, new(currentUserId), cancellationToken);
		}

		public async Task AddAsync(
			PostComment postComment,
			string currentUserId,
			CancellationToken cancellationToken)
		{
			await cacheHandler.AddAsync(postComment.ToFullResponse(currentUserId), currentUserId, cancellationToken);
		}

		public async Task AddAsync(
			PostComment postComment,
			UserId currentUserId,
			CancellationToken cancellationToken)
		{
			await cacheHandler.AddAsync(postComment, currentUserId.Id, cancellationToken);
		}
	}
}
