using InstaConnect.Follows.Tests.Features.Common.Utilities;

namespace InstaConnect.Follows.Tests.Features.Users.Utilities;

public abstract class BaseUserWebCommandTest : BaseUserWebTest
{
	protected BaseUserWebCommandTest(FollowsWebApplicationFactory webApplicationFactory)
		: base(webApplicationFactory)
	{
	}
}
