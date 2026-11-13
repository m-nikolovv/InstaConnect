namespace InstaConnect.Posts.Infrastructure.Features.PostComments.Helpers.Collections;

internal class PostCommentResponseFluent : IPostCommentResponseFluent
{
	private readonly IPaginator _paginator;
	private readonly ISortOrdererFactory _sortOrdererFactory;
	private readonly IPostCommentsSortTermerFactory _sortTermerFactory;
	private readonly IPostCommentsForUserSortTermerFactory _forUserSortTermerFactory;
	private readonly IMongoDbResponseFluentHandler<PostCommentResponse> _fluentHandler;

	public PostCommentResponseFluent(
		IPaginator paginator,
		ISortOrdererFactory sortOrdererFactory,
		IPostCommentsSortTermerFactory sortTermerFactory,
		IPostCommentsForUserSortTermerFactory forUserSortTermerFactory,
		IMongoDbResponseFluentHandler<PostCommentResponse> fluentHandler)
	{
		_paginator = paginator;
		_fluentHandler = fluentHandler;
		_sortTermerFactory = sortTermerFactory;
		_sortOrdererFactory = sortOrdererFactory;
		_forUserSortTermerFactory = forUserSortTermerFactory;
	}

	public IPostCommentResponseFluent ApplySorting(PostCommentsSortingQuery query)
	{
		_fluentHandler.ApplySorting(_sortOrdererFactory, _sortTermerFactory, query);

		return this;
	}

	public IPostCommentResponseFluent ApplySorting(PostCommentsForUserSortingQuery query)
	{
		_fluentHandler.ApplySorting(_sortOrdererFactory, _forUserSortTermerFactory, query);

		return this;
	}

	public IPostCommentResponseFluent ApplyPagination(PostCommentsPaginationQuery query)
	{
		_fluentHandler.ApplyPagination(_paginator, query);

		return this;
	}

	public async Task<PostCommentResponse?> FirstOrDefaultAsync(CancellationToken cancellationToken)
	{
		return await _fluentHandler.FirstOrDefaultAsync(cancellationToken);
	}

	public async Task<ICollection<PostCommentResponse>> ToListAsync(CancellationToken cancellationToken)
	{
		return await _fluentHandler.ToListAsync(cancellationToken);
	}
}
