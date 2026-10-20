using InstaConnect.Identity.Tests.Features.UserClaims.Assertions;

namespace InstaConnect.Identity.Tests.Features.UserClaims.Assertions;

public static class UserClaimMatchAssertions
{
	extension(UserClaim u)
	{
		public void ShouldSatisfy(UserClaim userClaim)
		{
			u.ShouldSatisfy(u => u.Matches(userClaim));
		}
	}
}
