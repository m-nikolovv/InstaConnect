using InstaConnect.Chats.Domain.Features.ChatMessages.Abstractions;

namespace InstaConnect.Chats.Infrastructure.Features.ChatMessages.Helpers.Repositories;

internal class ChatMessageCommandRepository : IChatMessageCommandRepository
{
	private readonly IChatMessageCollection _collection;
	private readonly IChatMessageCacheHandler _messageCacheHandler;
	private readonly IChatMessageIncludeBuilderFactory _includeBuilderFactory;

	public ChatMessageCommandRepository(
		IChatMessageCollection collection,
		IChatMessageCacheHandler messageCacheHandler,
		IChatMessageIncludeBuilderFactory includeBuilderFactory)
	{
		_collection = collection;
		_messageCacheHandler = messageCacheHandler;
		_includeBuilderFactory = includeBuilderFactory;
	}

	public async Task<ChatMessage?> GetByIdAsync(
		ChatMessageId id,
		ChatMessageInclude include,
		CancellationToken cancellationToken)
	{
		return await _collection
			.AggregateFluent()
			.Match(id)
			.ApplyIncludes(include)
			.FirstOrDefaultAsync(cancellationToken);
	}

	public async Task<ChatMessage?> GetByIdAsync(
		ChatMessageId id,
		CancellationToken cancellationToken)
	{
		var cachedEntity = await _messageCacheHandler.GetByIdAsync(id);

		if (cachedEntity != null)
		{
			return cachedEntity;
		}

		var include = _includeBuilderFactory.Create().Build();

		var entity = await GetByIdAsync(id, include, cancellationToken);

		if (entity != null)
		{
			await _messageCacheHandler.AddAsync(entity);
		}

		return entity;
	}

	public async Task<ICollection<ChatMessage>> GetByIdRangeAsync(
		IEnumerable<ChatMessageId> ids,
		ChatMessageInclude include,
		CancellationToken cancellationToken)
	{
		return await _collection
			.AggregateFluent()
			.Match(ids)
			.ApplyIncludes(include)
			.ToListAsync(cancellationToken);
	}

	public async Task<ICollection<ChatMessage>> GetByIdRangeAsync(
		IEnumerable<ChatMessageId> ids,
		CancellationToken cancellationToken)
	{
		var include = _includeBuilderFactory.Create().Build();

		return await GetByIdRangeAsync(ids, include, cancellationToken);
	}

	public async Task<bool> ExistsByIdAsync(
		ChatMessageId id,
		CancellationToken cancellationToken)
	{
		var cachedExists = await _messageCacheHandler.ExistsByIdAsync(id);

		if (cachedExists != null)
		{
			return cachedExists.Value;
		}

		var exists = await _collection
			.AggregateFluent()
			.Match(id)
			.AnyAsync(cancellationToken);

		await _messageCacheHandler.AddExistsByIdAsync(id, exists);

		return exists;
	}

	public async Task AddAsync(ChatMessage entity, CancellationToken cancellationToken)
	{
		await _collection.AddAsync(entity, cancellationToken);
	}

	public async Task AddRangeAsync(IEnumerable<ChatMessage> entities, CancellationToken cancellationToken)
	{
		await _collection.AddRangeAsync(entities, cancellationToken);
	}

	public async Task UpdateAsync(ChatMessage entity, CancellationToken cancellationToken)
	{
		await _collection.UpdateAsync(entity, cancellationToken);
	}

	public async Task DeleteAsync(ChatMessage entity, CancellationToken cancellationToken)
	{
		await _collection.DeleteAsync(entity, cancellationToken);
	}
}
