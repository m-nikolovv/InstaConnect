using InstaConnect.Posts.Infrastructure.Features.Users.Abstractions;

namespace InstaConnect.Posts.Infrastructure.Tests.Features.Users.Utilities;

public static class UserInfrastructureMockFactory
{
	public static IUserCollection CreateCollection()
	{
		return Mocker.Mock<IUserCollection>();
	}

	public static IUserFluent CreateFluent()
	{
		return Mocker.Mock<IUserFluent>();
	}

	public static IUserResponseFluent CreateResponseFluent()
	{
		return Mocker.Mock<IUserResponseFluent>();
	}

	public static IUserCacheHandler CreateCacheHandler()
	{
		return Mocker.Mock<IUserCacheHandler>();
	}
}
