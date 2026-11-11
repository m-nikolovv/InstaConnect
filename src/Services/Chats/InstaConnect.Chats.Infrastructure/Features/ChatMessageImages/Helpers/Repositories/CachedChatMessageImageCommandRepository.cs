using InstaConnect.Chats.Domain.Features.ChatMessageImages.Abstractions;
using InstaConnect.Chats.Infrastructure.Features.ChatMessageImages.Abstractions;

namespace InstaConnect.Chats.Infrastructure.Features.ChatMessageImages.Helpers.Repositories;

internal class CachedChatMessageImageCommandRepository : IChatMessageImageCommandRepository
{
	private readonly IChatMessageCacheHandler _messageCacheHandler;
	private readonly IChatMessageImageCommandRepository _repository;
	private readonly IChatMessageImageCacheHandler _messageImageCacheHandler;

	public CachedChatMessageImageCommandRepository(
		IChatMessageCacheHandler messageCacheHandler,
		IChatMessageImageCommandRepository repository,
		IChatMessageImageCacheHandler messageImageCacheHandler)
	{
		_repository = repository;
		_messageCacheHandler = messageCacheHandler;
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

		var entity = await _repository.GetByIdAsync(id, cancellationToken);

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
		return await _repository.GetByIdRangeAsync(ids, cancellationToken);
	}

	public async Task AddAsync(ChatMessageImage entity, CancellationToken cancellationToken)
	{
		await _repository.AddAsync(entity, cancellationToken);
		await _messageCacheHandler.DeleteResponseAsync(entity.Id.Id);
		await _messageImageCacheHandler.DeleteAsync(entity.Id);
	}

	public async Task AddRangeAsync(IEnumerable<ChatMessageImage> entities, CancellationToken cancellationToken)
	{
		await _repository.AddRangeAsync(entities, cancellationToken);
		await _messageCacheHandler.DeleteResponseRangeAsync(entities.Select(p => p.Id.Id));
		await _messageImageCacheHandler.DeleteRangeAsync(entities.Select(p => p.Id));
	}

	public async Task DeleteAsync(ChatMessageImage entity, CancellationToken cancellationToken)
	{
		await _repository.DeleteAsync(entity, cancellationToken);
		await _messageCacheHandler.DeleteResponseAsync(entity.Id.Id);
		await _messageImageCacheHandler.DeleteAsync(entity.Id);
	}

	public async Task DeleteRangeAsync(IEnumerable<ChatMessageImage> entities, CancellationToken cancellationToken)
	{
		await _repository.DeleteRangeAsync(entities, cancellationToken);
		await _messageCacheHandler.DeleteResponseRangeAsync(entities.Select(p => p.Id.Id));
		await _messageImageCacheHandler.DeleteRangeAsync(entities.Select(p => p.Id));
	}
}
