using InstaConnect.Posts.Domain.Features.PostComments.Abstractions;

namespace InstaConnect.Posts.Application.Tests.Features.PostComments.Utilities;

public static class PostCommentApplicationMockFactory
{
	public static IPostCommentCommandService CreateCommandService()
	{
		return Mocker.Mock<IPostCommentCommandService>();
	}

	public static IPostCommentQueryService CreateQueryService()
	{
		return Mocker.Mock<IPostCommentQueryService>();
	}
}
