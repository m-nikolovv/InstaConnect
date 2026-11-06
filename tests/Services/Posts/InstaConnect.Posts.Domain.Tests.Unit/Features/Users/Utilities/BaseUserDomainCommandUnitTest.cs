using InstaConnect.Posts.Tests.Features.Common.Utilities;

namespace InstaConnect.Posts.Domain.Tests.Unit.Features.Users.Utilities;

public abstract class BaseUserDomainCommandUnitTest : BasePostsCommandTest
{
	protected IUserFactory UserFactory { get; }

	protected IUserCommandRepository UserRepository { get; }

	protected BaseUserDomainCommandUnitTest()
	{
		UserFactory = UserDomainMockFactory.CreateFactory();
		UserRepository = UserDomainMockFactory.CreateCommandRepository();
	}
}
