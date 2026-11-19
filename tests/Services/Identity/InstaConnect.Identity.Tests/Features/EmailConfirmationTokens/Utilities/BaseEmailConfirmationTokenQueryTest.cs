namespace InstaConnect.Identity.Tests.Features.EmailConfirmationTokens.Utilities;

public abstract class BaseEmailConfirmationTokenQueryTest : BaseEmailConfirmationTokenTest
{
	protected BaseEmailConfirmationTokenQueryTest(IPasswordHasher passwordHasher, bool isEmailConfirmed = true) : base(passwordHasher, isEmailConfirmed)
	{
	}
}
