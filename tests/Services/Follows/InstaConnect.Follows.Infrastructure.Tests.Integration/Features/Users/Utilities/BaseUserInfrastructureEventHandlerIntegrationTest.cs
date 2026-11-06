namespace InstaConnect.Follows.Infrastructure.Tests.Integration.Features.Users.Utilities;

public abstract class BaseUserInfrastructureEventHandlerIntegrationTest : BaseFollowsWebCommandTest
{
	protected BaseUserInfrastructureEventHandlerIntegrationTest(FollowsWebApplicationFactory webApplicationFactory)
		: base(webApplicationFactory)
	{
	}
}
