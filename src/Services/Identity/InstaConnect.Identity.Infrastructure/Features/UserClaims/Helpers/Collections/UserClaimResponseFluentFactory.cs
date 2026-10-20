using InstaConnect.Common.Domain.Features.Databases.Abstractions;

namespace InstaConnect.Identity.Infrastructure.Features.UserClaims.Helpers.Collections;

internal class UserClaimResponseFluentFactory : IUserClaimResponseFluentFactory
{
	private readonly IPaginator _paginator;
	private readonly ISortOrdererFactory _sortOrdererFactory;
	private readonly IUserClaimsSortTermerFactory _sortTermerFactory;

	public UserClaimResponseFluentFactory(
		IPaginator paginator,
		ISortOrdererFactory sortOrdererFactory,
		IUserClaimsSortTermerFactory sortTermerFactory)
	{
		_paginator = paginator;
		_sortOrdererFactory = sortOrdererFactory;
		_sortTermerFactory = sortTermerFactory;
	}

	public IUserClaimResponseFluent Create(IAggregateFluent<UserClaimResponse> fluent)
	{
		return new UserClaimResponseFluent(_paginator, fluent, _sortOrdererFactory, _sortTermerFactory);
	}
}
