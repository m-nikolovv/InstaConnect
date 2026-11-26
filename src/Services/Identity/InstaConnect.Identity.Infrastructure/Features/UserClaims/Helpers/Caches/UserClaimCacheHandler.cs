using InstaConnect.Common.Infrastructure.Features.Caches.Abstractions;
using InstaConnect.Identity.Infrastructure.Features.UserClaims.Models.Options;
using InstaConnect.Identity.Infrastructure.Features.UserClaims.Utilities;
using InstaConnect.Identity.Infrastructure.Features.Users.Utilities;

namespace InstaConnect.Identity.Infrastructure.Features.UserClaims.Helpers.Caches;

internal class UserClaimCacheHandler : IUserClaimCacheHandler
{
	private readonly ICacheHandler _cacheHandler;
	private readonly UserClaimCacheOptions _cacheOptions;

	public UserClaimCacheHandler(ICacheHandler cacheHandler, UserClaimCacheOptions cacheOptions)
	{
		_cacheHandler = cacheHandler;
		_cacheOptions = cacheOptions;
	}

	public async Task<UserClaimResponse?> GetByIdAsync(UserClaimId id, UserId currentUserId, CancellationToken cancellationToken)
	{
		return await _cacheHandler.GetAsync<UserClaimResponse>(UserClaimCacheUtilities.GetResponseByIdKey(id, currentUserId), cancellationToken);
	}

	public async Task AddAsync(UserClaimResponse response, UserId currentUserId, CancellationToken cancellationToken)
	{
		await _cacheHandler.SetAsync(
			UserClaimCacheUtilities.GetResponseByIdKey(response.Id, currentUserId),
			response,
			_cacheOptions.Expirations[UserClaimCacheUtilities.GetResponseByIdKeyPrefix],
			[UserClaimCacheUtilities.GetTag(response.Id)],
			[UserCacheUtilities.GetTag(response.Id.Id)],
			cancellationToken);
	}

	public async Task AddRangeAsync(IEnumerable<UserClaimResponse> responses, UserId currentUserId, CancellationToken cancellationToken)
	{
		foreach (var response in responses)
		{
			await AddAsync(response, currentUserId, cancellationToken);
		}
	}

	public async Task DeleteAsync(UserClaimId id, CancellationToken cancellationToken)
	{
		await _cacheHandler.RemoveByTagAsync(UserClaimCacheUtilities.GetTag(id), cancellationToken);
	}

	public async Task DeleteRangeAsync(IEnumerable<UserClaimId> ids, CancellationToken cancellationToken)
	{
		await _cacheHandler.RemoveByTagRangeAsync(UserClaimCacheUtilities.GetTagRange(ids), cancellationToken);
	}
}
