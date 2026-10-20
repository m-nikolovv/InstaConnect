using Testcontainers.MongoDb;
using Testcontainers.RabbitMq;
using Testcontainers.Redis;

namespace InstaConnect.Common.Tests.Features.Utilities;

public static class ContainerFactory
{
	public static MongoDbContainer GetMongoDbContainer()
	{
		const string Image = "mongo:8.0";
		const string GlibcTunablesName = "GLIBC_TUNABLES";
		const string GlibcTunablesValue = "glibc.pthread.rseq=1";

		return new MongoDbBuilder(Image)
		   .WithEnvironment(GlibcTunablesName, GlibcTunablesValue)
		   .WithReplicaSet()
		   .WithCleanUp(true)
		   .Build();
	}

	public static RabbitMqContainer GetRabbitMqContainer()
	{
		const string Image = "rabbitmq:4.3-management";

		return new RabbitMqBuilder(Image)
			.WithCleanUp(true)
			.Build();
	}

	public static RedisContainer GetRedisContainer()
	{
		const string Image = "redis:7.4";

		return new RedisBuilder(Image)
			.WithCleanUp(true)
			.Build();
	}
}
