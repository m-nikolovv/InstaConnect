namespace InstaConnect.Identity.Domain.Features.EmailConfirmationTokens.Models.Requests;

public record EmailConfirmationTokenInclude(ICollection<IdentityIncludeDescriptor> Descriptors)
	: Include<IdentityDestinationType, IdentityIncludeType, IdentityIncludeDescriptor>(Descriptors);
