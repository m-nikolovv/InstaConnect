namespace InstaConnect.Posts.Infrastructure.Tests.Integration.Features.Users.Utilities;

public abstract class BaseUserInfrastructureEventHandlerIntegrationTest : BasePostsWebCommandTest
{
	protected BaseUserInfrastructureEventHandlerIntegrationTest(PostsWebApplicationFactory webApplicationFactory)
		: base(webApplicationFactory)
	{
	}
}
