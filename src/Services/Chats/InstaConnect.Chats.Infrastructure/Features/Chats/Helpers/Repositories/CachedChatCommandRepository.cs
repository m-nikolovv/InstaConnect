using InstaConnect.Chats.Domain.Features.Chats.Abstractions;

namespace InstaConnect.Chats.Infrastructure.Features.Chats.Helpers.Repositories;

internal class CachedChatCommandRepository : IChatCommandRepository
{
	private readonly IChatCacheHandler _cacheHandler;
	private readonly IChatCommandRepository _repository;

	public CachedChatCommandRepository(
		IChatCacheHandler cacheHandler,
		IChatCommandRepository repository)
	{
		_repository = repository;
		_cacheHandler = cacheHandler;
	}

	public async Task<Chat?> GetByIdAsync(
		ChatId id,
		ChatInclude include,
		CancellationToken cancellationToken)
	{
		return await _repository.GetByIdAsync(id, include, cancellationToken);
	}

	public async Task<Chat?> GetByIdAsync(
		ChatId id,
		CancellationToken cancellationToken)
	{
		var cachedEntity = await _cacheHandler.GetByIdAsync(id, cancellationToken);

		if (cachedEntity != null)
		{
			return cachedEntity;
		}

		var entity = await _repository.GetByIdAsync(id, cancellationToken);

		if (entity != null)
		{
			await _cacheHandler.AddAsync(entity, cancellationToken);
		}

		return entity;
	}

	public async Task<ICollection<Chat>> GetByIdRangeAsync(
		IEnumerable<ChatId> ids,
		ChatInclude include,
		CancellationToken cancellationToken)
	{
		return await _repository.GetByIdRangeAsync(ids, include, cancellationToken);
	}

	public async Task<ICollection<Chat>> GetByIdRangeAsync(
		IEnumerable<ChatId> ids,
		CancellationToken cancellationToken)
	{
		return await _repository.GetByIdRangeAsync(ids, cancellationToken);
	}

	public async Task<bool> ExistsByIdAsync(
		ChatId id,
		CancellationToken cancellationToken)
	{
		var cachedExists = await _cacheHandler.ExistsByIdAsync(id, cancellationToken);

		if (cachedExists != null)
		{
			return cachedExists.Value;
		}

		var exists = await _repository.ExistsByIdAsync(id, cancellationToken);

		await _cacheHandler.AddExistsByIdAsync(id, exists, cancellationToken);

		return exists;
	}

	public async Task AddAsync(Chat entity, CancellationToken cancellationToken)
	{
		await _repository.AddAsync(entity, cancellationToken);
		await _cacheHandler.DeleteAsync(entity.Id, cancellationToken);
	}

	public async Task AddRangeAsync(IEnumerable<Chat> entities, CancellationToken cancellationToken)
	{
		await _repository.AddRangeAsync(entities, cancellationToken);
		await _cacheHandler.DeleteRangeAsync(entities.Select(p => p.Id), cancellationToken);
	}

	public async Task DeleteAsync(Chat entity, CancellationToken cancellationToken)
	{
		await _repository.DeleteAsync(entity, cancellationToken);
		await _cacheHandler.DeleteAsync(entity.Id, cancellationToken);
	}
}
