using InstaConnect.Posts.Domain.Features.PostCommentLikes.Abstractions;

namespace InstaConnect.Posts.Application.Tests.Features.PostCommentLikes.Utilities;

public static class PostCommentLikeApplicationMockFactory
{
	public static IPostCommentLikeCommandService CreateCommandService()
	{
		return Mocker.Mock<IPostCommentLikeCommandService>();
	}

	public static IPostCommentLikeQueryService CreateQueryService()
	{
		return Mocker.Mock<IPostCommentLikeQueryService>();
	}
}
