namespace InstaConnect.Chats.Infrastructure.Features.ChatMessages.Abstractions;

public interface IChatMessageCacheHandler
{
	public Task<ChatMessage?> GetByIdAsync(ChatMessageId id);

	public Task<ChatMessageResponse?> GetByIdAsync(ChatMessageId id, CurrentUserQuery currentUser);

	public Task AddAsync(ChatMessage entity);

	public Task AddAsync(ChatMessageResponse response, CurrentUserQuery currentUser);

	public Task<bool?> ExistsByIdAsync(ChatMessageId id);

	public Task AddExistsByIdAsync(ChatMessageId id, bool exists);

	public Task DeleteAsync(ChatMessageId id);

	public Task DeleteRangeAsync(IEnumerable<ChatMessageId> ids);
}
