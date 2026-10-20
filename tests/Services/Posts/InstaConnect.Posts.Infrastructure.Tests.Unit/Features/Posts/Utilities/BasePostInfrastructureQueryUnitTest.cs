using InstaConnect.Posts.Infrastructure.Features.Posts.Abstractions;

namespace InstaConnect.Posts.Infrastructure.Tests.Unit.Features.Posts.Utilities;

public abstract class BasePostInfrastructureQueryUnitTest : BasePostTest
{
	protected IPostFluent Fluent { get; }

	protected IPostCollection Collection { get; }

	protected IPostResponseFluent ResponseFluent { get; }

	protected IPostIncludeBuilderFactory IncludeBuilderFactory { get; }

	protected BasePostInfrastructureQueryUnitTest()
	{
		Collection = PostInfrastructureMockFactory.CreateCollection();
		Fluent = PostInfrastructureMockFactory.CreateFluent();
		ResponseFluent = PostInfrastructureMockFactory.CreateResponseFluent();
		IncludeBuilderFactory = PostMockFactory.CreateIncludeBuilderFactory();
	}
}
