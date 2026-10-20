namespace InstaConnect.Common.Infrastructure.Features.Emails.Models;

public record SendGridOptions(
	string Sender,
	string ApiKey) : IApplicationOptions
{
	public const string SectionName = "SendGridConfiguration";
}
