using InstaConnect.Follows.Domain.Features.Follows.Abstractions;
using InstaConnect.Follows.Infrastructure.Features.Follows.Abstractions;
using InstaConnect.Follows.Tests.Features.Follows.Utilities;

namespace InstaConnect.Follows.Infrastructure.Tests.Unit.Features.Follows.Utilities;

public abstract class BaseFollowInfrastructureCommandUnitTest : BaseFollowTest
{
	protected IFollowFluent Fluent { get; }

	protected IFollowCollection Collection { get; }

	protected IFollowIncludeBuilderFactory IncludeBuilderFactory { get; }

	protected BaseFollowInfrastructureCommandUnitTest()
	{
		Fluent = FollowInfrastructureMockFactory.CreateFluent();
		Collection = FollowInfrastructureMockFactory.CreateCollection();
		IncludeBuilderFactory = FollowMockFactory.CreateIncludeBuilderFactory();
	}
}
