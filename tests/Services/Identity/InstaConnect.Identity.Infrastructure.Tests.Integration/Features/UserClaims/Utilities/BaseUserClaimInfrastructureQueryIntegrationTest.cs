using InstaConnect.Identity.Domain.Features.UserClaims.Abstractions;
using InstaConnect.Identity.Infrastructure.Features.UserClaims.Abstractions;

namespace InstaConnect.Identity.Infrastructure.Tests.Integration.Features.UserClaims.Utilities;

public abstract class BaseUserClaimInfrastructureQueryIntegrationTest : BaseUserClaimWebQueryTest
{
	protected IUserClaimCacheHandler CacheHandler { get; }

	protected IUserClaimQueryRepository Repository { get; }

	protected BaseUserClaimInfrastructureQueryIntegrationTest(IdentityWebApplicationFactory webApplicationFactory)
		: base(webApplicationFactory)
	{
		CacheHandler = ServiceScope.GetClaimCacheHandler();
		Repository = ServiceScope.GetClaimQueryRepository();
	}
}
