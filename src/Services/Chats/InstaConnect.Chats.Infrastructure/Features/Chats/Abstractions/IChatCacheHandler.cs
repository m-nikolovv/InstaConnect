namespace InstaConnect.Chats.Infrastructure.Features.Chats.Abstractions;

public interface IChatCacheHandler
{
	public Task<Chat?> GetByIdAsync(ChatId id, CancellationToken cancellationToken);

	public Task<ChatResponse?> GetByIdAsync(ChatId id, CurrentUserQuery currentUser, CancellationToken cancellationToken);

	public Task AddAsync(Chat entity, CancellationToken cancellationToken);

	public Task AddAsync(ChatResponse response, CurrentUserQuery currentUser, CancellationToken cancellationToken);

	public Task AddRangeAsync(IEnumerable<Chat> entities, CancellationToken cancellationToken);

	public Task<bool?> ExistsByIdAsync(ChatId id, CancellationToken cancellationToken);

	public Task AddExistsByIdAsync(ChatId id, bool exists, CancellationToken cancellationToken);

	public Task DeleteAsync(ChatId id, CancellationToken cancellationToken);

	public Task DeleteRangeAsync(IEnumerable<ChatId> ids, CancellationToken cancellationToken);

	public Task DeleteResponseAsync(ChatId id, CancellationToken cancellationToken);

	public Task DeleteResponseRangeAsync(IEnumerable<ChatId> ids, CancellationToken cancellationToken);
}
