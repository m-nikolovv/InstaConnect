using InstaConnect.Follows.Presentation.Features.Follows.Controllers.v1;
using InstaConnect.Follows.Presentation.Tests.Features.Follows.Utilities;

namespace InstaConnect.Follows.Presentation.Tests.Integration.Features.Follows.Utilities;

public abstract class BaseFollowPresentationQueryIntegrationTest : BaseFollowWebQueryTest
{
	protected FollowController Controller { get; }

	protected FollowingFollowController FollowingController { get; }

	protected BaseFollowPresentationQueryIntegrationTest(FollowsWebApplicationFactory webApplicationFactory) : base(webApplicationFactory)
	{
		Controller = ServiceScope.GetFollowController();
		FollowingController = ServiceScope.GetFollowingFollowController();
	}
}
