namespace InstaConnect.Identity.Domain.Features.Users.Models.Requests;

public record UserInclude(ICollection<IdentityIncludeDescriptor> Descriptors)
	: Include<IdentityDestinationType, IdentityIncludeType, IdentityIncludeDescriptor>(Descriptors);
