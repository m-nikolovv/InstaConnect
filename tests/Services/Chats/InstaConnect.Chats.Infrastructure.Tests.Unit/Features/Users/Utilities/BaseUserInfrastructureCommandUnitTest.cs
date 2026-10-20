using InstaConnect.Chats.Domain.Features.Users.Abstractions;
using InstaConnect.Chats.Infrastructure.Features.Users.Abstractions;
using InstaConnect.Chats.Tests.Features.Users.Utilities;

namespace InstaConnect.Chats.Infrastructure.Tests.Unit.Features.Users.Utilities;

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
