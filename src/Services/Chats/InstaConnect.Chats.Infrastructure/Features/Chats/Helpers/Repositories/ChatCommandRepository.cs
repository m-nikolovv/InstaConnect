using InstaConnect.Chats.Domain.Features.Chats.Abstractions;

namespace InstaConnect.Chats.Infrastructure.Features.Chats.Helpers.Repositories;

internal class ChatCommandRepository : IChatCommandRepository
{
	private readonly IChatCollection _collection;
	private readonly IChatCacheHandler _cacheHandler;
	private readonly IChatIncludeBuilderFactory _includeBuilderFactory;

	public ChatCommandRepository(
		IChatCollection collection,
		IChatCacheHandler cacheHandler,
		IChatIncludeBuilderFactory includeBuilderFactory)
	{
		_collection = collection;
		_cacheHandler = cacheHandler;
		_includeBuilderFactory = includeBuilderFactory;
	}

	public async Task<Chat?> GetByIdAsync(
		ChatId id,
		ChatInclude include,
		CancellationToken cancellationToken)
	{
		return await _collection
			.AggregateFluent()
			.Match(id)
			.ApplyIncludes(include)
			.FirstOrDefaultAsync(cancellationToken);
	}

	public async Task<Chat?> GetByIdAsync(
		ChatId id,
		CancellationToken cancellationToken)
	{
		var cachedEntity = await _cacheHandler.GetByIdAsync(id);

		if (cachedEntity != null)
		{
			return cachedEntity;
		}

		var include = _includeBuilderFactory.Create().Build();

		var entity = await GetByIdAsync(id, include, cancellationToken);

		if (entity != null)
		{
			await _cacheHandler.AddAsync(entity);
		}

		return entity;
	}

	public async Task<ICollection<Chat>> GetByIdRangeAsync(
		IEnumerable<ChatId> ids,
		ChatInclude include,
		CancellationToken cancellationToken)
	{
		return await _collection
			.AggregateFluent()
			.Match(ids)
			.ApplyIncludes(include)
			.ToListAsync(cancellationToken);
	}

	public async Task<ICollection<Chat>> GetByIdRangeAsync(
		IEnumerable<ChatId> ids,
		CancellationToken cancellationToken)
	{
		var include = _includeBuilderFactory.Create().Build();

		return await GetByIdRangeAsync(ids, include, cancellationToken);
	}

	public async Task<bool> ExistsByIdAsync(
		ChatId id,
		CancellationToken cancellationToken)
	{
		var cachedExists = await _cacheHandler.ExistsByIdAsync(id);

		if (cachedExists != null)
		{
			return cachedExists.Value;
		}

		var exists = await _collection
			.AggregateFluent()
			.Match(id)
			.AnyAsync(cancellationToken);

		await _cacheHandler.AddExistsByIdAsync(id, exists);

		return exists;
	}

	public async Task AddAsync(Chat entity, CancellationToken cancellationToken)
	{
		await _collection.AddAsync(entity, cancellationToken);
	}

	public async Task AddRangeAsync(IEnumerable<Chat> entities, CancellationToken cancellationToken)
	{
		await _collection.AddRangeAsync(entities, cancellationToken);
	}

	public async Task DeleteAsync(Chat entity, CancellationToken cancellationToken)
	{
		await _collection.DeleteAsync(entity, cancellationToken);
	}
}
