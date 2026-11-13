namespace InstaConnect.Identity.Tests.Features.ForgotPasswordTokens.Utilities;

public abstract class BaseForgotPasswordTokenQueryTest : BaseForgotPasswordTokenTest
{
	protected BaseForgotPasswordTokenQueryTest(IPasswordHasher passwordHasher, bool isEmailConfirmed = true) : base(passwordHasher, isEmailConfirmed)
	{
	}
}
