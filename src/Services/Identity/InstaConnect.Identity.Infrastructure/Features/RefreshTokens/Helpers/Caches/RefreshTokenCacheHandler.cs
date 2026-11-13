using InstaConnect.Common.Infrastructure.Features.Caches.Abstractions;
using InstaConnect.Identity.Domain.Features.RefreshTokens.Models.ValueObjects;
using InstaConnect.Identity.Infrastructure.Features.RefreshTokens.Models.Options;
using InstaConnect.Identity.Infrastructure.Features.RefreshTokens.Utilities;
using InstaConnect.Identity.Infrastructure.Features.Users.Utilities;

using Microsoft.Extensions.Options;

namespace InstaConnect.Identity.Infrastructure.Features.RefreshTokens.Helpers.Caches;

internal class RefreshTokenCacheHandler : IRefreshTokenCacheHandler
{
	private readonly ICacheHandler _cacheHandler;
	private readonly RefreshTokenCacheOptions _cacheOptions;

	public RefreshTokenCacheHandler(ICacheHandler cacheHandler, IOptions<RefreshTokenCacheOptions> cacheOptions)
	{
		_cacheHandler = cacheHandler;
		_cacheOptions = cacheOptions.Value;
	}

	public async Task<RefreshToken?> GetByIdAsync(RefreshTokenId id, CancellationToken cancellationToken)
	{
		return await _cacheHandler.GetAsync<RefreshToken>(RefreshTokenCacheUtilities.GetByIdKey(id), cancellationToken);
	}

	public async Task AddAsync(RefreshToken entity, CancellationToken cancellationToken)
	{
		await _cacheHandler.SetAsync(
			RefreshTokenCacheUtilities.GetByIdKey(entity.Id),
			entity,
			_cacheOptions.Expirations[RefreshTokenCacheUtilities.GetByIdKeyPrefix],
			[RefreshTokenCacheUtilities.GetTag(entity.Id)],
			[UserCacheUtilities.GetTag(entity.Id.Id)],
			cancellationToken);
	}

	public async Task AddRangeAsync(IEnumerable<RefreshToken> entities, CancellationToken cancellationToken)
	{
		foreach (var entity in entities)
		{
			await AddAsync(entity, cancellationToken);
		}
	}

	public async Task DeleteAsync(RefreshTokenId id, CancellationToken cancellationToken)
	{
		await _cacheHandler.RemoveByTagAsync(RefreshTokenCacheUtilities.GetTag(id), cancellationToken);
	}

	public async Task DeleteRangeAsync(IEnumerable<RefreshTokenId> ids, CancellationToken cancellationToken)
	{
		await _cacheHandler.RemoveByTagRangeAsync(RefreshTokenCacheUtilities.GetTagRange(ids), cancellationToken);
	}
}
