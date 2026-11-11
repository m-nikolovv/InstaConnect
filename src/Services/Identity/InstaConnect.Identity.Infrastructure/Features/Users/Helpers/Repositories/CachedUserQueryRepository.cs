using InstaConnect.Identity.Domain.Features.Users.Abstractions;

namespace InstaConnect.Identity.Infrastructure.Features.Users.Helpers.Repositories;

internal class CachedUserQueryRepository : IUserQueryRepository
{
	private readonly IUserCacheHandler _cacheHandler;
	private readonly IUserQueryRepository _repository;

	public CachedUserQueryRepository(
		IUserCacheHandler cacheHandler,
		IUserQueryRepository repository)
	{
		_repository = repository;
		_cacheHandler = cacheHandler;
	}

	public async Task<ICollection<UserResponse>> GetAllAsync(
		UsersFilterQuery filter,
		UsersSortingQuery sorting,
		UsersPaginationQuery pagination,
		CurrentUserQuery current,
		CancellationToken cancellationToken)
	{
		return await _repository.GetAllAsync(filter, sorting, pagination, current, cancellationToken);
	}

	public async Task<long> GetTotalCountAsync(
		UsersFilterQuery filter,
		CancellationToken cancellationToken)
	{
		return await _repository.GetTotalCountAsync(filter, cancellationToken);
	}

	public async Task<UserResponse?> GetByIdAsync(
		UserId id,
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
		UserId id,
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
