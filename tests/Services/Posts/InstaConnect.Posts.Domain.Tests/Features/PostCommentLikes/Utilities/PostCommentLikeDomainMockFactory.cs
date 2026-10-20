using InstaConnect.Common.Infrastructure.Features.Databases.Helpers;
using InstaConnect.Posts.Domain.Features.PostCommentLikes.Helpers;

namespace InstaConnect.Posts.Domain.Tests.Features.PostCommentLikes.Utilities;

public static class PostCommentLikeDomainMockFactory
{
	public static IPostCommentLikeFactory CreateFactory()
	{
		return Mocker.Mock<IPostCommentLikeFactory>();
	}

	public static IPostCommentLikeCollectionResponseFactory CreateCollectionResponseFactory()
	{
		return new PostCommentLikeCollectionResponseFactory(new Paginator());
	}

	public static IPostCommentLikeIncludeBuilderFactory CreateIncludeBuilderFactory()
	{
		return new PostCommentLikeIncludeBuilderFactory(new PostCommentLikeIncludeDescriptorFactory());
	}

	public static IPostCommentLikeCommandRepository CreateCommandRepository()
	{
		return Mocker.Mock<IPostCommentLikeCommandRepository>();
	}

	public static IPostCommentLikeQueryRepository CreateQueryRepository()
	{
		return Mocker.Mock<IPostCommentLikeQueryRepository>();
	}
}
