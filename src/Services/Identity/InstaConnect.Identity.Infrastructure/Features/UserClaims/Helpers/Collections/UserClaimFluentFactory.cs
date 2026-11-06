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
		_includerFactory = includerFactory;
		_sortTermerFactory = sortTermerFactory;
		_sortOrdererFactory = sortOrdererFactory;
		_responseFluentFactory = responseFluentFactory;
	}

	public IUserClaimFluent Create(IAggregateFluent<UserClaim> fluent)
	{
		return new UserClaimFluent(
			_paginator,
			fluent,
			_sortOrdererFactory,
			_includerFactory,
			_sortTermerFactory,
			_responseFluentFactory);
	}
}
