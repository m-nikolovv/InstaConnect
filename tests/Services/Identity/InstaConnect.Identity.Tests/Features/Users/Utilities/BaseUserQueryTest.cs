namespace InstaConnect.Identity.Tests.Features.Users.Utilities;

public abstract class BaseUserQueryTest : BaseUserTest
{
	protected BaseUserQueryTest(IPasswordHasher passwordHasher, bool isEmailConfirmed = true) : base(passwordHasher, isEmailConfirmed)
	{
	}
}
