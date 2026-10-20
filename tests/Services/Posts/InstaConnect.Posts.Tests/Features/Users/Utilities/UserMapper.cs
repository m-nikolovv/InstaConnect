namespace InstaConnect.Posts.Tests.Features.Users.Utilities;

public static class UserMapper
{
	extension(User user)
	{
		public UserId ToId()
		{
			return user.Id;
		}
	}
}
