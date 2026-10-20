namespace InstaConnect.Follows.Domain.Features.Follows.Helpers;

public class FollowFollowerIncludeBuilder
{
	private readonly ICollection<FollowsIncludeDescriptor> _descriptors;
	private readonly IFollowFollowerIncludeDescriptorFactory _descriptorFactory;

	internal FollowFollowerIncludeBuilder(
		ICollection<FollowsIncludeDescriptor> descriptors,
		IFollowFollowerIncludeDescriptorFactory descriptorFactory)
	{
		_descriptors = descriptors;
		_descriptorFactory = descriptorFactory;
	}

	public FollowFollowerIncludeBuilder WithFollower()
	{
		_descriptors.Add(_descriptorFactory.CreateFollower());

		return this;
	}

	public FollowFollowerIncludeBuilder WithFollower(FollowerInclude include)
	{
		_descriptors.Add(_descriptorFactory.CreateFollower());
		_descriptors.AddRange(include.Descriptors);

		return this;
	}

	public FollowFollowerIncludeBuilder WithFollowing()
	{
		_descriptors.Add(_descriptorFactory.CreateFollowing());

		return this;
	}
	public FollowFollowerIncludeBuilder WithFollowing(FollowingInclude include)
	{
		_descriptors.Add(_descriptorFactory.CreateFollowing());
		_descriptors.AddRange(include.Descriptors);

		return this;
	}

	public FollowFollowerInclude Build()
	{
		return new(_descriptors);
	}
}
