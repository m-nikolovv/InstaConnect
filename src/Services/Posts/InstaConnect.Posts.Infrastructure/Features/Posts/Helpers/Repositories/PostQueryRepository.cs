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
		var include = _includeBuilderFactory.Create().WithUser().WithPostLikes().WithPostComments().WithPostImages().Build();

		return await _collection
			.AggregateFluent()
			.Include(include)
			.Match(filter)
			.ProjectToFullResponse(currentUser)
			.Sort(sorting)
			.Paginate(pagination)
			.ToListAsync(cancellationToken);
	}

	public async Task<ICollection<PostResponse>> GetAllForUserAsync(
		PostsForUserFilterQuery filter,
		PostsForUserSortingQuery sorting,
		PostsPaginationQuery pagination,
		CurrentUserQuery currentUser,
		CancellationToken cancellationToken)
	{
		var include = _includeBuilderFactory.Create().WithPostLikes().WithPostComments().WithPostImages().Build();

		return await _collection
			.AggregateFluent()
			.Match(filter)
			.Include(include)
			.ProjectToResponseWithoutUser(currentUser)
			.Sort(sorting)
			.Paginate(pagination)
			.ToListAsync(cancellationToken);
	}

	public async Task<long> GetTotalCountAsync(
		PostsFilterQuery filter,
		CancellationToken cancellationToken)
	{
		var include = _includeBuilderFactory.Create().WithUser().Build();

		return await _collection
			.AggregateFluent()
			.Include(include)
			.Match(filter)
			.GetCountAsync(cancellationToken);
	}

	public async Task<long> GetTotalCountForUserAsync(
		PostsForUserFilterQuery filter,
		CancellationToken cancellationToken)
	{
		return await _collection
			.AggregateFluent()
			.Match(filter)
			.GetCountAsync(cancellationToken);
	}

	public async Task<PostResponse?> GetByIdAsync(
		PostId id,
		CurrentUserQuery currentUser,
		CancellationToken cancellationToken)
	{
		var include = _includeBuilderFactory.Create().WithUser().WithPostLikes().WithPostComments().WithPostImages().Build();

		return await _collection
			.AggregateFluent()
			.Match(id)
			.Include(include)
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
