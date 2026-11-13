using InstaConnect.Common.Infrastructure.Features.Caches.Abstractions;
using InstaConnect.Posts.Domain.Features.PostCommentImages.Models.ValueObjects;
using InstaConnect.Posts.Infrastructure.Features.PostCommentImages.Abstractions;
using InstaConnect.Posts.Infrastructure.Features.PostCommentImages.Models.Options;
using InstaConnect.Posts.Infrastructure.Features.PostCommentImages.Utilities;
using InstaConnect.Posts.Infrastructure.Features.PostComments.Utilities;

namespace InstaConnect.Posts.Infrastructure.Features.PostCommentImages.Helpers.Caches;

internal class PostCommentImageCacheHandler : IPostCommentImageCacheHandler
{
	private readonly ICacheHandler _cacheHandler;
	private readonly PostCommentImageCacheOptions _cacheOptions;

	public PostCommentImageCacheHandler(ICacheHandler cacheHandler, PostCommentImageCacheOptions cacheOptions)
	{
		_cacheHandler = cacheHandler;
		_cacheOptions = cacheOptions;
	}

	public async Task<PostCommentImage?> GetByIdAsync(PostCommentImageId id, CancellationToken cancellationToken)
	{
		return await _cacheHandler.GetAsync<PostCommentImage>(PostCommentImageCacheUtilities.GetByIdKey(id), cancellationToken);
	}

	public async Task AddAsync(PostCommentImage entity, CancellationToken cancellationToken)
	{
		await _cacheHandler.SetAsync(
			PostCommentImageCacheUtilities.GetByIdKey(entity.Id),
			entity,
			_cacheOptions.Expirations[PostCommentImageCacheUtilities.GetByIdKeyPrefix],
			[PostCommentImageCacheUtilities.GetTag(entity.Id)],
			[PostCommentCacheUtilities.GetTag(entity.Id.Id)],
			cancellationToken);
	}

	public async Task AddRangeAsync(IEnumerable<PostCommentImage> entities, CancellationToken cancellationToken)
	{
		foreach (var entity in entities)
		{
			await AddAsync(entity, cancellationToken);
		}
	}

	public async Task DeleteAsync(PostCommentImageId id, CancellationToken cancellationToken)
	{
		await _cacheHandler.RemoveByTagAsync(PostCommentImageCacheUtilities.GetTag(id), cancellationToken);
	}

	public async Task DeleteRangeAsync(IEnumerable<PostCommentImageId> ids, CancellationToken cancellationToken)
	{
		await _cacheHandler.RemoveByTagRangeAsync(PostCommentImageCacheUtilities.GetTagRange(ids), cancellationToken);
	}
}
