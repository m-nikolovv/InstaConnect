using InstaConnect.Posts.Domain.Features.PostLikes.Abstractions;

namespace InstaConnect.Posts.Application.Tests.Features.PostLikes.Utilities;

public static class PostLikeApplicationMockFactory
{
	public static IPostLikeCommandService CreateCommandService()
	{
		return Mocker.Mock<IPostLikeCommandService>();
	}

	public static IPostLikeQueryService CreateQueryService()
	{
		return Mocker.Mock<IPostLikeQueryService>();
	}
}
