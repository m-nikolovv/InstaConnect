namespace InstaConnect.Identity.Tests.Features.UserClaims.Utilities;

public abstract class BaseUserClaimQueryTest : BaseUserClaimTest
{
	protected BaseUserClaimQueryTest(IPasswordHasher passwordHasher, bool isEmailConfirmed = true) : base(passwordHasher, isEmailConfirmed)
	{
	}
}
