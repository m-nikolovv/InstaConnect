namespace InstaConnect.Identity.Application.Tests.Integration.Features.UserClaims.Utilities;

public abstract class BaseUserClaimApplicationQueryIntegrationTest : BaseUserClaimWebTest
{
	protected IApplicationSender Sender { get; }

	protected BaseUserClaimApplicationQueryIntegrationTest(IdentityWebApplicationFactory webApplicationFactory) : base(webApplicationFactory)
	{
		Sender = ServiceScope.GetSender();
	}

	public override async Task InitializeAsync()
	{
		await ServiceScope.AddRangeAsync(Users, CancellationToken);
		await OnInitializeAsync();
	}
}
