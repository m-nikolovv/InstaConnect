using InstaConnect.Posts.Infrastructure.Features.PostComments.Abstractions;

namespace InstaConnect.Posts.Infrastructure.Tests.Features.PostComments.Utilities;

public static class PostCommentInfrastructureMockFactory
{
	public static IPostCommentCollection CreateCollection()
	{
		return Mocker.Mock<IPostCommentCollection>();
	}

	public static IPostCommentFluent CreateFluent()
	{
		return Mocker.Mock<IPostCommentFluent>();
	}

	public static IPostCommentResponseFluent CreateResponseFluent()
	{
		return Mocker.Mock<IPostCommentResponseFluent>();
	}

	public static IPostCommentCacheHandler CreateCacheHandler()
	{
		return Mocker.Mock<IPostCommentCacheHandler>();
	}
}
