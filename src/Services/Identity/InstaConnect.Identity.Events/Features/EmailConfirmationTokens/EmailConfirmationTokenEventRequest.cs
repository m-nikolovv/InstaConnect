namespace InstaConnect.Identity.Events.Features.EmailConfirmationTokens;

public record EmailConfirmationTokenEventRequest(
	string Id,
	string Value,
	UserEventRequest User,
	DateTimeOffset ExpiresAtUtc,
	DateTimeOffset CreatedAtUtc);
