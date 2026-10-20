using InstaConnect.Identity.Domain.Features.UserClaims.Abstractions;
using InstaConnect.Identity.Domain.Tests.Features.UserClaims.Utilities;
using InstaConnect.Identity.Tests.Features.UserClaims.Abstractions;
using InstaConnect.Identity.Tests.Features.UserClaims.Extensions;

namespace InstaConnect.Identity.Domain.Tests.Integration.Features.UserClaims.Utilities;

public abstract class BaseUserClaimDomainCommandIntegrationTest : BaseUserClaimWebTest
{
	protected IUserClaimCommandService Service { get; }

	protected IUserClaimEventClient ClaimEventClient { get; }

	protected BaseUserClaimDomainCommandIntegrationTest(IdentityWebApplicationFactory webApplicationFactory)
		: base(webApplicationFactory)
	{
		Service = ServiceScope.GetClaimCommandService();
		ClaimEventClient = webApplicationFactory.CreateClaimEventClient();
	}

	public override async Task InitializeAsync()
	{
		await ServiceScope.AddAsync(User, CancellationToken);
		await OnInitializeAsync();
		await ClaimEventClient.StartAsync(CancellationToken);
	}

	public override async Task DisposeAsync()
	{
		await ClaimEventClient.StopAsync(CancellationToken);
	}
}
