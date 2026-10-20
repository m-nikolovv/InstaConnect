namespace InstaConnect.Follows.Domain.Features.Follows.Helpers;

public class FollowIncludeBuilder
{
	private readonly ICollection<FollowsIncludeDescriptor> _descriptors;
	private readonly IFollowIncludeDescriptorFactory _descriptorFactory;

	internal FollowIncludeBuilder(
		ICollection<FollowsIncludeDescriptor> descriptors,
		IFollowIncludeDescriptorFactory descriptorFactory)
	{
		_descriptors = descriptors;
		_descriptorFactory = descriptorFactory;
	}

	public FollowIncludeBuilder WithFollower()
	{
		_descriptors.Add(_descriptorFactory.CreateFollower());

		return this;
	}

	public FollowIncludeBuilder WithFollower(FollowerInclude include)
	{
		_descriptors.Add(_descriptorFactory.CreateFollower());
		_descriptors.AddRange(include.Descriptors);

		return this;
	}

	public FollowIncludeBuilder WithFollowing()
	{
		_descriptors.Add(_descriptorFactory.CreateFollowing());

		return this;
	}

	public FollowIncludeBuilder WithFollowing(FollowingInclude include)
	{
		_descriptors.Add(_descriptorFactory.CreateFollowing());
		_descriptors.AddRange(include.Descriptors);

		return this;
	}

	public FollowInclude Build()
	{
		return new(_descriptors);
	}
}
