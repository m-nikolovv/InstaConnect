using InstaConnect.Identity.Domain.Features.RefreshTokens.Models.ValueObjects;

namespace InstaConnect.Identity.Infrastructure.Features.RefreshTokens.Abstractions;

public interface IRefreshTokenCacheHandler
{
	public Task DeleteAsync(RefreshTokenId id, CancellationToken cancellationToken);

	public Task DeleteRangeAsync(IEnumerable<RefreshTokenId> ids, CancellationToken cancellationToken);
}
