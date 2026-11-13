namespace InstaConnect.Identity.Domain.Features.UserClaims.Abstractions;

public interface IUserClaimCommandRepository
{
	public Task AddAsync(UserClaim entity, CancellationToken cancellationToken);

	public Task AddRangeAsync(IEnumerable<UserClaim> entities, CancellationToken cancellationToken);

	public Task DeleteAsync(UserClaim entity, CancellationToken cancellationToken);

	public Task<UserClaim?> GetByIdAsync(UserClaimId id, CancellationToken cancellationToken);

	public Task<UserClaim?> GetByIdAsync(UserClaimId id, UserClaimInclude include, CancellationToken cancellationToken);

	public Task<ICollection<UserClaim>> GetByIdRangeAsync(IEnumerable<UserClaimId> ids, CancellationToken cancellationToken);

	public Task<bool> ExistsByIdAsync(UserClaimId id, CancellationToken cancellationToken);
}
