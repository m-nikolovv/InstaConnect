namespace InstaConnect.Chats.Infrastructure.Features.Chats.Abstractions;

public interface IChatCollection : IMongoDbCollection<Chat>
{
	public IChatFluent AggregateFluent();

	internal Task AddByParentAsync(
		FilterDefinition<Chat> filter,
		CancellationToken cancellationToken);

	internal Task UpdateByParentAsync(
		FilterDefinition<Chat> filter,
		CancellationToken cancellationToken);

	public Task DeleteAsync(
		Chat entity,
		CancellationToken cancellationToken);

	internal Task DeleteByParentAsync(
		FilterDefinition<Chat> filter,
		CancellationToken cancellationToken);
}
