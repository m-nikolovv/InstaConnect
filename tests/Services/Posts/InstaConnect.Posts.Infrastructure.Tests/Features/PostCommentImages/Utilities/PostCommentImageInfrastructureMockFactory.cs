using InstaConnect.Posts.Infrastructure.Features.PostCommentImages.Abstractions;

namespace InstaConnect.Posts.Infrastructure.Tests.Features.PostCommentImages.Utilities;

public static class PostCommentImageInfrastructureMockFactory
{
	public static IPostCommentImageCollection CreateCollection()
	{
		return Mocker.Mock<IPostCommentImageCollection>();
	}

	public static IPostCommentImageFluent CreateFluent()
	{
		return Mocker.Mock<IPostCommentImageFluent>();
	}
}
