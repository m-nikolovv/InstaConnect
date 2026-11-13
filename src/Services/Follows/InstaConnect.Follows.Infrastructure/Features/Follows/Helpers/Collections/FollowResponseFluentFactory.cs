namespace InstaConnect.Follows.Infrastructure.Features.Follows.Helpers.Collections;

internal class FollowResponseFluentFactory : IFollowResponseFluentFactory
{
	private readonly IPaginator _paginator;
	private readonly ISortOrdererFactory _sortOrdererFactory;
	private readonly IFollowsSortTermerFactory _sortTermerFactory;
	private readonly IMongoDbFluentHandlerFactory _fluentHandlerFactory;
	private readonly IFollowsForFollowingSortTermerFactory _forFollowingSortTermerFactory;

	public FollowResponseFluentFactory(
		IPaginator paginator,
		ISortOrdererFactory sortOrdererFactory,
		IFollowsSortTermerFactory sortTermerFactory,
		IMongoDbFluentHandlerFactory fluentHandlerFactory,
		IFollowsForFollowingSortTermerFactory forFollowingSortTermerFactory)
	{
		_paginator = paginator;
		_sortTermerFactory = sortTermerFactory;
		_sortOrdererFactory = sortOrdererFactory;
		_fluentHandlerFactory = fluentHandlerFactory;
		_forFollowingSortTermerFactory = forFollowingSortTermerFactory;
	}

	public IFollowResponseFluent Create(IAggregateFluent<FollowResponse> fluent)
	{
		return new FollowResponseFluent(
			_paginator,
			_sortOrdererFactory,
			_sortTermerFactory,
			_fluentHandlerFactory.CreateResponse(fluent),
			_forFollowingSortTermerFactory);
	}
}
