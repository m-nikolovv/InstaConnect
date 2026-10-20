namespace InstaConnect.Common.Infrastructure.Features.Summarizers.Models;

public record AnthropicOptions(
	string ApiKey,
	string Model) : IApplicationOptions
{
	public const string SectionName = "AnthropicConfiguration";
}
