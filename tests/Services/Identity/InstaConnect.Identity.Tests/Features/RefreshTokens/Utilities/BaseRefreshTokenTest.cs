namespace InstaConnect.Identity.Tests.Features.RefreshTokens.Utilities;

public abstract class BaseRefreshTokenTest : BaseIdentityTest
{
	protected BaseRefreshTokenTest(IPasswordHasher passwordHasher) : base(passwordHasher)
	{
	}
}
