using InstaConnect.Posts.Infrastructure.Features.PostCommentLikes.Abstractions;

namespace InstaConnect.Posts.Infrastructure.Tests.Features.PostCommentLikes.Utilities;

public static class PostCommentLikeInfrastructureMockFactory
{
	public static IPostCommentLikeCollection CreateCollection()
	{
		return Mocker.Mock<IPostCommentLikeCollection>();
	}

	public static IPostCommentLikeFluent CreateFluent()
	{
		return Mocker.Mock<IPostCommentLikeFluent>();
	}

	public static IPostCommentLikeResponseFluent CreateResponseFluent()
	{
		return Mocker.Mock<IPostCommentLikeResponseFluent>();
	}

	public static IPostCommentLikeCacheHandler CreateCacheHandler()
	{
		return Mocker.Mock<IPostCommentLikeCacheHandler>();
	}
}
