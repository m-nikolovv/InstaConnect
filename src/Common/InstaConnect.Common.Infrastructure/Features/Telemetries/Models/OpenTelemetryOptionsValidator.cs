namespace InstaConnect.Common.Infrastructure.Features.Telemetries.Models;

public class OpenTelemetryOptionsValidator : AbstractValidator<OpenTelemetryOptions>
{
	public OpenTelemetryOptionsValidator()
	{
		RuleFor(o => o.Endpoint)
			.NotEmptyWithMessage();
	}
}
