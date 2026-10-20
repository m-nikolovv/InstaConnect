namespace InstaConnect.Common.Infrastructure.Features.AccessTokens.Models;

public record AccessTokenOptions(
	string Issuer,
	string Audience,
	string SecurityKey,
	int LifetimeSeconds,
	bool ValidateIssuer,
	bool ValidateAudience,
	bool ValidateLifetime,
	bool ValidateIssuerSigningKey,
	int ClockSkewSeconds) : IApplicationOptions
{
	public const string SectionName = "AccessTokenConfiguration";
}
