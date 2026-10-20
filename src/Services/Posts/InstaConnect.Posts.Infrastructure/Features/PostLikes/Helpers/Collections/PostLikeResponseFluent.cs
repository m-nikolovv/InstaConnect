namespace InstaConnect.Posts.Infrastructure.Features.PostLikes.Helpers.Collections;

internal class PostLikeResponseFluent :
	MongoDbResponseFluent<PostLikeResponse>, IPostLikeResponseFluent
{
	private readonly IPaginator _paginator;
	private readonly ISortOrdererFactory _sortOrdererFactory;
	private readonly IPostLikesSortTermerFactory _sortTermerFactory;
	private readonly IPostLikesForUserSortTermerFactory _forUserSortTermerFactory;

	public PostLikeResponseFluent(
		IPaginator paginator,
		IAggregateFluent<PostLikeResponse> fluent,
		ISortOrdererFactory sortOrdererFactory,
		IPostLikesSortTermerFactory sortTermerFactory,
		IPostLikesForUserSortTermerFactory forUserSortTermerFactory) : base(fluent)
	{
		_paginator = paginator;
		_sortOrdererFactory = sortOrdererFactory;
		_sortTermerFactory = sortTermerFactory;
		_forUserSortTermerFactory = forUserSortTermerFactory;
	}

	public IPostLikeResponseFluent ApplySorting(PostLikesSortingQuery query)
	{
		ApplySorting(_sortOrdererFactory, _sortTermerFactory, query);

		return this;
	}

	public IPostLikeResponseFluent ApplySorting(PostLikesForUserSortingQuery query)
	{
		ApplySorting(_sortOrdererFactory, _forUserSortTermerFactory, query);

		return this;
	}

	public IPostLikeResponseFluent ApplyPagination(PostLikesPaginationQuery query)
	{
		ApplyPagination(_paginator, query);

		return this;
	}
}
