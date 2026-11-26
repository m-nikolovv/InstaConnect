using InstaConnect.Posts.Domain.Features.PostImages.Abstractions;
using InstaConnect.Posts.Infrastructure.Features.PostImages.Abstractions;

namespace InstaConnect.Posts.Tests.Features.PostImages.Utilities;

public static class PostImageSetups
{
	extension(IServiceProvider serviceProvider)
	{
		public IPostImageCommandRepository GetPostImageCommandRepository()
		{
			return serviceProvider.GetRequiredService<IPostImageCommandRepository>();
		}

		public IPostImageCollection GetPostImageCollection()
		{
			return serviceProvider.GetRequiredService<IPostImageCollection>();
		}

		public IPostImageCacheHandler GetPostImageCacheHandler()
		{
			return serviceProvider.GetRequiredService<IPostImageCacheHandler>();
		}
	}

	extension(IServiceScope serviceScope)
	{
		public IPostImageCommandRepository GetPostImageCommandRepository()
		{
			return serviceScope.ServiceProvider.GetPostImageCommandRepository();
		}

		public IPostImageCacheHandler GetPostImageCacheHandler()
		{
			return serviceScope.ServiceProvider.GetPostImageCacheHandler();
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
			var postImageRepository = serviceScope.GetPostImageCommandRepository();

			await postImageRepository.AddAsync(postImage, cancellationToken);
		}

		public async Task AddRangeAsync(
			IEnumerable<PostImage> postImages,
			CancellationToken cancellationToken)
		{
			var postImageRepository = serviceScope.GetPostImageCommandRepository();

			await postImageRepository.AddRangeAsync(postImages, cancellationToken);
		}

		public async Task DeleteAsync(
			PostImage postImage,
			CancellationToken cancellationToken)
		{
			var cacheHandler = serviceScope.GetPostCacheHandler();
			var imageCacheHandler = serviceScope.GetPostImageCacheHandler();
			var postImageRepository = serviceScope.GetPostImageCommandRepository();

			await postImageRepository.DeleteAsync(postImage, cancellationToken);
			await cacheHandler.DeleteResponseAsync(postImage.Id.Id, cancellationToken);
			await imageCacheHandler.DeleteAsync(postImage.Id, cancellationToken);
		}

		public async Task DeleteRangeAsync(
			IEnumerable<PostImage> postImages,
			CancellationToken cancellationToken)
		{
			var cacheHandler = serviceScope.GetPostCacheHandler();
			var imageCacheHandler = serviceScope.GetPostImageCacheHandler();
			var postImageRepository = serviceScope.GetPostImageCommandRepository();

			await postImageRepository.DeleteRangeAsync(postImages, cancellationToken);
			await cacheHandler.DeleteResponseRangeAsync(postImages.Select(p => p.Id.Id), cancellationToken);
			await imageCacheHandler.DeleteRangeAsync(postImages.Select(p => p.Id), cancellationToken);
		}

		public async Task SetupAddAsync(
			PostImage postImage,
			string currentUserId,
			CancellationToken cancellationToken)
		{
			var post = postImage.Post!;
			var user = post.User!;

			await serviceScope.AddAsync(user, cancellationToken);
			await serviceScope.AddAsync(post, cancellationToken);
			await serviceScope.AddPostCacheAsync(post, currentUserId, cancellationToken);
		}

		public async Task SetupAddAsync(
			PostImage postImage,
			UserId currentUserId,
			CancellationToken cancellationToken)
		{
			await serviceScope.SetupAddAsync(postImage, currentUserId.Id, cancellationToken);
		}

		public async Task SetupDeleteAsync(
			PostImage postImage,
			string currentUserId,
			CancellationToken cancellationToken)
		{
			var post = postImage.Post!;
			var user = post.User!;

			await serviceScope.AddAsync(user, cancellationToken);
			await serviceScope.AddAsync(post, cancellationToken);
			await serviceScope.AddAsync(postImage, cancellationToken);
			await serviceScope.AddPostCacheAsync(post, currentUserId, cancellationToken);
		}

		public async Task SetupDeleteAsync(
			PostImage postImage,
			UserId currentUserId,
			CancellationToken cancellationToken)
		{
			await serviceScope.SetupDeleteAsync(postImage, currentUserId.Id, cancellationToken);
		}

		public async Task SetupGetAllAsync(
			ICollection<PostImage> postImages,
			CancellationToken cancellationToken)
		{
			var posts = postImages.Select(p => p.Post!).DistinctBy(p => p.Id).ToList();
			var users = posts.Select(p => p.User!).DistinctBy(p => p.Id).ToList();

			await serviceScope.AddRangeAsync(users, cancellationToken);
			await serviceScope.AddRangeAsync(posts, cancellationToken);
			await serviceScope.AddRangeAsync(postImages, cancellationToken);
		}

		public async Task SetupGetByIdAsync(
			PostImage postImage,
			CancellationToken cancellationToken)
		{
			var post = postImage.Post!;
			var user = post.User!;

			await serviceScope.AddAsync(user, cancellationToken);
			await serviceScope.AddAsync(post, cancellationToken);
			await serviceScope.AddAsync(postImage, cancellationToken);
		}
	}
}
