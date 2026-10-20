namespace InstaConnect.Common.Infrastructure.Features.Telemetries.Models;

public record OpenTelemetryOptions(
	string Endpoint) : IApplicationOptions
{
	public const string SectionName = "OpenTelemetryConfiguration";
}
