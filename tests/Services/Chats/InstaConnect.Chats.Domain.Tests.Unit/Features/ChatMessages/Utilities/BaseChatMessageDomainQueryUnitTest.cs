using InstaConnect.Chats.Domain.Features.ChatMessages.Abstractions;
using InstaConnect.Chats.Domain.Features.Chats.Abstractions;
using InstaConnect.Chats.Tests.Features.ChatMessages.Utilities;

namespace InstaConnect.Chats.Domain.Tests.Unit.Features.ChatMessages.Utilities;

public abstract class BaseChatMessageDomainQueryUnitTest : BaseChatMessageTest
{
	protected IChatQueryRepository Repository { get; }

	protected IChatMessageQueryRepository MessageRepository { get; }

	protected IChatMessageCollectionResponseFactory CollectionResponseFactory { get; }

	protected BaseChatMessageDomainQueryUnitTest()
	{
		Repository = ChatDomainMockFactory.CreateQueryRepository();
		MessageRepository = ChatMessageDomainMockFactory.CreateQueryRepository();
		CollectionResponseFactory = ChatMessageDomainMockFactory.CreateCollectionResponseFactory();
	}
}
