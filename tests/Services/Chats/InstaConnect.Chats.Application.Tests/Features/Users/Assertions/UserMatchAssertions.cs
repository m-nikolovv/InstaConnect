using InstaConnect.Chats.Tests.Features.ChatMessages.Assertions;

namespace InstaConnect.Chats.Application.Tests.Features.Users.Assertions;

public static class UserMatchAssertions
{
	extension(AddUserCommandResponse response)
	{
		public void ShouldSatisfy(
		AddUserCommandRequest request,
		User user)
		{
			response.ShouldSatisfy(u => u.Matches(request, user));
		}
	}

	extension(UpdateUserCommandResponse response)
	{
		public void ShouldSatisfy(
		UpdateUserCommandRequest request,
		User user)
		{
			response.ShouldSatisfy(u => u.Matches(request, user));
		}
	}

	extension(User user)
	{
		public void ShouldSatisfy(AddUserCommandRequest request)
		{
			user.ShouldSatisfy(u => u.Matches(request));
		}

		public void ShouldSatisfy(UpdateUserCommandRequest request)
		{
			user.ShouldSatisfy(u => u.Matches(request));
		}
	}
}
