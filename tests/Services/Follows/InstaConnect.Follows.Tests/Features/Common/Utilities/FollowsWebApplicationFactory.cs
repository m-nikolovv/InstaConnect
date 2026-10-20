using InstaConnect.Common.Tests.Features.Extensions;
using InstaConnect.Follows.Infrastructure.Features.Common.Extensions;
using InstaConnect.Follows.Tests.Features.Common.Extensions;

using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;

using Testcontainers.MongoDb;
using Testcontainers.RabbitMq;
using Testcontainers.Redis;

namespace InstaConnect.Follows.Tests.Features.Common.Utilities;

public class FollowsWebApplicationFactory : WebApplicationFactory<Program>, IAsyncLifetime
{
	private readonly RedisContainer _redisContainer;
	private readonly MongoDbContainer _mongoDbContainer;
	private readonly RabbitMqContainer _rabbitMqContainer;

	public FollowsWebApplicationFactory()
	{
		_redisContainer = ContainerFactory.GetRedisContainer();
		_mongoDbContainer = ContainerFactory.GetMongoDbContainer();
		_rabbitMqContainer = ContainerFactory.GetRabbitMqContainer();
	}

	protected override void ConfigureWebHost(IWebHostBuilder builder)
	{
		builder.ConfigureTestServices(serviceCollection => serviceCollection.AddTestEventClient(_rabbitMqContainer.GetConnectionString(), FollowsInfrastructureReference.Assembly));

		builder.UpdateRedisConfiguration(_redisContainer.GetConnectionString());
		builder.UpdateMongoConfiguration(_mongoDbContainer.GetConnectionString());
		builder.UpdateRabbitMqConfiguration(_rabbitMqContainer.GetConnectionString());
		builder.UpdateAccessTokenConfiguration();
		builder.UpdateOpenTelemetryConfiguration();
		builder.UpdateCorsConfiguration();
		builder.UpdateMainConfiguration();
		builder.UpdateFollowConfiguration();
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
