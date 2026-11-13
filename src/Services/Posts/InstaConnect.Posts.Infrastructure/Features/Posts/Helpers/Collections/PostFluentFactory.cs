namespace InstaConnect.Posts.Infrastructure.Features.Posts.Helpers.Collections;

internal class PostFluentFactory : IPostFluentFactory
{
	private readonly IPaginator _paginator;
	private readonly IPostIncluderFactory _includerFactory;
	private readonly ISortOrdererFactory _sortOrdererFactory;
	private readonly IPostsSortTermerFactory _sortTermerFactory;
	private readonly IPostResponseFluentFactory _responseFluentFactory;
	private readonly IMongoDbFluentHandlerFactory _fluentHandlerFactory;
	private readonly IPostsForUserSortTermerFactory _forUserSortTermerFactory;

	public PostFluentFactory(
		IPaginator paginator,
		IPostIncluderFactory includerFactory,
		ISortOrdererFactory sortOrdererFactory,
		IPostsSortTermerFactory sortTermerFactory,
		IPostResponseFluentFactory responseFluentFactory,
		IMongoDbFluentHandlerFactory fluentHandlerFactory,
		IPostsForUserSortTermerFactory forUserSortTermerFactory)
	{
		_paginator = paginator;
		_includerFactory = includerFactory;
		_sortTermerFactory = sortTermerFactory;
		_sortOrdererFactory = sortOrdererFactory;
		_fluentHandlerFactory = fluentHandlerFactory;
		_responseFluentFactory = responseFluentFactory;
		_forUserSortTermerFactory = forUserSortTermerFactory;
	}

	public IPostFluent Create(IAggregateFluent<Post> fluent)
	{
		return new PostFluent(
			_paginator,
			_includerFactory,
			_sortOrdererFactory,
			_sortTermerFactory,
			_responseFluentFactory,
			_fluentHandlerFactory.Create<Post, PostId>(fluent),
			_forUserSortTermerFactory);
	}
}
