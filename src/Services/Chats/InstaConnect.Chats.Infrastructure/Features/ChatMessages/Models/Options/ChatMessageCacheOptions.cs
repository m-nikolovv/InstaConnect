using InstaConnect.Common.Domain.Features.Common.Abstractions;

namespace InstaConnect.Chats.Infrastructure.Features.ChatMessages.Models.Options;

public record ChatMessageCacheOptions(
	IDictionary<string, TimeSpan> Expirations) : IApplicationOptions
{
	public const string SectionName = "ChatMessageCacheConfiguration";
}
