using InstaConnect.Common.Events.Features.AccessTokens.Models;

namespace InstaConnect.Identity.Events.Features.UserClaims;

public record UserClaimEventRequest(
	string Id,
	ApplicationClaims Claim,
	UserEventRequest User,
	DateTimeOffset CreatedAtUtc);
