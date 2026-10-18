using InstaConnect.Posts.Domain.Features.Posts.Helpers;

namespace InstaConnect.Posts.Domain.Tests.Features.Posts.Utilities;

public static class PostDomainMockFactory
{
	public static IPostFactory CreateFactory()
	{
		return Mocker.Mock<IPostFactory>();
	}

	public static IPostCollectionResponseFactory CreateCollectionResponseFactory()
	{
		return new PostCollectionResponseFactory(new Paginator());
	}

	public static IPostCommandRepository CreateCommandRepository()
	{
		return Mocker.Mock<IPostCommandRepository>();
	}

	public static IPostQueryRepository CreateQueryRepository()
	{
		return Mocker.Mock<IPostQueryRepository>();
	}
}
