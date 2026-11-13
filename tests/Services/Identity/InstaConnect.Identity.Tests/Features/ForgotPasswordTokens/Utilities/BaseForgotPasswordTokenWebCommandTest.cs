namespace InstaConnect.Identity.Tests.Features.ForgotPasswordTokens.Utilities;

public abstract class BaseForgotPasswordTokenWebCommandTest : BaseForgotPasswordTokenWebTest
{
	protected BaseForgotPasswordTokenWebCommandTest(IdentityWebApplicationFactory webApplicationFactory, bool isEmailConfirmed = true)
		: base(webApplicationFactory, isEmailConfirmed)
	{
	}

	public override async Task InitializeAsync()
	{
		await ServiceScope.AddAsync(User, CancellationToken);
		await OnInitializeAsync();
	}
}
