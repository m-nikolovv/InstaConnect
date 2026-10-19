using InstaConnect.Chats.Application.Features.Common.Extensions;
using InstaConnect.Common.Domain.Features.Mappers.Abstractions;

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
