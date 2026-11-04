namespace InstaConnect.Follows.Infrastructure.Features.Follows.Helpers.Collections;

internal class FollowFluentFactory : IFollowFluentFactory
{
	private readonly IPaginator _paginator;
	private readonly ISortOrdererFactory _sortOrdererFactory;
	private readonly IFollowIncluderFactory _includerFactory;
	private readonly IFollowsSortTermerFactory _sortTermerFactory;
	private readonly IFollowResponseFluentFactory _responseFluentFactory;
	private readonly IFollowsForFollowingSortTermerFactory _forFollowingSortTermerFactory;

	public FollowFluentFactory(
		IPaginator paginator,
		ISortOrdererFactory sortOrdererFactory,
		IFollowIncluderFactory includerFactory,
		IFollowsSortTermerFactory sortTermerFactory,
		IFollowResponseFluentFactory responseFluentFactory,
		IFollowsForFollowingSortTermerFactory forFollowingSortTermerFactory)
	{
		_paginator = paginator;
		_sortOrdererFactory = sortOrdererFactory;
		_includerFactory = includerFactory;
		_sortTermerFactory = sortTermerFactory;
		_responseFluentFactory = responseFluentFactory;
		_forFollowingSortTermerFactory = forFollowingSortTermerFactory;
	}

	public IFollowFluent Create(IAggregateFluent<Follow> fluent)
	{
		return new FollowFluent(
			fluent,
			_paginator,
			_sortOrdererFactory,
			_includerFactory,
			_sortTermerFactory,
			_responseFluentFactory,
			_forFollowingSortTermerFactory);
	}
}
