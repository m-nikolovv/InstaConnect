using InstaConnect.Common.Domain.Features.Common.Abstractions;

namespace InstaConnect.Follows.Infrastructure.Features.Users.Models.Options;

public record UserCacheOptions(
	IDictionary<string, TimeSpan> Expirations) : IApplicationOptions
{
	public const string SectionName = "UserCacheConfiguration";
}
