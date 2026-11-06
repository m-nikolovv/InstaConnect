namespace InstaConnect.Follows.Tests.Features.Common.Utilities;

public abstract class BaseFollowsWebTest : BaseFollowsTest, IClassFixture<FollowsWebApplicationFactory>
{
	protected IServiceScope ServiceScope { get; }

	protected BaseFollowsWebTest(FollowsWebApplicationFactory webApplicationFactory)
	{
		ServiceScope = webApplicationFactory.Services.CreateScope();
	}
}
