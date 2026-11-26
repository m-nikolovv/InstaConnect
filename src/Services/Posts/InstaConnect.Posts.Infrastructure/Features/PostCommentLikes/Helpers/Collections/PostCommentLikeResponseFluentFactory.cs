namespace InstaConnect.Posts.Infrastructure.Features.PostCommentLikes.Helpers.Collections;

internal class PostCommentLikeResponseFluentFactory : IPostCommentLikeResponseFluentFactory
{
	private readonly IPaginator _paginator;
	private readonly ISortOrdererFactory _sortOrdererFactory;
	private readonly IMongoDbFluentHandlerFactory _fluentHandlerFactory;
	private readonly IPostCommentLikesSortTermerFactory _sortTermerFactory;
	private readonly IPostCommentLikesForUserSortTermerFactory _forUserSortTermerFactory;

	public PostCommentLikeResponseFluentFactory(
		IPaginator paginator,
		ISortOrdererFactory sortOrdererFactory,
		IMongoDbFluentHandlerFactory fluentHandlerFactory,
		IPostCommentLikesSortTermerFactory sortTermerFactory,
		IPostCommentLikesForUserSortTermerFactory forUserSortTermerFactory)
	{
		_paginator = paginator;
		_sortTermerFactory = sortTermerFactory;
		_sortOrdererFactory = sortOrdererFactory;
		_fluentHandlerFactory = fluentHandlerFactory;
		_forUserSortTermerFactory = forUserSortTermerFactory;
	}

	public IPostCommentLikeResponseFluent Create(IAggregateFluent<PostCommentLikeResponse> fluent)
	{
		return new PostCommentLikeResponseFluent(
			_paginator,
			_sortOrdererFactory,
			_sortTermerFactory,
			_forUserSortTermerFactory,
			_fluentHandlerFactory.CreateResponse(fluent));
	}
}
