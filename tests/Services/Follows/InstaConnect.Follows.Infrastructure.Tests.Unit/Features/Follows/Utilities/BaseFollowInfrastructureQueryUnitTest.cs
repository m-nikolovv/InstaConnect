using InstaConnect.Follows.Domain.Features.Follows.Abstractions;
using InstaConnect.Follows.Infrastructure.Features.Follows.Abstractions;
using InstaConnect.Follows.Tests.Features.Follows.Utilities;

namespace InstaConnect.Follows.Infrastructure.Tests.Unit.Features.Follows.Utilities;

public abstract class BaseFollowInfrastructureQueryUnitTest : BaseFollowQueryTest
{
	protected IFollowFluent Fluent { get; }

	protected IFollowCollection Collection { get; }

	protected IFollowCacheHandler CacheHandler { get; }

	protected IFollowResponseFluent ResponseFluent { get; }

	protected IFollowIncludeBuilderFactory IncludeBuilderFactory { get; }

	protected BaseFollowInfrastructureQueryUnitTest()
	{
		Fluent = FollowInfrastructureMockFactory.CreateFluent();
		Collection = FollowInfrastructureMockFactory.CreateCollection();
		CacheHandler = FollowInfrastructureMockFactory.CreateCacheHandler();
		ResponseFluent = FollowInfrastructureMockFactory.CreateResponseFluent();
		IncludeBuilderFactory = FollowMockFactory.CreateIncludeBuilderFactory();
	}
}
