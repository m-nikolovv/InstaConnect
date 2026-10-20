using InstaConnect.Common.Domain.Features.Databases.Abstractions;

namespace InstaConnect.Identity.Infrastructure.Features.UserClaims.Helpers.Collections;

internal class UserClaimResponseFluent :
	MongoDbResponseFluent<UserClaimResponse>, IUserClaimResponseFluent
{
	private readonly IPaginator _paginator;
	private readonly ISortOrdererFactory _sortOrdererFactory;
	private readonly IUserClaimsSortTermerFactory _sortTermerFactory;

	public UserClaimResponseFluent(
		IPaginator paginator,
		IAggregateFluent<UserClaimResponse> fluent,
		ISortOrdererFactory sortOrdererFactory,
		IUserClaimsSortTermerFactory sortTermerFactory) : base(fluent)
	{
		_paginator = paginator;
		_sortOrdererFactory = sortOrdererFactory;
		_sortTermerFactory = sortTermerFactory;
	}

	public IUserClaimResponseFluent ApplySorting(UserClaimsSortingQuery query)
	{
		ApplySorting(_sortOrdererFactory, _sortTermerFactory, query);

		return this;
	}

	public IUserClaimResponseFluent ApplyPagination(UserClaimsPaginationQuery query)
	{
		ApplyPagination(_paginator, query);

		return this;
	}
}
