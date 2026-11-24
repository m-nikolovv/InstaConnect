using InstaConnect.Posts.Infrastructure.Features.Posts.Abstractions;

namespace InstaConnect.Posts.Infrastructure.Tests.Features.Posts.Utilities;

public static class PostInfrastructureMockFactory
{
	public static IPostCollection CreateCollection()
	{
		return Mocker.Mock<IPostCollection>();
	}

	public static IPostFluent CreateFluent()
	{
		return Mocker.Mock<IPostFluent>();
	}

	public static IPostResponseFluent CreateResponseFluent()
	{
		return Mocker.Mock<IPostResponseFluent>();
	}

	public static IPostCacheHandler CreateCacheHandler()
	{
		return Mocker.Mock<IPostCacheHandler>();
	}
}
