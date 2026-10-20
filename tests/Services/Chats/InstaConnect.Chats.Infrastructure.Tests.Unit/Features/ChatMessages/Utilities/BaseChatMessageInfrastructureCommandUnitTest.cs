using InstaConnect.Chats.Domain.Features.ChatMessages.Abstractions;
using InstaConnect.Chats.Infrastructure.Features.ChatMessages.Abstractions;
using InstaConnect.Chats.Tests.Features.ChatMessages.Utilities;

namespace InstaConnect.Chats.Infrastructure.Tests.Unit.Features.ChatMessages.Utilities;

public abstract class BaseChatMessageInfrastructureCommandUnitTest : BaseChatMessageTest
{
	protected IChatMessageFluent Fluent { get; }

	protected IChatMessageCollection Collection { get; }

	protected IChatMessageIncludeBuilderFactory MessageIncludeBuilderFactory { get; }

	protected BaseChatMessageInfrastructureCommandUnitTest()
	{
		Fluent = ChatMessageInfrastructureMockFactory.CreateFluent();
		Collection = ChatMessageInfrastructureMockFactory.CreateCollection();
		MessageIncludeBuilderFactory = ChatMessageMockFactory.CreateIncludeBuilderFactory();
	}
}
