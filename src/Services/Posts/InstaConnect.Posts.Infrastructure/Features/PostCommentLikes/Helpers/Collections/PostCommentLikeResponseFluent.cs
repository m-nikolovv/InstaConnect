namespace InstaConnect.Posts.Infrastructure.Features.PostCommentLikes.Helpers.Collections;

internal class PostCommentLikeResponseFluent : IPostCommentLikeResponseFluent
{
	private readonly IPaginator _paginator;
	private readonly ISortOrdererFactory _sortOrdererFactory;
	private readonly IPostCommentLikesSortTermerFactory _sortTermerFactory;
	private readonly IPostCommentLikesForUserSortTermerFactory _forUserSortTermerFactory;
	private readonly IMongoDbResponseFluentHandler<PostCommentLikeResponse> _fluentHandler;

	public PostCommentLikeResponseFluent(
		IPaginator paginator,
		ISortOrdererFactory sortOrdererFactory,
		IPostCommentLikesSortTermerFactory sortTermerFactory,
		IPostCommentLikesForUserSortTermerFactory forUserSortTermerFactory,
		IMongoDbResponseFluentHandler<PostCommentLikeResponse> fluentHandler)
	{
		_paginator = paginator;
		_fluentHandler = fluentHandler;
		_sortTermerFactory = sortTermerFactory;
		_sortOrdererFactory = sortOrdererFactory;
		_forUserSortTermerFactory = forUserSortTermerFactory;
	}

	public IPostCommentLikeResponseFluent ApplySorting(PostCommentLikesSortingQuery query)
	{
		_fluentHandler.ApplySorting(_sortOrdererFactory, _sortTermerFactory, query);

		return this;
	}

	public IPostCommentLikeResponseFluent ApplySorting(PostCommentLikesForUserSortingQuery query)
	{
		_fluentHandler.ApplySorting(_sortOrdererFactory, _forUserSortTermerFactory, query);

		return this;
	}

	public IPostCommentLikeResponseFluent ApplyPagination(PostCommentLikesPaginationQuery query)
	{
		_fluentHandler.ApplyPagination(_paginator, query);

		return this;
	}

	public async Task<PostCommentLikeResponse?> FirstOrDefaultAsync(CancellationToken cancellationToken)
	{
		return await _fluentHandler.FirstOrDefaultAsync(cancellationToken);
	}

	public async Task<ICollection<PostCommentLikeResponse>> ToListAsync(CancellationToken cancellationToken)
	{
		return await _fluentHandler.ToListAsync(cancellationToken);
	}
}
