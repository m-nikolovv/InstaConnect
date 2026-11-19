namespace InstaConnect.Chats.Domain.Features.ChatMessages.Abstractions;

public interface IChatMessageCommandRepository
{
	public Task AddAsync(ChatMessage entity, CancellationToken cancellationToken);

	public Task UpdateAsync(ChatMessage entity, CancellationToken cancellationToken);

	public Task AddRangeAsync(IEnumerable<ChatMessage> entities, CancellationToken cancellationToken);

	public Task DeleteAsync(ChatMessage entity, CancellationToken cancellationToken);

	public Task<ChatMessage?> GetByIdAsync(ChatMessageId id, CancellationToken cancellationToken);

	public Task<ChatMessage?> GetByIdAsync(ChatMessageId id, ChatMessageInclude include, CancellationToken cancellationToken);

	public Task<ICollection<ChatMessage>> GetByIdRangeAsync(IEnumerable<ChatMessageId> ids, CancellationToken cancellationToken);

	public Task<ICollection<ChatMessage>> GetByIdRangeAsync(IEnumerable<ChatMessageId> ids, ChatMessageInclude include, CancellationToken cancellationToken);

	public Task<bool> ExistsByIdAsync(ChatMessageId id, CancellationToken cancellationToken);
}
