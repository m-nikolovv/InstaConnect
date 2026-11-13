namespace InstaConnect.Identity.Tests.Features.UserClaims.Utilities;

public abstract class BaseUserClaimWebQueryTest : BaseUserClaimWebTest
{
	protected BaseUserClaimWebQueryTest(IdentityWebApplicationFactory webApplicationFactory, bool isEmailConfirmed = true)
		: base(webApplicationFactory, isEmailConfirmed)
	{
	}

	public override async Task InitializeAsync()
	{
		await ServiceScope.AddRangeAsync(Users, CancellationToken);
		await ServiceScope.AddRangeAsync(UserClaims, CancellationToken);
		await OnInitializeAsync();
	}
}
