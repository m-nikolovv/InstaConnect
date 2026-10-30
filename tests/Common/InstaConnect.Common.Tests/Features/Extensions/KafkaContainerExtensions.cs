using Testcontainers.Kafka;

namespace InstaConnect.Common.Tests.Features.Extensions;

public static class KafkaContainerExtensions
{
	extension(KafkaContainer kafkaContainer)
	{
		public string GetBootstrapServers()
		{
			return new Uri(kafkaContainer.GetBootstrapAddress()).Authority;
		}
	}
}
