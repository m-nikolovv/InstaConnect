using InstaConnect.Posts.Domain.Features.PostLikes.Abstractions;

namespace InstaConnect.Posts.Infrastructure.Features.PostLikes.Helpers.Repositories;

internal class PostLikeQueryRepository : IPostLikeQueryRepository
{
	private readonly IPostLikeCollection _collection;
	private readonly IPostLikeCacheHandler _likeCacheHandler;
	private readonly IPostIncludeBuilderFactory _includeBuilderFactory;
	private readonly IPostLikeIncludeBuilderFactory _likeIncludeBuilderFactory;

	public PostLikeQueryRepository(
		IPostLikeCollection collection,
		IPostLikeCacheHandler likeCacheHandler,
		IPostIncludeBuilderFactory includeBuilderFactory,
		IPostLikeIncludeBuilderFactory likeIncludeBuilderFactory)
	{
		_collection = collection;
		_likeCacheHandler = likeCacheHandler;
		_includeBuilderFactory = includeBuilderFactory;
		_likeIncludeBuilderFactory = likeIncludeBuilderFactory;
	}

	public async Task<ICollection<PostLikeResponse>> GetAllAsync(
		PostLikesFilterQuery filter,
		PostLikesSortingQuery sorting,
		PostLikesPaginationQuery pagination,
		CurrentUserQuery currentUser,
		CancellationToken cancellationToken)
	{
		var likeInclude = _likeIncludeBuilderFactory.Create().WithUser().Build();

		return await _collection
			.AggregateFluent()
			.ApplyIncludes(likeInclude)
			.Match(filter)
			.ApplySorting(sorting)
			.ApplyPagination(pagination)
			.ProjectToResponseWithoutPost(currentUser)
			.ToListAsync(cancellationToken);
	}

	public async Task<ICollection<PostLikeResponse>> GetAllForUserAsync(
		PostLikesForUserFilterQuery filter,
		PostLikesForUserSortingQuery sorting,
		PostLikesPaginationQuery pagination,
		CurrentUserQuery currentUser,
		CancellationToken cancellationToken)
	{
		var include = _includeBuilderFactory.Create().WithUser().WithPostLikes().WithPostComments().WithPostImages().Build();
		var likeInclude = _likeIncludeBuilderFactory.Create().WithPost(include).Build();

		return await _collection
			.AggregateFluent()
			.Match(filter)
			.ApplySorting(sorting)
			.ApplyPagination(pagination)
			.ApplyIncludes(likeInclude)
			.ProjectToResponseWithoutUser(currentUser)
			.ToListAsync(cancellationToken);
	}

	public async Task<long> GetTotalCountAsync(
		PostLikesFilterQuery filter,
		CancellationToken cancellationToken)
	{
		var likeInclude = _likeIncludeBuilderFactory.Create().WithUser().Build();

		return await _collection
			.AggregateFluent()
			.ApplyIncludes(likeInclude)
			.Match(filter)
			.GetCountAsync(cancellationToken);
	}

	public async Task<long> GetTotalCountForUserAsync(
		PostLikesForUserFilterQuery filter,
		CancellationToken cancellationToken)
	{
		return await _collection
			.AggregateFluent()
			.Match(filter)
			.GetCountAsync(cancellationToken);
	}

	public async Task<PostLikeResponse?> GetByIdAsync(
		PostLikeId id,
		CurrentUserQuery currentUser,
		CancellationToken cancellationToken)
	{
		var cachedResponse = await _likeCacheHandler.GetByIdAsync(id, currentUser);

		if (cachedResponse != null)
		{
			return cachedResponse;
		}

		var include = _includeBuilderFactory.Create().WithUser().WithPostLikes().WithPostComments().WithPostImages().Build();
		var likeInclude = _likeIncludeBuilderFactory.Create().WithUser().WithPost(include).Build();

		var response = await _collection
			.AggregateFluent()
			.Match(id)
			.ApplyIncludes(likeInclude)
			.ProjectToFullResponse(currentUser)
			.FirstOrDefaultAsync(cancellationToken);

		if (response != null)
		{
			await _likeCacheHandler.AddAsync(response, currentUser);
		}

		return response;
	}

	public async Task<bool> ExistsByIdAsync(
		PostLikeId id,
		CancellationToken cancellationToken)
	{
		var cachedExists = await _likeCacheHandler.ExistsByIdAsync(id);

		if (cachedExists != null)
		{
			return cachedExists.Value;
		}

		var exists = await _collection
			.AggregateFluent()
			.Match(id)
			.AnyAsync(cancellationToken);

		await _likeCacheHandler.AddExistsByIdAsync(id, exists);

		return exists;
	}
}
