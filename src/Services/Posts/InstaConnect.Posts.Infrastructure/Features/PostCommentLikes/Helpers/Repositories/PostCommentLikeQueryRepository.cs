namespace InstaConnect.Posts.Infrastructure.Features.PostCommentLikes.Helpers.Repositories;

internal class PostCommentLikeQueryRepository : IPostCommentLikeQueryRepository
{
	private readonly IPostCommentLikeCollection _collection;
	private readonly IPostIncludeBuilderFactory _includeBuilderFactory;
	private readonly IPostCommentIncludeBuilderFactory _commentIncludeBuilderFactory;
	private readonly IPostCommentLikeIncludeBuilderFactory _commentLikeIncludeBuilderFactory;

	public PostCommentLikeQueryRepository(
		IPostCommentLikeCollection collection,
		IPostIncludeBuilderFactory includeBuilderFactory,
		IPostCommentIncludeBuilderFactory commentIncludeBuilderFactory,
		IPostCommentLikeIncludeBuilderFactory commentLikeIncludeBuilderFactory)
	{
		_collection = collection;
		_includeBuilderFactory = includeBuilderFactory;
		_commentIncludeBuilderFactory = commentIncludeBuilderFactory;
		_commentLikeIncludeBuilderFactory = commentLikeIncludeBuilderFactory;
	}

	public async Task<ICollection<PostCommentLikeResponse>> GetAllAsync(
		PostCommentLikesFilterQuery filter,
		PostCommentLikesSortingQuery sorting,
		PostCommentLikesPaginationQuery pagination,
		CurrentUserQuery currentUser,
		CancellationToken cancellationToken)
	{
		var commentLikeInclude = _commentLikeIncludeBuilderFactory.Create().WithUser().Build();

		return await _collection
			.AggregateFluent()
			.ApplyIncludes(commentLikeInclude)
			.Match(filter)
			.ProjectToResponseWithoutPostComment(currentUser)
			.ApplySorting(sorting)
			.ApplyPagination(pagination)
			.ToListAsync(cancellationToken);
	}

	public async Task<ICollection<PostCommentLikeResponse>> GetAllForUserAsync(
		PostCommentLikesForUserFilterQuery filter,
		PostCommentLikesForUserSortingQuery sorting,
		PostCommentLikesPaginationQuery pagination,
		CurrentUserQuery currentUser,
		CancellationToken cancellationToken)
	{
		var include = _includeBuilderFactory.Create().WithUser().WithPostLikes().WithPostImages().Build();
		var commentInclude = _commentIncludeBuilderFactory.Create().WithUser().WithPost(include).WithPostCommentLikes().WithPostCommentImages().Build();
		var commentLikeInclude = _commentLikeIncludeBuilderFactory.Create().WithPostComment(commentInclude).Build();

		return await _collection
			.AggregateFluent()
			.ApplyIncludes(commentLikeInclude)
			.Match(filter)
			.ProjectToResponseWithoutUser(currentUser)
			.ApplySorting(sorting)
			.ApplyPagination(pagination)
			.ToListAsync(cancellationToken);
	}

	public async Task<long> GetTotalCountAsync(
		PostCommentLikesFilterQuery filter,
		CancellationToken cancellationToken)
	{
		var commentLikeInclude = _commentLikeIncludeBuilderFactory.Create().WithUser().Build();

		return await _collection
			.AggregateFluent()
			.ApplyIncludes(commentLikeInclude)
			.Match(filter)
			.GetCountAsync(cancellationToken);
	}

	public async Task<long> GetTotalCountForUserAsync(
		PostCommentLikesForUserFilterQuery filter,
		CancellationToken cancellationToken)
	{
		var include = _includeBuilderFactory.Create().WithUser().WithPostLikes().WithPostImages().Build();
		var commentInclude = _commentIncludeBuilderFactory.Create().WithUser().WithPost(include).WithPostCommentLikes().WithPostCommentImages().Build();
		var commentLikeInclude = _commentLikeIncludeBuilderFactory.Create().WithPostComment(commentInclude).Build();

		return await _collection
			.AggregateFluent()
			.ApplyIncludes(commentLikeInclude)
			.Match(filter)
			.GetCountAsync(cancellationToken);
	}

	public async Task<PostCommentLikeResponse?> GetByIdAsync(
		PostCommentLikeId id,
		CurrentUserQuery currentUser,
		CancellationToken cancellationToken)
	{
		var include = _includeBuilderFactory.Create().WithUser().WithPostLikes().WithPostImages().Build();
		var commentInclude = _commentIncludeBuilderFactory.Create().WithUser().WithPost(include).WithPostCommentLikes().WithPostCommentImages().Build();
		var commentLikeInclude = _commentLikeIncludeBuilderFactory.Create().WithUser().WithPostComment(commentInclude).Build();

		return await _collection
			.AggregateFluent()
			.ApplyIncludes(commentLikeInclude)
			.Match(id)
			.ProjectToFullResponse(currentUser)
			.FirstOrDefaultAsync(cancellationToken);
	}

	public async Task<bool> ExistsByIdAsync(
		PostCommentLikeId id,
		CancellationToken cancellationToken)
	{
		return await _collection
			.AggregateFluent()
			.Match(id)
			.AnyAsync(cancellationToken);
	}
}
