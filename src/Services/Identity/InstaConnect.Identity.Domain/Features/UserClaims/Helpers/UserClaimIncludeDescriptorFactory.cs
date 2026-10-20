namespace InstaConnect.Identity.Domain.Features.UserClaims.Helpers;

public class UserClaimIncludeDescriptorFactory : IUserClaimIncludeDescriptorFactory
{
	public IdentityIncludeDescriptor CreateUser()
	{
		return new(IdentityDestinationType.UserClaim, IdentityIncludeType.User);
	}
}
