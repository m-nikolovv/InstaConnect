namespace InstaConnect.Identity.Infrastructure.Features.UserClaims.Helpers.Collections;

internal class UserClaimResponseFluent : IUserClaimResponseFluent
{
	private readonly IPaginator _paginator;
	private readonly ISortOrdererFactory _sortOrdererFactory;
	private readonly IUserClaimsSortTermerFactory _sortTermerFactory;
	private readonly IMongoDbResponseFluentHandler<UserClaimResponse> _fluentHandler;

	public UserClaimResponseFluent(
		IPaginator paginator,
		ISortOrdererFactory sortOrdererFactory,
		IUserClaimsSortTermerFactory sortTermerFactory,
		IMongoDbResponseFluentHandler<UserClaimResponse> fluentHandler)
	{
		_paginator = paginator;
		_fluentHandler = fluentHandler;
		_sortTermerFactory = sortTermerFactory;
		_sortOrdererFactory = sortOrdererFactory;
	}

	public IUserClaimResponseFluent ApplySorting(UserClaimsSortingQuery query)
	{
		_fluentHandler.ApplySorting(_sortOrdererFactory, _sortTermerFactory, query);

		return this;
	}

	public IUserClaimResponseFluent ApplyPagination(UserClaimsPaginationQuery query)
	{
		_fluentHandler.ApplyPagination(_paginator, query);

		return this;
	}

	public async Task<UserClaimResponse?> FirstOrDefaultAsync(CancellationToken cancellationToken)
	{
		return await _fluentHandler.FirstOrDefaultAsync(cancellationToken);
	}

	public async Task<ICollection<UserClaimResponse>> ToListAsync(CancellationToken cancellationToken)
	{
		return await _fluentHandler.ToListAsync(cancellationToken);
	}
}
