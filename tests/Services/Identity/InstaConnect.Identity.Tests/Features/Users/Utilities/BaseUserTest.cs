namespace InstaConnect.Identity.Tests.Features.Users.Utilities;

public abstract class BaseUserTest : BaseIdentityTest
{
	protected BaseUserTest(IPasswordHasher passwordHasher) : base(passwordHasher)
	{
	}
}
