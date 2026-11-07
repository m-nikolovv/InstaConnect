namespace InstaConnect.Identity.Tests.Features.Users.Utilities;

public abstract class BaseUserCommandTest : BaseUserTest
{
	protected BaseUserCommandTest(IPasswordHasher passwordHasher, bool isEmailConfirmed = true) : base(passwordHasher, isEmailConfirmed)
	{
	}
}
