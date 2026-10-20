namespace InstaConnect.Follows.Domain.Tests.Features.Users.Assertions;

public static class UserMatchAssertions
{
	extension(UserId response)
	{
		public void ShouldSatisfy(
			AddUserCommand request,
			User user)
		{
			response.ShouldSatisfy(u => u.Matches(request, user));
		}

		public void ShouldSatisfy(
			UpdateUserCommand request,
			User user)
		{
			response.ShouldSatisfy(u => u.Matches(request, user));
		}
	}

	extension(User u)
	{
		public void ShouldSatisfy(AddUserCommand request)
		{
			u.ShouldSatisfy(u => u.Matches(request));
		}

		public void ShouldSatisfy(UpdateUserCommand request)
		{
			u.ShouldSatisfy(u => u.Matches(request));
		}
	}
}
