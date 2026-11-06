using InstaConnect.Chats.Domain.Features.Users.Abstractions;
using InstaConnect.Chats.Tests.Features.Common.Utilities;

namespace InstaConnect.Chats.Domain.Tests.Unit.Features.Users.Utilities;

public abstract class BaseUserDomainCommandUnitTest : BaseChatsCommandTest
{
	protected IUserFactory UserFactory { get; }

	protected IUserCommandRepository UserRepository { get; }

	protected BaseUserDomainCommandUnitTest()
	{
		UserFactory = UserDomainMockFactory.CreateFactory();
		UserRepository = UserDomainMockFactory.CreateCommandRepository();
	}
}
