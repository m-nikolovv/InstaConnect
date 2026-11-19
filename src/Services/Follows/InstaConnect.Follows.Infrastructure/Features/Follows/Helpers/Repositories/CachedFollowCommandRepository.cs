using InstaConnect.Follows.Domain.Features.Follows.Abstractions;

namespace InstaConnect.Follows.Infrastructure.Features.Follows.Helpers.Repositories;

internal class CachedFollowCommandRepository : IFollowCommandRepository
{
	private readonly IFollowCacheHandler _cacheHandler;
	private readonly IFollowCommandRepository _repository;

	public CachedFollowCommandRepository(
		IFollowCacheHandler cacheHandler,
		IFollowCommandRepository repository)
	{
		_repository = repository;
		_cacheHandler = cacheHandler;
	}

	public async Task<Follow?> GetByIdAsync(
		FollowId id,
		FollowInclude include,
		CancellationToken cancellationToken)
	{
		return await _repository.GetByIdAsync(id, include, cancellationToken);
	}

	public async Task<Follow?> GetByIdAsync(
		FollowId id,
		CancellationToken cancellationToken)
	{
		return await _repository.GetByIdAsync(id, cancellationToken);
	}

	public async Task<ICollection<Follow>> GetByIdRangeAsync(
		IEnumerable<FollowId> ids,
		FollowInclude include,
		CancellationToken cancellationToken)
	{
		return await _repository.GetByIdRangeAsync(ids, include, cancellationToken);
	}

	public async Task<ICollection<Follow>> GetByIdRangeAsync(
		IEnumerable<FollowId> ids,
		CancellationToken cancellationToken)
	{
		return await _repository.GetByIdRangeAsync(ids, cancellationToken);
	}

	public async Task<bool> ExistsByIdAsync(
		FollowId id,
		CancellationToken cancellationToken)
	{
		return await _repository.ExistsByIdAsync(id, cancellationToken);
	}

	public async Task AddAsync(Follow entity, CancellationToken cancellationToken)
	{
		await _repository.AddAsync(entity, cancellationToken);
	}

	public async Task AddRangeAsync(IEnumerable<Follow> entities, CancellationToken cancellationToken)
	{
		await _repository.AddRangeAsync(entities, cancellationToken);
	}

	public async Task DeleteAsync(Follow entity, CancellationToken cancellationToken)
	{
		await _repository.DeleteAsync(entity, cancellationToken);
		await _cacheHandler.DeleteAsync(entity.Id, cancellationToken);
	}
}
