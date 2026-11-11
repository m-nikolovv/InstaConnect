using InstaConnect.Common.Infrastructure.Features.Caches.Abstractions;
using InstaConnect.Posts.Domain.Features.PostCommentImages.Models.ValueObjects;
using InstaConnect.Posts.Infrastructure.Features.PostCommentImages.Abstractions;
using InstaConnect.Posts.Infrastructure.Features.PostCommentImages.Models.Options;
using InstaConnect.Posts.Infrastructure.Features.PostCommentImages.Utilities;

using Microsoft.Extensions.Options;

namespace InstaConnect.Posts.Infrastructure.Features.PostCommentImages.Helpers.Caches;

internal class PostCommentImageCacheHandler : IPostCommentImageCacheHandler
{
	private readonly ICacheHandler _cacheHandler;
	private readonly PostCommentImageCacheOptions _cacheOptions;

	public PostCommentImageCacheHandler(ICacheHandler cacheHandler, IOptions<PostCommentImageCacheOptions> cacheOptions)
	{
		_cacheHandler = cacheHandler;
		_cacheOptions = cacheOptions.Value;
	}

	public async Task<PostCommentImage?> GetByIdAsync(PostCommentImageId id)
	{
		return await _cacheHandler.GetAsync<PostCommentImage>(PostCommentImageCacheUtilities.GetByIdKey(id));
	}

	public async Task AddAsync(PostCommentImage entity)
	{
		await _cacheHandler.SetAsync(PostCommentImageCacheUtilities.GetByIdKey(entity.Id), entity, _cacheOptions.Expirations[PostCommentImageCacheUtilities.GetByIdKeyPrefix], PostCommentImageCacheUtilities.GetTagRange(entity.Id));
	}

	public async Task DeleteAsync(PostCommentImageId id)
	{
		await _cacheHandler.RemoveByTagAsync(PostCommentImageCacheUtilities.GetTag(id));
	}

	public async Task DeleteRangeAsync(IEnumerable<PostCommentImageId> ids)
	{
		await _cacheHandler.RemoveByTagRangeAsync(PostCommentImageCacheUtilities.GetTagRange(ids));
	}
}
