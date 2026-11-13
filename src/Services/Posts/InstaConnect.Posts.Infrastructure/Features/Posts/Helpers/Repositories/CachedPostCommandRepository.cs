namespace InstaConnect.Posts.Infrastructure.Features.Posts.Helpers.Repositories;

internal class CachedPostCommandRepository : IPostCommandRepository
{
	private readonly IPostCacheHandler _cacheHandler;
	private readonly IPostCommandRepository _repository;

	public CachedPostCommandRepository(
		IPostCacheHandler cacheHandler,
		IPostCommandRepository repository)
	{
		_repository = repository;
		_cacheHandler = cacheHandler;
	}

	public async Task<Post?> GetByIdAsync(
		PostId id,
		PostInclude include,
		CancellationToken cancellationToken)
	{
		return await _repository.GetByIdAsync(id, include, cancellationToken);
	}

	public async Task<Post?> GetByIdAsync(
		PostId id,
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

	public async Task<ICollection<Post>> GetByIdRangeAsync(
		IEnumerable<PostId> ids,
		PostInclude include,
		CancellationToken cancellationToken)
	{
		return await _repository.GetByIdRangeAsync(ids, include, cancellationToken);
	}

	public async Task<ICollection<Post>> GetByIdRangeAsync(
		IEnumerable<PostId> ids,
		CancellationToken cancellationToken)
	{
		return await _repository.GetByIdRangeAsync(ids, cancellationToken);
	}

	public async Task<bool> ExistsByIdAsync(
		PostId id,
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

	public async Task AddAsync(Post entity, CancellationToken cancellationToken)
	{
		await _repository.AddAsync(entity, cancellationToken);
		await _cacheHandler.DeleteAsync(entity.Id, cancellationToken);
	}

	public async Task AddRangeAsync(IEnumerable<Post> entities, CancellationToken cancellationToken)
	{
		await _repository.AddRangeAsync(entities, cancellationToken);
		await _cacheHandler.DeleteRangeAsync(entities.Select(p => p.Id), cancellationToken);
	}

	public async Task UpdateAsync(Post entity, CancellationToken cancellationToken)
	{
		await _repository.UpdateAsync(entity, cancellationToken);
		await _cacheHandler.DeleteAsync(entity.Id, cancellationToken);
	}

	public async Task DeleteAsync(Post entity, CancellationToken cancellationToken)
	{
		await _repository.DeleteAsync(entity, cancellationToken);
		await _cacheHandler.DeleteAsync(entity.Id, cancellationToken);
	}
}
