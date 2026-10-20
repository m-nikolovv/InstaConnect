namespace InstaConnect.Posts.Domain.Tests.Features.Users.Assertions;

public static class UserMatchAssertions
{
	extension(UserId response)
	{
		public void ShouldSatisfy(
			AddUserCommand command,
			User user)
		{
			response.ShouldSatisfy(u => u.Matches(command, user));
		}

		public void ShouldSatisfy(
			UpdateUserCommand command,
			User user)
		{
			response.ShouldSatisfy(u => u.Matches(command, user));
		}
	}

	extension(User u)
	{
		public void ShouldSatisfy(AddUserCommand command)
		{
			u.ShouldSatisfy(u => u.Matches(command));
		}

		public void ShouldSatisfy(UpdateUserCommand command)
		{
			u.ShouldSatisfy(u => u.Matches(command));
		}
	}
}
