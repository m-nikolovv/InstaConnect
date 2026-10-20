namespace InstaConnect.Chats.Infrastructure.Features.ChatMessages.Abstractions;

public interface IChatMessageCollection : IMongoDbCollection<ChatMessage>
{
	public IChatMessageFluent AggregateFluent();

	public Task UpdateAsync(
		ChatMessage entity,
		CancellationToken cancellationToken);

	public Task DeleteAsync(
		ChatMessage entity,
		CancellationToken cancellationToken);
}
