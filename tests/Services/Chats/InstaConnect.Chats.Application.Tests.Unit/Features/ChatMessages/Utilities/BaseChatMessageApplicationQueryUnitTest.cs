using InstaConnect.Chats.Domain.Features.ChatMessages.Abstractions;
using InstaConnect.Chats.Tests.Features.ChatMessages.Utilities;

namespace InstaConnect.Chats.Application.Tests.Unit.Features.ChatMessages.Utilities;

public abstract class BaseChatMessageApplicationQueryUnitTest : BaseChatMessageTest
{
	protected IApplicationMapper Mapper { get; }

	protected IChatMessageQueryService MessageService { get; }

	protected BaseChatMessageApplicationQueryUnitTest()
	{
		Mapper = MockFactory.CreateMapper(ChatsApplicationReference.Assembly);
		MessageService = ChatMessageApplicationMockFactory.CreateQueryService();
	}
}
