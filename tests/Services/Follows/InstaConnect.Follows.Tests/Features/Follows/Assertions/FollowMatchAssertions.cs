using InstaConnect.Follows.Tests.Features.Follows.Assertions;
using InstaConnect.Follows.Tests.Features.Users.Assertions;

namespace InstaConnect.Follows.Tests.Features.Follows.Assertions;

public static class FollowMatchAssertions
{
	extension(ICollection<Follow> f)
	{
		public void ShouldSatisfy(ICollection<Follow> follows)
		{
			f.ShouldSatisfy(u => u.Matches(follows));
		}
	}

	extension(Follow u)
	{
		public void ShouldSatisfy(Follow follow)
		{
			u.ShouldSatisfy(u => u.Matches(follow));
		}
	}
}
