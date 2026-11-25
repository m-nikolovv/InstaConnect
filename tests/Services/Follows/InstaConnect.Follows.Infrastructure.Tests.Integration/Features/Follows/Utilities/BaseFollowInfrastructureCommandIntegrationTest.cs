using InstaConnect.Follows.Domain.Features.Follows.Abstractions;
using InstaConnect.Follows.Infrastructure.Features.Follows.Abstractions;

namespace InstaConnect.Follows.Infrastructure.Tests.Integration.Features.Follows.Utilities;

public abstract class BaseFollowInfrastructureCommandIntegrationTest : BaseFollowWebCommandTest
{
	protected IFollowCacheHandler CacheHandler { get; }

	protected IFollowCommandRepository Repository { get; }

	protected IFollowIncludeBuilderFactory IncludeBuilderFactory { get; }

	protected BaseFollowInfrastructureCommandIntegrationTest(FollowsWebApplicationFactory webApplicationFactory)
		: base(webApplicationFactory)
	{
		CacheHandler = ServiceScope.GetFollowCacheHandler();
		Repository = ServiceScope.GetFollowCommandRepository();
		IncludeBuilderFactory = ServiceScope.GetFollowIncludeBuilderFactory();
	}
}
