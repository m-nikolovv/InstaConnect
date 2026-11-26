using InstaConnect.Posts.Domain.Features.PostCommentImages.Abstractions;
using InstaConnect.Posts.Infrastructure.Features.PostCommentImages.Abstractions;

namespace InstaConnect.Posts.Tests.Features.PostCommentImages.Utilities;

public static class PostCommentImageSetups
{
	extension(IServiceProvider serviceProvider)
	{
		public IPostCommentImageCommandRepository GetPostCommentImageCommandRepository()
		{
			return serviceProvider.GetRequiredService<IPostCommentImageCommandRepository>();
		}

		public IPostCommentImageCollection GetPostCommentImageCollection()
		{
			return serviceProvider.GetRequiredService<IPostCommentImageCollection>();
		}

		public IPostCommentImageCacheHandler GetPostCommentImageCacheHandler()
		{
			return serviceProvider.GetRequiredService<IPostCommentImageCacheHandler>();
		}
	}

	extension(IServiceScope serviceScope)
	{
		public IPostCommentImageCommandRepository GetPostCommentImageCommandRepository()
		{
			return serviceScope.ServiceProvider.GetPostCommentImageCommandRepository();
		}

		public IPostCommentImageCacheHandler GetPostCommentImageCacheHandler()
		{
			return serviceScope.ServiceProvider.GetPostCommentImageCacheHandler();
		}

		public async Task<PostCommentImage?> GetByIdAsync(
			PostCommentImageId id,
			CancellationToken cancellationToken)
		{
			return await serviceScope.GetPostCommentImageCommandRepository().GetByIdAsync(id, cancellationToken);
		}

		public async Task<ICollection<PostCommentImage>> GetByIdRangeAsync(
			IEnumerable<PostCommentImageId> ids,
			CancellationToken cancellationToken)
		{
			return await serviceScope.GetPostCommentImageCommandRepository().GetByIdRangeAsync(ids, cancellationToken);
		}

		public async Task AddAsync(
			PostCommentImage postCommentImage,
			CancellationToken cancellationToken)
		{
			var postCommentImageRepository = serviceScope.GetPostCommentImageCommandRepository();

			await postCommentImageRepository.AddAsync(postCommentImage, cancellationToken);
		}

		public async Task AddRangeAsync(
			IEnumerable<PostCommentImage> postCommentImages,
			CancellationToken cancellationToken)
		{
			var postCommentImageRepository = serviceScope.GetPostCommentImageCommandRepository();

			await postCommentImageRepository.AddRangeAsync(postCommentImages, cancellationToken);
		}

		public async Task DeleteAsync(
			PostCommentImage postCommentImage,
			CancellationToken cancellationToken)
		{
			var commentCacheHandler = serviceScope.GetPostCommentCacheHandler();
			var commentImageCacheHandler = serviceScope.GetPostCommentImageCacheHandler();
			var postCommentImageRepository = serviceScope.GetPostCommentImageCommandRepository();

			await postCommentImageRepository.DeleteAsync(postCommentImage, cancellationToken);
			await commentCacheHandler.DeleteResponseAsync(postCommentImage.Id.Id, cancellationToken);
			await commentImageCacheHandler.DeleteAsync(postCommentImage.Id, cancellationToken);
		}

		public async Task DeleteRangeAsync(
			IEnumerable<PostCommentImage> postCommentImages,
			CancellationToken cancellationToken)
		{
			var commentCacheHandler = serviceScope.GetPostCommentCacheHandler();
			var commentImageCacheHandler = serviceScope.GetPostCommentImageCacheHandler();
			var postCommentImageRepository = serviceScope.GetPostCommentImageCommandRepository();

			await postCommentImageRepository.DeleteRangeAsync(postCommentImages, cancellationToken);
			await commentCacheHandler.DeleteResponseRangeAsync(postCommentImages.Select(p => p.Id.Id), cancellationToken);
			await commentImageCacheHandler.DeleteRangeAsync(postCommentImages.Select(p => p.Id), cancellationToken);
		}

		public async Task SetupAddAsync(
			PostCommentImage postCommentImage,
			string currentUserId,
			CancellationToken cancellationToken)
		{
			var postComment = postCommentImage.PostComment!;
			var post = postComment.Post!;
			var users = new List<User> { postComment.User!, post.User! }.DistinctBy(p => p.Id).ToList();

			await serviceScope.AddRangeAsync(users, cancellationToken);
			await serviceScope.AddAsync(post, cancellationToken);
			await serviceScope.AddAsync(postComment, cancellationToken);
			await serviceScope.AddPostCommentCacheAsync(postComment, currentUserId, cancellationToken);
		}

		public async Task SetupAddAsync(
			PostCommentImage postCommentImage,
			UserId currentUserId,
			CancellationToken cancellationToken)
		{
			await serviceScope.SetupAddAsync(postCommentImage, currentUserId.Id, cancellationToken);
		}

		public async Task SetupDeleteAsync(
			PostCommentImage postCommentImage,
			string currentUserId,
			CancellationToken cancellationToken)
		{
			var postComment = postCommentImage.PostComment!;
			var post = postComment.Post!;
			var users = new List<User> { postComment.User!, post.User! }.DistinctBy(p => p.Id).ToList();

			await serviceScope.AddRangeAsync(users, cancellationToken);
			await serviceScope.AddAsync(post, cancellationToken);
			await serviceScope.AddAsync(postComment, cancellationToken);
			await serviceScope.AddAsync(postCommentImage, cancellationToken);
			await serviceScope.AddPostCommentCacheAsync(postComment, currentUserId, cancellationToken);
		}

		public async Task SetupDeleteAsync(
			PostCommentImage postCommentImage,
			UserId currentUserId,
			CancellationToken cancellationToken)
		{
			await serviceScope.SetupDeleteAsync(postCommentImage, currentUserId.Id, cancellationToken);
		}

		public async Task SetupGetAllAsync(
			ICollection<PostCommentImage> postCommentImages,
			CancellationToken cancellationToken)
		{
			var postComments = postCommentImages.Select(p => p.PostComment!).DistinctBy(p => p.Id).ToList();
			var posts = postComments.Select(p => p.Post!).DistinctBy(p => p.Id).ToList();
			var users = postComments
				.Select(p => p.User!)
				.Concat(posts.Select(p => p.User!))
				.DistinctBy(p => p.Id)
				.ToList();

			await serviceScope.AddRangeAsync(users, cancellationToken);
			await serviceScope.AddRangeAsync(posts, cancellationToken);
			await serviceScope.AddRangeAsync(postComments, cancellationToken);
			await serviceScope.AddRangeAsync(postCommentImages, cancellationToken);
		}

		public async Task SetupGetByIdAsync(
			PostCommentImage postCommentImage,
			CancellationToken cancellationToken)
		{
			var postComment = postCommentImage.PostComment!;
			var post = postComment.Post!;
			var users = new List<User> { postComment.User!, post.User! }.DistinctBy(p => p.Id).ToList();

			await serviceScope.AddRangeAsync(users, cancellationToken);
			await serviceScope.AddAsync(post, cancellationToken);
			await serviceScope.AddAsync(postComment, cancellationToken);
			await serviceScope.AddAsync(postCommentImage, cancellationToken);
		}
	}
}
