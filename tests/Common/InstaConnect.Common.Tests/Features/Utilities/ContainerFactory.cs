using Testcontainers.MongoDb;
using Testcontainers.RabbitMq;
using Testcontainers.Redis;

namespace InstaConnect.Common.Tests.Features.Utilities;

public static class ContainerFactory
{
	public static MongoDbContainer GetMongoDbContainer()
	{
		const string Image = "mongo:8.0.32";
		const string Username = "instaconnect";
		const string Password = "instaconnect";

		return new MongoDbBuilder(Image)
		   .WithUsername(Username)
		   .WithPassword(Password)
		   .WithReplicaSet()
		   .WithCleanUp(true)
		   .Build();
	}

	public static RabbitMqContainer GetRabbitMqContainer()
	{
		const string Image = "rabbitmq:4.3";

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
