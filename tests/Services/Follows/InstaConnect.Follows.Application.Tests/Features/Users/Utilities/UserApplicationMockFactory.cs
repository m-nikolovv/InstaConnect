using InstaConnect.Follows.Domain.Features.Users.Abstractions;

namespace InstaConnect.Follows.Application.Tests.Features.Users.Utilities;

public static class UserApplicationMockFactory
{
	public static IUserCommandService CreateCommandService()
	{
		return Mocker.Mock<IUserCommandService>();
	}
}
