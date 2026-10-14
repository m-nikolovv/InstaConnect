namespace InstaConnect.Identity.Tests.Features.Users.Builders;

public class UserBuilderFactory
{
	public UserBuilder Create(string passwordHash)
	{
		return new(passwordHash);
	}
}
