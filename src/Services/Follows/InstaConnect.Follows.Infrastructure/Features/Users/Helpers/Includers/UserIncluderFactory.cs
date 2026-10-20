namespace InstaConnect.Follows.Infrastructure.Features.Users.Helpers.Includers;

internal class UserIncluderFactory : IUserIncluderFactory
{
	private readonly IEnumerable<IUserIncluder> _includers;

	public UserIncluderFactory(IEnumerable<IUserIncluder> includers)
	{
		_includers = includers;
	}

	public IEnumerable<IUserIncluder> Create(ICollection<FollowsIncludeDescriptor> descriptors)
	{
		var includers = _includers.Where(s => descriptors.Any(p =>
														p.IncludeType == s.IncludeType &&
														p.DestinationType == s.DestinationType));

		return includers;
	}
}
