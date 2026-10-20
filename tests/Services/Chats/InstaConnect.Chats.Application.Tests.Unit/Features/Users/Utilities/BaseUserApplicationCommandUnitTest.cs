using InstaConnect.Chats.Domain.Features.Users.Abstractions;
using InstaConnect.Chats.Tests.Features.Users.Utilities;

namespace InstaConnect.Chats.Application.Tests.Unit.Features.Users.Utilities;

public abstract class BaseUserApplicationCommandUnitTest : BaseUserTest
{
	protected IApplicationMapper Mapper { get; }

	protected IUserCommandService UserService { get; }

	protected BaseUserApplicationCommandUnitTest()
	{
		Mapper = MockFactory.CreateMapper(ChatsApplicationReference.Assembly);
		UserService = UserApplicationMockFactory.CreateCommandService();
	}
}
