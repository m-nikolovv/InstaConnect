namespace InstaConnect.Identity.Infrastructure.Features.Users.Helpers.Includers;

internal class UserIncluderFactory
	: IncluderFactory<IdentityIncludeType, IdentityDestinationType, IdentityIncludeDescriptor, IUserIncluder, User>, IUserIncluderFactory
{
	public UserIncluderFactory(IEnumerable<IUserIncluder> includers) : base(includers)
	{
	}
}
