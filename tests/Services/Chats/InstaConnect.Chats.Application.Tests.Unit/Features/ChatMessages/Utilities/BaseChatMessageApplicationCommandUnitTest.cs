using InstaConnect.Chats.Domain.Features.ChatMessages.Abstractions;
using InstaConnect.Chats.Tests.Features.ChatMessages.Utilities;

namespace InstaConnect.Chats.Application.Tests.Unit.Features.ChatMessages.Utilities;

public abstract class BaseChatMessageApplicationCommandUnitTest : BaseChatMessageTest
{
	protected IApplicationMapper Mapper { get; }

	protected IChatMessageCommandService MessageService { get; }

	protected BaseChatMessageApplicationCommandUnitTest()
	{
		Mapper = MockFactory.CreateMapper(ChatsApplicationReference.Assembly);
		MessageService = ChatMessageApplicationMockFactory.CreateCommandService();
	}
}
