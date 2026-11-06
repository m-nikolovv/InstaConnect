using InstaConnect.Follows.Domain.Features.Follows.Abstractions;
using InstaConnect.Follows.Domain.Tests.Features.Follows.Utilities;

namespace InstaConnect.Follows.Domain.Tests.Integration.Features.Follows.Utilities;

public abstract class BaseFollowDomainQueryIntegrationTest : BaseFollowsQueryWebTest
{
	protected IFollowQueryService Service { get; }

	protected BaseFollowDomainQueryIntegrationTest(FollowsWebApplicationFactory webApplicationFactory) : base(webApplicationFactory)
	{
		Service = ServiceScope.GetFollowQueryService();
	}
}
