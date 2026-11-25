using InstaConnect.Posts.Infrastructure.Features.Posts.Abstractions;

namespace InstaConnect.Posts.Infrastructure.Tests.Unit.Features.Posts.Utilities;

public abstract class BasePostInfrastructureQueryUnitTest : BasePostQueryTest
{
	protected IPostFluent Fluent { get; }

	protected IPostCollection Collection { get; }

	protected IPostCacheHandler CacheHandler { get; }

	protected IPostResponseFluent ResponseFluent { get; }

	protected IPostIncludeBuilderFactory IncludeBuilderFactory { get; }

	protected BasePostInfrastructureQueryUnitTest()
	{
		Fluent = PostInfrastructureMockFactory.CreateFluent();
		Collection = PostInfrastructureMockFactory.CreateCollection();
		CacheHandler = PostInfrastructureMockFactory.CreateCacheHandler();
		ResponseFluent = PostInfrastructureMockFactory.CreateResponseFluent();
		IncludeBuilderFactory = PostMockFactory.CreateIncludeBuilderFactory();
	}
}
