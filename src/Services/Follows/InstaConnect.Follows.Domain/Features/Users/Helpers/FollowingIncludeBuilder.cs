namespace InstaConnect.Follows.Domain.Features.Users.Helpers;

public class FollowingIncludeBuilder
{
	private readonly ICollection<FollowsIncludeDescriptor> _descriptors;
	private readonly IFollowingIncludeDescriptorFactory _descriptorsFactory;

	public FollowingIncludeBuilder(
		ICollection<FollowsIncludeDescriptor> descriptors,
		IFollowingIncludeDescriptorFactory descriptorsFactory)
	{
		_descriptors = descriptors;
		_descriptorsFactory = descriptorsFactory;
	}

	public FollowingIncludeBuilder WithFollowFollowers()
	{
		_descriptors.Add(_descriptorsFactory.CreateFollowFollowers());

		return this;
	}

	public FollowingIncludeBuilder WithFollowFollowers(FollowFollowerInclude include)
	{
		_descriptors.Add(_descriptorsFactory.CreateFollowFollowers());
		_descriptors.AddRange(include.Descriptors);

		return this;
	}

	public FollowingIncludeBuilder WithFollowFollowings()
	{
		_descriptors.Add(_descriptorsFactory.CreateFollowFollowings());

		return this;
	}

	public FollowingIncludeBuilder WithFollowFollowings(FollowInclude include)
	{
		_descriptors.Add(_descriptorsFactory.CreateFollowFollowings());
		_descriptors.AddRange(include.Descriptors);

		return this;
	}

	public FollowingInclude Build()
	{
		return new(_descriptors);
	}
}
