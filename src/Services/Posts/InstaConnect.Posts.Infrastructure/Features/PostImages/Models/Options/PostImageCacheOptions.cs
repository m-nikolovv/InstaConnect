using InstaConnect.Common.Domain.Features.Common.Abstractions;

namespace InstaConnect.Posts.Infrastructure.Features.PostImages.Models.Options;

public record PostImageCacheOptions(
	IDictionary<string, TimeSpan> Expirations) : IApplicationOptions
{
	public const string SectionName = "PostImageCacheConfiguration";
}
