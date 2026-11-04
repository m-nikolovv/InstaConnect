using InstaConnect.Posts.Domain.Features.PostComments.Abstractions;

namespace InstaConnect.Posts.Infrastructure.Features.PostComments.Helpers.Collections;

internal class PostCommentFluentFactory : IPostCommentFluentFactory
{
	private readonly IPaginator _paginator;
	private readonly ISortOrdererFactory _sortOrdererFactory;
	private readonly IPostCommentIncluderFactory _includerFactory;
	private readonly IPostCommentsSortTermerFactory _sortTermerFactory;
	private readonly IPostCommentIncludeBuilderFactory _includeBuilderFactory;
	private readonly IPostCommentResponseFluentFactory _responseFluentFactory;
	private readonly IPostCommentsForUserSortTermerFactory _forUserSortTermerFactory;

	public PostCommentFluentFactory(
		IPaginator paginator,
		ISortOrdererFactory sortOrdererFactory,
		IPostCommentIncluderFactory includerFactory,
		IPostCommentsSortTermerFactory sortTermerFactory,
		IPostCommentIncludeBuilderFactory includeBuilderFactory,
		IPostCommentResponseFluentFactory responseFluentFactory,
		IPostCommentsForUserSortTermerFactory forUserSortTermerFactory)
	{
		_paginator = paginator;
		_sortOrdererFactory = sortOrdererFactory;
		_includerFactory = includerFactory;
		_sortTermerFactory = sortTermerFactory;
		_includeBuilderFactory = includeBuilderFactory;
		_responseFluentFactory = responseFluentFactory;
		_forUserSortTermerFactory = forUserSortTermerFactory;
	}

	public IPostCommentFluent Create(IAggregateFluent<PostComment> fluent)
	{
		return new PostCommentFluent(
			fluent,
			_paginator,
			_sortOrdererFactory,
			_includerFactory,
			_sortTermerFactory,
			_includeBuilderFactory,
			_responseFluentFactory,
			_forUserSortTermerFactory);
	}
}
