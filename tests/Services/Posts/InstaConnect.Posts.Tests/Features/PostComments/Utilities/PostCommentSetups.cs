using InstaConnect.Posts.Domain.Features.PostComments.Abstractions;
using InstaConnect.Posts.Domain.Features.PostComments.Models.Responses;
using InstaConnect.Posts.Domain.Features.Posts.Models.Responses;
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

		public async Task<PostResponse?> GetPostCacheByIdAsync(
			PostComment postComment,
			string currentUserId,
			CancellationToken cancellationToken)
		{
			return await serviceScope.GetPostCacheByIdAsync(postComment.Id.Id.Id, currentUserId, cancellationToken);
		}

		public async Task<PostResponse?> GetPostCacheByIdAsync(
			PostComment postComment,
			UserId currentUserId,
			CancellationToken cancellationToken)
		{
			return await serviceScope.GetPostCacheByIdAsync(postComment, currentUserId.Id, cancellationToken);
		}

		public async Task<PostCommentResponse?> GetPostCommentCacheByIdAsync(
			string id,
			string commentId,
			string currentUserId,
			CancellationToken cancellationToken)
		{
			var commentCacheHandler = serviceScope.GetPostCommentCacheHandler();

			return await commentCacheHandler.GetByIdAsync(new(new(id), commentId), new(currentUserId), cancellationToken);
		}

		public async Task<PostCommentResponse?> GetPostCommentCacheByIdAsync(
			PostCommentId id,
			string currentUserId,
			CancellationToken cancellationToken)
		{
			return await serviceScope.GetPostCommentCacheByIdAsync(id.Id.Id, id.CommentId, currentUserId, cancellationToken);
		}

		public async Task<PostCommentResponse?> GetPostCommentCacheByIdAsync(
			PostCommentId id,
			UserId currentUserId,
			CancellationToken cancellationToken)
		{
			return await serviceScope.GetPostCommentCacheByIdAsync(id, currentUserId.Id, cancellationToken);
		}

		public async Task<PostCommentResponse?> GetPostCommentCacheByIdAsync(
			PostComment postComment,
			string currentUserId,
			CancellationToken cancellationToken)
		{
			return await serviceScope.GetPostCommentCacheByIdAsync(postComment.Id, currentUserId, cancellationToken);
		}

		public async Task<PostCommentResponse?> GetPostCommentCacheByIdAsync(
			PostComment postComment,
			UserId currentUserId,
			CancellationToken cancellationToken)
		{
			return await serviceScope.GetPostCommentCacheByIdAsync(postComment, currentUserId.Id, cancellationToken);
		}

		public async Task AddPostCommentCacheAsync(
			PostComment postComment,
			string currentUserId,
			CancellationToken cancellationToken)
		{
			var commentCacheHandler = serviceScope.GetPostCommentCacheHandler();

			await commentCacheHandler.AddAsync(postComment.ToFullResponse(currentUserId), new(currentUserId), cancellationToken);
		}

		public async Task AddPostCommentCacheAsync(
			PostComment postComment,
			UserId currentUserId,
			CancellationToken cancellationToken)
		{
			await serviceScope.AddPostCommentCacheAsync(postComment, currentUserId.Id, cancellationToken);
		}

		public async Task AddPostCommentCacheRangeAsync(
			ICollection<PostComment> postComments,
			string currentUserId,
			CancellationToken cancellationToken)
		{
			var commentCacheHandler = serviceScope.GetPostCommentCacheHandler();
			var responses = postComments.ToFullResponse(currentUserId);

			await commentCacheHandler.AddRangeAsync(responses, new(currentUserId), cancellationToken);
		}

		public async Task AddPostCommentCacheRangeAsync(
			ICollection<PostComment> postComments,
			UserId currentUserId,
			CancellationToken cancellationToken)
		{
			await serviceScope.AddPostCommentCacheRangeAsync(postComments, currentUserId.Id, cancellationToken);
		}

		public async Task DeletePostCommentCacheAsync(
			PostComment postComment,
			CancellationToken cancellationToken)
		{
			var cacheHandler = serviceScope.GetPostCacheHandler();
			var commentCacheHandler = serviceScope.GetPostCommentCacheHandler();

			await cacheHandler.DeleteResponseAsync(postComment.Id.Id, cancellationToken);
			await commentCacheHandler.DeleteAsync(postComment.Id, cancellationToken);
		}

		public async Task DeletePostCommentCacheRangeAsync(
			IEnumerable<PostComment> postComments,
			CancellationToken cancellationToken)
		{
			var cacheHandler = serviceScope.GetPostCacheHandler();
			var commentCacheHandler = serviceScope.GetPostCommentCacheHandler();

			await cacheHandler.DeleteResponseRangeAsync(postComments.Select(p => p.Id.Id), cancellationToken);
			await commentCacheHandler.DeleteRangeAsync(postComments.Select(p => p.Id), cancellationToken);
		}

		public async Task SetupAddPostCommentAsync(
			User user,
			Post post,
			string currentUserId,
			CancellationToken cancellationToken)
		{
			await serviceScope.AddAsync(user, cancellationToken);
			await serviceScope.AddAsync(post, cancellationToken);
			await serviceScope.AddPostCacheAsync(post, currentUserId, cancellationToken);
		}

		public async Task SetupAddPostCommentAsync(
			User user,
			Post post,
			UserId currentUserId,
			CancellationToken cancellationToken)
		{
			await serviceScope.SetupAddPostCommentAsync(user, post, currentUserId.Id, cancellationToken);
		}

		public async Task SetupUpdatePostCommentAsync(
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

		public async Task SetupUpdatePostCommentAsync(
			User user,
			Post post,
			PostComment postComment,
			UserId currentUserId,
			CancellationToken cancellationToken)
		{
			await serviceScope.SetupUpdatePostCommentAsync(user, post, postComment, currentUserId.Id, cancellationToken);
		}

		public async Task SetupDeletePostCommentAsync(
			ICollection<User> users,
			Post post,
			PostComment postComment,
			ICollection<PostCommentLike> postCommentLikes,
			ICollection<PostCommentImage> postCommentImages,
			string currentUserId,
			CancellationToken cancellationToken)
		{
			await serviceScope.AddRangeAsync(users, cancellationToken);
			await serviceScope.AddAsync(post, cancellationToken);
			await serviceScope.AddAsync(postComment, cancellationToken);
			await serviceScope.AddRangeAsync(postCommentLikes, cancellationToken);
			await serviceScope.AddRangeAsync(postCommentImages, cancellationToken);
			await serviceScope.AddPostCacheAsync(post, currentUserId, cancellationToken);
			await serviceScope.AddPostCommentCacheAsync(postComment, currentUserId, cancellationToken);
		}

		public async Task SetupDeletePostCommentAsync(
			ICollection<User> users,
			Post post,
			PostComment postComment,
			ICollection<PostCommentLike> postCommentLikes,
			ICollection<PostCommentImage> postCommentImages,
			UserId currentUserId,
			CancellationToken cancellationToken)
		{
			await serviceScope.SetupDeletePostCommentAsync(users, post, postComment, postCommentLikes, postCommentImages, currentUserId.Id, cancellationToken);
		}

		public async Task SetupGetPostCommentByIdAsync(
			ICollection<User> users,
			Post post,
			ICollection<PostLike> postLikes,
			ICollection<PostImage> postImages,
			PostComment postComment,
			ICollection<PostCommentLike> postCommentLikes,
			ICollection<PostCommentImage> postCommentImages,
			CancellationToken cancellationToken)
		{
			await serviceScope.AddRangeAsync(users, cancellationToken);
			await serviceScope.AddAsync(post, cancellationToken);
			await serviceScope.AddRangeAsync(postLikes, cancellationToken);
			await serviceScope.AddRangeAsync(postImages, cancellationToken);
			await serviceScope.AddAsync(postComment, cancellationToken);
			await serviceScope.AddRangeAsync(postCommentLikes, cancellationToken);
			await serviceScope.AddRangeAsync(postCommentImages, cancellationToken);
		}

		public async Task SetupGetAllPostCommentsAsync(
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

		public async Task SetupGetAllPostCommentsForUserAsync(
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

		public async Task DeleteAsync(
			PostComment postComment,
			CancellationToken cancellationToken)
		{
			var postCommentRepository = serviceScope.GetPostCommentCommandRepository();

			await postCommentRepository.DeleteAsync(postComment, cancellationToken);
			await serviceScope.DeletePostCommentCacheAsync(postComment, cancellationToken);
		}

		public async Task DeleteRangeAsync(
			IEnumerable<PostComment> postComments,
			CancellationToken cancellationToken)
		{
			var postCommentRepository = serviceScope.GetPostCommentCommandRepository();

			await postCommentRepository.DeleteRangeAsync(postComments, cancellationToken);
			await serviceScope.DeletePostCommentCacheRangeAsync(postComments, cancellationToken);
		}
	}
}
