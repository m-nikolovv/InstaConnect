using InstaConnect.Follows.Tests.Features.Common.Utilities;

namespace InstaConnect.Follows.Tests.Features.Follows.Utilities;

public abstract class BaseFollowWebTest : BaseFollowTest, IClassFixture<FollowsWebApplicationFactory>
{
	protected IServiceScope ServiceScope { get; }

	protected BaseFollowWebTest(FollowsWebApplicationFactory webApplicationFactory)
	{
		ServiceScope = webApplicationFactory.Services.CreateScope();
	}
}
