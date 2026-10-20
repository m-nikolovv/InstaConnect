namespace InstaConnect.Posts.Infrastructure.Features.PostCommentLikes.Helpers.Collections;

internal class PostCommentLikeResponseFluentFactory : IPostCommentLikeResponseFluentFactory
{
	private readonly IPaginator _paginator;
	private readonly ISortOrdererFactory _sortOrdererFactory;
	private readonly IPostCommentLikesSortTermerFactory _sortTermerFactory;
	private readonly IPostCommentLikesForUserSortTermerFactory _forUserSortTermerFactory;

	public PostCommentLikeResponseFluentFactory(
		IPaginator paginator,
		ISortOrdererFactory sortOrdererFactory,
		IPostCommentLikesSortTermerFactory sortTermerFactory,
		IPostCommentLikesForUserSortTermerFactory forUserSortTermerFactory)
	{
		_paginator = paginator;
		_sortOrdererFactory = sortOrdererFactory;
		_sortTermerFactory = sortTermerFactory;
		_forUserSortTermerFactory = forUserSortTermerFactory;
	}

	public IPostCommentLikeResponseFluent Create(IAggregateFluent<PostCommentLikeResponse> fluent)
	{
		return new PostCommentLikeResponseFluent(_paginator, fluent, _sortOrdererFactory, _sortTermerFactory, _forUserSortTermerFactory);
	}
}
