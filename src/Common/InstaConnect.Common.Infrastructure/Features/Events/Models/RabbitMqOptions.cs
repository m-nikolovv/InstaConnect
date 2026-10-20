namespace InstaConnect.Common.Infrastructure.Features.Events.Models;

public record RabbitMqOptions(
	string ConnectionString) : IApplicationOptions
{
	public const string SectionName = "RabbitMqConfiguration";
}
