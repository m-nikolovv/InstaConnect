namespace InstaConnect.Chats.Infrastructure.Features.Users.Helpers.Collections;

internal class UserResponseFluentFactory : IUserResponseFluentFactory
{
	private readonly IMongoDbFluentHandlerFactory _fluentHandlerFactory;

	public UserResponseFluentFactory(IMongoDbFluentHandlerFactory fluentHandlerFactory)
	{
		_fluentHandlerFactory = fluentHandlerFactory;
	}

	public IUserResponseFluent Create(IAggregateFluent<UserResponse> fluent)
	{
		return new UserResponseFluent(_fluentHandlerFactory.CreateResponse(fluent));
	}
}
