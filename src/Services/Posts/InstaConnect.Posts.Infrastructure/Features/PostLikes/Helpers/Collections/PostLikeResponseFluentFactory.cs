namespace InstaConnect.Posts.Infrastructure.Features.PostLikes.Helpers.Collections;

internal class PostLikeResponseFluentFactory : IPostLikeResponseFluentFactory
{
	private readonly IPaginator _paginator;
	private readonly ISortOrdererFactory _sortOrdererFactory;
	private readonly IPostLikesSortTermerFactory _sortTermerFactory;
	private readonly IMongoDbFluentHandlerFactory _fluentHandlerFactory;
	private readonly IPostLikesForUserSortTermerFactory _forUserSortTermerFactory;

	public PostLikeResponseFluentFactory(
		IPaginator paginator,
		ISortOrdererFactory sortOrdererFactory,
		IPostLikesSortTermerFactory sortTermerFactory,
		IMongoDbFluentHandlerFactory fluentHandlerFactory,
		IPostLikesForUserSortTermerFactory forUserSortTermerFactory)
	{
		_paginator = paginator;
		_sortTermerFactory = sortTermerFactory;
		_sortOrdererFactory = sortOrdererFactory;
		_fluentHandlerFactory = fluentHandlerFactory;
		_forUserSortTermerFactory = forUserSortTermerFactory;
	}

	public IPostLikeResponseFluent Create(IAggregateFluent<PostLikeResponse> fluent)
	{
		return new PostLikeResponseFluent(
			_paginator,
			_sortOrdererFactory,
			_sortTermerFactory,
			_forUserSortTermerFactory,
			_fluentHandlerFactory.CreateResponse(fluent));
	}
}
