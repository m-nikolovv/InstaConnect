namespace InstaConnect.Follows.Domain.Features.Users.Helpers;

public class UserIncludeDescriptorFactory : IUserIncludeDescriptorFactory
{
	public FollowsIncludeDescriptor CreateFollowFollowers()
	{
		return new(FollowsDestinationType.User, FollowsIncludeType.Follower);
	}

	public FollowsIncludeDescriptor CreateFollowFollowings()
	{
		return new(FollowsDestinationType.User, FollowsIncludeType.Following);
	}
}
