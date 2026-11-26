namespace InstaConnect.Identity.Infrastructure.Features.UserClaims.Helpers.Includers;

internal class UserClaimIncluderFactory
	: IncluderFactory<IdentityIncludeType, IdentityDestinationType, IdentityIncludeDescriptor, IUserClaimIncluder, UserClaim>, IUserClaimIncluderFactory
{
	public UserClaimIncluderFactory(IEnumerable<IUserClaimIncluder> includers) : base(includers)
	{
	}
}
