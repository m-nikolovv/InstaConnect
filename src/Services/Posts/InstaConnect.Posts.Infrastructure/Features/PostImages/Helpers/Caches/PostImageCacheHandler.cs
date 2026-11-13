using InstaConnect.Common.Infrastructure.Features.Caches.Abstractions;
using InstaConnect.Posts.Domain.Features.PostImages.Models.ValueObjects;
using InstaConnect.Posts.Infrastructure.Features.PostImages.Abstractions;
using InstaConnect.Posts.Infrastructure.Features.PostImages.Models.Options;
using InstaConnect.Posts.Infrastructure.Features.PostImages.Utilities;
using InstaConnect.Posts.Infrastructure.Features.Posts.Utilities;

using Microsoft.Extensions.Options;

namespace InstaConnect.Posts.Infrastructure.Features.PostImages.Helpers.Caches;

internal class PostImageCacheHandler : IPostImageCacheHandler
{
	private readonly ICacheHandler _cacheHandler;
	private readonly PostImageCacheOptions _cacheOptions;

	public PostImageCacheHandler(ICacheHandler cacheHandler, IOptions<PostImageCacheOptions> cacheOptions)
	{
		_cacheHandler = cacheHandler;
		_cacheOptions = cacheOptions.Value;
	}

	public async Task<PostImage?> GetByIdAsync(PostImageId id, CancellationToken cancellationToken)
	{
		return await _cacheHandler.GetAsync<PostImage>(PostImageCacheUtilities.GetByIdKey(id), cancellationToken);
	}

	public async Task AddAsync(PostImage entity, CancellationToken cancellationToken)
	{
		await _cacheHandler.SetAsync(
			PostImageCacheUtilities.GetByIdKey(entity.Id),
			entity,
			_cacheOptions.Expirations[PostImageCacheUtilities.GetByIdKeyPrefix],
			[PostImageCacheUtilities.GetTag(entity.Id)],
			[PostCacheUtilities.GetTag(entity.Id.Id)],
			cancellationToken);
	}

	public async Task AddRangeAsync(IEnumerable<PostImage> entities, CancellationToken cancellationToken)
	{
		foreach (var entity in entities)
		{
			await AddAsync(entity, cancellationToken);
		}
	}

	public async Task DeleteAsync(PostImageId id, CancellationToken cancellationToken)
	{
		await _cacheHandler.RemoveByTagAsync(PostImageCacheUtilities.GetTag(id), cancellationToken);
	}

	public async Task DeleteRangeAsync(IEnumerable<PostImageId> ids, CancellationToken cancellationToken)
	{
		await _cacheHandler.RemoveByTagRangeAsync(PostImageCacheUtilities.GetTagRange(ids), cancellationToken);
	}
}
