using InstaConnect.Identity.Presentation.Features.UserClaims.Utilities;

namespace InstaConnect.Identity.Presentation.Features.UserClaims.Models.Bodies;

public record AddUserClaimApiBody(ApplicationClaims Claim = UserClaimDefaultValues.Claim);
