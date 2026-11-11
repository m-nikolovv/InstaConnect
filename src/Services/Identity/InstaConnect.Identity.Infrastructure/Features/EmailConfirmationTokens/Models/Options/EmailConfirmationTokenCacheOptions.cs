using InstaConnect.Common.Domain.Features.Common.Abstractions;

namespace InstaConnect.Identity.Infrastructure.Features.EmailConfirmationTokens.Models.Options;

public record EmailConfirmationTokenCacheOptions(
	IDictionary<string, TimeSpan> Expirations) : IApplicationOptions
{
	public const string SectionName = "EmailConfirmationTokenCacheConfiguration";
}
