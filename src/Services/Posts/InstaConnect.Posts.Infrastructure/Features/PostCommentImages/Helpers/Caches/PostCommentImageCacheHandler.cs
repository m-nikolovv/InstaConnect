using InstaConnect.Common.Infrastructure.Features.Caches.Abstractions;
using InstaConnect.Posts.Domain.Features.PostCommentImages.Models.ValueObjects;
using InstaConnect.Posts.Infrastructure.Features.PostCommentImages.Abstractions;
using InstaConnect.Posts.Infrastructure.Features.PostCommentImages.Utilities;

namespace InstaConnect.Posts.Infrastructure.Features.PostCommentImages.Helpers.Caches;

internal class PostCommentImageCacheHandler : IPostCommentImageCacheHandler
{
	private readonly ICacheHandler _cacheHandler;

	public PostCommentImageCacheHandler(ICacheHandler cacheHandler)
	{
		_cacheHandler = cacheHandler;
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
