namespace InstaConnect.Identity.Infrastructure.Features.UserClaims.Abstractions;

public interface IUserClaimCacheHandler
{
	public Task<UserClaimResponse?> GetByIdAsync(UserClaimId id, UserId currentUserId, CancellationToken cancellationToken);

	public Task AddAsync(UserClaimResponse response, UserId currentUserId, CancellationToken cancellationToken);

	public Task AddRangeAsync(IEnumerable<UserClaimResponse> responses, UserId currentUserId, CancellationToken cancellationToken);

	public Task DeleteAsync(UserClaimId id, CancellationToken cancellationToken);

	public Task DeleteRangeAsync(IEnumerable<UserClaimId> ids, CancellationToken cancellationToken);
}
