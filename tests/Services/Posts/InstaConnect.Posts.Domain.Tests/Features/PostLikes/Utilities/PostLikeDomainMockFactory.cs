using InstaConnect.Common.Infrastructure.Features.Databases.Helpers;
using InstaConnect.Posts.Domain.Features.PostLikes.Helpers;

namespace InstaConnect.Posts.Domain.Tests.Features.PostLikes.Utilities;

public static class PostLikeDomainMockFactory
{
	public static IPostLikeFactory CreateFactory()
	{
		return Mocker.Mock<IPostLikeFactory>();
	}

	public static IPostLikeCollectionResponseFactory CreateCollectionResponseFactory()
	{
		return new PostLikeCollectionResponseFactory(new Paginator());
	}

	public static IPostLikeIncludeBuilderFactory CreateIncludeBuilderFactory()
	{
		return new PostLikeIncludeBuilderFactory(new PostLikeIncludeDescriptorFactory());
	}

	public static IPostLikeCommandRepository CreateCommandRepository()
	{
		return Mocker.Mock<IPostLikeCommandRepository>();
	}

	public static IPostLikeQueryRepository CreateQueryRepository()
	{
		return Mocker.Mock<IPostLikeQueryRepository>();
	}
}
