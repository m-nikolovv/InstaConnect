using InstaConnect.Identity.Presentation.Features.UserClaims.Controllers.v1;

namespace InstaConnect.Identity.Presentation.Tests.Integration.Features.UserClaims.Utilities;

public abstract class BaseUserClaimPresentationQueryIntegrationTest : BaseUserClaimWebTest
{
	protected UserClaimController Controller { get; }

	protected BaseUserClaimPresentationQueryIntegrationTest(IdentityWebApplicationFactory webApplicationFactory) : base(webApplicationFactory)
	{
		Controller = ServiceScope.GetUserClaimController();
	}

	public override async Task InitializeAsync()
	{
		await ServiceScope.AddRangeAsync(Users, CancellationToken);
		await OnInitializeAsync();
	}
}
