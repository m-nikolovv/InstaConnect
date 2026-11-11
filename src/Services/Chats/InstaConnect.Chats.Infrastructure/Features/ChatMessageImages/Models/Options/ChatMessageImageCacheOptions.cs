using InstaConnect.Common.Domain.Features.Common.Abstractions;

namespace InstaConnect.Chats.Infrastructure.Features.ChatMessageImages.Models.Options;

public record ChatMessageImageCacheOptions(
	IDictionary<string, TimeSpan> Expirations) : IApplicationOptions
{
	public const string SectionName = "ChatMessageImageCacheConfiguration";
}
