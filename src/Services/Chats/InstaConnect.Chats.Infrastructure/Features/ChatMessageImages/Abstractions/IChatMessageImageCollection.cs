namespace InstaConnect.Chats.Infrastructure.Features.ChatMessageImages.Abstractions;

public interface IChatMessageImageCollection : IMongoDbCollection<ChatMessageImage>
{
	public IChatMessageImageFluent AggregateFluent();

	internal Task CascadeAddAsync(
		FilterDefinition<ChatMessageImage> filter,
		CancellationToken cancellationToken);

	internal Task CascadeUpdateAsync(
		FilterDefinition<ChatMessageImage> filter,
		CancellationToken cancellationToken);

	public Task DeleteAsync(
		ChatMessageImage entity,
		CancellationToken cancellationToken);

	internal Task CascadeDeleteAsync(
		FilterDefinition<ChatMessageImage> filter,
		CancellationToken cancellationToken);

	public Task DeleteRangeAsync(
		IEnumerable<ChatMessageImage> entities,
		CancellationToken cancellationToken);
}
