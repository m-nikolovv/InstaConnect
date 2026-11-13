namespace InstaConnect.Chats.Infrastructure.Features.ChatMessages.Abstractions;

public interface IChatMessageCacheHandler
{
	public Task<ChatMessage?> GetByIdAsync(ChatMessageId id, CancellationToken cancellationToken);

	public Task<ChatMessageResponse?> GetByIdAsync(ChatMessageId id, CurrentUserQuery currentUser, CancellationToken cancellationToken);

	public Task AddAsync(ChatMessage entity, CancellationToken cancellationToken);

	public Task AddAsync(ChatMessageResponse response, CurrentUserQuery currentUser, CancellationToken cancellationToken);

	public Task AddRangeAsync(IEnumerable<ChatMessage> entities, CancellationToken cancellationToken);

	public Task<bool?> ExistsByIdAsync(ChatMessageId id, CancellationToken cancellationToken);

	public Task AddExistsByIdAsync(ChatMessageId id, bool exists, CancellationToken cancellationToken);

	public Task DeleteAsync(ChatMessageId id, CancellationToken cancellationToken);

	public Task DeleteRangeAsync(IEnumerable<ChatMessageId> ids, CancellationToken cancellationToken);

	public Task DeleteResponseAsync(ChatMessageId id, CancellationToken cancellationToken);

	public Task DeleteResponseRangeAsync(IEnumerable<ChatMessageId> ids, CancellationToken cancellationToken);
}
