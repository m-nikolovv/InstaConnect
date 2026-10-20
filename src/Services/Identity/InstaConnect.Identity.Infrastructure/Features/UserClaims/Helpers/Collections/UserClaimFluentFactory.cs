namespace InstaConnect.Identity.Infrastructure.Features.UserClaims.Helpers.Collections;

internal class UserClaimFluentFactory : IUserClaimFluentFactory
{
	private readonly IUserClaimIncluderFactory _includerFactory;
	private readonly IUserClaimResponseFluentFactory _responseFluentFactory;

	public UserClaimFluentFactory(IUserClaimIncluderFactory includerFactory, IUserClaimResponseFluentFactory responseFluentFactory)
	{
		_includerFactory = includerFactory;
		_responseFluentFactory = responseFluentFactory;
	}

	public IUserClaimFluent Create(IAggregateFluent<UserClaim> fluent)
	{
		return new UserClaimFluent(fluent, _includerFactory, _responseFluentFactory);
	}
}
