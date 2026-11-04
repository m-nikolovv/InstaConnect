namespace InstaConnect.Identity.Infrastructure.Features.UserClaims.Helpers.Collections;

internal class UserClaimFluentFactory : IUserClaimFluentFactory
{
	private readonly IPaginator _paginator;
	private readonly ISortOrdererFactory _sortOrdererFactory;
	private readonly IUserClaimIncluderFactory _includerFactory;
	private readonly IUserClaimsSortTermerFactory _sortTermerFactory;
	private readonly IUserClaimResponseFluentFactory _responseFluentFactory;

	public UserClaimFluentFactory(
		IPaginator paginator,
		ISortOrdererFactory sortOrdererFactory,
		IUserClaimIncluderFactory includerFactory,
		IUserClaimsSortTermerFactory sortTermerFactory,
		IUserClaimResponseFluentFactory responseFluentFactory)
	{
		_paginator = paginator;
		_sortOrdererFactory = sortOrdererFactory;
		_includerFactory = includerFactory;
		_sortTermerFactory = sortTermerFactory;
		_responseFluentFactory = responseFluentFactory;
	}

	public IUserClaimFluent Create(IAggregateFluent<UserClaim> fluent)
	{
		return new UserClaimFluent(
			fluent,
			_paginator,
			_sortOrdererFactory,
			_includerFactory,
			_sortTermerFactory,
			_responseFluentFactory);
	}
}
