using InstaConnect.Follows.Domain.Features.Users.Abstractions;
using InstaConnect.Follows.Infrastructure.Features.Users.Abstractions;
using InstaConnect.Follows.Tests.Features.Users.Utilities;

namespace InstaConnect.Follows.Infrastructure.Tests.Unit.Features.Users.Utilities;

public abstract class BaseUserInfrastructureCommandUnitTest : BaseUserTest
{
	protected IUserFluent Fluent { get; }

	protected IUserCollection Collection { get; }

	protected IUserIncludeBuilderFactory IncludeBuilderFactory { get; }

	protected BaseUserInfrastructureCommandUnitTest()
	{
		Fluent = UserInfrastructureMockFactory.CreateFluent();
		Collection = UserInfrastructureMockFactory.CreateCollection();
		IncludeBuilderFactory = UserMockFactory.CreateIncludeBuilderFactory();
	}
}
