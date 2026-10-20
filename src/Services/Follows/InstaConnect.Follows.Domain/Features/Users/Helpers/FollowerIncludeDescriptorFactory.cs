namespace InstaConnect.Follows.Domain.Features.Users.Helpers;

public class FollowerIncludeDescriptorFactory : IFollowerIncludeDescriptorFactory
{
	public FollowsIncludeDescriptor CreateFollowFollowers()
	{
		return new(FollowsDestinationType.Follower, FollowsIncludeType.FollowFollower);
	}

	public FollowsIncludeDescriptor CreateFollowFollowings()
	{
		return new(FollowsDestinationType.Follower, FollowsIncludeType.Following);
	}
}
