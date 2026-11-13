using InstaConnect.Common.Domain.Features.Common.Abstractions;

namespace InstaConnect.Posts.Infrastructure.Features.PostCommentImages.Models.Options;

public record PostCommentImageCacheOptions(
	IDictionary<string, TimeSpan> Expirations) : IApplicationOptions
{
	public const string SectionName = "PostCommentImageCacheConfiguration";
}
