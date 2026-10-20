using InstaConnect.Posts.Domain.Features.PostCommentImages.Abstractions;

namespace InstaConnect.Posts.Domain.Tests.Features.PostCommentImages.Utilities;

public static class PostCommentImageDomainMockFactory
{
	public static IPostCommentImageFactory CreateFactory()
	{
		return Mocker.Mock<IPostCommentImageFactory>();
	}

	public static IPostCommentImageCommandRepository CreateCommandRepository()
	{
		return Mocker.Mock<IPostCommentImageCommandRepository>();
	}
}
