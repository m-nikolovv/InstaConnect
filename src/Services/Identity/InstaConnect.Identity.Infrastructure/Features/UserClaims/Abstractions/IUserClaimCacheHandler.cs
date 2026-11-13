namespace InstaConnect.Identity.Infrastructure.Features.UserClaims.Abstractions;

public interface IUserClaimCacheHandler
{
	public Task<UserClaim?> GetByIdAsync(UserClaimId id, CancellationToken cancellationToken);

	public Task<UserClaimResponse?> GetByIdAsync(UserClaimId id, CurrentUserQuery currentUser, CancellationToken cancellationToken);

	public Task AddAsync(UserClaim entity, CancellationToken cancellationToken);

	public Task AddAsync(UserClaimResponse response, CurrentUserQuery currentUser, CancellationToken cancellationToken);

	public Task AddRangeAsync(IEnumerable<UserClaim> entities, CancellationToken cancellationToken);

	public Task<bool?> ExistsByIdAsync(UserClaimId id, CancellationToken cancellationToken);

	public Task AddExistsByIdAsync(UserClaimId id, bool exists, CancellationToken cancellationToken);

	public Task DeleteAsync(UserClaimId id, CancellationToken cancellationToken);

	public Task DeleteRangeAsync(IEnumerable<UserClaimId> ids, CancellationToken cancellationToken);
}
