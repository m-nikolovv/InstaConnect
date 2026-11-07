using InstaConnect.Identity.Domain.Features.RefreshTokens.Abstractions;
using InstaConnect.Identity.Infrastructure.Features.RefreshTokens.Abstractions;
using InstaConnect.Identity.Infrastructure.Tests.Features.RefreshTokens.Utilities;
using InstaConnect.Identity.Tests.Features.RefreshTokens.Utilities;

namespace InstaConnect.Identity.Infrastructure.Tests.Unit.Features.RefreshTokens.Utilities;

public abstract class BaseRefreshTokenInfrastructureCommandUnitTest : BaseRefreshTokenCommandTest
{
	protected IRefreshTokenFluent Fluent { get; }

	protected IRefreshTokenCollection Collection { get; }

	protected IRefreshTokenIncludeBuilderFactory IncludeBuilderFactory { get; }

	protected BaseRefreshTokenInfrastructureCommandUnitTest() : base(IdentityMockFactory.CreatePasswordHasher())
	{
		Fluent = RefreshTokenInfrastructureMockFactory.CreateFluent();
		Collection = RefreshTokenInfrastructureMockFactory.CreateCollection();
		IncludeBuilderFactory = RefreshTokenMockFactory.CreateIncludeBuilderFactory();

		PasswordHasher.ClearCalls();
	}
}
