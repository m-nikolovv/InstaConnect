namespace InstaConnect.Follows.Infrastructure.Features.Follows.Helpers.Collections;

internal class FollowResponseFluent : IFollowResponseFluent
{
	private readonly IPaginator _paginator;
	private readonly ISortOrdererFactory _sortOrdererFactory;
	private readonly IFollowsSortTermerFactory _sortTermerFactory;
	private readonly IMongoDbResponseFluentHandler<FollowResponse> _fluentHandler;
	private readonly IFollowsForFollowingSortTermerFactory _forFollowingSortTermerFactory;

	public FollowResponseFluent(
		IPaginator paginator,
		ISortOrdererFactory sortOrdererFactory,
		IFollowsSortTermerFactory sortTermerFactory,
		IMongoDbResponseFluentHandler<FollowResponse> fluentHandler,
		IFollowsForFollowingSortTermerFactory forFollowingSortTermerFactory)
	{
		_paginator = paginator;
		_fluentHandler = fluentHandler;
		_sortTermerFactory = sortTermerFactory;
		_sortOrdererFactory = sortOrdererFactory;
		_forFollowingSortTermerFactory = forFollowingSortTermerFactory;
	}

	public IFollowResponseFluent ApplySorting(FollowsSortingQuery query)
	{
		_fluentHandler.ApplySorting(_sortOrdererFactory, _sortTermerFactory, query);

		return this;
	}

	public IFollowResponseFluent ApplySorting(FollowsForFollowingSortingQuery query)
	{
		_fluentHandler.ApplySorting(_sortOrdererFactory, _forFollowingSortTermerFactory, query);

		return this;
	}

	public IFollowResponseFluent ApplyPagination(FollowsPaginationQuery query)
	{
		_fluentHandler.ApplyPagination(_paginator, query);

		return this;
	}

	public async Task<FollowResponse?> FirstOrDefaultAsync(CancellationToken cancellationToken)
	{
		return await _fluentHandler.FirstOrDefaultAsync(cancellationToken);
	}

	public async Task<ICollection<FollowResponse>> ToListAsync(CancellationToken cancellationToken)
	{
		return await _fluentHandler.ToListAsync(cancellationToken);
	}
}
