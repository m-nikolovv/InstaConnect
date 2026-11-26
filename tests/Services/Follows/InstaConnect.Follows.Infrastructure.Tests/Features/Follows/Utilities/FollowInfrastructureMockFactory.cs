using InstaConnect.Follows.Infrastructure.Features.Follows.Abstractions;

namespace InstaConnect.Follows.Infrastructure.Tests.Features.Follows.Utilities;

public static class FollowInfrastructureMockFactory
{
	public static IFollowCollection CreateCollection()
	{
		return Mocker.Mock<IFollowCollection>();
	}

	public static IFollowFluent CreateFluent()
	{
		return Mocker.Mock<IFollowFluent>();
	}

	public static IFollowResponseFluent CreateResponseFluent()
	{
		return Mocker.Mock<IFollowResponseFluent>();
	}

	public static IFollowCacheHandler CreateCacheHandler()
	{
		return Mocker.Mock<IFollowCacheHandler>();
	}
}
