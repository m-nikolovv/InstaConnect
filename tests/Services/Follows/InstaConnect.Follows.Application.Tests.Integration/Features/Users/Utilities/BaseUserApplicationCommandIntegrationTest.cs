namespace InstaConnect.Follows.Application.Tests.Integration.Features.Users.Utilities;

public abstract class BaseUserApplicationCommandIntegrationTest : BaseUserWebTest
{
	protected IApplicationSender Sender { get; }

	protected BaseUserApplicationCommandIntegrationTest(FollowsWebApplicationFactory webApplicationFactory) : base(webApplicationFactory)
	{
		Sender = ServiceScope.GetSender();
	}
}
