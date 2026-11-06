namespace InstaConnect.Identity.Tests.Features.ForgotPasswordTokens.Utilities;

public abstract class BaseForgotPasswordTokenTest : BaseIdentityTest
{
	protected BaseForgotPasswordTokenTest(IPasswordHasher passwordHasher) : base(passwordHasher)
	{
	}
}
