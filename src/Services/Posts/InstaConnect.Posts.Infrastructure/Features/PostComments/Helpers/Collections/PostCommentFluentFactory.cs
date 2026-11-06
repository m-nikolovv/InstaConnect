namespace InstaConnect.Posts.Infrastructure.Features.PostComments.Helpers.Collections;

internal class PostCommentFluentFactory : IPostCommentFluentFactory
{
	private readonly IPaginator _paginator;
	private readonly ISortOrdererFactory _sortOrdererFactory;
	private readonly IPostCommentIncluderFactory _includerFactory;
	private readonly IPostCommentsSortTermerFactory _sortTermerFactory;
	private readonly IPostCommentResponseFluentFactory _responseFluentFactory;
	private readonly IPostCommentsForUserSortTermerFactory _forUserSortTermerFactory;

	public PostCommentFluentFactory(
		IPaginator paginator,
		ISortOrdererFactory sortOrdererFactory,
		IPostCommentIncluderFactory includerFactory,
		IPostCommentsSortTermerFactory sortTermerFactory,
		IPostCommentResponseFluentFactory responseFluentFactory,
		IPostCommentsForUserSortTermerFactory forUserSortTermerFactory)
	{
		_paginator = paginator;
		_includerFactory = includerFactory;
		_sortTermerFactory = sortTermerFactory;
		_sortOrdererFactory = sortOrdererFactory;
		_responseFluentFactory = responseFluentFactory;
		_forUserSortTermerFactory = forUserSortTermerFactory;
	}

	public IPostCommentFluent Create(IAggregateFluent<PostComment> fluent)
	{
		return new PostCommentFluent(
			_paginator,
			fluent,
			_sortOrdererFactory,
			_includerFactory,
			_sortTermerFactory,
			_responseFluentFactory,
			_forUserSortTermerFactory);
	}
}
