namespace InstaConnect.Identity.Infrastructure.Features.Users.Helpers.Collections;

internal class UserFluentFactory : IUserFluentFactory
{
	private readonly IUserIncluderFactory _includerFactory;
	private readonly IUserResponseFluentFactory _responseFluentFactory;
	private readonly IMongoDbFluentHandlerFactory _fluentHandlerFactory;

	public UserFluentFactory(
		IUserIncluderFactory includerFactory,
		IUserResponseFluentFactory responseFluentFactory,
		IMongoDbFluentHandlerFactory fluentHandlerFactory)
	{
		_includerFactory = includerFactory;
		_fluentHandlerFactory = fluentHandlerFactory;
		_responseFluentFactory = responseFluentFactory;
	}

	public IUserFluent Create(IAggregateFluent<User> fluent)
	{
		return new UserFluent(
			_includerFactory,
			_responseFluentFactory,
			_fluentHandlerFactory.Create<User, UserId>(fluent));
	}
}
