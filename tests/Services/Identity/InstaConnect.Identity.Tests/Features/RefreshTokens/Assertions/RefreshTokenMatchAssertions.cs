using InstaConnect.Identity.Tests.Features.RefreshTokens.Assertions;
using InstaConnect.Identity.Tests.Features.UserClaims.Assertions;

namespace InstaConnect.Identity.Tests.Features.RefreshTokens.Assertions;

public static class RefreshTokenMatchAssertions
{
	extension(RefreshToken u)
	{
		public void ShouldSatisfy(RefreshToken refreshToken)
		{
			u.ShouldSatisfy(u => u.Matches(refreshToken));
		}
	}
}
