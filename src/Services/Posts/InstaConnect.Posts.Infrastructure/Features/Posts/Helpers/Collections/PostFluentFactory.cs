namespace InstaConnect.Posts.Infrastructure.Features.Posts.Helpers.Collections;

internal class PostFluentFactory : IPostFluentFactory
{
	private readonly IPaginator _paginator;
	private readonly IPostIncluderFactory _includerFactory;
	private readonly ISortOrdererFactory _sortOrdererFactory;
	private readonly IPostsSortTermerFactory _sortTermerFactory;
	private readonly IPostIncludeBuilderFactory _includeBuilderFactory;
	private readonly IPostResponseFluentFactory _responseFluentFactory;
	private readonly IPostsForUserSortTermerFactory _forUserSortTermerFactory;

	public PostFluentFactory(
		IPaginator paginator,
		IPostIncluderFactory includerFactory,
		ISortOrdererFactory sortOrdererFactory,
		IPostsSortTermerFactory sortTermerFactory,
		IPostIncludeBuilderFactory includeBuilderFactory,
		IPostResponseFluentFactory responseFluentFactory,
		IPostsForUserSortTermerFactory forUserSortTermerFactory)
	{
		_paginator = paginator;
		_includerFactory = includerFactory;
		_sortOrdererFactory = sortOrdererFactory;
		_sortTermerFactory = sortTermerFactory;
		_includeBuilderFactory = includeBuilderFactory;
		_responseFluentFactory = responseFluentFactory;
		_forUserSortTermerFactory = forUserSortTermerFactory;
	}

	public IPostFluent Create(IAggregateFluent<Post> fluent)
	{
		return new PostFluent(
			fluent,
			_paginator,
			_includerFactory,
			_sortOrdererFactory,
			_sortTermerFactory,
			_includeBuilderFactory,
			_responseFluentFactory,
			_forUserSortTermerFactory);
	}
}
