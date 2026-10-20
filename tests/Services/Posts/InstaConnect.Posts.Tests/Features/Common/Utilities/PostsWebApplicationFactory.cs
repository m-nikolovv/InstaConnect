using InstaConnect.Common.Tests.Features.Extensions;
using InstaConnect.Posts.Infrastructure.Features.Common.Extensions;
using InstaConnect.Posts.Tests.Features.PostComments.Extensions;
using InstaConnect.Posts.Tests.Features.Posts.Extensions;

using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;

using Testcontainers.MongoDb;
using Testcontainers.RabbitMq;

namespace InstaConnect.Posts.Tests.Features.Common.Utilities;

public class PostsWebApplicationFactory : WebApplicationFactory<Program>, IAsyncLifetime
{
	private readonly MongoDbContainer _mongoDbContainer;
	private readonly RabbitMqContainer _rabbitMqContainer;

	public PostsWebApplicationFactory()
	{
		_mongoDbContainer = ContainerFactory.GetMongoDbContainer();
		_rabbitMqContainer = ContainerFactory.GetRabbitMqContainer();
	}

	protected override void ConfigureWebHost(IWebHostBuilder builder)
	{
		builder.ConfigureTestServices(serviceCollection =>
		{
			serviceCollection.AddMockImageHandler();
			serviceCollection.AddPostMockSummarizer();
			serviceCollection.AddPostCommentMockSummarizer();
			serviceCollection.AddTestEventClient(_rabbitMqContainer.GetConnectionString(), PostsInfrastructureReference.Assembly);
		});

		builder.UpdateMongoConfiguration(_mongoDbContainer.GetConnectionString());
		builder.UpdateRabbitMqConfiguration(_rabbitMqContainer.GetConnectionString());
		builder.UpdateAccessTokenConfiguration();
		builder.UpdateCloudinaryConfiguration();
		builder.UpdateAnthropicConfiguration();
		builder.UpdateOpenTelemetryConfiguration();
		builder.UpdateCorsConfiguration();
		builder.UpdateMainConfiguration();
	}

	public async Task InitializeAsync()
	{
		await _mongoDbContainer.StartAsync();
		await _rabbitMqContainer.StartAsync();
	}

	public new async Task DisposeAsync()
	{
		await _mongoDbContainer.DisposeAsync().AsTask();
		await _rabbitMqContainer.DisposeAsync().AsTask();
	}
}
