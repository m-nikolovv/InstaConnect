namespace InstaConnect.Chats.Domain.Features.ChatMessageImages.Abstractions;

public interface IChatMessageImageCommandRepository
{
	public Task<ChatMessageImage?> GetByIdAsync(
		ChatMessageImageId id,
		CancellationToken cancellationToken);

	public Task<ICollection<ChatMessageImage>> GetByIdRangeAsync(
		IEnumerable<ChatMessageImageId> ids,
		CancellationToken cancellationToken);

	public Task AddAsync(ChatMessageImage entity, CancellationToken cancellationToken);

	public Task AddRangeAsync(IEnumerable<ChatMessageImage> entities, CancellationToken cancellationToken);

	public Task DeleteAsync(ChatMessageImage entity, CancellationToken cancellationToken);

	public Task DeleteRangeAsync(IEnumerable<ChatMessageImage> entities, CancellationToken cancellationToken);
}
