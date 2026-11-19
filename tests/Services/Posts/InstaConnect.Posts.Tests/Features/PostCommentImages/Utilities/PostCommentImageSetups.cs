using InstaConnect.Posts.Domain.Features.PostCommentImages.Abstractions;
using InstaConnect.Posts.Infrastructure.Features.PostCommentImages.Abstractions;
using InstaConnect.Posts.Infrastructure.Features.PostCommentImages.Helpers.Repositories;

namespace InstaConnect.Posts.Tests.Features.PostCommentImages.Utilities;

public static class PostCommentImageSetups
{
	extension(IServiceProvider serviceProvider)
	{
		public IPostCommentImageCommandRepository GetPostCommentImageCommandRepository()
		{
			return new PostCommentImageCommandRepository(serviceProvider.GetPostCommentImageCollection());
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
	}
}
