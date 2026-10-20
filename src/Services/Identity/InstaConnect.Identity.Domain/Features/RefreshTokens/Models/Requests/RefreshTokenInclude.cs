namespace InstaConnect.Identity.Domain.Features.RefreshTokens.Models.Requests;

public record RefreshTokenInclude(ICollection<IdentityIncludeDescriptor> Descriptors)
	: Include<IdentityDestinationType, IdentityIncludeType, IdentityIncludeDescriptor>(Descriptors);
