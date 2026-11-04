namespace InstaConnect.Identity.Infrastructure.Features.Users.Helpers.Collections;

internal class UserFluentFactory : IUserFluentFactory
{
	private readonly IPaginator _paginator;
	private readonly IUserIncluderFactory _includerFactory;
	private readonly ISortOrdererFactory _sortOrdererFactory;
	private readonly IUsersSortTermerFactory _sortTermerFactory;
	private readonly IUserResponseFluentFactory _responseFluentFactory;

	public UserFluentFactory(
		IPaginator paginator,
		IUserIncluderFactory includerFactory,
		ISortOrdererFactory sortOrdererFactory,
		IUsersSortTermerFactory sortTermerFactory,
		IUserResponseFluentFactory responseFluentFactory)
	{
		_paginator = paginator;
		_includerFactory = includerFactory;
		_sortOrdererFactory = sortOrdererFactory;
		_sortTermerFactory = sortTermerFactory;
		_responseFluentFactory = responseFluentFactory;
	}

	public IUserFluent Create(IAggregateFluent<User> fluent)
	{
		return new UserFluent(
			fluent,
			_paginator,
			_includerFactory,
			_sortOrdererFactory,
			_sortTermerFactory,
			_responseFluentFactory);
	}
}
