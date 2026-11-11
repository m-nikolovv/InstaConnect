using InstaConnect.Identity.Domain.Features.UserClaims.Abstractions;

namespace InstaConnect.Identity.Infrastructure.Features.UserClaims.Helpers.Repositories;

internal class CachedUserClaimQueryRepository : IUserClaimQueryRepository
{
	private readonly IUserClaimCacheHandler _cacheHandler;
	private readonly IUserClaimQueryRepository _repository;

	public CachedUserClaimQueryRepository(
		IUserClaimCacheHandler cacheHandler,
		IUserClaimQueryRepository repository)
	{
		_repository = repository;
		_cacheHandler = cacheHandler;
	}

	public async Task<ICollection<UserClaimResponse>> GetAllAsync(
		UserClaimsFilterQuery filter,
		UserClaimsSortingQuery sorting,
		UserClaimsPaginationQuery pagination,
		CurrentUserQuery current,
		CancellationToken cancellationToken)
	{
		return await _repository.GetAllAsync(filter, sorting, pagination, current, cancellationToken);
	}

	public async Task<long> GetTotalCountAsync(
		UserClaimsFilterQuery filter,
		CancellationToken cancellationToken)
	{
		return await _repository.GetTotalCountAsync(filter, cancellationToken);
	}

	public async Task<UserClaimResponse?> GetByIdAsync(
		UserClaimId id,
		CurrentUserQuery current,
		CancellationToken cancellationToken)
	{
		var cachedResponse = await _cacheHandler.GetByIdAsync(id, current);

		if (cachedResponse != null)
		{
			return cachedResponse;
		}

		var response = await _repository.GetByIdAsync(id, current, cancellationToken);

		if (response != null)
		{
			await _cacheHandler.AddAsync(response, current);
		}

		return response;
	}

	public async Task<bool> ExistsByIdAsync(
		UserClaimId id,
		CancellationToken cancellationToken)
	{
		var cachedExists = await _cacheHandler.ExistsByIdAsync(id);

		if (cachedExists != null)
		{
			return cachedExists.Value;
		}

		var exists = await _repository.ExistsByIdAsync(id, cancellationToken);

		await _cacheHandler.AddExistsByIdAsync(id, exists);

		return exists;
	}
}
