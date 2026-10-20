using InstaConnect.Identity.Domain.Features.UserClaims.Abstractions;
using InstaConnect.Identity.Infrastructure.Features.UserClaims.Abstractions;
using InstaConnect.Identity.Tests.Features.UserClaims.Utilities;

namespace InstaConnect.Identity.Infrastructure.Tests.Unit.Features.UserClaims.Utilities;

public abstract class BaseUserClaimInfrastructureCommandUnitTest : BaseUserClaimTest
{
	protected IUserClaimFluent Fluent { get; }

	protected IUserClaimCollection Collection { get; }

	protected IUserClaimIncludeBuilderFactory IncludeBuilderFactory { get; }

	protected BaseUserClaimInfrastructureCommandUnitTest() : base(IdentityMockFactory.CreatePasswordHasher())
	{
		Fluent = UserClaimInfrastructureMockFactory.CreateFluent();
		Collection = UserClaimInfrastructureMockFactory.CreateCollection();
		IncludeBuilderFactory = UserClaimMockFactory.CreateIncludeBuilderFactory();

		PasswordHasher.ClearCalls();
	}
}
