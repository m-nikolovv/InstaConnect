namespace InstaConnect.Chats.Application.Tests.Features.Users.Utilities;

public static class UserMapper
{
	extension(User user)
	{
		public UserId ToResponse(
			AddUserCommandRequest request)
		{
			return user.ToId();
		}

		public UserId ToResponse(
			UpdateUserCommandRequest request)
		{
			return user.ToId();
		}
	}
}
