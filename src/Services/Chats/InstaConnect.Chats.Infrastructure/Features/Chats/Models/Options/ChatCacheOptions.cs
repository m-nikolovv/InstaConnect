using InstaConnect.Common.Domain.Features.Common.Abstractions;

namespace InstaConnect.Chats.Infrastructure.Features.Chats.Models.Options;

public record ChatCacheOptions(
	IDictionary<string, TimeSpan> Expirations) : IApplicationOptions
{
	public const string SectionName = "ChatCacheConfiguration";
}
