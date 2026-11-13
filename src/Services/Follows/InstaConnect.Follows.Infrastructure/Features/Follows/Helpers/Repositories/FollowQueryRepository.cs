using InstaConnect.Follows.Domain.Features.Follows.Abstractions;

namespace InstaConnect.Follows.Infrastructure.Features.Follows.Helpers.Repositories;

internal class FollowQueryRepository : IFollowQueryRepository
{
	private readonly IFollowCollection _collection;
	private readonly IFollowIncludeBuilderFactory _includeBuilderFactory;

	public FollowQueryRepository(
		IFollowCollection collection,
		IFollowIncludeBuilderFactory includeBuilderFactory)
	{
		_collection = collection;
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
			.Include(include)
			.Match(filter)
			.ProjectToResponseWithoutFollower(currentUser)
			.Sort(sorting)
			.Paginate(pagination)
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
			.Include(include)
			.Match(filter)
			.ProjectToResponseWithoutFollowing(currentUser)
			.Sort(sorting)
			.Paginate(pagination)
			.ToListAsync(cancellationToken);
	}

	public async Task<long> GetTotalCountAsync(
		FollowsFilterQuery filter,
		CancellationToken cancellationToken)
	{
		var include = _includeBuilderFactory.Create().WithFollowing().Build();

		return await _collection
			.AggregateFluent()
			.Include(include)
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
			.Include(include)
			.Match(filter)
			.GetCountAsync(cancellationToken);
	}

	public async Task<FollowResponse?> GetByIdAsync(
		FollowId id,
		CurrentUserQuery currentUser,
		CancellationToken cancellationToken)
	{
		var include = _includeBuilderFactory.Create().WithFollower().WithFollowing().Build();

		return await _collection
			.AggregateFluent()
			.Match(id)
			.Include(include)
			.ProjectToFullResponse(currentUser)
			.FirstOrDefaultAsync(cancellationToken);
	}

	public async Task<bool> ExistsByIdAsync(
		FollowId id,
		CancellationToken cancellationToken)
	{
		return await _collection
			.AggregateFluent()
			.Match(id)
			.AnyAsync(cancellationToken);
	}
}
