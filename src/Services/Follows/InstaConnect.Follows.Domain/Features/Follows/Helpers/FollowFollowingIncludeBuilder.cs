namespace InstaConnect.Follows.Domain.Features.Follows.Helpers;

public class FollowFollowingIncludeBuilder
{
	private readonly ICollection<FollowsIncludeDescriptor> _descriptors;
	private readonly IFollowFollowingIncludeDescriptorFactory _descriptorFactory;

	internal FollowFollowingIncludeBuilder(
		ICollection<FollowsIncludeDescriptor> descriptors,
		IFollowFollowingIncludeDescriptorFactory descriptorFactory)
	{
		_descriptors = descriptors;
		_descriptorFactory = descriptorFactory;
	}

	public FollowFollowingIncludeBuilder WithFollower()
	{
		_descriptors.Add(_descriptorFactory.CreateFollower());

		return this;
	}

	public FollowFollowingIncludeBuilder WithFollower(FollowerInclude include)
	{
		_descriptors.Add(_descriptorFactory.CreateFollower());
		_descriptors.AddRange(include.Descriptors);

		return this;
	}

	public FollowFollowingIncludeBuilder WithFollowing()
	{
		_descriptors.Add(_descriptorFactory.CreateFollowing());

		return this;
	}
	public FollowFollowingIncludeBuilder WithFollowing(FollowingInclude include)
	{
		_descriptors.Add(_descriptorFactory.CreateFollowing());
		_descriptors.AddRange(include.Descriptors);

		return this;
	}

	public FollowFollowingInclude Build()
	{
		return new(_descriptors);
	}
}
