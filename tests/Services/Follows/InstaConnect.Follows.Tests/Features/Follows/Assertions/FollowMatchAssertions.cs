using InstaConnect.Common.Tests.Features.Assertions;
using InstaConnect.Follows.Tests.Features.Follows.Assertions;
using InstaConnect.Follows.Tests.Features.Users.Assertions;

namespace InstaConnect.Follows.Tests.Features.Follows.Assertions;

public static class FollowMatchAssertions
{
	extension(Follow u)
	{
		public void ShouldSatisfy(Follow follow)
		{
			u.ShouldSatisfy(u => u.Matches(follow));
		}
	}
}
