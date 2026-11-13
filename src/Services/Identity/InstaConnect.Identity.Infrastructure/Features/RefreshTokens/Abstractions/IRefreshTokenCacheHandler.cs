using InstaConnect.Identity.Domain.Features.RefreshTokens.Models.ValueObjects;

namespace InstaConnect.Identity.Infrastructure.Features.RefreshTokens.Abstractions;

public interface IRefreshTokenCacheHandler
{
	public Task<RefreshToken?> GetByIdAsync(RefreshTokenId id, CancellationToken cancellationToken);

	public Task AddAsync(RefreshToken entity, CancellationToken cancellationToken);

	public Task AddRangeAsync(IEnumerable<RefreshToken> entities, CancellationToken cancellationToken);

	public Task DeleteAsync(RefreshTokenId id, CancellationToken cancellationToken);

	public Task DeleteRangeAsync(IEnumerable<RefreshTokenId> ids, CancellationToken cancellationToken);
}
