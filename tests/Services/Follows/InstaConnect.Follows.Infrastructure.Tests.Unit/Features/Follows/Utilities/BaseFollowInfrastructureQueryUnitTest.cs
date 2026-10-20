using InstaConnect.Follows.Domain.Features.Follows.Abstractions;
using InstaConnect.Follows.Infrastructure.Features.Follows.Abstractions;
using InstaConnect.Follows.Tests.Features.Follows.Utilities;

namespace InstaConnect.Follows.Infrastructure.Tests.Unit.Features.Follows.Utilities;

public abstract class BaseFollowInfrastructureQueryUnitTest : BaseFollowTest
{
	protected IFollowFluent Fluent { get; }

	protected IFollowCollection Collection { get; }

	protected IFollowResponseFluent ResponseFluent { get; }

	protected IFollowIncludeBuilderFactory IncludeBuilderFactory { get; }

	protected BaseFollowInfrastructureQueryUnitTest()
	{
		Collection = FollowInfrastructureMockFactory.CreateCollection();
		Fluent = FollowInfrastructureMockFactory.CreateFluent();
		ResponseFluent = FollowInfrastructureMockFactory.CreateResponseFluent();
		IncludeBuilderFactory = FollowMockFactory.CreateIncludeBuilderFactory();
	}
}
