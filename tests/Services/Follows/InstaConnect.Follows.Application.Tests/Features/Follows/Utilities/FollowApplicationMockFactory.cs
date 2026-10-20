using InstaConnect.Follows.Domain.Features.Follows.Abstractions;

namespace InstaConnect.Follows.Application.Tests.Features.Follows.Utilities;

public static class FollowApplicationMockFactory
{
	public static IFollowCommandService CreateCommandService()
	{
		return Mocker.Mock<IFollowCommandService>();
	}

	public static IFollowQueryService CreateQueryService()
	{
		return Mocker.Mock<IFollowQueryService>();
	}
}
