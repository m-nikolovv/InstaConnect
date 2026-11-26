using InstaConnect.Chats.Domain.Features.ChatMessages.Abstractions;
using InstaConnect.Chats.Domain.Features.Chats.Abstractions;
using InstaConnect.Chats.Infrastructure.Features.ChatMessages.Abstractions;
using InstaConnect.Chats.Tests.Features.ChatMessages.Utilities;
using InstaConnect.Chats.Tests.Features.Chats.Utilities;

namespace InstaConnect.Chats.Infrastructure.Tests.Unit.Features.ChatMessages.Utilities;

public abstract class BaseChatMessageInfrastructureQueryUnitTest : BaseChatMessageQueryTest
{
	protected IChatMessageFluent Fluent { get; }

	protected IChatMessageCollection Collection { get; }

	protected IChatMessageResponseFluent ResponseFluent { get; }

	protected IChatMessageCacheHandler MessageCacheHandler { get; }

	protected IChatIncludeBuilderFactory IncludeBuilderFactory { get; }

	protected IChatMessageIncludeBuilderFactory MessageIncludeBuilderFactory { get; }

	protected BaseChatMessageInfrastructureQueryUnitTest()
	{
		Fluent = ChatMessageInfrastructureMockFactory.CreateFluent();
		Collection = ChatMessageInfrastructureMockFactory.CreateCollection();
		ResponseFluent = ChatMessageInfrastructureMockFactory.CreateResponseFluent();
		MessageCacheHandler = ChatMessageInfrastructureMockFactory.CreateCacheHandler();
		IncludeBuilderFactory = ChatMockFactory.CreateIncludeBuilderFactory();
		MessageIncludeBuilderFactory = ChatMessageMockFactory.CreateIncludeBuilderFactory();
	}
}
