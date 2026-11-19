namespace InstaConnect.Identity.Tests.Features.Users.Utilities;

public abstract class BaseUserWebCommandTest : BaseUserWebTest
{
	protected BaseUserWebCommandTest(IdentityWebApplicationFactory webApplicationFactory, bool isEmailConfirmed = true)
		: base(webApplicationFactory, isEmailConfirmed)
	{
	}
}
