namespace InstaConnect.Identity.Domain.Features.RefreshTokens.Models.Responses;

public record SessionToken(
	RefreshTokenId Id,
	AccessToken AccessToken,
	DateTimeOffset ExpiresAtUtc);
