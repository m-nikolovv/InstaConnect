namespace InstaConnect.Follows.Domain.Features.Users.Helpers;

public class FollowingIncludeDescriptorFactory : IFollowingIncludeDescriptorFactory
{
	public FollowsIncludeDescriptor CreateFollowFollowers()
	{
		return new(FollowsDestinationType.Following, FollowsIncludeType.FollowFollower);
	}

	public FollowsIncludeDescriptor CreateFollowFollowings()
	{
		return new(FollowsDestinationType.Following, FollowsIncludeType.Following);
	}
}
