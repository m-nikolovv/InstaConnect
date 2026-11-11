namespace InstaConnect.Chats.Infrastructure.Features.ChatMessages.Abstractions;

public interface IChatMessageCollection : IMongoDbCollection<ChatMessage>
{
	public IChatMessageFluent AggregateFluent();

	internal Task CascadeAddAsync(
		FilterDefinition<ChatMessage> filter,
		CancellationToken cancellationToken);

	public Task UpdateAsync(
		ChatMessage entity,
		CancellationToken cancellationToken);

	internal Task CascadeUpdateAsync(
		FilterDefinition<ChatMessage> filter,
		CancellationToken cancellationToken);

	public Task DeleteAsync(
		ChatMessage entity,
		CancellationToken cancellationToken);

	internal Task CascadeDeleteAsync(
		FilterDefinition<ChatMessage> filter,
		CancellationToken cancellationToken);
}
