using InstaConnect.Chats.Domain.Features.ChatMessageImages.Abstractions;
using InstaConnect.Chats.Infrastructure.Features.ChatMessageImages.Abstractions;

namespace InstaConnect.Chats.Infrastructure.Features.ChatMessageImages.Helpers.Repositories;

internal class ChatMessageImageCommandRepository : IChatMessageImageCommandRepository
{
	private readonly IChatMessageImageCollection _collection;
	private readonly IChatMessageCacheHandler _messageCacheHandler;
	private readonly IChatMessageImageCacheHandler _messageImageCacheHandler;

	public ChatMessageImageCommandRepository(
		IChatMessageImageCollection collection,
		IChatMessageCacheHandler messageCacheHandler,
		IChatMessageImageCacheHandler messageImageCacheHandler)
	{
		_collection = collection;
		_messageCacheHandler = messageCacheHandler;
		_messageImageCacheHandler = messageImageCacheHandler;
	}

	public async Task<ChatMessageImage?> GetByIdAsync(
		ChatMessageImageId id,
		CancellationToken cancellationToken)
	{
		return await _collection
			.AggregateFluent()
			.Match(id)
			.FirstOrDefaultAsync(cancellationToken);
	}

	public async Task<ICollection<ChatMessageImage>> GetByIdRangeAsync(
		IEnumerable<ChatMessageImageId> ids,
		CancellationToken cancellationToken)
	{
		return await _collection
			.AggregateFluent()
			.Match(ids)
			.ToListAsync(cancellationToken);
	}

	public async Task AddAsync(ChatMessageImage entity, CancellationToken cancellationToken)
	{
		await _collection.AddAsync(entity, cancellationToken);
		await _messageCacheHandler.DeleteResponseAsync(entity.Id.Id, cancellationToken);
	}

	public async Task AddRangeAsync(IEnumerable<ChatMessageImage> entities, CancellationToken cancellationToken)
	{
		await _collection.AddRangeAsync(entities, cancellationToken);
		await _messageCacheHandler.DeleteResponseRangeAsync(entities.Select(p => p.Id.Id), cancellationToken);
	}

	public async Task DeleteAsync(ChatMessageImage entity, CancellationToken cancellationToken)
	{
		await _collection.DeleteAsync(entity, cancellationToken);
		await _messageCacheHandler.DeleteResponseAsync(entity.Id.Id, cancellationToken);
		await _messageImageCacheHandler.DeleteAsync(entity.Id, cancellationToken);
	}

	public async Task DeleteRangeAsync(IEnumerable<ChatMessageImage> entities, CancellationToken cancellationToken)
	{
		await _collection.DeleteRangeAsync(entities, cancellationToken);
		await _messageCacheHandler.DeleteResponseRangeAsync(entities.Select(p => p.Id.Id), cancellationToken);
		await _messageImageCacheHandler.DeleteRangeAsync(entities.Select(p => p.Id), cancellationToken);
	}
}
