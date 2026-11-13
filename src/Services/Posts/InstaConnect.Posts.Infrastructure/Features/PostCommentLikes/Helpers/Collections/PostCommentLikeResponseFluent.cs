namespace InstaConnect.Posts.Infrastructure.Features.PostCommentLikes.Helpers.Collections;

internal class PostCommentLikeResponseFluent : IPostCommentLikeResponseFluent
{
	private readonly IPaginator _paginator;
	private readonly ISortOrdererFactory _sortOrdererFactory;
	private readonly IPostCommentLikesSortTermerFactory _sortTermerFactory;
	private readonly IPostCommentLikesForUserSortTermerFactory _forUserSortTermerFactory;
	private readonly IMongoDbResponseFluentHandler<PostCommentLikeResponse> _fluentHandler;

	public PostCommentLikeResponseFluent(
		IPaginator paginator,
		ISortOrdererFactory sortOrdererFactory,
		IPostCommentLikesSortTermerFactory sortTermerFactory,
		IPostCommentLikesForUserSortTermerFactory forUserSortTermerFactory,
		IMongoDbResponseFluentHandler<PostCommentLikeResponse> fluentHandler)
	{
		_paginator = paginator;
		_fluentHandler = fluentHandler;
		_sortTermerFactory = sortTermerFactory;
		_sortOrdererFactory = sortOrdererFactory;
		_forUserSortTermerFactory = forUserSortTermerFactory;
	}

	public IPostCommentLikeResponseFluent Sort(PostCommentLikesSortingQuery query)
	{
		_fluentHandler.Sort(_sortOrdererFactory, _sortTermerFactory, query);

		return this;
	}

	public IPostCommentLikeResponseFluent Sort(PostCommentLikesForUserSortingQuery query)
	{
		_fluentHandler.Sort(_sortOrdererFactory, _forUserSortTermerFactory, query);

		return this;
	}

	public IPostCommentLikeResponseFluent Paginate(PostCommentLikesPaginationQuery query)
	{
		_fluentHandler.Paginate(_paginator, query);

		return this;
	}

	public async Task<PostCommentLikeResponse?> FirstOrDefaultAsync(CancellationToken cancellationToken)
	{
		return await _fluentHandler.FirstOrDefaultAsync(cancellationToken);
	}

	public async Task<ICollection<PostCommentLikeResponse>> ToListAsync(CancellationToken cancellationToken)
	{
		return await _fluentHandler.ToListAsync(cancellationToken);
	}
}
