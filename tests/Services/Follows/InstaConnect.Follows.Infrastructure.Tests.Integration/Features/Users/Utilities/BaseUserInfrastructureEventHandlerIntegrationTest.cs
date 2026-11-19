namespace InstaConnect.Follows.Infrastructure.Tests.Integration.Features.Users.Utilities;

public abstract class BaseUserInfrastructureEventHandlerIntegrationTest : BaseUserWebCommandTest
{
	protected BaseUserInfrastructureEventHandlerIntegrationTest(FollowsWebApplicationFactory webApplicationFactory)
		: base(webApplicationFactory)
	{
	}
}
