using InstaConnect.Chats.Domain.Features.ChatMessages.Abstractions;

namespace InstaConnect.Chats.Infrastructure.Features.ChatMessages.Helpers.Repositories;

internal class CachedChatMessageCommandRepository : IChatMessageCommandRepository
{
	private readonly IChatCacheHandler _cacheHandler;
	private readonly IChatMessageCommandRepository _repository;
	private readonly IChatMessageCacheHandler _messageCacheHandler;

	public CachedChatMessageCommandRepository(
		IChatCacheHandler cacheHandler,
		IChatMessageCommandRepository repository,
		IChatMessageCacheHandler messageCacheHandler)
	{
		_repository = repository;
		_cacheHandler = cacheHandler;
		_messageCacheHandler = messageCacheHandler;
	}

	public async Task<ChatMessage?> GetByIdAsync(
		ChatMessageId id,
		ChatMessageInclude include,
		CancellationToken cancellationToken)
	{
		return await _repository.GetByIdAsync(id, include, cancellationToken);
	}

	public async Task<ChatMessage?> GetByIdAsync(
		ChatMessageId id,
		CancellationToken cancellationToken)
	{
		var cachedEntity = await _messageCacheHandler.GetByIdAsync(id, cancellationToken);

		if (cachedEntity != null)
		{
			return cachedEntity;
		}

		var entity = await _repository.GetByIdAsync(id, cancellationToken);

		if (entity != null)
		{
			await _messageCacheHandler.AddAsync(entity, cancellationToken);
		}

		return entity;
	}

	public async Task<ICollection<ChatMessage>> GetByIdRangeAsync(
		IEnumerable<ChatMessageId> ids,
		ChatMessageInclude include,
		CancellationToken cancellationToken)
	{
		return await _repository.GetByIdRangeAsync(ids, include, cancellationToken);
	}

	public async Task<ICollection<ChatMessage>> GetByIdRangeAsync(
		IEnumerable<ChatMessageId> ids,
		CancellationToken cancellationToken)
	{
		return await _repository.GetByIdRangeAsync(ids, cancellationToken);
	}

	public async Task<bool> ExistsByIdAsync(
		ChatMessageId id,
		CancellationToken cancellationToken)
	{
		var cachedExists = await _messageCacheHandler.ExistsByIdAsync(id, cancellationToken);

		if (cachedExists != null)
		{
			return cachedExists.Value;
		}

		var exists = await _repository.ExistsByIdAsync(id, cancellationToken);

		await _messageCacheHandler.AddExistsByIdAsync(id, exists, cancellationToken);

		return exists;
	}

	public async Task AddAsync(ChatMessage entity, CancellationToken cancellationToken)
	{
		await _repository.AddAsync(entity, cancellationToken);
		await _cacheHandler.DeleteResponseAsync(entity.Id.Id, cancellationToken);
		await _messageCacheHandler.DeleteAsync(entity.Id, cancellationToken);
	}

	public async Task AddRangeAsync(IEnumerable<ChatMessage> entities, CancellationToken cancellationToken)
	{
		await _repository.AddRangeAsync(entities, cancellationToken);
		await _cacheHandler.DeleteResponseRangeAsync(entities.Select(p => p.Id.Id), cancellationToken);
		await _messageCacheHandler.DeleteRangeAsync(entities.Select(p => p.Id), cancellationToken);
	}

	public async Task UpdateAsync(ChatMessage entity, CancellationToken cancellationToken)
	{
		await _repository.UpdateAsync(entity, cancellationToken);
		await _messageCacheHandler.DeleteAsync(entity.Id, cancellationToken);
	}

	public async Task DeleteAsync(ChatMessage entity, CancellationToken cancellationToken)
	{
		await _repository.DeleteAsync(entity, cancellationToken);
		await _cacheHandler.DeleteResponseAsync(entity.Id.Id, cancellationToken);
		await _messageCacheHandler.DeleteAsync(entity.Id, cancellationToken);
	}
}
