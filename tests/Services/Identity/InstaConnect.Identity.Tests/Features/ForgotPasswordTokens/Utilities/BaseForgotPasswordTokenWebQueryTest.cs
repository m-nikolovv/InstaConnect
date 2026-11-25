namespace InstaConnect.Identity.Tests.Features.ForgotPasswordTokens.Utilities;

public abstract class BaseForgotPasswordTokenWebQueryTest : BaseForgotPasswordTokenWebTest
{
	protected BaseForgotPasswordTokenWebQueryTest(IdentityWebApplicationFactory webApplicationFactory, bool isEmailConfirmed = true)
		: base(webApplicationFactory, isEmailConfirmed)
	{
	}

	public override async Task InitializeAsync()
	{
		await ServiceScope.AddRangeAsync(Users, CancellationToken);
		await ServiceScope.AddRangeAsync(ForgotPasswordTokens, CancellationToken);
		await OnInitializeAsync();
	}
}
