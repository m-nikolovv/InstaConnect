using InstaConnect.Common.Domain.Features.Common.Abstractions;

namespace InstaConnect.Posts.Infrastructure.Features.PostLikes.Models.Options;

public record PostLikeCacheOptions(
	IDictionary<string, TimeSpan> Expirations) : IApplicationOptions
{
	public const string SectionName = "PostLikeCacheConfiguration";
}
