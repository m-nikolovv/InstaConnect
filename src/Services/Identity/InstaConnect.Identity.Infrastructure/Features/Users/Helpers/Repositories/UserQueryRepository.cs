using InstaConnect.Identity.Domain.Features.Users.Abstractions;

namespace InstaConnect.Identity.Infrastructure.Features.Users.Helpers.Repositories;

internal class UserQueryRepository : IUserQueryRepository
{
	private readonly IUserCollection _collection;
	private readonly IUserCacheHandler _cacheHandler;

	public UserQueryRepository(
		IUserCollection collection,
		IUserCacheHandler cacheHandler)
	{
		_collection = collection;
		_cacheHandler = cacheHandler;
	}

	public async Task<ICollection<UserResponse>> GetAllAsync(
		UsersFilterQuery filter,
		UsersSortingQuery sorting,
		UsersPaginationQuery pagination,
		CurrentUserQuery current,
		CancellationToken cancellationToken)
	{
		return await _collection
			.AggregateFluent()
			.Match(filter)
			.ApplySorting(sorting)
			.ApplyPagination(pagination)
			.ProjectToFullResponse(current)
			.ToListAsync(cancellationToken);
	}

	public async Task<long> GetTotalCountAsync(
		UsersFilterQuery filter,
		CancellationToken cancellationToken)
	{
		return await _collection
			.AggregateFluent()
			.Match(filter)
			.GetCountAsync(cancellationToken);
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

		var response = await _collection
			.AggregateFluent()
			.Match(id)
			.ProjectToFullResponse(current)
			.FirstOrDefaultAsync(cancellationToken);

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

		var exists = await _collection
			.AggregateFluent()
			.Match(id)
			.AnyAsync(cancellationToken);

		await _cacheHandler.AddExistsByIdAsync(id, exists);

		return exists;
	}
}
