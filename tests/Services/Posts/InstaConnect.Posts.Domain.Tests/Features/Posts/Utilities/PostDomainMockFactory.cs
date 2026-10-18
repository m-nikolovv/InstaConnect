using InstaConnect.Posts.Domain.Features.Posts.Helpers;

namespace InstaConnect.Posts.Domain.Tests.Features.Posts.Utilities;

public static class PostDomainMockFactory
{
	public static IPostFactory CreateFactory()
	{
		return Mocker.Mock<IPostFactory>();
	}

	public static IPostAnalyzer CreateAnalyzer()
	{
		var analyzer = Mocker.Mock<IPostAnalyzer>();

		analyzer
			.AnalyzeAsync(Matcher.Any<PostResponse>(), Matcher.Any<CancellationToken>())
			.ReturnsTaskResponse<PostAnalyzeResponse, PostResponse>(post => post.ToAnalyzeResponse());

		return analyzer;
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
