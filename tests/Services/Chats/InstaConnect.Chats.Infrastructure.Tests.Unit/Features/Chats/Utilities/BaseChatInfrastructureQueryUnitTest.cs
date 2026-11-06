using InstaConnect.Chats.Domain.Features.Chats.Abstractions;
using InstaConnect.Chats.Infrastructure.Features.Chats.Abstractions;
using InstaConnect.Chats.Tests.Features.Chats.Utilities;
using InstaConnect.Chats.Tests.Features.Common.Utilities;

namespace InstaConnect.Chats.Infrastructure.Tests.Unit.Features.Chats.Utilities;

public abstract class BaseChatInfrastructureQueryUnitTest : BaseChatsQueryTest
{
	protected IChatFluent Fluent { get; }

	protected IChatCollection Collection { get; }

	protected IChatResponseFluent ResponseFluent { get; }

	protected IChatIncludeBuilderFactory IncludeBuilderFactory { get; }

	protected BaseChatInfrastructureQueryUnitTest()
	{
		Collection = ChatInfrastructureMockFactory.CreateCollection();
		Fluent = ChatInfrastructureMockFactory.CreateFluent();
		ResponseFluent = ChatInfrastructureMockFactory.CreateResponseFluent();
		IncludeBuilderFactory = ChatMockFactory.CreateIncludeBuilderFactory();
	}
}
