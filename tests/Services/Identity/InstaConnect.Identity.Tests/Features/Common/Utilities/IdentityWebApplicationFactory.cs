using InstaConnect.Common.Tests.Features.Extensions;
using InstaConnect.Identity.Infrastructure.Features.Common.Extensions;
using InstaConnect.Identity.Tests.Features.Common.Extensions;

using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;

using Testcontainers.Kafka;
using Testcontainers.MongoDb;
using Testcontainers.Redis;

namespace InstaConnect.Identity.Tests.Features.Common.Utilities;

public class IdentityWebApplicationFactory : WebApplicationFactory<Program>, IAsyncLifetime
{
	private readonly KafkaContainer _kafkaContainer;
	private readonly RedisContainer _redisContainer;
	private readonly MongoDbContainer _mongoDbContainer;

	public IdentityWebApplicationFactory()
	{
		_kafkaContainer = ContainerFactory.GetKafkaContainer();
		_redisContainer = ContainerFactory.GetRedisContainer();
		_mongoDbContainer = ContainerFactory.GetMongoDbContainer();
	}

	protected override void ConfigureWebHost(IWebHostBuilder builder)
	{
		builder.ConfigureTestServices(serviceCollection =>
		{
			serviceCollection.AddMockImageHandler();
			serviceCollection.AddMockEmailSender();
			serviceCollection.AddTestEventClient(null, IdentityInfrastructureReference.Assembly);
		});

		builder.UpdateKafkaConfiguration(_kafkaContainer.GetBootstrapServers());
		builder.UpdateRedisConfiguration(_redisContainer.GetConnectionString());
		builder.UpdateMongoConfiguration(_mongoDbContainer.GetConnectionString());
		builder.UpdateAccessTokenConfiguration();
		builder.UpdateOpenTelemetryConfiguration();
		builder.UpdateCloudinaryConfiguration();
		builder.UpdateCorsConfiguration();
		builder.UpdateMainConfiguration();
		builder.UpdateSendGridConfiguration();
		builder.UpdateAdminConfiguration();
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
