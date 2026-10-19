using InstaConnect.Chats.Application.Features.Common.Extensions;
using InstaConnect.Common.Domain.Features.Mappers.Abstractions;

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
