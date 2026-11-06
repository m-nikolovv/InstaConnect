using InstaConnect.Identity.Infrastructure.Features.Users.Abstractions;

namespace InstaConnect.Identity.Infrastructure.Tests.Unit.Features.Users.Utilities;

public abstract class BaseUserInfrastructureQueryUnitTest : BaseIdentityQueryTest
{
	protected IUserFluent Fluent { get; }

	protected IUserCollection Collection { get; }

	protected IUserResponseFluent ResponseFluent { get; }

	protected BaseUserInfrastructureQueryUnitTest() : base(IdentityMockFactory.CreatePasswordHasher())
	{
		Collection = UserInfrastructureMockFactory.CreateCollection();
		Fluent = UserInfrastructureMockFactory.CreateFluent();
		ResponseFluent = UserInfrastructureMockFactory.CreateResponseFluent();

		PasswordHasher.ClearCalls();
	}
}
