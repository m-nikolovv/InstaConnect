namespace InstaConnect.Common.Infrastructure.Features.Events.Models;

public record KafkaOptions(
	string ConnectionString,
	string Username,
	string Password) : IApplicationOptions
{
	public const string SectionName = "KafkaConfiguration";
}
