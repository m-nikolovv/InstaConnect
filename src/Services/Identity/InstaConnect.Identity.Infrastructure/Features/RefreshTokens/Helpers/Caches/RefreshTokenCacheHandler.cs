using InstaConnect.Common.Infrastructure.Features.Caches.Abstractions;
using InstaConnect.Identity.Domain.Features.RefreshTokens.Models.ValueObjects;
using InstaConnect.Identity.Infrastructure.Features.RefreshTokens.Models.Options;
using InstaConnect.Identity.Infrastructure.Features.RefreshTokens.Utilities;

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

	public async Task<RefreshToken?> GetByIdAsync(RefreshTokenId id)
	{
		return await _cacheHandler.GetAsync<RefreshToken>(RefreshTokenCacheUtilities.GetByIdKey(id));
	}

	public async Task AddAsync(RefreshToken entity)
	{
		await _cacheHandler.SetAsync(RefreshTokenCacheUtilities.GetByIdKey(entity.Id), entity, _cacheOptions.Expirations[RefreshTokenCacheUtilities.GetByIdKeyPrefix], RefreshTokenCacheUtilities.GetTagRange(entity.Id));
	}

	public async Task DeleteAsync(RefreshTokenId id)
	{
		await _cacheHandler.RemoveByTagAsync(RefreshTokenCacheUtilities.GetTag(id));
	}

	public async Task DeleteRangeAsync(IEnumerable<RefreshTokenId> ids)
	{
		await _cacheHandler.RemoveByTagRangeAsync(RefreshTokenCacheUtilities.GetTagRange(ids));
	}
}
