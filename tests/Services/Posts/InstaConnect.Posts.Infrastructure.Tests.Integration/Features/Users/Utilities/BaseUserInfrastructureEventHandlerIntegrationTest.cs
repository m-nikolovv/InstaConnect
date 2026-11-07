namespace InstaConnect.Posts.Infrastructure.Tests.Integration.Features.Users.Utilities;

public abstract class BaseUserInfrastructureEventHandlerIntegrationTest : BaseUserWebCommandTest
{
	protected BaseUserInfrastructureEventHandlerIntegrationTest(PostsWebApplicationFactory webApplicationFactory)
		: base(webApplicationFactory)
	{
	}
}
