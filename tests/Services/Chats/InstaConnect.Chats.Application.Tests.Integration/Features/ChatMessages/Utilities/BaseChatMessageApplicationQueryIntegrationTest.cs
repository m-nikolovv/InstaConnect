using InstaConnect.Chats.Infrastructure.Features.ChatMessages.Abstractions;

namespace InstaConnect.Chats.Application.Tests.Integration.Features.ChatMessages.Utilities;

public abstract class BaseChatMessageApplicationQueryIntegrationTest : BaseChatMessageWebQueryTest
{
	protected IApplicationSender Sender { get; }

	protected IChatMessageCacheHandler MessageCacheHandler { get; }

	protected BaseChatMessageApplicationQueryIntegrationTest(ChatsWebApplicationFactory webApplicationFactory) : base(webApplicationFactory)
	{
		Sender = ServiceScope.GetSender();
		MessageCacheHandler = ServiceScope.GetMessageCacheHandler();
	}
}
