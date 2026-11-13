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

	public async Task<UserClaim?> GetByIdAsync(UserClaimId id, CancellationToken cancellationToken)
	{
		return await _cacheHandler.GetAsync<UserClaim>(UserClaimCacheUtilities.GetByIdKey(id), cancellationToken);
	}

	public async Task<UserClaimResponse?> GetByIdAsync(UserClaimId id, CurrentUserQuery currentUser, CancellationToken cancellationToken)
	{
		return await _cacheHandler.GetAsync<UserClaimResponse>(UserClaimCacheUtilities.GetResponseByIdKey(id, currentUser), cancellationToken);
	}

	public async Task AddAsync(UserClaim entity, CancellationToken cancellationToken)
	{
		await _cacheHandler.SetAsync(
			UserClaimCacheUtilities.GetByIdKey(entity.Id),
			entity,
			_cacheOptions.Expirations[UserClaimCacheUtilities.GetByIdKeyPrefix],
			[UserClaimCacheUtilities.GetTag(entity.Id)],
			[UserCacheUtilities.GetTag(entity.Id.Id)],
			cancellationToken);
	}

	public async Task AddAsync(UserClaimResponse response, CurrentUserQuery currentUser, CancellationToken cancellationToken)
	{
		await _cacheHandler.SetAsync(
			UserClaimCacheUtilities.GetResponseByIdKey(response.Id, currentUser),
			response,
			_cacheOptions.Expirations[UserClaimCacheUtilities.GetResponseByIdKeyPrefix],
			[UserClaimCacheUtilities.GetTag(response.Id)],
			[UserCacheUtilities.GetTag(response.Id.Id)],
			cancellationToken);
	}

	public async Task AddRangeAsync(IEnumerable<UserClaim> entities, CancellationToken cancellationToken)
	{
		foreach (var entity in entities)
		{
			await AddAsync(entity, cancellationToken);
		}
	}

	public async Task<bool?> ExistsByIdAsync(UserClaimId id, CancellationToken cancellationToken)
	{
		return await _cacheHandler.GetAsync<bool?>(UserClaimCacheUtilities.ExistsByIdKey(id), cancellationToken);
	}

	public async Task AddExistsByIdAsync(UserClaimId id, bool exists, CancellationToken cancellationToken)
	{
		await _cacheHandler.SetAsync<bool?>(
			UserClaimCacheUtilities.ExistsByIdKey(id),
			exists,
			_cacheOptions.Expirations[UserClaimCacheUtilities.ExistsByIdKeyPrefix],
			[UserClaimCacheUtilities.GetTag(id)],
			[UserCacheUtilities.GetTag(id.Id)],
			cancellationToken);
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
