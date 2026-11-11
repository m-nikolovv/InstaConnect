namespace InstaConnect.Chats.Infrastructure.Features.Chats.Abstractions;

public interface IChatCollection : IMongoDbCollection<Chat>
{
	public IChatFluent AggregateFluent();

	internal Task CascadeAddAsync(
		FilterDefinition<Chat> filter,
		CancellationToken cancellationToken);

	internal Task CascadeUpdateAsync(
		FilterDefinition<Chat> filter,
		CancellationToken cancellationToken);

	public Task DeleteAsync(
		Chat entity,
		CancellationToken cancellationToken);

	internal Task CascadeDeleteAsync(
		FilterDefinition<Chat> filter,
		CancellationToken cancellationToken);
}
