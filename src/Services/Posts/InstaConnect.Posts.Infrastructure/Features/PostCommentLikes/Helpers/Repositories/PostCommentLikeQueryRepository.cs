using InstaConnect.Posts.Domain.Features.PostCommentLikes.Abstractions;
using InstaConnect.Posts.Domain.Features.PostComments.Abstractions;

namespace InstaConnect.Posts.Infrastructure.Features.PostCommentLikes.Helpers.Repositories;

internal class PostCommentLikeQueryRepository : IPostCommentLikeQueryRepository
{
	private readonly IPostCommentLikeCollection _collection;
	private readonly IPostIncludeBuilderFactory _includeBuilderFactory;
	private readonly IPostCommentLikeCacheHandler _commentLikeCacheHandler;
	private readonly IPostCommentIncludeBuilderFactory _commentIncludeBuilderFactory;
	private readonly IPostCommentLikeIncludeBuilderFactory _commentLikeIncludeBuilderFactory;

	public PostCommentLikeQueryRepository(
		IPostCommentLikeCollection collection,
		IPostIncludeBuilderFactory includeBuilderFactory,
		IPostCommentLikeCacheHandler commentLikeCacheHandler,
		IPostCommentIncludeBuilderFactory commentIncludeBuilderFactory,
		IPostCommentLikeIncludeBuilderFactory commentLikeIncludeBuilderFactory)
	{
		_collection = collection;
		_includeBuilderFactory = includeBuilderFactory;
		_commentLikeCacheHandler = commentLikeCacheHandler;
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
			.ApplySorting(sorting)
			.ApplyPagination(pagination)
			.ProjectToResponseWithoutPostComment(currentUser)
			.ToListAsync(cancellationToken);
	}

	public async Task<ICollection<PostCommentLikeResponse>> GetAllForUserAsync(
		PostCommentLikesForUserFilterQuery filter,
		PostCommentLikesForUserSortingQuery sorting,
		PostCommentLikesPaginationQuery pagination,
		CurrentUserQuery currentUser,
		CancellationToken cancellationToken)
	{
		var include = _includeBuilderFactory.Create().WithUser().WithPostLikes().WithPostComments().WithPostImages().Build();
		var commentInclude = _commentIncludeBuilderFactory.Create().WithUser().WithPost(include).WithPostCommentLikes().WithPostCommentImages().Build();
		var commentLikeInclude = _commentLikeIncludeBuilderFactory.Create().WithPostComment(commentInclude).Build();

		return await _collection
			.AggregateFluent()
			.Match(filter)
			.ApplySorting(sorting)
			.ApplyPagination(pagination)
			.ApplyIncludes(commentLikeInclude)
			.ProjectToResponseWithoutUser(currentUser)
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
		return await _collection
			.AggregateFluent()
			.Match(filter)
			.GetCountAsync(cancellationToken);
	}

	public async Task<PostCommentLikeResponse?> GetByIdAsync(
		PostCommentLikeId id,
		CurrentUserQuery currentUser,
		CancellationToken cancellationToken)
	{
		var cachedResponse = await _commentLikeCacheHandler.GetByIdAsync(id, currentUser);

		if (cachedResponse != null)
		{
			return cachedResponse;
		}

		var include = _includeBuilderFactory.Create().WithUser().WithPostLikes().WithPostComments().WithPostImages().Build();
		var commentInclude = _commentIncludeBuilderFactory.Create().WithUser().WithPost(include).WithPostCommentLikes().WithPostCommentImages().Build();
		var commentLikeInclude = _commentLikeIncludeBuilderFactory.Create().WithUser().WithPostComment(commentInclude).Build();

		var response = await _collection
			.AggregateFluent()
			.Match(id)
			.ApplyIncludes(commentLikeInclude)
			.ProjectToFullResponse(currentUser)
			.FirstOrDefaultAsync(cancellationToken);

		if (response != null)
		{
			await _commentLikeCacheHandler.AddAsync(response, currentUser);
		}

		return response;
	}

	public async Task<bool> ExistsByIdAsync(
		PostCommentLikeId id,
		CancellationToken cancellationToken)
	{
		var cachedExists = await _commentLikeCacheHandler.ExistsByIdAsync(id);

		if (cachedExists != null)
		{
			return cachedExists.Value;
		}

		var exists = await _collection
			.AggregateFluent()
			.Match(id)
			.AnyAsync(cancellationToken);

		await _commentLikeCacheHandler.AddExistsByIdAsync(id, exists);

		return exists;
	}
}
