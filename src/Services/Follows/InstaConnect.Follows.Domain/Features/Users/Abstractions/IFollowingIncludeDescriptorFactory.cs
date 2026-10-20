namespace InstaConnect.Follows.Domain.Features.Users.Abstractions;

public interface IFollowingIncludeDescriptorFactory
{
	public FollowsIncludeDescriptor CreateFollowFollowers();
	public FollowsIncludeDescriptor CreateFollowFollowings();
}
