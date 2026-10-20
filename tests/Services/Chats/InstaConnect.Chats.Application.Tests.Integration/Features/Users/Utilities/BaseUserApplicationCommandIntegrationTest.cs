namespace InstaConnect.Chats.Application.Tests.Integration.Features.Users.Utilities;

public abstract class BaseUserApplicationCommandIntegrationTest : BaseUserWebTest
{
	protected IApplicationSender Sender { get; }

	protected BaseUserApplicationCommandIntegrationTest(ChatsWebApplicationFactory webApplicationFactory) : base(webApplicationFactory)
	{
		Sender = ServiceScope.GetSender();
	}
}
