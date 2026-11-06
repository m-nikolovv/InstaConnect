using InstaConnect.Chats.Domain.Features.Chats.Abstractions;
using InstaConnect.Chats.Tests.Features.Common.Utilities;

namespace InstaConnect.Chats.Application.Tests.Unit.Features.Chats.Utilities;

public abstract class BaseChatApplicationCommandUnitTest : BaseChatsCommandTest
{
	protected IApplicationMapper Mapper { get; }

	protected IChatCommandService Service { get; }

	protected BaseChatApplicationCommandUnitTest()
	{
		Mapper = MockFactory.CreateMapper(ChatsApplicationReference.Assembly);
		Service = ChatApplicationMockFactory.CreateCommandService();
	}
}
