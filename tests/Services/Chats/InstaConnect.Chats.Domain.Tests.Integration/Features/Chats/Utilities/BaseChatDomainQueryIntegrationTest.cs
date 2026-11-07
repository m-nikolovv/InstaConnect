using InstaConnect.Chats.Domain.Features.Chats.Abstractions;
using InstaConnect.Chats.Domain.Tests.Features.Chats.Utilities;

namespace InstaConnect.Chats.Domain.Tests.Integration.Features.Chats.Utilities;

public abstract class BaseChatDomainQueryIntegrationTest : BaseChatWebQueryTest
{
	protected IChatQueryService Service { get; }

	protected BaseChatDomainQueryIntegrationTest(ChatsWebApplicationFactory webApplicationFactory) : base(webApplicationFactory)
	{
		Service = ServiceScope.GetChatQueryService();
	}
}
