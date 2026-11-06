using InstaConnect.Identity.Domain.Features.UserClaims.Abstractions;

namespace InstaConnect.Identity.Infrastructure.Tests.Integration.Features.UserClaims.Utilities;

public abstract class BaseUserClaimInfrastructureCommandIntegrationTest : BaseIdentityWebCommandTest
{
	protected IUserClaimCommandRepository Repository { get; }

	protected IUserClaimIncludeBuilderFactory IncludeBuilderFactory { get; }

	protected BaseUserClaimInfrastructureCommandIntegrationTest(IdentityWebApplicationFactory webApplicationFactory)
		: base(webApplicationFactory)
	{
		Repository = ServiceScope.GetClaimCommandRepository();
		IncludeBuilderFactory = ServiceScope.GetClaimIncludeBuilderFactory();
	}
}
