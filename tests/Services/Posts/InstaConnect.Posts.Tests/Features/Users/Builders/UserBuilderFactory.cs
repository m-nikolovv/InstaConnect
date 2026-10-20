namespace InstaConnect.Posts.Tests.Features.Users.Builders;

public class UserBuilderFactory
{
	public UserBuilder Create()
	{
		return new();
	}

	public UserBuilder Create(User user)
	{
		return new(user);
	}
}
