using InstaConnect.Chats.Domain.Features.ChatMessages.Abstractions;
using InstaConnect.Chats.Domain.Tests.Features.ChatMessages.Utilities;
using InstaConnect.Chats.Infrastructure.Features.ChatMessages.Abstractions;

namespace InstaConnect.Chats.Domain.Tests.Integration.Features.ChatMessages.Utilities;

public abstract class BaseChatMessageDomainQueryIntegrationTest : BaseChatMessageWebQueryTest
{
	protected IChatMessageQueryService Service { get; }

	protected IChatMessageCacheHandler MessageCacheHandler { get; }

	protected BaseChatMessageDomainQueryIntegrationTest(ChatsWebApplicationFactory webApplicationFactory)
		: base(webApplicationFactory)
	{
		Service = ServiceScope.GetChatMessageQueryService();
		MessageCacheHandler = ServiceScope.GetMessageCacheHandler();
	}
}
