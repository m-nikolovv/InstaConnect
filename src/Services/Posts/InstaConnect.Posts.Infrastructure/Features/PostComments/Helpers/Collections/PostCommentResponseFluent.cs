namespace InstaConnect.Posts.Infrastructure.Features.PostComments.Helpers.Collections;

internal class PostCommentResponseFluent :
	MongoDbResponseFluent<PostCommentResponse>, IPostCommentResponseFluent
{
	private readonly IPaginator _paginator;
	private readonly ISortOrdererFactory _sortOrdererFactory;
	private readonly IPostCommentsSortTermerFactory _sortTermerFactory;
	private readonly IPostCommentsForUserSortTermerFactory _forUserSortTermerFactory;

	public PostCommentResponseFluent(
		IPaginator paginator,
		IAggregateFluent<PostCommentResponse> fluent,
		ISortOrdererFactory sortOrdererFactory,
		IPostCommentsSortTermerFactory sortTermerFactory,
		IPostCommentsForUserSortTermerFactory forUserSortTermerFactory) : base(fluent)
	{
		_paginator = paginator;
		_sortOrdererFactory = sortOrdererFactory;
		_sortTermerFactory = sortTermerFactory;
		_forUserSortTermerFactory = forUserSortTermerFactory;
	}

	public IPostCommentResponseFluent ApplySorting(PostCommentsSortingQuery query)
	{
		ApplySorting(_sortOrdererFactory, _sortTermerFactory, query);

		return this;
	}

	public IPostCommentResponseFluent ApplySorting(PostCommentsForUserSortingQuery query)
	{
		ApplySorting(_sortOrdererFactory, _forUserSortTermerFactory, query);

		return this;
	}

	public IPostCommentResponseFluent ApplyPagination(PostCommentsPaginationQuery query)
	{
		ApplyPagination(_paginator, query);

		return this;
	}
}
