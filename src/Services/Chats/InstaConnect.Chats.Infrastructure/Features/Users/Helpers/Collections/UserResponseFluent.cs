namespace InstaConnect.Chats.Infrastructure.Features.Users.Helpers.Collections;

internal class UserResponseFluent :
	MongoDbResponseFluent<UserResponse>, IUserResponseFluent
{
	public UserResponseFluent(IAggregateFluent<UserResponse> fluent) : base(fluent)
	{
	}
}
