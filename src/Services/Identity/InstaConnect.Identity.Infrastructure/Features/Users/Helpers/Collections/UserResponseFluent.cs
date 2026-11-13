namespace InstaConnect.Identity.Infrastructure.Features.Users.Helpers.Collections;

internal class UserResponseFluent : IUserResponseFluent
{
	private readonly IPaginator _paginator;
	private readonly ISortOrdererFactory _sortOrdererFactory;
	private readonly IUsersSortTermerFactory _sortTermerFactory;
	private readonly IMongoDbResponseFluentHandler<UserResponse> _fluentHandler;

	public UserResponseFluent(
		IPaginator paginator,
		ISortOrdererFactory sortOrdererFactory,
		IUsersSortTermerFactory sortTermerFactory,
		IMongoDbResponseFluentHandler<UserResponse> fluentHandler)
	{
		_paginator = paginator;
		_fluentHandler = fluentHandler;
		_sortTermerFactory = sortTermerFactory;
		_sortOrdererFactory = sortOrdererFactory;
	}

	public IUserResponseFluent Sort(UsersSortingQuery query)
	{
		_fluentHandler.Sort(_sortOrdererFactory, _sortTermerFactory, query);

		return this;
	}

	public IUserResponseFluent Paginate(UsersPaginationQuery query)
	{
		_fluentHandler.Paginate(_paginator, query);

		return this;
	}

	public async Task<UserResponse?> FirstOrDefaultAsync(CancellationToken cancellationToken)
	{
		return await _fluentHandler.FirstOrDefaultAsync(cancellationToken);
	}

	public async Task<ICollection<UserResponse>> ToListAsync(CancellationToken cancellationToken)
	{
		return await _fluentHandler.ToListAsync(cancellationToken);
	}
}
