namespace InstaConnect.Posts.Tests.Features.Users.Assertions;

public static class UserMatchAssertions
{
	extension(User u)
	{
		public void ShouldSatisfy(User user)
		{
			u.ShouldSatisfy(u => u.Matches(user));
		}
	}
}
