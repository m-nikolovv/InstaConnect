using InstaConnect.Common.Infrastructure.Features.Caches.Abstractions;
using InstaConnect.Posts.Infrastructure.Features.PostLikes.Models.Options;
using InstaConnect.Posts.Infrastructure.Features.PostLikes.Utilities;

using Microsoft.Extensions.Options;

namespace InstaConnect.Posts.Infrastructure.Features.PostLikes.Helpers.Caches;

internal class PostLikeCacheHandler : IPostLikeCacheHandler
{
	private readonly ICacheHandler _cacheHandler;
	private readonly PostLikeCacheOptions _cacheOptions;

	public PostLikeCacheHandler(ICacheHandler cacheHandler, IOptions<PostLikeCacheOptions> cacheOptions)
	{
		_cacheHandler = cacheHandler;
		_cacheOptions = cacheOptions.Value;
	}

	public async Task<PostLike?> GetByIdAsync(PostLikeId id)
	{
		return await _cacheHandler.GetAsync<PostLike>(PostLikeCacheUtilities.GetByIdKey(id));
	}

	public async Task<PostLikeResponse?> GetByIdAsync(PostLikeId id, CurrentUserQuery currentUser)
	{
		return await _cacheHandler.GetAsync<PostLikeResponse>(PostLikeCacheUtilities.GetResponseByIdKey(id, currentUser));
	}

	public async Task AddAsync(PostLike entity)
	{
		await _cacheHandler.SetAsync(PostLikeCacheUtilities.GetByIdKey(entity.Id), entity, _cacheOptions.Expirations[PostLikeCacheUtilities.GetByIdKeyPrefix], PostLikeCacheUtilities.GetTagRange(entity.Id));
	}

	public async Task AddAsync(PostLikeResponse response, CurrentUserQuery currentUser)
	{
		await _cacheHandler.SetAsync(PostLikeCacheUtilities.GetResponseByIdKey(response.Id, currentUser), response, _cacheOptions.Expirations[PostLikeCacheUtilities.GetResponseByIdKeyPrefix], PostLikeCacheUtilities.GetTagRange(response));
	}

	public async Task<bool?> ExistsByIdAsync(PostLikeId id)
	{
		return await _cacheHandler.GetAsync<bool?>(PostLikeCacheUtilities.ExistsByIdKey(id));
	}

	public async Task AddExistsByIdAsync(PostLikeId id, bool exists)
	{
		await _cacheHandler.SetAsync<bool?>(PostLikeCacheUtilities.ExistsByIdKey(id), exists, _cacheOptions.Expirations[PostLikeCacheUtilities.ExistsByIdKeyPrefix], PostLikeCacheUtilities.GetTagRange(id));
	}

	public async Task DeleteAsync(PostLikeId id)
	{
		await _cacheHandler.RemoveByTagAsync(PostLikeCacheUtilities.GetTag(id));
	}

	public async Task DeleteRangeAsync(IEnumerable<PostLikeId> ids)
	{
		await _cacheHandler.RemoveByTagRangeAsync(PostLikeCacheUtilities.GetTagRange(ids));
	}
}
