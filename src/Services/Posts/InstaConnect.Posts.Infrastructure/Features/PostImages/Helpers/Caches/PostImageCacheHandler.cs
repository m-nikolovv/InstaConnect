using InstaConnect.Common.Infrastructure.Features.Caches.Abstractions;
using InstaConnect.Posts.Domain.Features.PostImages.Models.ValueObjects;
using InstaConnect.Posts.Infrastructure.Features.PostImages.Abstractions;
using InstaConnect.Posts.Infrastructure.Features.PostImages.Utilities;

namespace InstaConnect.Posts.Infrastructure.Features.PostImages.Helpers.Caches;

internal class PostImageCacheHandler : IPostImageCacheHandler
{
	private readonly ICacheHandler _cacheHandler;

	public PostImageCacheHandler(ICacheHandler cacheHandler)
	{
		_cacheHandler = cacheHandler;
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
