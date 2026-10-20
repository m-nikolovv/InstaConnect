using InstaConnect.Identity.Domain.Features.Users.Abstractions;
using InstaConnect.Identity.Infrastructure.Features.Users.Abstractions;
using InstaConnect.Identity.Tests.Features.Users.Utilities;

namespace InstaConnect.Identity.Infrastructure.Tests.Unit.Features.Users.Utilities;

public abstract class BaseUserInfrastructureCommandUnitTest : BaseUserTest
{
	protected IUserFluent Fluent { get; }

	protected IUserCollection Collection { get; }

	protected IUserIncludeBuilderFactory IncludeBuilderFactory { get; }

	protected BaseUserInfrastructureCommandUnitTest() : base(IdentityMockFactory.CreatePasswordHasher())
	{
		Fluent = UserInfrastructureMockFactory.CreateFluent();
		Collection = UserInfrastructureMockFactory.CreateCollection();
		IncludeBuilderFactory = UserMockFactory.CreateIncludeBuilderFactory();

		PasswordHasher.ClearCalls();
	}
}
