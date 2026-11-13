namespace InstaConnect.Chats.Infrastructure.Features.ChatMessageImages.Abstractions;

public interface IChatMessageImageCacheHandler
{
	public Task<ChatMessageImage?> GetByIdAsync(ChatMessageImageId id, CancellationToken cancellationToken);

	public Task AddAsync(ChatMessageImage entity, CancellationToken cancellationToken);

	public Task AddRangeAsync(IEnumerable<ChatMessageImage> entities, CancellationToken cancellationToken);

	public Task DeleteAsync(ChatMessageImageId id, CancellationToken cancellationToken);

	public Task DeleteRangeAsync(IEnumerable<ChatMessageImageId> ids, CancellationToken cancellationToken);
}
