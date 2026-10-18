using InstaConnect.Common.Domain.Features.Common.Abstractions;

namespace InstaConnect.Common.Infrastructure.Features.Analyzers.Models;

public record OpenAiOptions(
	string ApiKey,
	string Model) : IApplicationOptions
{
	public const string SectionName = "OpenAiConfiguration";
}
