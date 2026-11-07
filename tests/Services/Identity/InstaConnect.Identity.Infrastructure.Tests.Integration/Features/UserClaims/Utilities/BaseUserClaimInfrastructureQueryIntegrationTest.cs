using InstaConnect.Identity.Domain.Features.UserClaims.Abstractions;

namespace InstaConnect.Identity.Infrastructure.Tests.Integration.Features.UserClaims.Utilities;

public abstract class BaseUserClaimInfrastructureQueryIntegrationTest : BaseUserClaimWebQueryTest
{
	protected IUserClaimQueryRepository Repository { get; }

	protected BaseUserClaimInfrastructureQueryIntegrationTest(IdentityWebApplicationFactory webApplicationFactory)
		: base(webApplicationFactory)
	{
		Repository = ServiceScope.GetClaimQueryRepository();
	}
}
