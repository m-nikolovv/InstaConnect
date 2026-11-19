namespace InstaConnect.Chats.Infrastructure.Features.ChatMessageImages.Abstractions;

public interface IChatMessageImageCollection
{
	public IChatMessageImageFluent AggregateFluent();

	public Task AddAsync(
		ChatMessageImage entity,
		CancellationToken cancellationToken);

	public Task AddRangeAsync(
		IEnumerable<ChatMessageImage> entities,
		CancellationToken cancellationToken);

	public Task DeleteAsync(
		ChatMessageImage entity,
		CancellationToken cancellationToken);

	internal Task DeleteByParentAsync(
		FilterDefinition<ChatMessageImage> filter,
		CancellationToken cancellationToken);

	public Task DeleteRangeAsync(
		IEnumerable<ChatMessageImage> entities,
		CancellationToken cancellationToken);
}
