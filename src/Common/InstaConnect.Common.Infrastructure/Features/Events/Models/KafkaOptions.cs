using Confluent.Kafka;

namespace InstaConnect.Common.Infrastructure.Features.Events.Models;

public record KafkaOptions(
	string ConnectionString,
	string Username,
	string Password,
	SecurityProtocol SecurityProtocol,
	SaslMechanism SaslMechanism) : IApplicationOptions
{
	public const string SectionName = "KafkaConfiguration";

	public IDictionary<string, KafkaConsumerOptions> Consumers { get; init; } = new Dictionary<string, KafkaConsumerOptions>();
}
