using InstaConnect.Chats.Domain.Features.ChatMessages.Abstractions;
using InstaConnect.Chats.Infrastructure.Features.ChatMessages.Abstractions;
using InstaConnect.Chats.Infrastructure.Features.Chats.Abstractions;
using InstaConnect.Chats.Tests.Features.ChatMessages.Utilities;

namespace InstaConnect.Chats.Infrastructure.Tests.Unit.Features.ChatMessages.Utilities;

public abstract class BaseChatMessageInfrastructureCommandUnitTest : BaseChatMessageCommandTest
{
	protected IChatMessageFluent Fluent { get; }

	protected IChatCacheHandler CacheHandler { get; }

	protected IChatMessageCollection Collection { get; }

	protected IChatMessageCacheHandler MessageCacheHandler { get; }

	protected IChatMessageIncludeBuilderFactory MessageIncludeBuilderFactory { get; }

	protected BaseChatMessageInfrastructureCommandUnitTest()
	{
		Fluent = ChatMessageInfrastructureMockFactory.CreateFluent();
		CacheHandler = ChatInfrastructureMockFactory.CreateCacheHandler();
		Collection = ChatMessageInfrastructureMockFactory.CreateCollection();
		MessageCacheHandler = ChatMessageInfrastructureMockFactory.CreateCacheHandler();
		MessageIncludeBuilderFactory = ChatMessageMockFactory.CreateIncludeBuilderFactory();
	}
}
