using InstaConnect.Chats.Domain.Features.Users.Abstractions;

namespace InstaConnect.Chats.Application.Tests.Features.Users.Utilities;

public static class UserApplicationMockFactory
{
	public static IUserCommandService CreateCommandService()
	{
		return Mocker.Mock<IUserCommandService>();
	}
}
