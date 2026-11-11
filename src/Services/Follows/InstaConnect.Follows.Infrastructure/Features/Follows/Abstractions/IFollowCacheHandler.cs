namespace InstaConnect.Follows.Infrastructure.Features.Follows.Abstractions;

public interface IFollowCacheHandler
{
	public Task<Follow?> GetByIdAsync(FollowId id);

	public Task<FollowResponse?> GetByIdAsync(FollowId id, CurrentUserQuery currentUser);

	public Task AddAsync(Follow entity);

	public Task AddAsync(FollowResponse response, CurrentUserQuery currentUser);

	public Task AddRangeAsync(IEnumerable<Follow> entities);

	public Task<bool?> ExistsByIdAsync(FollowId id);

	public Task AddExistsByIdAsync(FollowId id, bool exists);

	public Task DeleteAsync(FollowId id);

	public Task DeleteRangeAsync(IEnumerable<FollowId> ids);
}
