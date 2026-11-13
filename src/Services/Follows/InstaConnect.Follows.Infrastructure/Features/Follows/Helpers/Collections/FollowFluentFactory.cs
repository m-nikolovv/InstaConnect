namespace InstaConnect.Follows.Infrastructure.Features.Follows.Helpers.Collections;

internal class FollowFluentFactory : IFollowFluentFactory
{
	private readonly IPaginator _paginator;
	private readonly IFollowIncluderFactory _includerFactory;
	private readonly ISortOrdererFactory _sortOrdererFactory;
	private readonly IFollowsSortTermerFactory _sortTermerFactory;
	private readonly IMongoDbFluentHandlerFactory _fluentHandlerFactory;
	private readonly IFollowResponseFluentFactory _responseFluentFactory;
	private readonly IFollowsForFollowingSortTermerFactory _forFollowingSortTermerFactory;

	public FollowFluentFactory(
		IPaginator paginator,
		IFollowIncluderFactory includerFactory,
		ISortOrdererFactory sortOrdererFactory,
		IFollowsSortTermerFactory sortTermerFactory,
		IMongoDbFluentHandlerFactory fluentHandlerFactory,
		IFollowResponseFluentFactory responseFluentFactory,
		IFollowsForFollowingSortTermerFactory forFollowingSortTermerFactory)
	{
		_paginator = paginator;
		_includerFactory = includerFactory;
		_sortTermerFactory = sortTermerFactory;
		_sortOrdererFactory = sortOrdererFactory;
		_fluentHandlerFactory = fluentHandlerFactory;
		_responseFluentFactory = responseFluentFactory;
		_forFollowingSortTermerFactory = forFollowingSortTermerFactory;
	}

	public IFollowFluent Create(IAggregateFluent<Follow> fluent)
	{
		return new FollowFluent(
			_paginator,
			_includerFactory,
			_sortOrdererFactory,
			_sortTermerFactory,
			_responseFluentFactory,
			_fluentHandlerFactory.Create<Follow, FollowId>(fluent),
			_forFollowingSortTermerFactory);
	}
}
