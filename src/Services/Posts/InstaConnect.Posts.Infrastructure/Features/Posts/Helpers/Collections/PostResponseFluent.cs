namespace InstaConnect.Posts.Infrastructure.Features.Posts.Helpers.Collections;

internal class PostResponseFluent :
	MongoDbResponseFluent<PostResponse>, IPostResponseFluent
{
	private readonly IPaginator _paginator;
	private readonly ISortOrdererFactory _sortOrdererFactory;
	private readonly IPostsSortTermerFactory _sortTermerFactory;
	private readonly IPostsForUserSortTermerFactory _forUserSortTermerFactory;

	public PostResponseFluent(
		IPaginator paginator,
		IAggregateFluent<PostResponse> fluent,
		ISortOrdererFactory sortOrdererFactory,
		IPostsSortTermerFactory sortTermerFactory,
		IPostsForUserSortTermerFactory forUserSortTermerFactory) : base(fluent)
	{
		_paginator = paginator;
		_sortOrdererFactory = sortOrdererFactory;
		_sortTermerFactory = sortTermerFactory;
		_forUserSortTermerFactory = forUserSortTermerFactory;
	}

	public IPostResponseFluent ApplySorting(PostsSortingQuery query)
	{
		ApplySorting(_sortOrdererFactory, _sortTermerFactory, query);

		return this;
	}

	public IPostResponseFluent ApplySorting(PostsForUserSortingQuery query)
	{
		ApplySorting(_sortOrdererFactory, _forUserSortTermerFactory, query);

		return this;
	}

	public IPostResponseFluent ApplyPagination(PostsPaginationQuery query)
	{
		ApplyPagination(_paginator, query);

		return this;
	}
}
