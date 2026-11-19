using InstaConnect.Chats.Presentation.Features.ChatMessages.Controllers.v1;

namespace InstaConnect.Chats.Presentation.Tests.Integration.Features.ChatMessages.Utilities;

public abstract class BaseChatMessagePresentationQueryIntegrationTest : BaseChatMessageWebQueryTest
{
	protected ChatMessageController Controller { get; }

	protected BaseChatMessagePresentationQueryIntegrationTest(ChatsWebApplicationFactory webApplicationFactory) : base(webApplicationFactory)
	{
		Controller = ServiceScope.GetChatMessageController();
	}
}
