namespace InstaConnect.Follows.Domain.Features.Follows.Helpers;

public class FollowFollowingIncludeDescriptorFactory : IFollowFollowingIncludeDescriptorFactory
{
	public FollowsIncludeDescriptor CreateFollower()
	{
		return new(FollowsDestinationType.FollowFollowing, FollowsIncludeType.Follower);
	}

	public FollowsIncludeDescriptor CreateFollowing()
	{
		return new(FollowsDestinationType.FollowFollowing, FollowsIncludeType.Following);
	}
}
