namespace InstaConnect.Chats.Infrastructure.Features.Chats.Abstractions;

public interface IChatCacheHandler
{
	public Task<Chat?> GetByIdAsync(ChatId id);

	public Task<ChatResponse?> GetByIdAsync(ChatId id, CurrentUserQuery currentUser);

	public Task AddAsync(Chat entity);

	public Task AddAsync(ChatResponse response, CurrentUserQuery currentUser);

	public Task<bool?> ExistsByIdAsync(ChatId id);

	public Task AddExistsByIdAsync(ChatId id, bool exists);

	public Task DeleteAsync(ChatId id);

	public Task DeleteRangeAsync(IEnumerable<ChatId> ids);
}
