using InstaConnect.Posts.Domain.Features.PostLikes.Abstractions;

namespace InstaConnect.Posts.Infrastructure.Features.PostLikes.Helpers.Repositories;

internal class PostLikeQueryRepository : IPostLikeQueryRepository
{
	private readonly IPostLikeCollection _collection;
	private readonly IPostIncludeBuilderFactory _includeBuilderFactory;
	private readonly IPostLikeIncludeBuilderFactory _likeIncludeBuilderFactory;

	public PostLikeQueryRepository(
		IPostLikeCollection collection,
		IPostIncludeBuilderFactory includeBuilderFactory,
		IPostLikeIncludeBuilderFactory likeIncludeBuilderFactory)
	{
		_collection = collection;
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
			.ProjectToResponseWithoutPost(currentUser)
			.ApplySorting(sorting)
			.ApplyPagination(pagination)
			.ToListAsync(cancellationToken);
	}

	public async Task<ICollection<PostLikeResponse>> GetAllForUserAsync(
		PostLikesForUserFilterQuery filter,
		PostLikesForUserSortingQuery sorting,
		PostLikesPaginationQuery pagination,
		CurrentUserQuery currentUser,
		CancellationToken cancellationToken)
	{
		var include = _includeBuilderFactory.Create().WithUser().WithPostLikes().WithPostImages().Build();
		var likeInclude = _likeIncludeBuilderFactory.Create().WithPost(include).Build();

		return await _collection
			.AggregateFluent()
			.ApplyIncludes(likeInclude)
			.Match(filter)
			.ProjectToResponseWithoutUser(currentUser)
			.ApplySorting(sorting)
			.ApplyPagination(pagination)
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
		var include = _includeBuilderFactory.Create().WithUser().WithPostLikes().WithPostImages().Build();
		var likeInclude = _likeIncludeBuilderFactory.Create().WithPost(include).Build();

		return await _collection
			.AggregateFluent()
			.ApplyIncludes(likeInclude)
			.Match(filter)
			.GetCountAsync(cancellationToken);
	}

	public async Task<PostLikeResponse?> GetByIdAsync(
		PostLikeId id,
		CurrentUserQuery currentUser,
		CancellationToken cancellationToken)
	{
		var include = _includeBuilderFactory.Create().WithUser().WithPostLikes().WithPostImages().Build();
		var likeInclude = _likeIncludeBuilderFactory.Create().WithUser().WithPost(include).Build();

		return await _collection
			.AggregateFluent()
			.ApplyIncludes(likeInclude)
			.Match(id)
			.ProjectToFullResponse(currentUser)
			.FirstOrDefaultAsync(cancellationToken);
	}

	public async Task<bool> ExistsByIdAsync(
		PostLikeId id,
		CancellationToken cancellationToken)
	{
		return await _collection
			.AggregateFluent()
			.Match(id)
			.AnyAsync(cancellationToken);
	}
}
