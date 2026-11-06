using InstaConnect.Follows.Domain.Features.Users.Abstractions;
using InstaConnect.Follows.Tests.Features.Common.Utilities;

namespace InstaConnect.Follows.Domain.Tests.Unit.Features.Users.Utilities;

public abstract class BaseUserDomainCommandUnitTest : BaseFollowsCommandTest
{
	protected IUserFactory UserFactory { get; }

	protected IUserCommandRepository UserRepository { get; }

	protected BaseUserDomainCommandUnitTest()
	{
		UserFactory = UserDomainMockFactory.CreateFactory();
		UserRepository = UserDomainMockFactory.CreateCommandRepository();
	}
}
