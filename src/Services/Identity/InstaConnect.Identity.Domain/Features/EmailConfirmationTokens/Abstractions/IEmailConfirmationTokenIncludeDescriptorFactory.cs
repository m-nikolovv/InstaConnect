namespace InstaConnect.Identity.Domain.Features.EmailConfirmationTokens.Abstractions;

public interface IEmailConfirmationTokenIncludeDescriptorFactory
{
	public IdentityIncludeDescriptor CreateUser();
}
