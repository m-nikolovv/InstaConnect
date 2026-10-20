namespace InstaConnect.Identity.Events.Features.ForgotPasswordTokens;

public record ForgotPasswordTokenEventRequest(
	string Id,
	string Value,
	UserEventRequest User,
	DateTimeOffset ExpiresAtUtc,
	DateTimeOffset CreatedAtUtc);
