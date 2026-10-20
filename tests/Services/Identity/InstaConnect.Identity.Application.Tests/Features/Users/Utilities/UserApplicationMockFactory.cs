using InstaConnect.Identity.Domain.Features.Users.Abstractions;

namespace InstaConnect.Identity.Application.Tests.Features.Users.Utilities;

public static class UserApplicationMockFactory
{
	public static IUserCommandService CreateCommandService()
	{
		return Mocker.Mock<IUserCommandService>();
	}

	public static IUserQueryService CreateQueryService()
	{
		return Mocker.Mock<IUserQueryService>();
	}
}
