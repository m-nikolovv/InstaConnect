namespace InstaConnect.Posts.Infrastructure.Features.Posts.Helpers.Collections;

internal class PostResponseFluentFactory : IPostResponseFluentFactory
{
	private readonly IPaginator _paginator;
	private readonly ISortOrdererFactory _sortOrdererFactory;
	private readonly IPostsSortTermerFactory _sortTermerFactory;
	private readonly IMongoDbFluentHandlerFactory _fluentHandlerFactory;
	private readonly IPostsForUserSortTermerFactory _forUserSortTermerFactory;

	public PostResponseFluentFactory(
		IPaginator paginator,
		ISortOrdererFactory sortOrdererFactory,
		IPostsSortTermerFactory sortTermerFactory,
		IMongoDbFluentHandlerFactory fluentHandlerFactory,
		IPostsForUserSortTermerFactory forUserSortTermerFactory)
	{
		_paginator = paginator;
		_sortTermerFactory = sortTermerFactory;
		_sortOrdererFactory = sortOrdererFactory;
		_fluentHandlerFactory = fluentHandlerFactory;
		_forUserSortTermerFactory = forUserSortTermerFactory;
	}

	public IPostResponseFluent Create(IAggregateFluent<PostResponse> fluent)
	{
		return new PostResponseFluent(
			_paginator,
			_sortOrdererFactory,
			_sortTermerFactory,
			_forUserSortTermerFactory,
			_fluentHandlerFactory.CreateResponse(fluent));
	}
}
