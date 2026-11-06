using InstaConnect.Chats.Domain.Features.Chats.Abstractions;
using InstaConnect.Chats.Infrastructure.Features.Chats.Abstractions;
using InstaConnect.Chats.Tests.Features.Chats.Utilities;
using InstaConnect.Chats.Tests.Features.Common.Utilities;

namespace InstaConnect.Chats.Infrastructure.Tests.Unit.Features.Chats.Utilities;

public abstract class BaseChatInfrastructureCommandUnitTest : BaseChatsCommandTest
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
