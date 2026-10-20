using InstaConnect.Identity.Presentation.Features.Users.Controllers.v1;

namespace InstaConnect.Identity.Presentation.Tests.Integration.Features.Users.Utilities;

public abstract class BaseUserPresentationQueryIntegrationTest : BaseUserWebTest
{
	protected UserController Controller { get; }

	protected BaseUserPresentationQueryIntegrationTest(IdentityWebApplicationFactory webApplicationFactory) : base(webApplicationFactory)
	{
		Controller = ServiceScope.GetUserController();
	}
}
