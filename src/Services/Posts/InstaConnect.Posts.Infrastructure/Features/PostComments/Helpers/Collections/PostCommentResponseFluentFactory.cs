namespace InstaConnect.Posts.Infrastructure.Features.PostComments.Helpers.Collections;

internal class PostCommentResponseFluentFactory : IPostCommentResponseFluentFactory
{
	private readonly IPaginator _paginator;
	private readonly ISortOrdererFactory _sortOrdererFactory;
	private readonly IPostCommentsSortTermerFactory _sortTermerFactory;
	private readonly IMongoDbFluentHandlerFactory _fluentHandlerFactory;
	private readonly IPostCommentsForUserSortTermerFactory _forUserSortTermerFactory;

	public PostCommentResponseFluentFactory(
		IPaginator paginator,
		ISortOrdererFactory sortOrdererFactory,
		IPostCommentsSortTermerFactory sortTermerFactory,
		IMongoDbFluentHandlerFactory fluentHandlerFactory,
		IPostCommentsForUserSortTermerFactory forUserSortTermerFactory)
	{
		_paginator = paginator;
		_sortTermerFactory = sortTermerFactory;
		_sortOrdererFactory = sortOrdererFactory;
		_fluentHandlerFactory = fluentHandlerFactory;
		_forUserSortTermerFactory = forUserSortTermerFactory;
	}

	public IPostCommentResponseFluent Create(IAggregateFluent<PostCommentResponse> fluent)
	{
		return new PostCommentResponseFluent(
			_paginator,
			_sortOrdererFactory,
			_sortTermerFactory,
			_forUserSortTermerFactory,
			_fluentHandlerFactory.CreateResponse(fluent));
	}
}
