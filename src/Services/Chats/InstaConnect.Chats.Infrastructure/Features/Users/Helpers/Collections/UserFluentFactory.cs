namespace InstaConnect.Chats.Infrastructure.Features.Users.Helpers.Collections;

internal class UserFluentFactory : IUserFluentFactory
{
	private readonly IUserIncluderFactory _includerFactory;
	private readonly IUserResponseFluentFactory _responseFluentFactory;

	public UserFluentFactory(IUserIncluderFactory includerFactory, IUserResponseFluentFactory responseFluentFactory)
	{
		_includerFactory = includerFactory;
		_responseFluentFactory = responseFluentFactory;
	}

	public IUserFluent Create(IAggregateFluent<User> fluent)
	{
		return new UserFluent(fluent, _includerFactory, _responseFluentFactory);
	}
}
