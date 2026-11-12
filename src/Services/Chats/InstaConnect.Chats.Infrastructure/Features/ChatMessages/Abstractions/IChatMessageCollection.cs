namespace InstaConnect.Chats.Infrastructure.Features.ChatMessages.Abstractions;

public interface IChatMessageCollection
{
	public IChatMessageFluent AggregateFluent();

	public Task AddAsync(
		ChatMessage entity,
		CancellationToken cancellationToken);

	public Task AddRangeAsync(
		IEnumerable<ChatMessage> entities,
		CancellationToken cancellationToken);

	public Task UpdateAsync(
		ChatMessage entity,
		CancellationToken cancellationToken);

	public Task DeleteAsync(
		ChatMessage entity,
		CancellationToken cancellationToken);

	internal Task DeleteByParentAsync(
		FilterDefinition<ChatMessage> filter,
		CancellationToken cancellationToken);
}
