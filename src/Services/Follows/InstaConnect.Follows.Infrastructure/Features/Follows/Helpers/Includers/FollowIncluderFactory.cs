namespace InstaConnect.Follows.Infrastructure.Features.Follows.Helpers.Includers;

internal class FollowIncluderFactory
	: IncluderFactory<FollowsIncludeType, FollowsDestinationType, FollowsIncludeDescriptor, IFollowIncluder, Follow>, IFollowIncluderFactory
{
	public FollowIncluderFactory(IEnumerable<IFollowIncluder> includers) : base(includers)
	{
	}
}
