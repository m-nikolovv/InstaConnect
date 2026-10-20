namespace InstaConnect.Follows.Domain.Features.Users.Helpers;

public class UserIncludeDescriptorFactory : IUserIncludeDescriptorFactory
{
	public FollowsIncludeDescriptor CreateFollowFollowers()
	{
		return new(FollowsDestinationType.User, FollowsIncludeType.FollowFollower);
	}

	public FollowsIncludeDescriptor CreateFollowFollowings()
	{
		return new(FollowsDestinationType.User, FollowsIncludeType.Following);
	}
}
