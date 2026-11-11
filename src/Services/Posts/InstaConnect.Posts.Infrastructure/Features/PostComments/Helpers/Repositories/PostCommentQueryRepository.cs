using InstaConnect.Posts.Domain.Features.PostComments.Abstractions;

namespace InstaConnect.Posts.Infrastructure.Features.PostComments.Helpers.Repositories;

internal class PostCommentQueryRepository : IPostCommentQueryRepository
{
	private readonly IPostCommentCollection _collection;
	private readonly IPostCommentCacheHandler _commentCacheHandler;
	private readonly IPostIncludeBuilderFactory _includeBuilderFactory;
	private readonly IPostCommentIncludeBuilderFactory _commentIncludeBuilderFactory;

	public PostCommentQueryRepository(
		IPostCommentCollection collection,
		IPostCommentCacheHandler commentCacheHandler,
		IPostIncludeBuilderFactory includeBuilderFactory,
		IPostCommentIncludeBuilderFactory commentIncludeBuilderFactory)
	{
		_collection = collection;
		_commentCacheHandler = commentCacheHandler;
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
		var commentInclude = _commentIncludeBuilderFactory.Create().WithUser().WithPostCommentLikes().WithPostCommentImages().Build();

		return await _collection
			.AggregateFluent()
			.ApplyIncludes(commentInclude)
			.Match(filter)
			.ApplySorting(sorting)
			.ApplyPagination(pagination)
			.ProjectToResponseWithoutPost(currentUser)
			.ToListAsync(cancellationToken);
	}

	public async Task<ICollection<PostCommentResponse>> GetAllForUserAsync(
		PostCommentsForUserFilterQuery filter,
		PostCommentsForUserSortingQuery sorting,
		PostCommentsPaginationQuery pagination,
		CurrentUserQuery currentUser,
		CancellationToken cancellationToken)
	{
		var include = _includeBuilderFactory.Create().WithUser().WithPostLikes().WithPostComments().WithPostImages().Build();
		var commentInclude = _commentIncludeBuilderFactory.Create().WithPost(include).WithPostCommentLikes().WithPostCommentImages().Build();

		return await _collection
			.AggregateFluent()
			.Match(filter)
			.ApplySorting(sorting)
			.ApplyPagination(pagination)
			.ApplyIncludes(commentInclude)
			.ProjectToResponseWithoutUser(currentUser)
			.ToListAsync(cancellationToken);
	}

	public async Task<long> GetTotalCountAsync(
		PostCommentsFilterQuery filter,
		CancellationToken cancellationToken)
	{
		var commentInclude = _commentIncludeBuilderFactory.Create().WithUser().Build();

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
		return await _collection
			.AggregateFluent()
			.Match(filter)
			.GetCountAsync(cancellationToken);
	}

	public async Task<PostCommentResponse?> GetByIdAsync(
		PostCommentId id,
		CurrentUserQuery currentUser,
		CancellationToken cancellationToken)
	{
		var cachedResponse = await _commentCacheHandler.GetByIdAsync(id, currentUser);

		if (cachedResponse != null)
		{
			return cachedResponse;
		}

		var include = _includeBuilderFactory.Create().WithUser().WithPostLikes().WithPostComments().WithPostImages().Build();
		var commentInclude = _commentIncludeBuilderFactory.Create().WithUser().WithPostCommentLikes().WithPost(include).WithPostCommentImages().Build();

		var response = await _collection
			.AggregateFluent()
			.Match(id)
			.ApplyIncludes(commentInclude)
			.ProjectToFullResponse(currentUser)
			.FirstOrDefaultAsync(cancellationToken);

		if (response != null)
		{
			await _commentCacheHandler.AddAsync(response, currentUser);
		}

		return response;
	}

	public async Task<bool> ExistsByIdAsync(
		PostCommentId id,
		CancellationToken cancellationToken)
	{
		var cachedExists = await _commentCacheHandler.ExistsByIdAsync(id);

		if (cachedExists != null)
		{
			return cachedExists.Value;
		}

		var exists = await _collection
			.AggregateFluent()
			.Match(id)
			.AnyAsync(cancellationToken);

		await _commentCacheHandler.AddExistsByIdAsync(id, exists);

		return exists;
	}
}
