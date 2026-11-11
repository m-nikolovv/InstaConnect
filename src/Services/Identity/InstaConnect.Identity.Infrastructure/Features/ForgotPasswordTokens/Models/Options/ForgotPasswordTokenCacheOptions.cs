using InstaConnect.Common.Domain.Features.Common.Abstractions;

namespace InstaConnect.Identity.Infrastructure.Features.ForgotPasswordTokens.Models.Options;

public record ForgotPasswordTokenCacheOptions(
	IDictionary<string, TimeSpan> Expirations) : IApplicationOptions
{
	public const string SectionName = "ForgotPasswordTokenCacheConfiguration";
}
