namespace InstaConnect.Identity.Application.Tests.Integration.Features.RefreshTokens.Utilities;

public abstract class BaseRefreshTokenApplicationCommandIntegrationTest : BaseRefreshTokenWebTest
{
	protected IApplicationSender Sender { get; }

	protected BaseRefreshTokenApplicationCommandIntegrationTest(IdentityWebApplicationFactory webApplicationFactory) : base(webApplicationFactory)
	{
		Sender = ServiceScope.GetSender();
	}

	public override async Task InitializeAsync()
	{
		await ServiceScope.AddAsync(User, CancellationToken);
		await ServiceScope.AddAsync(UserClaim, CancellationToken);
		await OnInitializeAsync();
	}
}
