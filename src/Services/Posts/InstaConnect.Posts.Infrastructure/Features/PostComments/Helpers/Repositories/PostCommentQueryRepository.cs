namespace InstaConnect.Posts.Infrastructure.Features.PostComments.Helpers.Repositories;

internal class PostCommentQueryRepository : IPostCommentQueryRepository
{
	private readonly IPostCommentCollection _collection;
	private readonly IPostIncludeBuilderFactory _includeBuilderFactory;
	private readonly IPostCommentIncludeBuilderFactory _commentIncludeBuilderFactory;

	public PostCommentQueryRepository(
		IPostCommentCollection collection,
		IPostIncludeBuilderFactory includeBuilderFactory,
		IPostCommentIncludeBuilderFactory commentIncludeBuilderFactory)
	{
		_collection = collection;
		_includeBuilderFactory = includeBuilderFactory;
		_commentIncludeBuilderFactory = commentIncludeBuilderFactory;
	}

	public async Task<ICollection<PostCommentResponse>> GetAllAsync(
		PostCommentsFilterQuery filter,
		PostCommentsSortingQuery sorting,
		PostCommentsPaginationQuery pagination,
		CurrentUserQuery currentUser,
		CancellationToken cancellationToken)
	{
		var commentInclude = _commentIncludeBuilderFactory.Create().WithUser().WithPostCommentLikes().Build();

		return await _collection
			.AggregateFluent()
			.ApplyIncludes(commentInclude)
			.Match(filter)
			.ProjectToResponseWithoutPost(currentUser)
			.ApplySorting(sorting)
			.ApplyPagination(pagination)
			.ToListAsync(cancellationToken);
	}

	public async Task<ICollection<PostCommentResponse>> GetAllForUserAsync(
		PostCommentsForUserFilterQuery filter,
		PostCommentsForUserSortingQuery sorting,
		PostCommentsPaginationQuery pagination,
		CurrentUserQuery currentUser,
		CancellationToken cancellationToken)
	{
		var include = _includeBuilderFactory.Create().WithUser().WithPostLikes().WithPostImages().Build();
		var commentInclude = _commentIncludeBuilderFactory.Create().WithPost(include).WithPostCommentLikes().Build();

		return await _collection
			.AggregateFluent()
			.ApplyIncludes(commentInclude)
			.Match(filter)
			.ProjectToResponseWithoutUser(currentUser)
			.ApplySorting(sorting)
			.ApplyPagination(pagination)
			.ToListAsync(cancellationToken);
	}

	public async Task<long> GetTotalCountAsync(
		PostCommentsFilterQuery filter,
		CancellationToken cancellationToken)
	{
		var commentInclude = _commentIncludeBuilderFactory.Create().WithUser().WithPostCommentLikes().Build();

		return await _collection
			.AggregateFluent()
			.ApplyIncludes(commentInclude)
			.Match(filter)
			.GetCountAsync(cancellationToken);
	}

	public async Task<long> GetTotalCountForUserAsync(
		PostCommentsForUserFilterQuery filter,
		CancellationToken cancellationToken)
	{
		var include = _includeBuilderFactory.Create().WithUser().WithPostLikes().WithPostImages().Build();
		var commentInclude = _commentIncludeBuilderFactory.Create().WithPost(include).WithPostCommentLikes().Build();

		return await _collection
			.AggregateFluent()
			.ApplyIncludes(commentInclude)
			.Match(filter)
			.GetCountAsync(cancellationToken);
	}

	public async Task<PostCommentResponse?> GetByIdAsync(
		PostCommentId id,
		CurrentUserQuery currentUser,
		CancellationToken cancellationToken)
	{
		var include = _includeBuilderFactory.Create().WithUser().WithPostLikes().WithPostImages().Build();
		var commentInclude = _commentIncludeBuilderFactory.Create().WithUser().WithPostCommentLikes().WithPost(include).Build();

		return await _collection
			.AggregateFluent()
			.ApplyIncludes(commentInclude)
			.Match(id)
			.ProjectToFullResponse(currentUser)
			.FirstOrDefaultAsync(cancellationToken);
	}

	public async Task<bool> ExistsByIdAsync(
		PostCommentId id,
		CancellationToken cancellationToken)
	{
		return await _collection
			.AggregateFluent()
			.Match(id)
			.AnyAsync(cancellationToken);
	}
}
