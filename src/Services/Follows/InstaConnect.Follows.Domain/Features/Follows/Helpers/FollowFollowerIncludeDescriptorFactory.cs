namespace InstaConnect.Follows.Domain.Features.Follows.Helpers;

public class FollowFollowerIncludeDescriptorFactory : IFollowFollowerIncludeDescriptorFactory
{
	public FollowsIncludeDescriptor CreateFollower()
	{
		return new(FollowsDestinationType.FollowFollower, FollowsIncludeType.Follower);
	}

	public FollowsIncludeDescriptor CreateFollowing()
	{
		return new(FollowsDestinationType.FollowFollower, FollowsIncludeType.Following);
	}
}
