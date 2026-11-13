namespace InstaConnect.Identity.Tests.Features.Users.Utilities;

public abstract class BaseUserWebQueryTest : BaseUserWebTest
{
	protected BaseUserWebQueryTest(IdentityWebApplicationFactory webApplicationFactory, bool isEmailConfirmed = true)
		: base(webApplicationFactory, isEmailConfirmed)
	{
	}

	public override async Task InitializeAsync()
	{
		await ServiceScope.AddRangeAsync(Users, CancellationToken);
		await OnInitializeAsync();
	}
}
