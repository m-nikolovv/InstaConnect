using InstaConnect.Chats.Domain.Features.ChatMessageImages.Abstractions;
using InstaConnect.Chats.Infrastructure.Features.ChatMessageImages.Abstractions;

namespace InstaConnect.Chats.Infrastructure.Features.ChatMessageImages.Helpers.Repositories;

internal class ChatMessageImageCommandRepository : IChatMessageImageCommandRepository
{
	private readonly IChatMessageImageCollection _collection;
	private readonly IChatMessageImageCacheHandler _messageImageCacheHandler;

	public ChatMessageImageCommandRepository(
		IChatMessageImageCollection collection,
		IChatMessageImageCacheHandler messageImageCacheHandler)
	{
		_collection = collection;
		_messageImageCacheHandler = messageImageCacheHandler;
	}

	public async Task<ChatMessageImage?> GetByIdAsync(
		ChatMessageImageId id,
		CancellationToken cancellationToken)
	{
		var cachedEntity = await _messageImageCacheHandler.GetByIdAsync(id);

		if (cachedEntity != null)
		{
			return cachedEntity;
		}

		var entity = await _collection
			.AggregateFluent()
			.Match(id)
			.FirstOrDefaultAsync(cancellationToken);

		if (entity != null)
		{
			await _messageImageCacheHandler.AddAsync(entity);
		}

		return entity;
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
	}

	public async Task AddRangeAsync(IEnumerable<ChatMessageImage> entities, CancellationToken cancellationToken)
	{
		await _collection.AddRangeAsync(entities, cancellationToken);
	}

	public async Task DeleteAsync(ChatMessageImage entity, CancellationToken cancellationToken)
	{
		await _collection.DeleteAsync(entity, cancellationToken);
	}

	public async Task DeleteRangeAsync(IEnumerable<ChatMessageImage> entities, CancellationToken cancellationToken)
	{
		await _collection.DeleteRangeAsync(entities, cancellationToken);
	}
}
