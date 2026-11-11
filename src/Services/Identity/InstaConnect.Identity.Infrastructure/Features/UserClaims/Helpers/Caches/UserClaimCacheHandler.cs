using InstaConnect.Common.Infrastructure.Features.Caches.Abstractions;
using InstaConnect.Identity.Infrastructure.Features.UserClaims.Models.Options;
using InstaConnect.Identity.Infrastructure.Features.UserClaims.Utilities;
using InstaConnect.Identity.Infrastructure.Features.Users.Utilities;

using Microsoft.Extensions.Options;

namespace InstaConnect.Identity.Infrastructure.Features.UserClaims.Helpers.Caches;

internal class UserClaimCacheHandler : IUserClaimCacheHandler
{
	private readonly ICacheHandler _cacheHandler;
	private readonly UserClaimCacheOptions _cacheOptions;

	public UserClaimCacheHandler(ICacheHandler cacheHandler, IOptions<UserClaimCacheOptions> cacheOptions)
	{
		_cacheHandler = cacheHandler;
		_cacheOptions = cacheOptions.Value;
	}

	public async Task<UserClaim?> GetByIdAsync(UserClaimId id)
	{
		return await _cacheHandler.GetAsync<UserClaim>(UserClaimCacheUtilities.GetByIdKey(id));
	}

	public async Task<UserClaimResponse?> GetByIdAsync(UserClaimId id, CurrentUserQuery currentUser)
	{
		return await _cacheHandler.GetAsync<UserClaimResponse>(UserClaimCacheUtilities.GetResponseByIdKey(id, currentUser));
	}

	public async Task AddAsync(UserClaim entity)
	{
		await _cacheHandler.SetAsync(
			UserClaimCacheUtilities.GetByIdKey(entity.Id),
			entity,
			_cacheOptions.Expirations[UserClaimCacheUtilities.GetByIdKeyPrefix],
			[UserClaimCacheUtilities.GetTag(entity.Id),
			 UserCacheUtilities.GetTag(entity.Id.Id)]);
	}

	public async Task AddAsync(UserClaimResponse response, CurrentUserQuery currentUser)
	{
		await _cacheHandler.SetAsync(
			UserClaimCacheUtilities.GetResponseByIdKey(response.Id, currentUser),
			response,
			_cacheOptions.Expirations[UserClaimCacheUtilities.GetResponseByIdKeyPrefix],
			[UserClaimCacheUtilities.GetTag(response.Id),
			 UserCacheUtilities.GetTag(response.Id.Id)]);
	}

	public async Task<bool?> ExistsByIdAsync(UserClaimId id)
	{
		return await _cacheHandler.GetAsync<bool?>(UserClaimCacheUtilities.ExistsByIdKey(id));
	}

	public async Task AddExistsByIdAsync(UserClaimId id, bool exists)
	{
		await _cacheHandler.SetAsync<bool?>(
			UserClaimCacheUtilities.ExistsByIdKey(id),
			exists,
			_cacheOptions.Expirations[UserClaimCacheUtilities.ExistsByIdKeyPrefix],
			[UserClaimCacheUtilities.GetTag(id),
			 UserCacheUtilities.GetTag(id.Id)]);
	}

	public async Task DeleteAsync(UserClaimId id)
	{
		await _cacheHandler.RemoveByTagAsync(UserClaimCacheUtilities.GetTag(id));
	}

	public async Task DeleteRangeAsync(IEnumerable<UserClaimId> ids)
	{
		await _cacheHandler.RemoveByTagRangeAsync(UserClaimCacheUtilities.GetTagRange(ids));
	}
}
