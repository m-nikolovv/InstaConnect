namespace InstaConnect.Identity.Domain.Features.ForgotPasswordTokens.Helpers;

public class ForgotPasswordTokenIncludeDescriptorFactory : IForgotPasswordTokenIncludeDescriptorFactory
{
	public IdentityIncludeDescriptor CreateUser()
	{
		return new(IdentityDestinationType.ForgotPasswordToken, IdentityIncludeType.User);
	}
}
