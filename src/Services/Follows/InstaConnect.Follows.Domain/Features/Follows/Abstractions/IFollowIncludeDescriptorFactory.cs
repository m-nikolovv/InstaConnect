namespace InstaConnect.Follows.Domain.Features.Follows.Abstractions;

public interface IFollowIncludeDescriptorFactory
{
	public FollowsIncludeDescriptor CreateFollower();
	public FollowsIncludeDescriptor CreateFollowing();
}
