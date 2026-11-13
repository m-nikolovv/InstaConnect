namespace InstaConnect.Posts.Infrastructure.Features.Users.Abstractions;

public interface IUserCacheHandler
{
	public Task<User?> GetByIdAsync(UserId id, CancellationToken cancellationToken);

	public Task<UserResponse?> GetByIdAsync(UserId id, CurrentUserQuery currentUser, CancellationToken cancellationToken);

	public Task AddAsync(User entity, CancellationToken cancellationToken);

	public Task AddAsync(UserResponse response, CurrentUserQuery currentUser, CancellationToken cancellationToken);

	public Task AddRangeAsync(IEnumerable<User> entities, CancellationToken cancellationToken);

	public Task<bool?> ExistsByIdAsync(UserId id, CancellationToken cancellationToken);

	public Task AddExistsByIdAsync(UserId id, bool exists, CancellationToken cancellationToken);

	public Task<User?> GetByNameAsync(Name name, CancellationToken cancellationToken);

	public Task AddByNameAsync(User entity, CancellationToken cancellationToken);

	public Task<User?> GetByEmailAsync(Email email, CancellationToken cancellationToken);

	public Task AddByEmailAsync(User entity, CancellationToken cancellationToken);

	public Task DeleteAsync(UserId id, CancellationToken cancellationToken);

	public Task DeleteRangeAsync(IEnumerable<UserId> ids, CancellationToken cancellationToken);
}
