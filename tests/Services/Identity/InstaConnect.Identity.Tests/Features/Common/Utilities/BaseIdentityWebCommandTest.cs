namespace InstaConnect.Identity.Tests.Features.Common.Utilities;

public abstract class BaseIdentityWebCommandTest : BaseIdentityCommandTest, IClassFixture<IdentityWebApplicationFactory>
{
	protected IServiceScope ServiceScope { get; }

	protected BaseIdentityWebCommandTest(IdentityWebApplicationFactory webApplicationFactory, bool isEmailConfirmed = true) : base(webApplicationFactory.Services.GetPasswordHasher(), isEmailConfirmed)
	{
		ServiceScope = webApplicationFactory.Services.CreateScope();
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
