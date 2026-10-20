namespace InstaConnect.Follows.Infrastructure.Features.Users.Helpers.Collections;

internal class UserResponseFluentFactory : IUserResponseFluentFactory
{
	public IUserResponseFluent Create(IAggregateFluent<UserResponse> fluent)
	{
		return new UserResponseFluent(fluent);
	}
}
