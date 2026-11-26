namespace InstaConnect.Identity.Tests.Features.EmailConfirmationTokens.Utilities;

public abstract class BaseEmailConfirmationTokenWebQueryTest : BaseEmailConfirmationTokenWebTest
{
	protected BaseEmailConfirmationTokenWebQueryTest(IdentityWebApplicationFactory webApplicationFactory, bool isEmailConfirmed = true)
		: base(webApplicationFactory, isEmailConfirmed)
	{
	}
}
