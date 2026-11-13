namespace InstaConnect.Identity.Tests.Features.UserClaims.Utilities;

public abstract class BaseUserClaimTest : BaseIdentityTest
{
	protected BaseUserClaimTest(IPasswordHasher passwordHasher, bool isEmailConfirmed = true) : base(passwordHasher, isEmailConfirmed)
	{
	}
}
