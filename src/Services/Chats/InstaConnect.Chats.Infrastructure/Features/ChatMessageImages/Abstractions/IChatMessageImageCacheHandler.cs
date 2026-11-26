namespace InstaConnect.Chats.Infrastructure.Features.ChatMessageImages.Abstractions;

public interface IChatMessageImageCacheHandler
{
	public Task DeleteAsync(ChatMessageImageId id, CancellationToken cancellationToken);

	public Task DeleteRangeAsync(IEnumerable<ChatMessageImageId> ids, CancellationToken cancellationToken);
}
