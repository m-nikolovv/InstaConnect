namespace InstaConnect.Common.Infrastructure.Features.Images.Models;

public record CloudinaryOptions(
	string CloudName,
	string ApiKey,
	string ApiSecret) : IApplicationOptions
{
	public const string SectionName = "CloudinaryConfiguration";
}
