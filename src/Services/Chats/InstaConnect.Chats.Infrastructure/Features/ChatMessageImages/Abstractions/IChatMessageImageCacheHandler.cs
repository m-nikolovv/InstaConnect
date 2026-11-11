namespace InstaConnect.Chats.Infrastructure.Features.ChatMessageImages.Abstractions;

public interface IChatMessageImageCacheHandler
{
	public Task<ChatMessageImage?> GetByIdAsync(ChatMessageImageId id);

	public Task AddAsync(ChatMessageImage entity);

	public Task AddRangeAsync(IEnumerable<ChatMessageImage> entities);

	public Task DeleteAsync(ChatMessageImageId id);

	public Task DeleteRangeAsync(IEnumerable<ChatMessageImageId> ids);
}
