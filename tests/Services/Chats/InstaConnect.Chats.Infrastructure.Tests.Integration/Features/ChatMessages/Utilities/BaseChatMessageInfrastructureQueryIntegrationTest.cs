using InstaConnect.Chats.Domain.Features.ChatMessages.Abstractions;

namespace InstaConnect.Chats.Infrastructure.Tests.Integration.Features.ChatMessages.Utilities;

public abstract class BaseChatMessageInfrastructureQueryIntegrationTest : BaseChatsWebQueryTest
{
	protected IChatMessageQueryRepository Repository { get; }

	protected BaseChatMessageInfrastructureQueryIntegrationTest(ChatsWebApplicationFactory webApplicationFactory)
		: base(webApplicationFactory)
	{
		Repository = ServiceScope.GetMessageQueryRepository();
	}
}
