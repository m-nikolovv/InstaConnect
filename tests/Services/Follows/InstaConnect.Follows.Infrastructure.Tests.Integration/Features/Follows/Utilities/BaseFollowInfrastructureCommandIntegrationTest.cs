using InstaConnect.Follows.Domain.Features.Follows.Abstractions;

namespace InstaConnect.Follows.Infrastructure.Tests.Integration.Features.Follows.Utilities;

public abstract class BaseFollowInfrastructureCommandIntegrationTest : BaseFollowWebCommandTest
{
	protected IFollowCommandRepository Repository { get; }

	protected IFollowIncludeBuilderFactory IncludeBuilderFactory { get; }

	protected BaseFollowInfrastructureCommandIntegrationTest(FollowsWebApplicationFactory webApplicationFactory)
		: base(webApplicationFactory)
	{
		Repository = ServiceScope.GetFollowCommandRepository();
		IncludeBuilderFactory = ServiceScope.GetFollowIncludeBuilderFactory();
	}
}
