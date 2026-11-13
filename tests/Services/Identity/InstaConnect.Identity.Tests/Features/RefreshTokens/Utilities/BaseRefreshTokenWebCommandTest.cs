namespace InstaConnect.Identity.Tests.Features.RefreshTokens.Utilities;

public abstract class BaseRefreshTokenWebCommandTest : BaseRefreshTokenWebTest
{
	protected BaseRefreshTokenWebCommandTest(IdentityWebApplicationFactory webApplicationFactory, bool isEmailConfirmed = true)
		: base(webApplicationFactory, isEmailConfirmed)
	{
	}

	public override async Task InitializeAsync()
	{
		await ServiceScope.AddAsync(User, CancellationToken);
		await OnInitializeAsync();
	}
}
