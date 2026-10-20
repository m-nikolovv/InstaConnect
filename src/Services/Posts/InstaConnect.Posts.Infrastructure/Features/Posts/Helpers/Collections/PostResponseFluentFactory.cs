namespace InstaConnect.Posts.Infrastructure.Features.Posts.Helpers.Collections;

internal class PostResponseFluentFactory : IPostResponseFluentFactory
{
	private readonly IPaginator _paginator;
	private readonly ISortOrdererFactory _sortOrdererFactory;
	private readonly IPostsSortTermerFactory _sortTermerFactory;
	private readonly IPostsForUserSortTermerFactory _forUserSortTermerFactory;

	public PostResponseFluentFactory(
		IPaginator paginator,
		ISortOrdererFactory sortOrdererFactory,
		IPostsSortTermerFactory sortTermerFactory,
		IPostsForUserSortTermerFactory forUserSortTermerFactory)
	{
		_paginator = paginator;
		_sortOrdererFactory = sortOrdererFactory;
		_sortTermerFactory = sortTermerFactory;
		_forUserSortTermerFactory = forUserSortTermerFactory;
	}

	public IPostResponseFluent Create(IAggregateFluent<PostResponse> fluent)
	{
		return new PostResponseFluent(_paginator, fluent, _sortOrdererFactory, _sortTermerFactory, _forUserSortTermerFactory);
	}
}
