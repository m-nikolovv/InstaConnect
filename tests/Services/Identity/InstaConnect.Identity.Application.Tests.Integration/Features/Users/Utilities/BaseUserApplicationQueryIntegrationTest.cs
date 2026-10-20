namespace InstaConnect.Identity.Application.Tests.Integration.Features.Users.Utilities;

public abstract class BaseUserApplicationQueryIntegrationTest : BaseUserWebTest
{
	protected IApplicationSender Sender { get; }

	protected BaseUserApplicationQueryIntegrationTest(IdentityWebApplicationFactory webApplicationFactory) : base(webApplicationFactory)
	{
		Sender = ServiceScope.GetSender();
	}
}
