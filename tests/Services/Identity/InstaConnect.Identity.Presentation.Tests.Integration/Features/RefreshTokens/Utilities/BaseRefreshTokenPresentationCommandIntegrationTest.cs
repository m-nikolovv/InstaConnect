namespace InstaConnect.Identity.Presentation.Tests.Integration.Features.RefreshTokens.Utilities;

public abstract class BaseRefreshTokenPresentationCommandIntegrationTest : BaseRefreshTokenWebTest
{
	protected RefreshTokenController Controller { get; }

	protected BaseRefreshTokenPresentationCommandIntegrationTest(IdentityWebApplicationFactory webApplicationFactory) : base(webApplicationFactory)
	{
		Controller = ServiceScope.GetRefreshTokenController();
	}

	public override async Task InitializeAsync()
	{
		await ServiceScope.AddAsync(User, CancellationToken);
		await ServiceScope.AddAsync(UserClaim, CancellationToken);
		await OnInitializeAsync();
	}
}
