namespace InstaConnect.Identity.Domain.Features.ForgotPasswordTokens.Abstractions;

public interface IForgotPasswordTokenIncludeDescriptorFactory
{
	public IdentityIncludeDescriptor CreateUser();
}
