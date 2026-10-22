namespace InstaConnect.Identity.Events.Features.UserClaims;

public record UserClaimAddedEventRequest(UserClaimEventRequest UserClaim) : IEventRequest;
