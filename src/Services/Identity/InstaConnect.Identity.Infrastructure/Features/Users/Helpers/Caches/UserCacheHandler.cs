using InstaConnect.Common.Infrastructure.Features.Caches.Abstractions;
using InstaConnect.Identity.Infrastructure.Features.Users.Models.Options;
using InstaConnect.Identity.Infrastructure.Features.Users.Utilities;

namespace InstaConnect.Identity.Infrastructure.Features.Users.Helpers.Caches;

internal class UserCacheHandler : IUserCacheHandler
{
	private readonly ICacheHandler _cacheHandler;
	private readonly UserCacheOptions _cacheOptions;

	public UserCacheHandler(ICacheHandler cacheHandler, UserCacheOptions cacheOptions)
	{
		_cacheHandler = cacheHandler;
		_cacheOptions = cacheOptions;
	}

	public async Task<UserResponse?> GetByIdAsync(UserId id, UserId currentUserId, CancellationToken cancellationToken)
	{
		return await _cacheHandler.GetAsync<UserResponse>(UserCacheUtilities.GetResponseByIdKey(id, currentUserId), cancellationToken);
	}

	public async Task AddAsync(UserResponse response, UserId currentUserId, CancellationToken cancellationToken)
	{
		await _cacheHandler.SetAsync(
			UserCacheUtilities.GetResponseByIdKey(response.Id, currentUserId),
			response,
			_cacheOptions.Expirations[UserCacheUtilities.GetResponseByIdKeyPrefix],
			[UserCacheUtilities.GetTag(response.Id)],
			cancellationToken);
	}

	public async Task AddRangeAsync(IEnumerable<UserResponse> responses, UserId currentUserId, CancellationToken cancellationToken)
	{
		foreach (var response in responses)
		{
			await AddAsync(response, currentUserId, cancellationToken);
		}
	}

	public async Task DeleteAsync(UserId id, CancellationToken cancellationToken)
	{
		await _cacheHandler.RemoveByTagAsync(UserCacheUtilities.GetTag(id), cancellationToken);
	}

	public async Task DeleteRangeAsync(IEnumerable<UserId> ids, CancellationToken cancellationToken)
	{
		await _cacheHandler.RemoveByTagRangeAsync(UserCacheUtilities.GetTagRange(ids), cancellationToken);
	}
}
