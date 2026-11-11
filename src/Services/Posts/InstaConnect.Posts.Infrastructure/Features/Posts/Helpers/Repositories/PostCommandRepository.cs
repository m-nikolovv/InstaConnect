namespace InstaConnect.Posts.Infrastructure.Features.Posts.Helpers.Repositories;

internal class PostCommandRepository : IPostCommandRepository
{
	private readonly IPostCollection _collection;
	private readonly IPostCacheHandler _cacheHandler;
	private readonly IPostIncludeBuilderFactory _includeBuilderFactory;

	public PostCommandRepository(
		IPostCollection collection,
		IPostCacheHandler cacheHandler,
		IPostIncludeBuilderFactory includeBuilderFactory)
	{
		_collection = collection;
		_cacheHandler = cacheHandler;
		_includeBuilderFactory = includeBuilderFactory;
	}

	public async Task<Post?> GetByIdAsync(
		PostId id,
		PostInclude include,
		CancellationToken cancellationToken)
	{
		return await _collection
			.AggregateFluent()
			.Match(id)
			.ApplyIncludes(include)
			.FirstOrDefaultAsync(cancellationToken);
	}

	public async Task<Post?> GetByIdAsync(
		PostId id,
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

	public async Task<ICollection<Post>> GetByIdRangeAsync(
		IEnumerable<PostId> ids,
		PostInclude include,
		CancellationToken cancellationToken)
	{
		return await _collection
			.AggregateFluent()
			.Match(ids)
			.ApplyIncludes(include)
			.ToListAsync(cancellationToken);
	}

	public async Task<ICollection<Post>> GetByIdRangeAsync(
		IEnumerable<PostId> ids,
		CancellationToken cancellationToken)
	{
		var include = _includeBuilderFactory.Create().Build();

		return await GetByIdRangeAsync(ids, include, cancellationToken);
	}

	public async Task<bool> ExistsByIdAsync(
		PostId id,
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

	public async Task AddAsync(Post entity, CancellationToken cancellationToken)
	{
		await _collection.AddAsync(entity, cancellationToken);
	}

	public async Task AddRangeAsync(IEnumerable<Post> entities, CancellationToken cancellationToken)
	{
		await _collection.AddRangeAsync(entities, cancellationToken);
	}

	public async Task UpdateAsync(Post entity, CancellationToken cancellationToken)
	{
		await _collection.UpdateAsync(entity, cancellationToken);
	}

	public async Task DeleteAsync(Post entity, CancellationToken cancellationToken)
	{
		await _collection.DeleteAsync(entity, cancellationToken);
	}
}
