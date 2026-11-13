using InstaConnect.Identity.Presentation.Features.RefreshTokens.Controllers.v1;

namespace InstaConnect.Identity.Presentation.Tests.Integration.Features.RefreshTokens.Utilities;

public abstract class BaseRefreshTokenPresentationCommandIntegrationTest : BaseRefreshTokenWebCommandTest
{
	protected RefreshTokenController Controller { get; }

	protected BaseRefreshTokenPresentationCommandIntegrationTest(IdentityWebApplicationFactory webApplicationFactory) : base(webApplicationFactory)
	{
		Controller = ServiceScope.GetRefreshTokenController();
	}
}
