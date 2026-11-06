namespace InstaConnect.Identity.Tests.Features.Common.Utilities;

public abstract class BaseIdentityQueryTest : BaseIdentityTest
{
	protected BaseIdentityQueryTest(IPasswordHasher passwordHasher, bool isEmailConfirmed = true) : base(passwordHasher, isEmailConfirmed)
	{
	}
}
