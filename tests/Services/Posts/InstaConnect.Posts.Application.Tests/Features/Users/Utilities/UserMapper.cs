namespace InstaConnect.Posts.Application.Tests.Features.Users.Utilities;

public static class UserMapper
{
	extension(User user)
	{
		public UserId ToResponse(
			AddUserCommandRequest request)
		{
			return new(request.Id);
		}

		public UserId ToResponse(
			UpdateUserCommandRequest request)
		{
			return user.ToId();
		}
	}
}
