using InstaConnect.Chats.Domain.Features.ChatMessageImages.Abstractions;
using InstaConnect.Chats.Infrastructure.Features.ChatMessages.Abstractions;

namespace InstaConnect.Chats.Infrastructure.Tests.Integration.Features.ChatMessageImages.Utilities;

public abstract class BaseChatMessageImageInfrastructureCommandIntegrationTest : BaseChatMessageImageWebCommandTest
{
	protected IChatMessageCacheHandler MessageCacheHandler { get; }

	protected IChatMessageImageCommandRepository Repository { get; }

	protected BaseChatMessageImageInfrastructureCommandIntegrationTest(ChatsWebApplicationFactory webApplicationFactory)
		: base(webApplicationFactory)
	{
		MessageCacheHandler = ServiceScope.GetMessageCacheHandler();
		Repository = ServiceScope.GetMessageImageCommandRepository();
	}
}
