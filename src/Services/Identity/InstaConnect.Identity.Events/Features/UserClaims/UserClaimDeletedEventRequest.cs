namespace InstaConnect.Identity.Events.Features.UserClaims;

public record UserClaimDeletedEventRequest(UserClaimEventRequest UserClaim) : IEventRequest;
