using InstaConnect.Chats.Infrastructure.Features.Common.Extensions;
using InstaConnect.Chats.Infrastructure.Features.Common.Utilities;
using InstaConnect.Chats.Tests.Features.ChatMessages.Extensions;
using InstaConnect.Chats.Tests.Features.Common.Extensions;
using InstaConnect.Common.Tests.Features.Extensions;

using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;

using Testcontainers.Kafka;
using Testcontainers.MongoDb;
using Testcontainers.Redis;

namespace InstaConnect.Chats.Tests.Features.Common.Utilities;

public class ChatsWebApplicationFactory : WebApplicationFactory<Program>, IAsyncLifetime
{
	private readonly KafkaContainer _kafkaContainer;
	private readonly RedisContainer _redisContainer;
	private readonly MongoDbContainer _mongoDbContainer;

	public ChatsWebApplicationFactory()
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
			serviceCollection.AddChatMessageMockSummarizer();
			serviceCollection.AddTestEventClient((context, kafkaConfigurator) => kafkaConfigurator.MapUserEventHandler(context, ChatsEventHandlerUtilities.GroupId.GetTest()), ChatsInfrastructureReference.Assembly);
		});

		builder.UpdateKafkaConfiguration(_kafkaContainer.GetBootstrapServers());
		builder.UpdateRedisConfiguration(_redisContainer.GetConnectionString());
		builder.UpdateMongoConfiguration(_mongoDbContainer.GetConnectionString());
		builder.UpdateAccessTokenConfiguration();
		builder.UpdateCloudinaryConfiguration();
		builder.UpdateAnthropicConfiguration();
		builder.UpdateOpenTelemetryConfiguration();
		builder.UpdateCorsConfiguration();
		builder.UpdateMainConfiguration();
		builder.UpdateChatMessageConfiguration();
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
