using InstaConnect.Posts.Infrastructure.Features.Posts.Abstractions;

namespace InstaConnect.Posts.Infrastructure.Tests.Unit.Features.Posts.Utilities;

public abstract class BasePostInfrastructureCommandUnitTest : BasePostTest
{
	protected IPostFluent Fluent { get; }

	protected IPostCollection Collection { get; }

	protected IPostIncludeBuilderFactory IncludeBuilderFactory { get; }

	protected BasePostInfrastructureCommandUnitTest()
	{
		Fluent = PostInfrastructureMockFactory.CreateFluent();
		Collection = PostInfrastructureMockFactory.CreateCollection();
		IncludeBuilderFactory = PostMockFactory.CreateIncludeBuilderFactory();
	}
}
