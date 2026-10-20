using InstaConnect.Identity.Presentation.Features.UserClaims.Utilities;

namespace InstaConnect.Identity.Presentation.Features.UserClaims.Models.Requests;

public record DeleteUserClaimApiRequest(
	[FromRoute] string Id,
	[FromRoute] ApplicationClaims Claim = UserClaimDefaultValues.Claim);
