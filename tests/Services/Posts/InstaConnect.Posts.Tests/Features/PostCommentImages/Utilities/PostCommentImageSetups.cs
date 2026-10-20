using InstaConnect.Posts.Domain.Features.PostCommentImages.Abstractions;

namespace InstaConnect.Posts.Tests.Features.PostCommentImages.Utilities;

public static class PostCommentImageSetups
{
	extension(IServiceProvider serviceProvider)
	{
		public IPostCommentImageCommandRepository GetPostCommentImageCommandRepository()
		{
			return serviceProvider.GetRequiredService<IPostCommentImageCommandRepository>();
		}
	}

	extension(IServiceScope serviceScope)
	{
		public IPostCommentImageCommandRepository GetPostCommentImageCommandRepository()
		{
			return serviceScope.ServiceProvider.GetPostCommentImageCommandRepository();
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
			await serviceScope.GetPostCommentImageCommandRepository().AddAsync(postCommentImage, cancellationToken);
		}

		public async Task AddRangeAsync(
			IEnumerable<PostCommentImage> postCommentImages,
			CancellationToken cancellationToken)
		{
			await serviceScope.GetPostCommentImageCommandRepository().AddRangeAsync(postCommentImages, cancellationToken);
		}

		public async Task DeleteAsync(
			PostCommentImage postCommentImage,
			CancellationToken cancellationToken)
		{
			await serviceScope.GetPostCommentImageCommandRepository().DeleteAsync(postCommentImage, cancellationToken);
		}

		public async Task DeleteRangeAsync(
			IEnumerable<PostCommentImage> postCommentImages,
			CancellationToken cancellationToken)
		{
			await serviceScope.GetPostCommentImageCommandRepository().DeleteRangeAsync(postCommentImages, cancellationToken);
		}
	}
}
