using InstaConnect.Posts.Infrastructure.Features.PostLikes.Abstractions;

namespace InstaConnect.Posts.Infrastructure.Tests.Features.PostLikes.Utilities;

public static class PostLikeInfrastructureMockFactory
{
	public static IPostLikeCollection CreateCollection()
	{
		return Mocker.Mock<IPostLikeCollection>();
	}

	public static IPostLikeFluent CreateFluent()
	{
		return Mocker.Mock<IPostLikeFluent>();
	}

	public static IPostLikeResponseFluent CreateResponseFluent()
	{
		return Mocker.Mock<IPostLikeResponseFluent>();
	}

	public static IPostLikeCacheHandler CreateCacheHandler()
	{
		return Mocker.Mock<IPostLikeCacheHandler>();
	}
}
