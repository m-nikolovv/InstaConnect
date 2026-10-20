namespace InstaConnect.Identity.Events.Features.UserClaims;

public record UserClaimEventRequest(
	string Id,
	string Claim,
	UserEventRequest User,
	DateTimeOffset CreatedAtUtc);
