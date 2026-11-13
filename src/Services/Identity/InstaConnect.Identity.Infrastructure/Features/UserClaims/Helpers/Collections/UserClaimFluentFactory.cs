namespace InstaConnect.Identity.Infrastructure.Features.UserClaims.Helpers.Collections;

internal class UserClaimFluentFactory : IUserClaimFluentFactory
{
	private readonly IUserClaimIncluderFactory _includerFactory;
	private readonly IMongoDbFluentHandlerFactory _fluentHandlerFactory;
	private readonly IUserClaimResponseFluentFactory _responseFluentFactory;

	public UserClaimFluentFactory(
		IUserClaimIncluderFactory includerFactory,
		IMongoDbFluentHandlerFactory fluentHandlerFactory,
		IUserClaimResponseFluentFactory responseFluentFactory)
	{
		_includerFactory = includerFactory;
		_fluentHandlerFactory = fluentHandlerFactory;
		_responseFluentFactory = responseFluentFactory;
	}

	public IUserClaimFluent Create(IAggregateFluent<UserClaim> fluent)
	{
		return new UserClaimFluent(
			_includerFactory,
			_responseFluentFactory,
			_fluentHandlerFactory.Create<UserClaim, UserClaimId>(fluent));
	}
}
