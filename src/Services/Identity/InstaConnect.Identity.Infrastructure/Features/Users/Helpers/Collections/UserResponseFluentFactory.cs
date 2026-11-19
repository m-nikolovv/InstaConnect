namespace InstaConnect.Identity.Infrastructure.Features.Users.Helpers.Collections;

internal class UserResponseFluentFactory : IUserResponseFluentFactory
{
	private readonly IPaginator _paginator;
	private readonly ISortOrdererFactory _sortOrdererFactory;
	private readonly IUsersSortTermerFactory _sortTermerFactory;
	private readonly IMongoDbFluentHandlerFactory _fluentHandlerFactory;

	public UserResponseFluentFactory(
		IPaginator paginator,
		ISortOrdererFactory sortOrdererFactory,
		IUsersSortTermerFactory sortTermerFactory,
		IMongoDbFluentHandlerFactory fluentHandlerFactory)
	{
		_paginator = paginator;
		_sortTermerFactory = sortTermerFactory;
		_sortOrdererFactory = sortOrdererFactory;
		_fluentHandlerFactory = fluentHandlerFactory;
	}

	public IUserResponseFluent Create(IAggregateFluent<UserResponse> fluent)
	{
		return new UserResponseFluent(
			_paginator,
			_sortOrdererFactory,
			_sortTermerFactory,
			_fluentHandlerFactory.CreateResponse(fluent));
	}
}
