namespace InstaConnect.Posts.Infrastructure.Features.PostCommentLikes.Helpers.Collections;

internal class PostCommentLikeResponseFluent :
	MongoDbResponseFluent<PostCommentLikeResponse>, IPostCommentLikeResponseFluent
{
	private readonly IPaginator _paginator;
	private readonly ISortOrdererFactory _sortOrdererFactory;
	private readonly IPostCommentLikesSortTermerFactory _sortTermerFactory;
	private readonly IPostCommentLikesForUserSortTermerFactory _forUserSortTermerFactory;

	public PostCommentLikeResponseFluent(
		IPaginator paginator,
		IAggregateFluent<PostCommentLikeResponse> fluent,
		ISortOrdererFactory sortOrdererFactory,
		IPostCommentLikesSortTermerFactory sortTermerFactory,
		IPostCommentLikesForUserSortTermerFactory forUserSortTermerFactory) : base(fluent)
	{
		_paginator = paginator;
		_sortOrdererFactory = sortOrdererFactory;
		_sortTermerFactory = sortTermerFactory;
		_forUserSortTermerFactory = forUserSortTermerFactory;
	}

	public IPostCommentLikeResponseFluent ApplySorting(PostCommentLikesSortingQuery query)
	{
		ApplySorting(_sortOrdererFactory, _sortTermerFactory, query);

		return this;
	}

	public IPostCommentLikeResponseFluent ApplySorting(PostCommentLikesForUserSortingQuery query)
	{
		ApplySorting(_sortOrdererFactory, _forUserSortTermerFactory, query);

		return this;
	}

	public IPostCommentLikeResponseFluent ApplyPagination(PostCommentLikesPaginationQuery query)
	{
		ApplyPagination(_paginator, query);

		return this;
	}
}
