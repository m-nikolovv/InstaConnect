namespace InstaConnect.Common.Infrastructure.Features.OutboxEvents.Models;

public record OutboxEventOptions(
	int LifetimeSeconds) : IApplicationOptions
{
	public const string SectionName = "OutboxEventConfiguration";
}
