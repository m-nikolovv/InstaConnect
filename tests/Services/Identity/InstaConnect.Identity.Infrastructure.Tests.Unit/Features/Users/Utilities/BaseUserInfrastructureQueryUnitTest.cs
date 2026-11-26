using InstaConnect.Identity.Infrastructure.Features.Users.Abstractions;
using InstaConnect.Identity.Tests.Features.Users.Utilities;

namespace InstaConnect.Identity.Infrastructure.Tests.Unit.Features.Users.Utilities;

public abstract class BaseUserInfrastructureQueryUnitTest : BaseUserQueryTest
{
	protected IUserFluent Fluent { get; }

	protected IUserCollection Collection { get; }

	protected IUserCacheHandler CacheHandler { get; }

	protected IUserResponseFluent ResponseFluent { get; }

	protected BaseUserInfrastructureQueryUnitTest() : base(IdentityMockFactory.CreatePasswordHasher())
	{
		Fluent = UserInfrastructureMockFactory.CreateFluent();
		Collection = UserInfrastructureMockFactory.CreateCollection();
		CacheHandler = UserInfrastructureMockFactory.CreateCacheHandler();
		ResponseFluent = UserInfrastructureMockFactory.CreateResponseFluent();

		PasswordHasher.ClearCalls();
	}
}
