using InstaConnect.Common.Domain.Features.Common.Abstractions;

namespace InstaConnect.Identity.Infrastructure.Features.RefreshTokens.Models.Options;

public record RefreshTokenCacheOptions(
	IDictionary<string, TimeSpan> Expirations) : IApplicationOptions
{
	public const string SectionName = "RefreshTokenCacheConfiguration";
}
