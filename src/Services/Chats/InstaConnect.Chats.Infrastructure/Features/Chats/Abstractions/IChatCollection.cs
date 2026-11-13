namespace InstaConnect.Chats.Infrastructure.Features.Chats.Abstractions;

public interface IChatCollection
{
	public IChatFluent AggregateFluent();

	public Task AddAsync(
		Chat entity,
		CancellationToken cancellationToken);

	public Task AddRangeAsync(
		IEnumerable<Chat> entities,
		CancellationToken cancellationToken);

	public Task DeleteAsync(
		Chat entity,
		CancellationToken cancellationToken);

	internal Task DeleteByParentAsync(
		FilterDefinition<Chat> filter,
		CancellationToken cancellationToken);
}
