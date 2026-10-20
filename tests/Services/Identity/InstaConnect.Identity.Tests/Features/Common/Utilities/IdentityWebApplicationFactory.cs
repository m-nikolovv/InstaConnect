using InstaConnect.Common.Tests.Features.Extensions;
using InstaConnect.Identity.Infrastructure.Features.Common.Extensions;
using InstaConnect.Identity.Tests.Features.Common.Extensions;

using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;

using Testcontainers.MongoDb;
using Testcontainers.RabbitMq;
using Testcontainers.Redis;

namespace InstaConnect.Identity.Tests.Features.Common.Utilities;

public class IdentityWebApplicationFactory : WebApplicationFactory<Program>, IAsyncLifetime
{
	private readonly RedisContainer _redisContainer;
	private readonly MongoDbContainer _mongoDbContainer;
	private readonly RabbitMqContainer _rabbitMqContainer;

	public IdentityWebApplicationFactory()
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
			serviceCollection.AddMockEmailSender();
			serviceCollection.AddTestEventClient(_rabbitMqContainer.GetConnectionString(), IdentityInfrastructureReference.Assembly);
		});

		builder.UpdateMongoConfiguration(_mongoDbContainer.GetConnectionString());
		builder.UpdateRabbitMqConfiguration(_rabbitMqContainer.GetConnectionString());
		builder.UpdateRedisConfiguration(_redisContainer.GetConnectionString());
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
