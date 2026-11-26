namespace InstaConnect.Posts.Infrastructure.Features.PostLikes.Helpers.Collections;

internal class PostLikeResponseFluent : IPostLikeResponseFluent
{
	private readonly IPaginator _paginator;
	private readonly ISortOrdererFactory _sortOrdererFactory;
	private readonly IPostLikesSortTermerFactory _sortTermerFactory;
	private readonly IPostLikesForUserSortTermerFactory _forUserSortTermerFactory;
	private readonly IMongoDbResponseFluentHandler<PostLikeResponse> _fluentHandler;

	public PostLikeResponseFluent(
		IPaginator paginator,
		ISortOrdererFactory sortOrdererFactory,
		IPostLikesSortTermerFactory sortTermerFactory,
		IPostLikesForUserSortTermerFactory forUserSortTermerFactory,
		IMongoDbResponseFluentHandler<PostLikeResponse> fluentHandler)
	{
		_paginator = paginator;
		_fluentHandler = fluentHandler;
		_sortTermerFactory = sortTermerFactory;
		_sortOrdererFactory = sortOrdererFactory;
		_forUserSortTermerFactory = forUserSortTermerFactory;
	}

	public IPostLikeResponseFluent Sort(PostLikesSortingQuery query)
	{
		_fluentHandler.Sort(_sortOrdererFactory, _sortTermerFactory, query);

		return this;
	}

	public IPostLikeResponseFluent Sort(PostLikesForUserSortingQuery query)
	{
		_fluentHandler.Sort(_sortOrdererFactory, _forUserSortTermerFactory, query);

		return this;
	}

	public IPostLikeResponseFluent Paginate(PostLikesPaginationQuery query)
	{
		_fluentHandler.Paginate(_paginator, query);

		return this;
	}

	public async Task<PostLikeResponse?> FirstOrDefaultAsync(CancellationToken cancellationToken)
	{
		return await _fluentHandler.FirstOrDefaultAsync(cancellationToken);
	}

	public async Task<ICollection<PostLikeResponse>> ToListAsync(CancellationToken cancellationToken)
	{
		return await _fluentHandler.ToListAsync(cancellationToken);
	}
}
