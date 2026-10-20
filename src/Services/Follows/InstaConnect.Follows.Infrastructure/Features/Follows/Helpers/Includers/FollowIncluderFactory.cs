namespace InstaConnect.Follows.Infrastructure.Features.Follows.Helpers.Includers;

internal class FollowIncluderFactory : IFollowIncluderFactory
{
	private readonly IEnumerable<IFollowIncluder> _includers;

	public FollowIncluderFactory(IEnumerable<IFollowIncluder> includers)
	{
		_includers = includers;
	}

	public IEnumerable<IFollowIncluder> Create(ICollection<FollowsIncludeDescriptor> descriptors)
	{
		var includers = _includers.Where(s => descriptors.Any(p =>
														p.IncludeType == s.IncludeType &&
														p.DestinationType == s.DestinationType));

		return includers;
	}
}
