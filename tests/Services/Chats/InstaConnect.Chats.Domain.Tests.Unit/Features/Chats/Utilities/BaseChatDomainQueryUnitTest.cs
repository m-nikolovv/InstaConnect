using InstaConnect.Chats.Domain.Features.Chats.Abstractions;
using InstaConnect.Chats.Domain.Features.Users.Abstractions;
using InstaConnect.Chats.Tests.Features.Chats.Utilities;

namespace InstaConnect.Chats.Domain.Tests.Unit.Features.Chats.Utilities;

public abstract class BaseChatDomainQueryUnitTest : BaseChatTest
{
	protected IChatQueryRepository Repository { get; }

	protected IUserQueryRepository UserRepository { get; }

	internal IChatCollectionResponseFactory CollectionResponseFactory { get; }

	protected BaseChatDomainQueryUnitTest()
	{
		Repository = ChatDomainMockFactory.CreateQueryRepository();
		UserRepository = UserDomainMockFactory.CreateQueryRepository();
		CollectionResponseFactory = ChatDomainMockFactory.CreateCollectionResponseFactory();
	}
}
