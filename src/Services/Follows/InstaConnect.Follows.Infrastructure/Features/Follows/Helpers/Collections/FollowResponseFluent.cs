namespace InstaConnect.Follows.Infrastructure.Features.Follows.Helpers.Collections;

internal class FollowResponseFluent :
	MongoDbResponseFluent<FollowResponse>, IFollowResponseFluent
{
	private readonly IPaginator _paginator;
	private readonly ISortOrdererFactory _sortOrdererFactory;
	private readonly IFollowsSortTermerFactory _sortTermerFactory;
	private readonly IFollowsForFollowingSortTermerFactory _forFollowingSortTermerFactory;

	public FollowResponseFluent(
		IPaginator paginator,
		IAggregateFluent<FollowResponse> fluent,
		ISortOrdererFactory sortOrdererFactory,
		IFollowsSortTermerFactory sortTermerFactory,
		IFollowsForFollowingSortTermerFactory forFollowingSortTermerFactory) : base(fluent)
	{
		_paginator = paginator;
		_sortOrdererFactory = sortOrdererFactory;
		_sortTermerFactory = sortTermerFactory;
		_forFollowingSortTermerFactory = forFollowingSortTermerFactory;
	}

	public IFollowResponseFluent ApplySorting(FollowsSortingQuery query)
	{
		ApplySorting(_sortOrdererFactory, _sortTermerFactory, query);

		return this;
	}

	public IFollowResponseFluent ApplySorting(FollowsForFollowingSortingQuery query)
	{
		ApplySorting(_sortOrdererFactory, _forFollowingSortTermerFactory, query);

		return this;
	}

	public IFollowResponseFluent ApplyPagination(FollowsPaginationQuery query)
	{
		ApplyPagination(_paginator, query);

		return this;
	}
}
