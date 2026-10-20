namespace InstaConnect.Posts.Application.Tests.Integration.Features.Users.Utilities;

public abstract class BaseUserApplicationCommandIntegrationTest : BaseUserWebTest
{
	protected IApplicationSender Sender { get; }

	protected BaseUserApplicationCommandIntegrationTest(PostsWebApplicationFactory webApplicationFactory) : base(webApplicationFactory)
	{
		Sender = ServiceScope.GetSender();
	}
}
