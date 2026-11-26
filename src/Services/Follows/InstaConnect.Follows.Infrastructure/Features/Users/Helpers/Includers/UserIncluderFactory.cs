namespace InstaConnect.Follows.Infrastructure.Features.Users.Helpers.Includers;

internal class UserIncluderFactory
	: IncluderFactory<FollowsIncludeType, FollowsDestinationType, FollowsIncludeDescriptor, IUserIncluder, User>, IUserIncluderFactory
{
	public UserIncluderFactory(IEnumerable<IUserIncluder> includers) : base(includers)
	{
	}
}
