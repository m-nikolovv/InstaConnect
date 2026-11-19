using InstaConnect.Chats.Presentation.Features.Chats.Controllers.v1;

namespace InstaConnect.Chats.Presentation.Tests.Integration.Features.Chats.Utilities;

public abstract class BaseChatPresentationQueryIntegrationTest : BaseChatWebQueryTest
{
	protected ChatController Controller { get; }

	protected BaseChatPresentationQueryIntegrationTest(ChatsWebApplicationFactory webApplicationFactory) : base(webApplicationFactory)
	{
		Controller = ServiceScope.GetChatController();
	}
}
