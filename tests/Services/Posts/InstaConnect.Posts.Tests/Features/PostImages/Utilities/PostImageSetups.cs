using InstaConnect.Posts.Domain.Features.PostImages.Abstractions;
using InstaConnect.Posts.Domain.Features.PostImages.Models.ValueObjects;

using Microsoft.Extensions.DependencyInjection;

namespace InstaConnect.Posts.Tests.Features.PostImages.Utilities;

public static class PostImageSetups
{
	extension(IServiceProvider serviceProvider)
	{
		public IPostImageCommandRepository GetPostImageCommandRepository()
		{
			return serviceProvider.GetRequiredService<IPostImageCommandRepository>();
		}
	}

	extension(IServiceScope serviceScope)
	{
		public IPostImageCommandRepository GetPostImageCommandRepository()
		{
			return serviceScope.ServiceProvider.GetPostImageCommandRepository();
		}

		public async Task<PostImage?> GetByIdAsync(
			PostImageId id,
			CancellationToken cancellationToken)
		{
			return await serviceScope.GetPostImageCommandRepository().GetByIdAsync(id, cancellationToken);
		}

		public async Task<ICollection<PostImage>> GetByIdRangeAsync(
			IEnumerable<PostImageId> ids,
			CancellationToken cancellationToken)
		{
			return await serviceScope.GetPostImageCommandRepository().GetByIdRangeAsync(ids, cancellationToken);
		}

		public async Task AddAsync(
			PostImage postImage,
			CancellationToken cancellationToken)
		{
			await serviceScope.GetPostImageCommandRepository().AddAsync(postImage, cancellationToken);
		}

		public async Task AddRangeAsync(
			IEnumerable<PostImage> postImages,
			CancellationToken cancellationToken)
		{
			await serviceScope.GetPostImageCommandRepository().AddRangeAsync(postImages, cancellationToken);
		}

		public async Task DeleteAsync(
			PostImage postImage,
			CancellationToken cancellationToken)
		{
			await serviceScope.GetPostImageCommandRepository().DeleteAsync(postImage, cancellationToken);
		}

		public async Task DeleteRangeAsync(
			IEnumerable<PostImage> postImages,
			CancellationToken cancellationToken)
		{
			await serviceScope.GetPostImageCommandRepository().DeleteRangeAsync(postImages, cancellationToken);
		}
	}
}
