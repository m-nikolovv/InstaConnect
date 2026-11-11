using InstaConnect.Follows.Domain.Features.Follows.Abstractions;

namespace InstaConnect.Follows.Infrastructure.Features.Follows.Helpers.Repositories;

internal class FollowQueryRepository : IFollowQueryRepository
{
	private readonly IFollowCollection _collection;
	private readonly IFollowCacheHandler _cacheHandler;
	private readonly IFollowIncludeBuilderFactory _includeBuilderFactory;

	public FollowQueryRepository(
		IFollowCollection collection,
		IFollowCacheHandler cacheHandler,
		IFollowIncludeBuilderFactory includeBuilderFactory)
	{
		_collection = collection;
		_cacheHandler = cacheHandler;
		_includeBuilderFactory = includeBuilderFactory;
	}

	public async Task<ICollection<FollowResponse>> GetAllAsync(
		FollowsFilterQuery filter,
		FollowsSortingQuery sorting,
		FollowsPaginationQuery pagination,
		CurrentUserQuery currentUser,
		CancellationToken cancellationToken)
	{
		var include = _includeBuilderFactory.Create().WithFollowing().Build();

		return await _collection
			.AggregateFluent()
			.ApplyIncludes(include)
			.Match(filter)
			.ApplySorting(sorting)
			.ApplyPagination(pagination)
			.ProjectToResponseWithoutFollower(currentUser)
			.ToListAsync(cancellationToken);
	}

	public async Task<ICollection<FollowResponse>> GetAllForFollowingAsync(
		FollowsForFollowingFilterQuery filter,
		FollowsForFollowingSortingQuery sorting,
		FollowsPaginationQuery pagination,
		CurrentUserQuery currentUser,
		CancellationToken cancellationToken)
	{
		var include = _includeBuilderFactory.Create().WithFollower().Build();

		return await _collection
			.AggregateFluent()
			.ApplyIncludes(include)
			.Match(filter)
			.ApplySorting(sorting)
			.ApplyPagination(pagination)
			.ProjectToResponseWithoutFollowing(currentUser)
			.ToListAsync(cancellationToken);
	}

	public async Task<long> GetTotalCountAsync(
		FollowsFilterQuery filter,
		CancellationToken cancellationToken)
	{
		var include = _includeBuilderFactory.Create().WithFollowing().Build();

		return await _collection
			.AggregateFluent()
			.ApplyIncludes(include)
			.Match(filter)
			.GetCountAsync(cancellationToken);
	}

	public async Task<long> GetTotalCountForFollowingAsync(
		FollowsForFollowingFilterQuery filter,
		CancellationToken cancellationToken)
	{
		var include = _includeBuilderFactory.Create().WithFollower().Build();

		return await _collection
			.AggregateFluent()
			.ApplyIncludes(include)
			.Match(filter)
			.GetCountAsync(cancellationToken);
	}

	public async Task<FollowResponse?> GetByIdAsync(
		FollowId id,
		CurrentUserQuery currentUser,
		CancellationToken cancellationToken)
	{
		var cachedResponse = await _cacheHandler.GetByIdAsync(id, currentUser);

		if (cachedResponse != null)
		{
			return cachedResponse;
		}

		var include = _includeBuilderFactory.Create().WithFollower().WithFollowing().Build();

		var response = await _collection
			.AggregateFluent()
			.Match(id)
			.ApplyIncludes(include)
			.ProjectToFullResponse(currentUser)
			.FirstOrDefaultAsync(cancellationToken);

		if (response != null)
		{
			await _cacheHandler.AddAsync(response, currentUser);
		}

		return response;
	}

	public async Task<bool> ExistsByIdAsync(
		FollowId id,
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
