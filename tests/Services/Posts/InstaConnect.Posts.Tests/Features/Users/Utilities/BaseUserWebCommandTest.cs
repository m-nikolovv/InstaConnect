namespace InstaConnect.Posts.Tests.Features.Users.Utilities;

public abstract class BaseUserWebCommandTest : BaseUserWebTest
{
	protected BaseUserWebCommandTest(PostsWebApplicationFactory webApplicationFactory)
		: base(webApplicationFactory)
	{
	}
}
