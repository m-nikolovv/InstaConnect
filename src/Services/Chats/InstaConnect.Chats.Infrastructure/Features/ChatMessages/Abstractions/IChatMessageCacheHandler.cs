namespace InstaConnect.Chats.Infrastructure.Features.ChatMessages.Abstractions;

public interface IChatMessageCacheHandler
{
	public Task<ChatMessageResponse?> GetByIdAsync(ChatMessageId id, UserId currentUserId, CancellationToken cancellationToken);

	public Task AddAsync(ChatMessageResponse response, UserId currentUserId, CancellationToken cancellationToken);

	public Task AddRangeAsync(IEnumerable<ChatMessageResponse> responses, UserId currentUserId, CancellationToken cancellationToken);

	public Task DeleteAsync(ChatMessageId id, CancellationToken cancellationToken);

	public Task DeleteRangeAsync(IEnumerable<ChatMessageId> ids, CancellationToken cancellationToken);

	public Task DeleteResponseAsync(ChatMessageId id, CancellationToken cancellationToken);

	public Task DeleteResponseRangeAsync(IEnumerable<ChatMessageId> ids, CancellationToken cancellationToken);
}
