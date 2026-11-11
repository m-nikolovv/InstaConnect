using InstaConnect.Identity.Domain.Features.RefreshTokens.Models.ValueObjects;

namespace InstaConnect.Identity.Infrastructure.Features.RefreshTokens.Abstractions;

public interface IRefreshTokenCacheHandler
{
	public Task<RefreshToken?> GetByIdAsync(RefreshTokenId id);

	public Task AddAsync(RefreshToken entity);

	public Task DeleteAsync(RefreshTokenId id);

	public Task DeleteRangeAsync(IEnumerable<RefreshTokenId> ids);
}
