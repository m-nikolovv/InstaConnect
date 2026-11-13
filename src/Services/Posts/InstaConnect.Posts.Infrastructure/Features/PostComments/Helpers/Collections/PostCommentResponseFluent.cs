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

	public IPostCommentResponseFluent Sort(PostCommentsSortingQuery query)
	{
		_fluentHandler.Sort(_sortOrdererFactory, _sortTermerFactory, query);

		return this;
	}

	public IPostCommentResponseFluent Sort(PostCommentsForUserSortingQuery query)
	{
		_fluentHandler.Sort(_sortOrdererFactory, _forUserSortTermerFactory, query);

		return this;
	}

	public IPostCommentResponseFluent Paginate(PostCommentsPaginationQuery query)
	{
		_fluentHandler.Paginate(_paginator, query);

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
