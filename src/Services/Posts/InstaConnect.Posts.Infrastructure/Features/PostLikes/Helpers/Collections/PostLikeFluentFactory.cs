using InstaConnect.Posts.Domain.Features.PostLikes.Abstractions;

namespace InstaConnect.Posts.Infrastructure.Features.PostLikes.Helpers.Collections;

internal class PostLikeFluentFactory : IPostLikeFluentFactory
{
	private readonly IPaginator _paginator;
	private readonly ISortOrdererFactory _sortOrdererFactory;
	private readonly IPostLikeIncluderFactory _includerFactory;
	private readonly IPostLikesSortTermerFactory _sortTermerFactory;
	private readonly IPostLikeIncludeBuilderFactory _includeBuilderFactory;
	private readonly IPostLikeResponseFluentFactory _responseFluentFactory;
	private readonly IPostLikesForUserSortTermerFactory _forUserSortTermerFactory;

	public PostLikeFluentFactory(
		IPaginator paginator,
		ISortOrdererFactory sortOrdererFactory,
		IPostLikeIncluderFactory includerFactory,
		IPostLikesSortTermerFactory sortTermerFactory,
		IPostLikeIncludeBuilderFactory includeBuilderFactory,
		IPostLikeResponseFluentFactory responseFluentFactory,
		IPostLikesForUserSortTermerFactory forUserSortTermerFactory)
	{
		_paginator = paginator;
		_sortOrdererFactory = sortOrdererFactory;
		_includerFactory = includerFactory;
		_sortTermerFactory = sortTermerFactory;
		_includeBuilderFactory = includeBuilderFactory;
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
			_includeBuilderFactory,
			_responseFluentFactory,
			_forUserSortTermerFactory);
	}
}
