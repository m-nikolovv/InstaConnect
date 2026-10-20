using InstaConnect.Posts.Infrastructure.Features.Users.Abstractions;
using InstaConnect.Posts.Tests.Features.Users.Utilities;

namespace InstaConnect.Posts.Infrastructure.Tests.Unit.Features.Users.Utilities;

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
