using InstaConnect.Chats.Infrastructure.Features.Common.Extensions;
using InstaConnect.Chats.Tests.Features.ChatMessages.Extensions;
using InstaConnect.Chats.Tests.Features.Common.Extensions;
using InstaConnect.Common.Tests.Features.Extensions;

using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;

using Testcontainers.MongoDb;
using Testcontainers.RabbitMq;
using Testcontainers.Redis;

namespace InstaConnect.Chats.Tests.Features.Common.Utilities;

public class ChatsWebApplicationFactory : WebApplicationFactory<Program>, IAsyncLifetime
{
	private readonly RedisContainer _redisContainer;
	private readonly MongoDbContainer _mongoDbContainer;
	private readonly RabbitMqContainer _rabbitMqContainer;

	public ChatsWebApplicationFactory()
	{
		_redisContainer = ContainerFactory.GetRedisContainer();
		_mongoDbContainer = ContainerFactory.GetMongoDbContainer();
		_rabbitMqContainer = ContainerFactory.GetRabbitMqContainer();
	}

	protected override void ConfigureWebHost(IWebHostBuilder builder)
	{
		builder.ConfigureTestServices(serviceCollection =>
		{
			serviceCollection.AddMockImageHandler();
			serviceCollection.AddChatMessageMockSummarizer();
			serviceCollection.AddTestEventClient(_rabbitMqContainer.GetConnectionString(), ChatsInfrastructureReference.Assembly);
		});

		builder.UpdateRedisConfiguration(_redisContainer.GetConnectionString());
		builder.UpdateMongoConfiguration(_mongoDbContainer.GetConnectionString());
		builder.UpdateRabbitMqConfiguration(_rabbitMqContainer.GetConnectionString());
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
		await _redisContainer.StartAsync();
		await _mongoDbContainer.StartAsync();
		await _rabbitMqContainer.StartAsync();
	}

	public new async Task DisposeAsync()
	{
		await _redisContainer.DisposeAsync().AsTask();
		await _mongoDbContainer.DisposeAsync().AsTask();
		await _rabbitMqContainer.DisposeAsync().AsTask();
	}
}
