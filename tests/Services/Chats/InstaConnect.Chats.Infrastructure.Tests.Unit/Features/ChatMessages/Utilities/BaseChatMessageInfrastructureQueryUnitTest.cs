using InstaConnect.Chats.Domain.Features.ChatMessages.Abstractions;
using InstaConnect.Chats.Domain.Features.Chats.Abstractions;
using InstaConnect.Chats.Infrastructure.Features.ChatMessages.Abstractions;
using InstaConnect.Chats.Tests.Features.ChatMessages.Utilities;
using InstaConnect.Chats.Tests.Features.Chats.Utilities;

namespace InstaConnect.Chats.Infrastructure.Tests.Unit.Features.ChatMessages.Utilities;

public abstract class BaseChatMessageInfrastructureQueryUnitTest : BaseChatMessageTest
{
	protected IChatMessageFluent Fluent { get; }

	protected IChatMessageCollection Collection { get; }

	protected IChatMessageResponseFluent ResponseFluent { get; }

	protected IChatIncludeBuilderFactory IncludeBuilderFactory { get; }

	protected IChatMessageIncludeBuilderFactory MessageIncludeBuilderFactory { get; }

	protected BaseChatMessageInfrastructureQueryUnitTest()
	{
		Collection = ChatMessageInfrastructureMockFactory.CreateCollection();
		Fluent = ChatMessageInfrastructureMockFactory.CreateFluent();
		ResponseFluent = ChatMessageInfrastructureMockFactory.CreateResponseFluent();
		IncludeBuilderFactory = ChatMockFactory.CreateIncludeBuilderFactory();
		MessageIncludeBuilderFactory = ChatMessageMockFactory.CreateIncludeBuilderFactory();
	}
}
