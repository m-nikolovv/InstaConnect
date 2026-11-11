namespace InstaConnect.Follows.Infrastructure.Features.Users.Abstractions;

public interface IUserCacheHandler
{
	public Task<User?> GetByIdAsync(UserId id);

	public Task<UserResponse?> GetByIdAsync(UserId id, CurrentUserQuery currentUser);

	public Task AddAsync(User entity);

	public Task AddAsync(UserResponse response, CurrentUserQuery currentUser);

	public Task AddRangeAsync(IEnumerable<User> entities);

	public Task<bool?> ExistsByIdAsync(UserId id);

	public Task AddExistsByIdAsync(UserId id, bool exists);

	public Task<User?> GetByNameAsync(Name name);

	public Task AddByNameAsync(User entity);

	public Task<User?> GetByEmailAsync(Email email);

	public Task AddByEmailAsync(User entity);

	public Task DeleteAsync(UserId id);

	public Task DeleteRangeAsync(IEnumerable<UserId> ids);
}
