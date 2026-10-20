namespace InstaConnect.Identity.Domain.Features.UserClaims.Abstractions;

public interface IUserClaimIncludeDescriptorFactory
{
	public IdentityIncludeDescriptor CreateUser();
}
