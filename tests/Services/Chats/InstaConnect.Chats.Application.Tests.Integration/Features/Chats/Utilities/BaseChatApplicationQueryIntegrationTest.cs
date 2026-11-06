namespace InstaConnect.Chats.Application.Tests.Integration.Features.Chats.Utilities;

public abstract class BaseChatApplicationQueryIntegrationTest : BaseChatsWebQueryTest
{
	protected IApplicationSender Sender { get; }

	protected BaseChatApplicationQueryIntegrationTest(ChatsWebApplicationFactory webApplicationFactory) : base(webApplicationFactory)
	{
		Sender = ServiceScope.GetSender();
	}
}
