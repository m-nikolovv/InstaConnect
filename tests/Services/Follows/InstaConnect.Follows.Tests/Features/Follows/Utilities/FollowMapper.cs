namespace InstaConnect.Follows.Tests.Features.Follows.Utilities;

public static class FollowMapper
{
	extension(Follow follow)
	{
		public FollowId ToId(
)
		{
			return follow.Id;
		}
	}
}
