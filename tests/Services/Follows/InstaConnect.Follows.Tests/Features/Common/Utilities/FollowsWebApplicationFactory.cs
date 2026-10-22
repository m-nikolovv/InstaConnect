using InstaConnect.Common.Tests.Features.Extensions;
using InstaConnect.Follows.Infrastructure.Features.Common.Extensions;
using InstaConnect.Follows.Infrastructure.Features.Common.Utilities;
using InstaConnect.Follows.Tests.Features.Common.Extensions;
using InstaConnect.Follows.Tests.Features.Users.Extensions;

using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;

using Testcontainers.Kafka;
using Testcontainers.MongoDb;
using Testcontainers.Redis;

namespace InstaConnect.Follows.Tests.Features.Common.Utilities;

public class FollowsWebApplicationFactory : WebApplicationFactory<Program>, IAsyncLifetime
{
	private readonly KafkaContainer _kafkaContainer;
	private readonly RedisContainer _redisContainer;
	private readonly MongoDbContainer _mongoDbContainer;

	public FollowsWebApplicationFactory()
	{
		_kafkaContainer = ContainerFactory.GetKafkaContainer();
		_redisContainer = ContainerFactory.GetRedisContainer();
		_mongoDbContainer = ContainerFactory.GetMongoDbContainer();
	}

	protected override void ConfigureWebHost(IWebHostBuilder builder)
	{
		builder.ConfigureTestServices(serviceCollection => serviceCollection.AddTestEventClient(riderConfigurator => riderConfigurator.MapUserEventProducer().MapFollowEventProducer(), (context, kafkaConfigurator, consumerOptions) => kafkaConfigurator.MapUserEventHandler(context, FollowsEventHandlerUtilities.Prefix.GetTest(), consumerOptions), FollowsInfrastructureReference.Assembly));

		builder.UpdateKafkaConfiguration(_kafkaContainer.GetBootstrapServers());
		builder.UpdateRedisConfiguration(_redisContainer.GetConnectionString());
		builder.UpdateMongoConfiguration(_mongoDbContainer.GetConnectionString());
		builder.UpdateAccessTokenConfiguration();
		builder.UpdateOpenTelemetryConfiguration();
		builder.UpdateCorsConfiguration();
		builder.UpdateMainConfiguration();
		builder.UpdateFollowConfiguration();
	}

	public async Task InitializeAsync()
	{
		await _kafkaContainer.StartAsync();
		await _redisContainer.StartAsync();
		await _mongoDbContainer.StartAsync();
	}

	public new async Task DisposeAsync()
	{
		await _kafkaContainer.DisposeAsync().AsTask();
		await _redisContainer.DisposeAsync().AsTask();
		await _mongoDbContainer.DisposeAsync().AsTask();
	}
}
