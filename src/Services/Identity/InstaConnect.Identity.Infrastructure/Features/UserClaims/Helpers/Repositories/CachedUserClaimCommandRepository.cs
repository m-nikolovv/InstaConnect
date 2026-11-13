using InstaConnect.Identity.Domain.Features.UserClaims.Abstractions;

namespace InstaConnect.Identity.Infrastructure.Features.UserClaims.Helpers.Repositories;

internal class CachedUserClaimCommandRepository : IUserClaimCommandRepository
{
	private readonly IUserClaimCacheHandler _cacheHandler;
	private readonly IUserClaimCommandRepository _repository;

	public CachedUserClaimCommandRepository(
		IUserClaimCacheHandler cacheHandler,
		IUserClaimCommandRepository repository)
	{
		_repository = repository;
		_cacheHandler = cacheHandler;
	}

	public async Task<UserClaim?> GetByIdAsync(
		UserClaimId id,
		UserClaimInclude include,
		CancellationToken cancellationToken)
	{
		return await _repository.GetByIdAsync(id, include, cancellationToken);
	}

	public async Task<UserClaim?> GetByIdAsync(
		UserClaimId id,
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

	public async Task<ICollection<UserClaim>> GetByIdRangeAsync(
		IEnumerable<UserClaimId> ids,
		CancellationToken cancellationToken)
	{
		return await _repository.GetByIdRangeAsync(ids, cancellationToken);
	}

	public async Task<bool> ExistsByIdAsync(
		UserClaimId id,
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

	public async Task AddAsync(UserClaim entity, CancellationToken cancellationToken)
	{
		await _repository.AddAsync(entity, cancellationToken);
		await _cacheHandler.DeleteAsync(entity.Id, cancellationToken);
	}

	public async Task AddRangeAsync(IEnumerable<UserClaim> entities, CancellationToken cancellationToken)
	{
		await _repository.AddRangeAsync(entities, cancellationToken);
		await _cacheHandler.DeleteRangeAsync(entities.Select(p => p.Id), cancellationToken);
	}

	public async Task DeleteAsync(UserClaim entity, CancellationToken cancellationToken)
	{
		await _repository.DeleteAsync(entity, cancellationToken);
		await _cacheHandler.DeleteAsync(entity.Id, cancellationToken);
	}
}
