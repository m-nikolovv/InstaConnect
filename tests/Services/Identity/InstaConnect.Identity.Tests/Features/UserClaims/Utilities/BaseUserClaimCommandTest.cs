namespace InstaConnect.Identity.Tests.Features.UserClaims.Utilities;

public abstract class BaseUserClaimCommandTest : BaseUserClaimTest
{
	protected BaseUserClaimCommandTest(IPasswordHasher passwordHasher, bool isEmailConfirmed = true) : base(passwordHasher, isEmailConfirmed)
	{
	}
}
