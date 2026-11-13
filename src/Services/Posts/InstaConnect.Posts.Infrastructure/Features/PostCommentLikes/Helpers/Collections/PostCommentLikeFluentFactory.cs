namespace InstaConnect.Posts.Infrastructure.Features.PostCommentLikes.Helpers.Collections;

internal class PostCommentLikeFluentFactory : IPostCommentLikeFluentFactory
{
	private readonly IPaginator _paginator;
	private readonly ISortOrdererFactory _sortOrdererFactory;
	private readonly IPostCommentLikeIncluderFactory _includerFactory;
	private readonly IMongoDbFluentHandlerFactory _fluentHandlerFactory;
	private readonly IPostCommentLikesSortTermerFactory _sortTermerFactory;
	private readonly IPostCommentLikeResponseFluentFactory _responseFluentFactory;
	private readonly IPostCommentLikesForUserSortTermerFactory _forUserSortTermerFactory;

	public PostCommentLikeFluentFactory(
		IPaginator paginator,
		ISortOrdererFactory sortOrdererFactory,
		IPostCommentLikeIncluderFactory includerFactory,
		IMongoDbFluentHandlerFactory fluentHandlerFactory,
		IPostCommentLikesSortTermerFactory sortTermerFactory,
		IPostCommentLikeResponseFluentFactory responseFluentFactory,
		IPostCommentLikesForUserSortTermerFactory forUserSortTermerFactory)
	{
		_paginator = paginator;
		_includerFactory = includerFactory;
		_sortTermerFactory = sortTermerFactory;
		_sortOrdererFactory = sortOrdererFactory;
		_fluentHandlerFactory = fluentHandlerFactory;
		_responseFluentFactory = responseFluentFactory;
		_forUserSortTermerFactory = forUserSortTermerFactory;
	}

	public IPostCommentLikeFluent Create(IAggregateFluent<PostCommentLike> fluent)
	{
		return new PostCommentLikeFluent(
			_paginator,
			_sortOrdererFactory,
			_includerFactory,
			_sortTermerFactory,
			_responseFluentFactory,
			_forUserSortTermerFactory,
			_fluentHandlerFactory.Create<PostCommentLike, PostCommentLikeId>(fluent));
	}
}
