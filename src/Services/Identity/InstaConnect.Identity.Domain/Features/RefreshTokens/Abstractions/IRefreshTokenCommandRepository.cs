namespace InstaConnect.Identity.Domain.Features.RefreshTokens.Abstractions;

public interface IRefreshTokenCommandRepository
{
	public Task<RefreshToken?> GetByIdAsync(
		RefreshTokenId id,
		RefreshTokenInclude include,
		CancellationToken cancellationToken);

	public Task<RefreshToken?> GetByIdAsync(
		RefreshTokenId id,
		CancellationToken cancellationToken);

	public Task<ICollection<RefreshToken>> GetByIdRangeAsync(
		IEnumerable<RefreshTokenId> ids,
		CancellationToken cancellationToken);

	public Task AddAsync(RefreshToken entity, CancellationToken cancellationToken);

	public Task AddRangeAsync(IEnumerable<RefreshToken> entities, CancellationToken cancellationToken);

	public Task UpdateAsync(RefreshToken entity, CancellationToken cancellationToken);

	public Task DeleteAsync(RefreshToken entity, CancellationToken cancellationToken);
}
