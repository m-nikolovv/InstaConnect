using InstaConnect.Chats.Infrastructure.Features.Chats.Abstractions;

namespace InstaConnect.Chats.Application.Tests.Integration.Features.Chats.Utilities;

public abstract class BaseChatApplicationQueryIntegrationTest : BaseChatWebQueryTest
{
	protected IApplicationSender Sender { get; }

	protected IChatCacheHandler CacheHandler { get; }

	protected BaseChatApplicationQueryIntegrationTest(ChatsWebApplicationFactory webApplicationFactory) : base(webApplicationFactory)
	{
		Sender = ServiceScope.GetSender();
		CacheHandler = ServiceScope.GetCacheHandler();
	}
}
