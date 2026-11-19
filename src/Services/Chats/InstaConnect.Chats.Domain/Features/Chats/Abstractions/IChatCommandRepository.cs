namespace InstaConnect.Chats.Domain.Features.Chats.Abstractions;

public interface IChatCommandRepository
{
	public Task AddAsync(Chat entity, CancellationToken cancellationToken);

	public Task AddRangeAsync(IEnumerable<Chat> entities, CancellationToken cancellationToken);

	public Task DeleteAsync(Chat entity, CancellationToken cancellationToken);

	public Task<Chat?> GetByIdAsync(ChatId id, CancellationToken cancellationToken);

	public Task<Chat?> GetByIdAsync(ChatId id, ChatInclude include, CancellationToken cancellationToken);

	public Task<ICollection<Chat>> GetByIdRangeAsync(IEnumerable<ChatId> ids, CancellationToken cancellationToken);

	public Task<ICollection<Chat>> GetByIdRangeAsync(IEnumerable<ChatId> ids, ChatInclude include, CancellationToken cancellationToken);

	public Task<bool> ExistsByIdAsync(ChatId id, CancellationToken cancellationToken);
}
