using InstaConnect.Identity.Tests.Features.UserClaims.Abstractions;
using InstaConnect.Identity.Tests.Features.UserClaims.Extensions;

namespace InstaConnect.Identity.Application.Tests.Integration.Features.UserClaims.Utilities;

public abstract class BaseUserClaimApplicationCommandIntegrationTest : BaseUserClaimWebTest
{
	protected IApplicationSender Sender { get; }

	protected IUserClaimEventClient ClaimEventClient { get; }

	protected BaseUserClaimApplicationCommandIntegrationTest(IdentityWebApplicationFactory webApplicationFactory) : base(webApplicationFactory)
	{
		Sender = ServiceScope.GetSender();
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
