namespace InstaConnect.Identity.Tests.Features.Common.Utilities;

public abstract class BaseIdentityWebQueryTest : BaseIdentityWebTest
{
	protected BaseIdentityWebQueryTest(IdentityWebApplicationFactory webApplicationFactory, bool isEmailConfirmed = true)
		: base(webApplicationFactory, isEmailConfirmed)
	{
	}

	public override async Task InitializeAsync()
	{
		await ServiceScope.AddRangeAsync(Users, CancellationToken);
		await ServiceScope.AddRangeAsync(UserClaims, CancellationToken);
		await ServiceScope.AddRangeAsync(RefreshTokens, CancellationToken);
		await ServiceScope.AddRangeAsync(ForgotPasswordTokens, CancellationToken);
		await ServiceScope.AddRangeAsync(EmailConfirmationTokens, CancellationToken);
		await OnInitializeAsync();
	}
}
