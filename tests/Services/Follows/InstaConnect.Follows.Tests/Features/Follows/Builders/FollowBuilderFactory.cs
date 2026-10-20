namespace InstaConnect.Follows.Tests.Features.Follows.Builders;

public class FollowBuilderFactory
{
	public FollowBuilder Create(User follower, User following)
	{
		return new(follower, following);
	}

	public FollowBuilder Create(Follow follow)
	{
		return new(follow);
	}
}
