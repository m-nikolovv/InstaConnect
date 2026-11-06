using InstaConnect.Follows.Domain.Features.Follows.Abstractions;

namespace InstaConnect.Follows.Infrastructure.Tests.Integration.Features.Follows.Utilities;

public abstract class BaseFollowInfrastructureQueryIntegrationTest : BaseFollowsQueryWebTest
{
	protected IFollowQueryRepository Repository { get; }

	protected BaseFollowInfrastructureQueryIntegrationTest(FollowsWebApplicationFactory webApplicationFactory)
		: base(webApplicationFactory)
	{
		Repository = ServiceScope.GetFollowQueryRepository();
	}
}
