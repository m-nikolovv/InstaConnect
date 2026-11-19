using InstaConnect.Common.Infrastructure.Features.Caches.Abstractions;
using InstaConnect.Follows.Infrastructure.Features.Follows.Models.Options;
using InstaConnect.Follows.Infrastructure.Features.Follows.Utilities;
using InstaConnect.Follows.Infrastructure.Features.Users.Utilities;

namespace InstaConnect.Follows.Infrastructure.Features.Follows.Helpers.Caches;

internal class FollowCacheHandler : IFollowCacheHandler
{
	private readonly ICacheHandler _cacheHandler;
	private readonly FollowCacheOptions _cacheOptions;

	public FollowCacheHandler(ICacheHandler cacheHandler, FollowCacheOptions cacheOptions)
	{
		_cacheHandler = cacheHandler;
		_cacheOptions = cacheOptions;
	}

	public async Task<FollowResponse?> GetByIdAsync(FollowId id, UserId currentUserId, CancellationToken cancellationToken)
	{
		return await _cacheHandler.GetAsync<FollowResponse>(FollowCacheUtilities.GetResponseByIdKey(id, currentUserId), cancellationToken);
	}

	public async Task AddAsync(FollowResponse response, UserId currentUserId, CancellationToken cancellationToken)
	{
		await _cacheHandler.SetAsync(
			FollowCacheUtilities.GetResponseByIdKey(response.Id, currentUserId),
			response,
			_cacheOptions.Expirations[FollowCacheUtilities.GetResponseByIdKeyPrefix],
			[FollowCacheUtilities.GetTag(response.Id)],
			[UserCacheUtilities.GetTag(response.Id.FollowerId),
			 UserCacheUtilities.GetTag(response.Id.FollowingId)],
			cancellationToken);
	}

	public async Task AddRangeAsync(IEnumerable<FollowResponse> responses, UserId currentUserId, CancellationToken cancellationToken)
	{
		foreach (var response in responses)
		{
			await AddAsync(response, currentUserId, cancellationToken);
		}
	}

	public async Task DeleteAsync(FollowId id, CancellationToken cancellationToken)
	{
		await _cacheHandler.RemoveByTagAsync(FollowCacheUtilities.GetTag(id), cancellationToken);
	}

	public async Task DeleteRangeAsync(IEnumerable<FollowId> ids, CancellationToken cancellationToken)
	{
		await _cacheHandler.RemoveByTagRangeAsync(FollowCacheUtilities.GetTagRange(ids), cancellationToken);
	}
}
