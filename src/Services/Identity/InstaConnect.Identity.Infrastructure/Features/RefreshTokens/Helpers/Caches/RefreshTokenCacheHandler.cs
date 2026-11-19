using InstaConnect.Common.Infrastructure.Features.Caches.Abstractions;
using InstaConnect.Identity.Domain.Features.RefreshTokens.Models.ValueObjects;
using InstaConnect.Identity.Infrastructure.Features.RefreshTokens.Utilities;

namespace InstaConnect.Identity.Infrastructure.Features.RefreshTokens.Helpers.Caches;

internal class RefreshTokenCacheHandler : IRefreshTokenCacheHandler
{
	private readonly ICacheHandler _cacheHandler;

	public RefreshTokenCacheHandler(ICacheHandler cacheHandler)
	{
		_cacheHandler = cacheHandler;
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
