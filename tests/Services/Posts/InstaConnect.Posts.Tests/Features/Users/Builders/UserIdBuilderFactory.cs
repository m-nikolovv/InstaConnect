namespace InstaConnect.Posts.Tests.Features.Users.Builders;

public class UserIdBuilderFactory
{
	public UserIdBuilder Create(UserId id)
	{
		return new(id);
	}
}
