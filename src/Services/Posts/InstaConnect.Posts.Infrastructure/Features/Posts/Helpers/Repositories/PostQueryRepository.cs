namespace InstaConnect.Posts.Infrastructure.Features.Posts.Helpers.Repositories;

internal class PostQueryRepository : IPostQueryRepository
{
	private readonly IPostCollection _collection;
	private readonly IPostIncludeBuilderFactory _includeBuilderFactory;

	public PostQueryRepository(
		IPostCollection collection,
		IPostIncludeBuilderFactory includeBuilderFactory)
	{
		_collection = collection;
		_includeBuilderFactory = includeBuilderFactory;
	}

	public async Task<ICollection<PostResponse>> GetAllAsync(
		PostsFilterQuery filter,
		PostsSortingQuery sorting,
		PostsPaginationQuery pagination,
		CurrentUserQuery currentUser,
		CancellationToken cancellationToken)
	{
		var include = _includeBuilderFactory.Create().WithUser().WithPostLikes().WithPostImages().Build();

		return await _collection
			.AggregateFluent()
			.ApplyIncludes(include)
			.Match(filter)
			.ProjectToFullResponse(currentUser)
			.ApplySorting(sorting)
			.ApplyPagination(pagination)
			.ToListAsync(cancellationToken);
	}

	public async Task<ICollection<PostResponse>> GetAllForUserAsync(
		PostsForUserFilterQuery filter,
		PostsForUserSortingQuery sorting,
		PostsPaginationQuery pagination,
		CurrentUserQuery currentUser,
		CancellationToken cancellationToken)
	{
		var include = _includeBuilderFactory.Create().WithPostLikes().WithPostImages().Build();

		return await _collection
			.AggregateFluent()
			.ApplyIncludes(include)
			.Match(filter)
			.ProjectToResponseWithoutUser(currentUser)
			.ApplySorting(sorting)
			.ApplyPagination(pagination)
			.ToListAsync(cancellationToken);
	}

	public async Task<long> GetTotalCountAsync(
		PostsFilterQuery filter,
		CancellationToken cancellationToken)
	{
		var include = _includeBuilderFactory.Create().WithUser().WithPostLikes().WithPostImages().Build();

		return await _collection
			.AggregateFluent()
			.ApplyIncludes(include)
			.Match(filter)
			.GetCountAsync(cancellationToken);
	}

	public async Task<long> GetTotalCountForUserAsync(
		PostsForUserFilterQuery filter,
		CancellationToken cancellationToken)
	{
		var include = _includeBuilderFactory.Create().WithPostLikes().WithPostImages().Build();

		return await _collection
			.AggregateFluent()
			.ApplyIncludes(include)
			.Match(filter)
			.GetCountAsync(cancellationToken);
	}

	public async Task<PostResponse?> GetByIdAsync(
		PostId id,
		CurrentUserQuery currentUser,
		CancellationToken cancellationToken)
	{
		var include = _includeBuilderFactory.Create().WithUser().WithPostLikes().WithPostImages().Build();

		return await _collection
			.AggregateFluent()
			.ApplyIncludes(include)
			.Match(id)
			.ProjectToFullResponse(currentUser)
			.FirstOrDefaultAsync(cancellationToken);
	}

	public async Task<bool> ExistsByIdAsync(
		PostId id,
		CancellationToken cancellationToken)
	{
		return await _collection
			.AggregateFluent()
			.Match(id)
			.AnyAsync(cancellationToken);
	}
}
