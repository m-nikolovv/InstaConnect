using InstaConnect.Common.Domain.Features.Common.Abstractions;

namespace InstaConnect.Common.Presentation.Features.Controllers.Models;

public record RateLimiterPolicyOptions(
	int PermitLimit,
	TimeSpan Window,
	int SegmentsPerWindow) : IApplicationOptions
{
	public const string SectionName = "RateLimiterPolicyConfiguration";
}
