namespace InstaConnect.Follows.Infrastructure.Features.Users.Abstractions;

public interface IUserCacheHandler
{
	public Task<UserResponse?> GetByIdAsync(UserId id, UserId currentUserId, CancellationToken cancellationToken);

	public Task AddAsync(UserResponse response, UserId currentUserId, CancellationToken cancellationToken);

	public Task AddRangeAsync(IEnumerable<UserResponse> responses, UserId currentUserId, CancellationToken cancellationToken);

	public Task DeleteAsync(UserId id, CancellationToken cancellationToken);

	public Task DeleteRangeAsync(IEnumerable<UserId> ids, CancellationToken cancellationToken);
}
