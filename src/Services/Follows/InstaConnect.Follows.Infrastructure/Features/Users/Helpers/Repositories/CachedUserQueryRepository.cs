using InstaConnect.Follows.Domain.Features.Users.Abstractions;

namespace InstaConnect.Follows.Infrastructure.Features.Users.Helpers.Repositories;

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

	public async Task<UserResponse?> GetByIdAsync(
		UserId id,
		CurrentUserQuery currentUser,
		CancellationToken cancellationToken)
	{
		var cachedResponse = await _cacheHandler.GetByIdAsync(id, currentUser, cancellationToken);

		if (cachedResponse != null)
		{
			return cachedResponse;
		}

		var response = await _repository.GetByIdAsync(id, currentUser, cancellationToken);

		if (response != null)
		{
			await _cacheHandler.AddAsync(response, currentUser, cancellationToken);
		}

		return response;
	}

	public async Task<bool> ExistsByIdAsync(
		UserId id,
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
}
