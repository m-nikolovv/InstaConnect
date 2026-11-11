namespace InstaConnect.Chats.Infrastructure.Features.ChatMessages.Abstractions;

public interface IChatMessageCollection : IMongoDbCollection<ChatMessage>
{
	public IChatMessageFluent AggregateFluent();

	internal Task AddByParentAsync(
		FilterDefinition<ChatMessage> filter,
		CancellationToken cancellationToken);

	public Task UpdateAsync(
		ChatMessage entity,
		CancellationToken cancellationToken);

	internal Task UpdateByParentAsync(
		FilterDefinition<ChatMessage> filter,
		CancellationToken cancellationToken);

	public Task DeleteAsync(
		ChatMessage entity,
		CancellationToken cancellationToken);

	internal Task DeleteByParentAsync(
		FilterDefinition<ChatMessage> filter,
		CancellationToken cancellationToken);
}
