using Testcontainers.Kafka;
using Testcontainers.MongoDb;
using Testcontainers.Redis;

namespace InstaConnect.Common.Tests.Features.Utilities;

public static class ContainerFactory
{
	public static MongoDbContainer GetMongoDbContainer()
	{
		const string Image = "mongo:latest";
		const string GlibcTunablesName = "GLIBC_TUNABLES";
		const string GlibcTunablesValue = "glibc.pthread.rseq=1";

		return new MongoDbBuilder(Image)
		   .WithEnvironment(GlibcTunablesName, GlibcTunablesValue)
		   .WithReplicaSet()
		   .WithCleanUp(true)
		   .Build();
	}

	public static KafkaContainer GetKafkaContainer()
	{
		const string Image = "apache/kafka:latest";
		const string SecurityProtocolMapName = "KAFKA_LISTENER_SECURITY_PROTOCOL_MAP";
		const string SecurityProtocolMapValue = "BROKER:PLAINTEXT,CONTROLLER:PLAINTEXT,PLAINTEXT:SASL_PLAINTEXT";
		const string SaslMechanismsName = "KAFKA_SASL_ENABLED_MECHANISMS";
		const string SaslMechanismsValue = "PLAIN";
		const string SaslJaasConfigName = "KAFKA_LISTENER_NAME_PLAINTEXT_PLAIN_SASL_JAAS_CONFIG";
		const string SaslJaasConfigValueFormat =
			"org.apache.kafka.common.security.plain.PlainLoginModule required username=\"{0}\" password=\"{1}\" user_{0}=\"{1}\";";

		return new KafkaBuilder(Image)
			.WithEnvironment(SecurityProtocolMapName, SecurityProtocolMapValue)
			.WithEnvironment(SaslMechanismsName, SaslMechanismsValue)
			.WithEnvironment(SaslJaasConfigName, SaslJaasConfigValueFormat.FormatCurrentCulture(MockValues.KafkaUsername, MockValues.KafkaPassword))
			.WithCleanUp(true)
			.Build();
	}

	public static RedisContainer GetRedisContainer()
	{
		const string Image = "redis:latest";

		return new RedisBuilder(Image)
			.WithCleanUp(true)
			.Build();
	}
}
