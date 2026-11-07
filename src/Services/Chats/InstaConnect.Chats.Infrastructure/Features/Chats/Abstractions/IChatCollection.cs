namespace InstaConnect.Chats.Infrastructure.Features.Chats.Abstractions;

public interface IChatCollection : IMongoDbCollection<Chat>
{
	public IChatFluent AggregateFluent();

	public Task DeleteAsync(
		Chat entity,
		CancellationToken cancellationToken);

	internal Task CascadeDeleteAsync(
		FilterDefinition<Chat> filter,
		CancellationToken cancellationToken);
}
