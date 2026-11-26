namespace InstaConnect.Chats.Infrastructure.Features.Chats.Abstractions;

public interface IChatCacheHandler
{
	public Task<ChatResponse?> GetByIdAsync(ChatId id, UserId currentUserId, CancellationToken cancellationToken);

	public Task AddAsync(ChatResponse response, UserId currentUserId, CancellationToken cancellationToken);

	public Task AddRangeAsync(IEnumerable<ChatResponse> responses, UserId currentUserId, CancellationToken cancellationToken);

	public Task DeleteAsync(ChatId id, CancellationToken cancellationToken);

	public Task DeleteRangeAsync(IEnumerable<ChatId> ids, CancellationToken cancellationToken);

	public Task DeleteResponseAsync(ChatId id, CancellationToken cancellationToken);

	public Task DeleteResponseRangeAsync(IEnumerable<ChatId> ids, CancellationToken cancellationToken);
}
