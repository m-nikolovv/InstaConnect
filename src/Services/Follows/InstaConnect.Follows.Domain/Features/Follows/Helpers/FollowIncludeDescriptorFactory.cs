namespace InstaConnect.Follows.Domain.Features.Follows.Helpers;

public class FollowIncludeDescriptorFactory : IFollowIncludeDescriptorFactory
{
	public FollowsIncludeDescriptor CreateFollower()
	{
		return new(FollowsDestinationType.Follow, FollowsIncludeType.Follower);
	}

	public FollowsIncludeDescriptor CreateFollowing()
	{
		return new(FollowsDestinationType.Follow, FollowsIncludeType.Following);
	}
}
