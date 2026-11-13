namespace InstaConnect.Identity.Infrastructure.Features.Users.Helpers.Collections;

internal class UserFluentFactory : IUserFluentFactory
{
	private readonly IPaginator _paginator;
	private readonly IUserIncluderFactory _includerFactory;
	private readonly ISortOrdererFactory _sortOrdererFactory;
	private readonly IUsersSortTermerFactory _sortTermerFactory;
	private readonly IUserResponseFluentFactory _responseFluentFactory;
	private readonly IMongoDbFluentHandlerFactory _fluentHandlerFactory;

	public UserFluentFactory(
		IPaginator paginator,
		IUserIncluderFactory includerFactory,
		ISortOrdererFactory sortOrdererFactory,
		IUsersSortTermerFactory sortTermerFactory,
		IUserResponseFluentFactory responseFluentFactory,
		IMongoDbFluentHandlerFactory fluentHandlerFactory)
	{
		_paginator = paginator;
		_includerFactory = includerFactory;
		_sortTermerFactory = sortTermerFactory;
		_sortOrdererFactory = sortOrdererFactory;
		_fluentHandlerFactory = fluentHandlerFactory;
		_responseFluentFactory = responseFluentFactory;
	}

	public IUserFluent Create(IAggregateFluent<User> fluent)
	{
		return new UserFluent(
			_paginator,
			_includerFactory,
			_sortOrdererFactory,
			_sortTermerFactory,
			_responseFluentFactory,
			_fluentHandlerFactory.Create<User, UserId>(fluent));
	}
}
