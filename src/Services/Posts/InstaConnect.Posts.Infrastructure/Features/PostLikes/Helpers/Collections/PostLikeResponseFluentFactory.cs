namespace InstaConnect.Posts.Infrastructure.Features.PostLikes.Helpers.Collections;

internal class PostLikeResponseFluentFactory : IPostLikeResponseFluentFactory
{
	private readonly IPaginator _paginator;
	private readonly ISortOrdererFactory _sortOrdererFactory;
	private readonly IPostLikesSortTermerFactory _sortTermerFactory;
	private readonly IPostLikesForUserSortTermerFactory _forUserSortTermerFactory;

	public PostLikeResponseFluentFactory(
		IPaginator paginator,
		ISortOrdererFactory sortOrdererFactory,
		IPostLikesSortTermerFactory sortTermerFactory,
		IPostLikesForUserSortTermerFactory forUserSortTermerFactory)
	{
		_paginator = paginator;
		_sortOrdererFactory = sortOrdererFactory;
		_sortTermerFactory = sortTermerFactory;
		_forUserSortTermerFactory = forUserSortTermerFactory;
	}

	public IPostLikeResponseFluent Create(IAggregateFluent<PostLikeResponse> fluent)
	{
		return new PostLikeResponseFluent(_paginator, fluent, _sortOrdererFactory, _sortTermerFactory, _forUserSortTermerFactory);
	}
}
