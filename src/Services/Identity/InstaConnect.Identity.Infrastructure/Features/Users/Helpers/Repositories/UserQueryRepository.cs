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
			.ProjectToFullResponse(current)
			.Sort(sorting)
			.Paginate(pagination)
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
		var cachedResponse = await _cacheHandler.GetByIdAsync(id, current.Id, cancellationToken);

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
			await _cacheHandler.AddAsync(response, current.Id, cancellationToken);
		}

		return response;
	}

	public async Task<bool> ExistsByIdAsync(
		UserId id,
		CancellationToken cancellationToken)
	{
		return await _collection
			.AggregateFluent()
			.Match(id)
			.AnyAsync(cancellationToken);
	}
}
