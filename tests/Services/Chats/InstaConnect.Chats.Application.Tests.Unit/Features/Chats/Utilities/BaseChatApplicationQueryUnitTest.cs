using InstaConnect.Chats.Domain.Features.Chats.Abstractions;
using InstaConnect.Chats.Tests.Features.Chats.Utilities;

namespace InstaConnect.Chats.Application.Tests.Unit.Features.Chats.Utilities;

public abstract class BaseChatApplicationQueryUnitTest : BaseChatTest
{
	protected IApplicationMapper Mapper { get; }

	protected IChatQueryService Service { get; }

	protected BaseChatApplicationQueryUnitTest()
	{
		Mapper = MockFactory.CreateMapper(ChatsApplicationReference.Assembly);
		Service = ChatApplicationMockFactory.CreateQueryService();
	}
}
