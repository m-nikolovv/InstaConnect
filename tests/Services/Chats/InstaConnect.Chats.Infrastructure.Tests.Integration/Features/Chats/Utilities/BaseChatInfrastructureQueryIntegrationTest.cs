using InstaConnect.Chats.Domain.Features.Chats.Abstractions;
using InstaConnect.Chats.Infrastructure.Features.Chats.Abstractions;

namespace InstaConnect.Chats.Infrastructure.Tests.Integration.Features.Chats.Utilities;

public abstract class BaseChatInfrastructureQueryIntegrationTest : BaseChatWebQueryTest
{
	protected IChatCacheHandler CacheHandler { get; }

	protected IChatQueryRepository Repository { get; }

	protected BaseChatInfrastructureQueryIntegrationTest(ChatsWebApplicationFactory webApplicationFactory)
		: base(webApplicationFactory)
	{
		CacheHandler = ServiceScope.GetCacheHandler();
		Repository = ServiceScope.GetQueryRepository();
	}
}
