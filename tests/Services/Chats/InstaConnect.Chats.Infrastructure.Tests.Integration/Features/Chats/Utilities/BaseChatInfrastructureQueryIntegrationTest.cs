using InstaConnect.Chats.Domain.Features.Chats.Abstractions;

namespace InstaConnect.Chats.Infrastructure.Tests.Integration.Features.Chats.Utilities;

public abstract class BaseChatInfrastructureQueryIntegrationTest : BaseChatWebQueryTest
{
	protected IChatQueryRepository Repository { get; }

	protected BaseChatInfrastructureQueryIntegrationTest(ChatsWebApplicationFactory webApplicationFactory)
		: base(webApplicationFactory)
	{
		Repository = ServiceScope.GetQueryRepository();
	}
}
