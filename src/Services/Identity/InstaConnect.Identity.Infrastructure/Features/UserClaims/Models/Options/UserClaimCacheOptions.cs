using InstaConnect.Common.Domain.Features.Common.Abstractions;

namespace InstaConnect.Identity.Infrastructure.Features.UserClaims.Models.Options;

public record UserClaimCacheOptions(
	IDictionary<string, TimeSpan> Expirations) : IApplicationOptions
{
	public const string SectionName = "UserClaimCacheConfiguration";
}
