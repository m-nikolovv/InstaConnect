namespace InstaConnect.Follows.Domain.Features.Users.Helpers;

public class UserIncludeBuilder
{
	private readonly IUserIncludeDescriptorFactory _descriptorsFactory;
	private readonly ICollection<FollowsIncludeDescriptor> _descriptors;

	public UserIncludeBuilder(
		IUserIncludeDescriptorFactory descriptorsFactory,
		ICollection<FollowsIncludeDescriptor> descriptors)
	{
		_descriptorsFactory = descriptorsFactory;
		_descriptors = descriptors;
	}

	public UserIncludeBuilder WithFollowers()
	{
		_descriptors.Add(_descriptorsFactory.CreateFollowFollowers());

		return this;
	}

	public UserIncludeBuilder WithFollowFollowers(FollowFollowerInclude include)
	{
		_descriptors.Add(_descriptorsFactory.CreateFollowFollowers());
		_descriptors.AddRange(include.Descriptors);

		return this;
	}

	public UserIncludeBuilder WithFollowings()
	{
		_descriptors.Add(_descriptorsFactory.CreateFollowFollowings());

		return this;
	}

	public UserIncludeBuilder WithFollowFollowings(FollowFollowingInclude include)
	{
		_descriptors.Add(_descriptorsFactory.CreateFollowFollowings());
		_descriptors.AddRange(include.Descriptors);

		return this;
	}

	public UserInclude Build()
	{
		return new(_descriptors);
	}
}
