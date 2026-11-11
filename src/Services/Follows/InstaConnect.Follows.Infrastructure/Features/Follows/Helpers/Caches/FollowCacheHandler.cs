using InstaConnect.Common.Infrastructure.Features.Caches.Abstractions;
using InstaConnect.Follows.Infrastructure.Features.Follows.Models.Options;
using InstaConnect.Follows.Infrastructure.Features.Follows.Utilities;
using InstaConnect.Follows.Infrastructure.Features.Users.Utilities;

using Microsoft.Extensions.Options;

namespace InstaConnect.Follows.Infrastructure.Features.Follows.Helpers.Caches;

internal class FollowCacheHandler : IFollowCacheHandler
{
	private readonly ICacheHandler _cacheHandler;
	private readonly FollowCacheOptions _cacheOptions;

	public FollowCacheHandler(ICacheHandler cacheHandler, IOptions<FollowCacheOptions> cacheOptions)
	{
		_cacheHandler = cacheHandler;
		_cacheOptions = cacheOptions.Value;
	}

	public async Task<Follow?> GetByIdAsync(FollowId id)
	{
		return await _cacheHandler.GetAsync<Follow>(FollowCacheUtilities.GetByIdKey(id));
	}

	public async Task<FollowResponse?> GetByIdAsync(FollowId id, CurrentUserQuery currentUser)
	{
		return await _cacheHandler.GetAsync<FollowResponse>(FollowCacheUtilities.GetResponseByIdKey(id, currentUser));
	}

	public async Task AddAsync(Follow entity)
	{
		await _cacheHandler.SetAsync(
			FollowCacheUtilities.GetByIdKey(entity.Id),
			entity,
			_cacheOptions.Expirations[FollowCacheUtilities.GetByIdKeyPrefix],
			[FollowCacheUtilities.GetTag(entity.Id),
			 UserCacheUtilities.GetTag(entity.Id.FollowerId),
			 UserCacheUtilities.GetTag(entity.Id.FollowingId)]);
	}

	public async Task AddAsync(FollowResponse response, CurrentUserQuery currentUser)
	{
		await _cacheHandler.SetAsync(
			FollowCacheUtilities.GetResponseByIdKey(response.Id, currentUser),
			response,
			_cacheOptions.Expirations[FollowCacheUtilities.GetResponseByIdKeyPrefix],
			[FollowCacheUtilities.GetTag(response.Id),
			 UserCacheUtilities.GetTag(response.Id.FollowerId),
			 UserCacheUtilities.GetTag(response.Id.FollowingId)]);
	}

	public async Task AddRangeAsync(IEnumerable<Follow> entities)
	{
		foreach (var entity in entities)
		{
			await AddAsync(entity);
		}
	}

	public async Task<bool?> ExistsByIdAsync(FollowId id)
	{
		return await _cacheHandler.GetAsync<bool?>(FollowCacheUtilities.ExistsByIdKey(id));
	}

	public async Task AddExistsByIdAsync(FollowId id, bool exists)
	{
		await _cacheHandler.SetAsync<bool?>(
			FollowCacheUtilities.ExistsByIdKey(id),
			exists,
			_cacheOptions.Expirations[FollowCacheUtilities.ExistsByIdKeyPrefix],
			[FollowCacheUtilities.GetTag(id),
			 UserCacheUtilities.GetTag(id.FollowerId),
			 UserCacheUtilities.GetTag(id.FollowingId)]);
	}

	public async Task DeleteAsync(FollowId id)
	{
		await _cacheHandler.RemoveByTagAsync(FollowCacheUtilities.GetTag(id));
	}

	public async Task DeleteRangeAsync(IEnumerable<FollowId> ids)
	{
		await _cacheHandler.RemoveByTagRangeAsync(FollowCacheUtilities.GetTagRange(ids));
	}
}
