namespace InstaConnect.Posts.Infrastructure.Features.PostLikes.Helpers.Collections;

internal class PostLikeFluentFactory : IPostLikeFluentFactory
{
	private readonly IPaginator _paginator;
	private readonly ISortOrdererFactory _sortOrdererFactory;
	private readonly IPostLikeIncluderFactory _includerFactory;
	private readonly IPostLikesSortTermerFactory _sortTermerFactory;
	private readonly IPostLikeResponseFluentFactory _responseFluentFactory;
	private readonly IPostLikesForUserSortTermerFactory _forUserSortTermerFactory;

	public PostLikeFluentFactory(
		IPaginator paginator,
		ISortOrdererFactory sortOrdererFactory,
		IPostLikeIncluderFactory includerFactory,
		IPostLikesSortTermerFactory sortTermerFactory,
		IPostLikeResponseFluentFactory responseFluentFactory,
		IPostLikesForUserSortTermerFactory forUserSortTermerFactory)
	{
		_paginator = paginator;
		_sortOrdererFactory = sortOrdererFactory;
		_includerFactory = includerFactory;
		_sortTermerFactory = sortTermerFactory;
		_responseFluentFactory = responseFluentFactory;
		_forUserSortTermerFactory = forUserSortTermerFactory;
	}

	public IPostLikeFluent Create(IAggregateFluent<PostLike> fluent)
	{
		return new PostLikeFluent(
			fluent,
			_paginator,
			_sortOrdererFactory,
			_includerFactory,
			_sortTermerFactory,
			_responseFluentFactory,
			_forUserSortTermerFactory);
	}
}
