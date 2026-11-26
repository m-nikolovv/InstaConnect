using InstaConnect.Common.Domain.Features.Common.Abstractions;

namespace InstaConnect.Posts.Infrastructure.Features.Posts.Models.Options;

public record PostCacheOptions(
	IDictionary<string, TimeSpan> Expirations) : IApplicationOptions
{
	public const string SectionName = "PostCacheConfiguration";
}
