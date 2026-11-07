namespace InstaConnect.Chats.Application.Tests.Integration.Features.ChatMessages.Utilities;

public abstract class BaseChatMessageApplicationQueryIntegrationTest : BaseChatMessageWebQueryTest
{
	protected IApplicationSender Sender { get; }

	protected BaseChatMessageApplicationQueryIntegrationTest(ChatsWebApplicationFactory webApplicationFactory) : base(webApplicationFactory)
	{
		Sender = ServiceScope.GetSender();
	}
}
