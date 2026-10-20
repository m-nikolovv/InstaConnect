namespace InstaConnect.Posts.Infrastructure.Features.PostComments.Helpers.Collections;

internal class PostCommentResponseFluentFactory : IPostCommentResponseFluentFactory
{
	private readonly IPaginator _paginator;
	private readonly ISortOrdererFactory _sortOrdererFactory;
	private readonly IPostCommentsSortTermerFactory _sortTermerFactory;
	private readonly IPostCommentsForUserSortTermerFactory _forUserSortTermerFactory;

	public PostCommentResponseFluentFactory(
		IPaginator paginator,
		ISortOrdererFactory sortOrdererFactory,
		IPostCommentsSortTermerFactory sortTermerFactory,
		IPostCommentsForUserSortTermerFactory forUserSortTermerFactory)
	{
		_paginator = paginator;
		_sortOrdererFactory = sortOrdererFactory;
		_sortTermerFactory = sortTermerFactory;
		_forUserSortTermerFactory = forUserSortTermerFactory;
	}

	public IPostCommentResponseFluent Create(IAggregateFluent<PostCommentResponse> fluent)
	{
		return new PostCommentResponseFluent(_paginator, fluent, _sortOrdererFactory, _sortTermerFactory, _forUserSortTermerFactory);
	}
}
