namespace InstaConnect.Common.Infrastructure.Features.OutboxEvents.Models;

public record OutboxEventOptions(
	TimeSpan ExpireAfter) : IApplicationOptions
{
	public const string SectionName = "OutboxEventConfiguration";
}
