namespace InstaConnect.Identity.Domain.Features.EmailConfirmationTokens.Helpers;

public class EmailConfirmationTokenIncludeDescriptorFactory : IEmailConfirmationTokenIncludeDescriptorFactory
{
	public IdentityIncludeDescriptor CreateUser()
	{
		return new(IdentityDestinationType.EmailConfirmationToken, IdentityIncludeType.User);
	}
}
