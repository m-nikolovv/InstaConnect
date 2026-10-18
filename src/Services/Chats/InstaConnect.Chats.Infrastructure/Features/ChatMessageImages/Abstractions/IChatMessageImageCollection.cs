using InstaConnect.Common.Infrastructure.Features.Databases.Abstractions;

namespace InstaConnect.Chats.Infrastructure.Features.ChatMessageImages.Abstractions;

public interface IChatMessageImageCollection : IMongoDbCollection<ChatMessageImage>
{
	public IChatMessageImageFluent AggregateFluent();

	public Task DeleteAsync(
		ChatMessageImage entity,
		CancellationToken cancellationToken);

	public Task DeleteRangeAsync(
		IEnumerable<ChatMessageImage> entities,
		CancellationToken cancellationToken);
}
