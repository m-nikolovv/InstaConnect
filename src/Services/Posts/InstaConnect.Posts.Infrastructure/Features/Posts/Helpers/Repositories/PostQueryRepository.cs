namespace InstaConnect.Posts.Infrastructure.Features.Posts.Helpers.Repositories;

internal class PostQueryRepository : IPostQueryRepository
{
	private readonly IPostCollection _collection;
	private readonly IPostCacheHandler _cacheHandler;
	private readonly IPostIncludeBuilderFactory _includeBuilderFactory;

	public PostQueryRepository(
		IPostCollection collection,
		IPostCacheHandler cacheHandler,
		IPostIncludeBuilderFactory includeBuilderFactory)
	{
		_collection = collection;
		_cacheHandler = cacheHandler;
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
			.ApplyIncludes(include)
			.Match(filter)
			.ApplySorting(sorting)
			.ApplyPagination(pagination)
			.ProjectToFullResponse(currentUser)
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
			.ApplySorting(sorting)
			.ApplyPagination(pagination)
			.ApplyIncludes(include)
			.ProjectToResponseWithoutUser(currentUser)
			.ToListAsync(cancellationToken);
	}

	public async Task<long> GetTotalCountAsync(
		PostsFilterQuery filter,
		CancellationToken cancellationToken)
	{
		var include = _includeBuilderFactory.Create().WithUser().Build();

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
		var cachedResponse = await _cacheHandler.GetByIdAsync(id, currentUser);

		if (cachedResponse != null)
		{
			return cachedResponse;
		}

		var include = _includeBuilderFactory.Create().WithUser().WithPostLikes().WithPostComments().WithPostImages().Build();

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
		PostId id,
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
