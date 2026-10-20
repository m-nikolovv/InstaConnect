namespace InstaConnect.Identity.Domain.Features.ForgotPasswordTokens.Models.Requests;

public record ForgotPasswordTokenInclude(ICollection<IdentityIncludeDescriptor> Descriptors)
	: Include<IdentityDestinationType, IdentityIncludeType, IdentityIncludeDescriptor>(Descriptors);
