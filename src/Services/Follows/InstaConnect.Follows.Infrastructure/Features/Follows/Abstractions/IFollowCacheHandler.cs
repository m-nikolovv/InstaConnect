namespace InstaConnect.Follows.Infrastructure.Features.Follows.Abstractions;

public interface IFollowCacheHandler
{
	public Task<FollowResponse?> GetByIdAsync(FollowId id, UserId currentUserId, CancellationToken cancellationToken);

	public Task AddAsync(FollowResponse response, UserId currentUserId, CancellationToken cancellationToken);

	public Task AddRangeAsync(IEnumerable<FollowResponse> responses, UserId currentUserId, CancellationToken cancellationToken);

	public Task DeleteAsync(FollowId id, CancellationToken cancellationToken);

	public Task DeleteRangeAsync(IEnumerable<FollowId> ids, CancellationToken cancellationToken);
}
