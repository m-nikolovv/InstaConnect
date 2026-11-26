namespace InstaConnect.Chats.Infrastructure.Features.Users.Abstractions;

public interface IUserCollection
{
	public IUserFluent AggregateFluent();

	public Task AddAsync(
		User entity,
		CancellationToken cancellationToken);

	public Task AddRangeAsync(
		IEnumerable<User> entities,
		CancellationToken cancellationToken);

	public Task UpdateAsync(
		User entity,
		CancellationToken cancellationToken);

	public Task DeleteAsync(
		User entity,
		CancellationToken cancellationToken);
}
