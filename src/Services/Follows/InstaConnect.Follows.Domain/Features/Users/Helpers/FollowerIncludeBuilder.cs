namespace InstaConnect.Follows.Domain.Features.Users.Helpers;

public class FollowerIncludeBuilder
{
	private readonly ICollection<FollowsIncludeDescriptor> _descriptors;
	private readonly IFollowerIncludeDescriptorFactory _descriptorsFactory;

	public FollowerIncludeBuilder(
		ICollection<FollowsIncludeDescriptor> descriptors,
		IFollowerIncludeDescriptorFactory descriptorsFactory)
	{
		_descriptors = descriptors;
		_descriptorsFactory = descriptorsFactory;
	}

	public FollowerIncludeBuilder WithFollowFollowers()
	{
		_descriptors.Add(_descriptorsFactory.CreateFollowFollowers());

		return this;
	}

	public FollowerIncludeBuilder WithFollowFollowers(FollowFollowerInclude include)
	{
		_descriptors.Add(_descriptorsFactory.CreateFollowFollowers());
		_descriptors.AddRange(include.Descriptors);

		return this;
	}

	public FollowerIncludeBuilder WithFollowFollowings()
	{
		_descriptors.Add(_descriptorsFactory.CreateFollowFollowings());

		return this;
	}

	public FollowerIncludeBuilder WithFollowFollowings(FollowFollowingInclude include)
	{
		_descriptors.Add(_descriptorsFactory.CreateFollowFollowings());
		_descriptors.AddRange(include.Descriptors);

		return this;
	}

	public FollowerInclude Build()
	{
		return new(_descriptors);
	}
}
