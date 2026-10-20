namespace InstaConnect.Identity.Domain.Features.RefreshTokens.Helpers;

public class RefreshTokenIncludeDescriptorFactory : IRefreshTokenIncludeDescriptorFactory
{
	public IdentityIncludeDescriptor CreateUser()
	{
		return new(IdentityDestinationType.RefreshToken, IdentityIncludeType.User);
	}
}
