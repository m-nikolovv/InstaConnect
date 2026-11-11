namespace InstaConnect.Identity.Infrastructure.Features.UserClaims.Abstractions;

public interface IUserClaimCacheHandler
{
	public Task<UserClaim?> GetByIdAsync(UserClaimId id);

	public Task<UserClaimResponse?> GetByIdAsync(UserClaimId id, CurrentUserQuery currentUser);

	public Task AddAsync(UserClaim entity);

	public Task AddAsync(UserClaimResponse response, CurrentUserQuery currentUser);

	public Task AddRangeAsync(IEnumerable<UserClaim> entities);

	public Task<bool?> ExistsByIdAsync(UserClaimId id);

	public Task AddExistsByIdAsync(UserClaimId id, bool exists);

	public Task DeleteAsync(UserClaimId id);

	public Task DeleteRangeAsync(IEnumerable<UserClaimId> ids);
}
