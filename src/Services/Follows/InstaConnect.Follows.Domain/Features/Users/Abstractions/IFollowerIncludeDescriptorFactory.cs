namespace InstaConnect.Follows.Domain.Features.Users.Abstractions;

public interface IFollowerIncludeDescriptorFactory
{
	public FollowsIncludeDescriptor CreateFollowFollowers();
	public FollowsIncludeDescriptor CreateFollowFollowings();
}
