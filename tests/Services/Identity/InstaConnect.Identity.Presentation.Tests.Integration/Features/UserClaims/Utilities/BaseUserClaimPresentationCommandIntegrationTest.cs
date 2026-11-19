using InstaConnect.Identity.Presentation.Features.UserClaims.Controllers.v1;
using InstaConnect.Identity.Tests.Features.UserClaims.Abstractions;
using InstaConnect.Identity.Tests.Features.UserClaims.Extensions;

namespace InstaConnect.Identity.Presentation.Tests.Integration.Features.UserClaims.Utilities;

public abstract class BaseUserClaimPresentationCommandIntegrationTest : BaseUserClaimWebCommandTest
{
	protected UserClaimController Controller { get; }

	protected IUserClaimEventClient ClaimEventClient { get; }

	protected BaseUserClaimPresentationCommandIntegrationTest(IdentityWebApplicationFactory webApplicationFactory) : base(webApplicationFactory)
	{
		Controller = ServiceScope.GetUserClaimController();
		ClaimEventClient = webApplicationFactory.CreateClaimEventClient();
	}

	public override async Task InitializeAsync()
	{
		await base.InitializeAsync();
		await ClaimEventClient.StartAsync(CancellationToken);
	}

	public override async Task DisposeAsync()
	{
		await ClaimEventClient.StopAsync(CancellationToken);
	}
}
