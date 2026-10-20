using InstaConnect.Chats.Domain.Features.Chats.Abstractions;
using InstaConnect.Chats.Infrastructure.Features.Chats.Abstractions;
using InstaConnect.Chats.Tests.Features.Chats.Utilities;

namespace InstaConnect.Chats.Infrastructure.Tests.Unit.Features.Chats.Utilities;

public abstract class BaseChatInfrastructureCommandUnitTest : BaseChatTest
{
	protected IChatFluent Fluent { get; }

	protected IChatCollection Collection { get; }

	protected IChatIncludeBuilderFactory IncludeBuilderFactory { get; }

	protected BaseChatInfrastructureCommandUnitTest()
	{
		Fluent = ChatInfrastructureMockFactory.CreateFluent();
		Collection = ChatInfrastructureMockFactory.CreateCollection();
		IncludeBuilderFactory = ChatMockFactory.CreateIncludeBuilderFactory();
	}
}
