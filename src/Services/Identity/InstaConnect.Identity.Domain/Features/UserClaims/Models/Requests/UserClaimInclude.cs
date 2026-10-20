namespace InstaConnect.Identity.Domain.Features.UserClaims.Models.Requests;

public record UserClaimInclude(ICollection<IdentityIncludeDescriptor> Descriptors)
	: Include<IdentityDestinationType, IdentityIncludeType, IdentityIncludeDescriptor>(Descriptors);
