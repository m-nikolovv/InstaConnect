namespace InstaConnect.Chats.Infrastructure.Features.ChatMessageImages.Abstractions;

public interface IChatMessageImageCollection : IMongoDbCollection<ChatMessageImage>
{
	public IChatMessageImageFluent AggregateFluent();

	internal Task AddByParentAsync(
		FilterDefinition<ChatMessageImage> filter,
		CancellationToken cancellationToken);

	internal Task UpdateByParentAsync(
		FilterDefinition<ChatMessageImage> filter,
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
