using InstaConnect.Posts.Domain.Features.Users.Abstractions;

namespace InstaConnect.Posts.Application.Tests.Features.Users.Utilities;

public static class UserApplicationMockFactory
{
	public static IUserCommandService CreateCommandService()
	{
		return Mocker.Mock<IUserCommandService>();
	}
}
