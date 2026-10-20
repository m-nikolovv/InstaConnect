namespace InstaConnect.Identity.Domain.Features.RefreshTokens.Abstractions;

public interface IRefreshTokenIncludeDescriptorFactory
{
	public IdentityIncludeDescriptor CreateUser();
}
