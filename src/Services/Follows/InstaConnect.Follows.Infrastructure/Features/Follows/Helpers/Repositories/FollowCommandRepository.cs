using InstaConnect.Follows.Domain.Features.Follows.Abstractions;

namespace InstaConnect.Follows.Infrastructure.Features.Follows.Helpers.Repositories;

internal class FollowCommandRepository : IFollowCommandRepository
{
	private readonly IFollowCollection _collection;
	private readonly IFollowCacheHandler _cacheHandler;
	private readonly IFollowIncludeBuilderFactory _includeBuilderFactory;

	public FollowCommandRepository(
		IFollowCollection collection,
		IFollowCacheHandler cacheHandler,
		IFollowIncludeBuilderFactory includeBuilderFactory)
	{
		_collection = collection;
		_cacheHandler = cacheHandler;
		_includeBuilderFactory = includeBuilderFactory;
	}

	public async Task<Follow?> GetByIdAsync(
		FollowId id,
		FollowInclude include,
		CancellationToken cancellationToken)
	{
		return await _collection
			.AggregateFluent()
			.Match(id)
			.ApplyIncludes(include)
			.FirstOrDefaultAsync(cancellationToken);
	}

	public async Task<Follow?> GetByIdAsync(
		FollowId id,
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

	public async Task<ICollection<Follow>> GetByIdRangeAsync(
		IEnumerable<FollowId> ids,
		FollowInclude include,
		CancellationToken cancellationToken)
	{
		return await _collection
			.AggregateFluent()
			.Match(ids)
			.ApplyIncludes(include)
			.ToListAsync(cancellationToken);
	}

	public async Task<ICollection<Follow>> GetByIdRangeAsync(
		IEnumerable<FollowId> ids,
		CancellationToken cancellationToken)
	{
		var include = _includeBuilderFactory.Create().Build();

		return await GetByIdRangeAsync(ids, include, cancellationToken);
	}

	public async Task<bool> ExistsByIdAsync(
		FollowId id,
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

	public async Task AddAsync(Follow entity, CancellationToken cancellationToken)
	{
		await _collection.AddAsync(entity, cancellationToken);
	}

	public async Task AddRangeAsync(IEnumerable<Follow> entities, CancellationToken cancellationToken)
	{
		await _collection.AddRangeAsync(entities, cancellationToken);
	}

	public async Task DeleteAsync(Follow entity, CancellationToken cancellationToken)
	{
		await _collection.DeleteAsync(entity, cancellationToken);
	}
}
