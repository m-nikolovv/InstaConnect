namespace InstaConnect.Identity.Tests.Features.EmailConfirmationTokens.Utilities;

public abstract class BaseEmailConfirmationTokenTest : BaseIdentityTest
{
	protected BaseEmailConfirmationTokenTest(IPasswordHasher passwordHasher) : base(passwordHasher, false)
	{
	}
}
