namespace InstaConnect.Identity.Infrastructure.Features.UserClaims.Helpers.Collections;

internal class UserClaimResponseFluentFactory : IUserClaimResponseFluentFactory
{
	private readonly IMongoDbFluentHandlerFactory _fluentHandlerFactory;

	public UserClaimResponseFluentFactory(IMongoDbFluentHandlerFactory fluentHandlerFactory)
	{
		_fluentHandlerFactory = fluentHandlerFactory;
	}

	public IUserClaimResponseFluent Create(IAggregateFluent<UserClaimResponse> fluent)
	{
		return new UserClaimResponseFluent(_fluentHandlerFactory.CreateResponse(fluent));
	}
}
