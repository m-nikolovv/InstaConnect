using InstaConnect.Common.Domain.Features.Common.Abstractions;

namespace InstaConnect.Follows.Infrastructure.Features.Follows.Models.Options;

public record FollowCacheOptions(
	IDictionary<string, TimeSpan> Expirations) : IApplicationOptions
{
	public const string SectionName = "FollowCacheConfiguration";
}
