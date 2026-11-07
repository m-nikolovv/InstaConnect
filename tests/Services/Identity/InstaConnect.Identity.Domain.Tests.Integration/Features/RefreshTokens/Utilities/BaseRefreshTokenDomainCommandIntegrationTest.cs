using InstaConnect.Identity.Tests.Features.RefreshTokens.Utilities;
using InstaConnect.Identity.Domain.Features.RefreshTokens.Abstractions;
using InstaConnect.Identity.Domain.Tests.Features.RefreshTokens.Utilities;

namespace InstaConnect.Identity.Domain.Tests.Integration.Features.RefreshTokens.Utilities;

public abstract class BaseRefreshTokenDomainCommandIntegrationTest : BaseRefreshTokenWebCommandTest
{
	protected IRefreshTokenCommandService Service { get; }

	protected BaseRefreshTokenDomainCommandIntegrationTest(IdentityWebApplicationFactory webApplicationFactory)
		: base(webApplicationFactory)
	{
		Service = ServiceScope.GetRefreshTokenCommandService();
	}
}
