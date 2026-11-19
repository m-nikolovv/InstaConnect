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
		return await _repository.GetByIdAsync(id, cancellationToken);
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
		return await _repository.ExistsByIdAsync(id, cancellationToken);
	}

	public async Task AddAsync(UserClaim entity, CancellationToken cancellationToken)
	{
		await _repository.AddAsync(entity, cancellationToken);
	}

	public async Task AddRangeAsync(IEnumerable<UserClaim> entities, CancellationToken cancellationToken)
	{
		await _repository.AddRangeAsync(entities, cancellationToken);
	}

	public async Task DeleteAsync(UserClaim entity, CancellationToken cancellationToken)
	{
		await _repository.DeleteAsync(entity, cancellationToken);
		await _cacheHandler.DeleteAsync(entity.Id, cancellationToken);
	}
}
