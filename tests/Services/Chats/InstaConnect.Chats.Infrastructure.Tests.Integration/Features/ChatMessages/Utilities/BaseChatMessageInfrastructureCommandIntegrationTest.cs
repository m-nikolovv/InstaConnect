using InstaConnect.Chats.Domain.Features.ChatMessages.Abstractions;
using InstaConnect.Chats.Infrastructure.Features.ChatMessages.Abstractions;
using InstaConnect.Chats.Infrastructure.Features.Chats.Abstractions;

namespace InstaConnect.Chats.Infrastructure.Tests.Integration.Features.ChatMessages.Utilities;

public abstract class BaseChatMessageInfrastructureCommandIntegrationTest : BaseChatMessageWebCommandTest
{
	protected IChatCacheHandler CacheHandler { get; }

	protected IChatMessageCommandRepository Repository { get; }

	protected IChatMessageCacheHandler MessageCacheHandler { get; }

	protected IChatMessageIncludeBuilderFactory MessageIncludeBuilderFactory { get; }

	protected BaseChatMessageInfrastructureCommandIntegrationTest(ChatsWebApplicationFactory webApplicationFactory)
		: base(webApplicationFactory)
	{
		CacheHandler = ServiceScope.GetCacheHandler();
		Repository = ServiceScope.GetMessageCommandRepository();
		MessageCacheHandler = ServiceScope.GetMessageCacheHandler();
		MessageIncludeBuilderFactory = ServiceScope.GetMessageIncludeBuilderFactory();
	}
}
