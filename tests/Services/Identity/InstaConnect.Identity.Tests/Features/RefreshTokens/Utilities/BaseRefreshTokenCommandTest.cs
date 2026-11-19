namespace InstaConnect.Identity.Tests.Features.RefreshTokens.Utilities;

public abstract class BaseRefreshTokenCommandTest : BaseRefreshTokenTest
{
	protected BaseRefreshTokenCommandTest(IPasswordHasher passwordHasher, bool isEmailConfirmed = true) : base(passwordHasher, isEmailConfirmed)
	{
	}
}
