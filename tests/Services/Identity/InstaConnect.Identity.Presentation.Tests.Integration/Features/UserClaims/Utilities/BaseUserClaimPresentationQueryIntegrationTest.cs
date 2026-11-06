using InstaConnect.Identity.Presentation.Features.UserClaims.Controllers.v1;

namespace InstaConnect.Identity.Presentation.Tests.Integration.Features.UserClaims.Utilities;

public abstract class BaseUserClaimPresentationQueryIntegrationTest : BaseIdentityWebQueryTest
{
	protected UserClaimController Controller { get; }

	protected BaseUserClaimPresentationQueryIntegrationTest(IdentityWebApplicationFactory webApplicationFactory) : base(webApplicationFactory)
	{
		Controller = ServiceScope.GetUserClaimController();
	}
}
