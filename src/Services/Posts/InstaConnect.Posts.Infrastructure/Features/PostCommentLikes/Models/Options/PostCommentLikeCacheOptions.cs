using InstaConnect.Common.Domain.Features.Common.Abstractions;

namespace InstaConnect.Posts.Infrastructure.Features.PostCommentLikes.Models.Options;

public record PostCommentLikeCacheOptions(
	IDictionary<string, TimeSpan> Expirations) : IApplicationOptions
{
	public const string SectionName = "PostCommentLikeCacheConfiguration";
}
