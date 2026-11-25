using InstaConnect.Chats.Domain.Features.Chats.Abstractions;
using InstaConnect.Chats.Infrastructure.Features.Chats.Abstractions;
using InstaConnect.Chats.Tests.Features.Chats.Utilities;

namespace InstaConnect.Chats.Infrastructure.Tests.Unit.Features.Chats.Utilities;

public abstract class BaseChatInfrastructureQueryUnitTest : BaseChatQueryTest
{
	protected IChatFluent Fluent { get; }

	protected IChatCollection Collection { get; }

	protected IChatCacheHandler CacheHandler { get; }

	protected IChatResponseFluent ResponseFluent { get; }

	protected IChatIncludeBuilderFactory IncludeBuilderFactory { get; }

	protected BaseChatInfrastructureQueryUnitTest()
	{
		Fluent = ChatInfrastructureMockFactory.CreateFluent();
		Collection = ChatInfrastructureMockFactory.CreateCollection();
		CacheHandler = ChatInfrastructureMockFactory.CreateCacheHandler();
		ResponseFluent = ChatInfrastructureMockFactory.CreateResponseFluent();
		IncludeBuilderFactory = ChatMockFactory.CreateIncludeBuilderFactory();
	}
}
