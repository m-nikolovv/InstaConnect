using InstaConnect.Follows.Infrastructure.Features.Users.Abstractions;
using InstaConnect.Follows.Tests.Features.Users.Utilities;

namespace InstaConnect.Follows.Infrastructure.Tests.Unit.Features.Users.Utilities;

public abstract class BaseUserInfrastructureQueryUnitTest : BaseUserTest
{
	protected IUserFluent Fluent { get; }

	protected IUserCollection Collection { get; }

	protected IUserResponseFluent ResponseFluent { get; }

	protected BaseUserInfrastructureQueryUnitTest()
	{
		Collection = UserInfrastructureMockFactory.CreateCollection();
		Fluent = UserInfrastructureMockFactory.CreateFluent();
		ResponseFluent = UserInfrastructureMockFactory.CreateResponseFluent();
	}
}
