namespace InstaConnect.Posts.Infrastructure.Features.Posts.Helpers.Collections;

internal class PostResponseFluent : IPostResponseFluent
{
	private readonly IPaginator _paginator;
	private readonly ISortOrdererFactory _sortOrdererFactory;
	private readonly IPostsSortTermerFactory _sortTermerFactory;
	private readonly IPostsForUserSortTermerFactory _forUserSortTermerFactory;
	private readonly IMongoDbResponseFluentHandler<PostResponse> _fluentHandler;

	public PostResponseFluent(
		IPaginator paginator,
		ISortOrdererFactory sortOrdererFactory,
		IPostsSortTermerFactory sortTermerFactory,
		IPostsForUserSortTermerFactory forUserSortTermerFactory,
		IMongoDbResponseFluentHandler<PostResponse> fluentHandler)
	{
		_paginator = paginator;
		_fluentHandler = fluentHandler;
		_sortTermerFactory = sortTermerFactory;
		_sortOrdererFactory = sortOrdererFactory;
		_forUserSortTermerFactory = forUserSortTermerFactory;
	}

	public IPostResponseFluent Sort(PostsSortingQuery query)
	{
		_fluentHandler.Sort(_sortOrdererFactory, _sortTermerFactory, query);

		return this;
	}

	public IPostResponseFluent Sort(PostsForUserSortingQuery query)
	{
		_fluentHandler.Sort(_sortOrdererFactory, _forUserSortTermerFactory, query);

		return this;
	}

	public IPostResponseFluent Paginate(PostsPaginationQuery query)
	{
		_fluentHandler.Paginate(_paginator, query);

		return this;
	}

	public async Task<PostResponse?> FirstOrDefaultAsync(CancellationToken cancellationToken)
	{
		return await _fluentHandler.FirstOrDefaultAsync(cancellationToken);
	}

	public async Task<ICollection<PostResponse>> ToListAsync(CancellationToken cancellationToken)
	{
		return await _fluentHandler.ToListAsync(cancellationToken);
	}
}
