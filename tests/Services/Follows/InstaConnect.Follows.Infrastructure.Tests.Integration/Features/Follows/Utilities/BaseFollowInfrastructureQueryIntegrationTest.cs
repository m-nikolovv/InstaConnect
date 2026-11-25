using InstaConnect.Follows.Domain.Features.Follows.Abstractions;
using InstaConnect.Follows.Infrastructure.Features.Follows.Abstractions;

namespace InstaConnect.Follows.Infrastructure.Tests.Integration.Features.Follows.Utilities;

public abstract class BaseFollowInfrastructureQueryIntegrationTest : BaseFollowWebQueryTest
{
	protected IFollowCacheHandler CacheHandler { get; }

	protected IFollowQueryRepository Repository { get; }

	protected BaseFollowInfrastructureQueryIntegrationTest(FollowsWebApplicationFactory webApplicationFactory)
		: base(webApplicationFactory)
	{
		CacheHandler = ServiceScope.GetFollowCacheHandler();
		Repository = ServiceScope.GetFollowQueryRepository();
	}
}
