namespace InstaConnect.Follows.Infrastructure.Features.Follows.Abstractions;

public interface IFollowCacheHandler
{
	public Task<Follow?> GetByIdAsync(FollowId id, CancellationToken cancellationToken);

	public Task<FollowResponse?> GetByIdAsync(FollowId id, CurrentUserQuery currentUser, CancellationToken cancellationToken);

	public Task AddAsync(Follow entity, CancellationToken cancellationToken);

	public Task AddAsync(FollowResponse response, CurrentUserQuery currentUser, CancellationToken cancellationToken);

	public Task AddRangeAsync(IEnumerable<Follow> entities, CancellationToken cancellationToken);

	public Task<bool?> ExistsByIdAsync(FollowId id, CancellationToken cancellationToken);

	public Task AddExistsByIdAsync(FollowId id, bool exists, CancellationToken cancellationToken);

	public Task DeleteAsync(FollowId id, CancellationToken cancellationToken);

	public Task DeleteRangeAsync(IEnumerable<FollowId> ids, CancellationToken cancellationToken);
}
