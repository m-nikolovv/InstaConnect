using InstaConnect.Identity.Domain.Features.UserClaims.Abstractions;
using InstaConnect.Identity.Infrastructure.Features.UserClaims.Abstractions;

namespace InstaConnect.Identity.Infrastructure.Tests.Integration.Features.UserClaims.Utilities;

public abstract class BaseUserClaimInfrastructureCommandIntegrationTest : BaseUserClaimWebCommandTest
{
	protected IUserClaimCacheHandler CacheHandler { get; }

	protected IUserClaimCommandRepository Repository { get; }

	protected IUserClaimIncludeBuilderFactory IncludeBuilderFactory { get; }

	protected BaseUserClaimInfrastructureCommandIntegrationTest(IdentityWebApplicationFactory webApplicationFactory)
		: base(webApplicationFactory)
	{
		CacheHandler = ServiceScope.GetClaimCacheHandler();
		Repository = ServiceScope.GetClaimCommandRepository();
		IncludeBuilderFactory = ServiceScope.GetClaimIncludeBuilderFactory();
	}
}
