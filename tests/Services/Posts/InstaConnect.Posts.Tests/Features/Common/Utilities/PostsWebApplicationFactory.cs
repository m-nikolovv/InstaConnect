using InstaConnect.Common.Tests.Features.Extensions;
using InstaConnect.Identity.Events.Features.Common.Extensions;
using InstaConnect.Posts.Events.Features.Common.Extensions;
using InstaConnect.Posts.Infrastructure.Features.Common.Extensions;
using InstaConnect.Posts.Infrastructure.Features.Common.Utilities;
using InstaConnect.Posts.Tests.Features.PostComments.Extensions;
using InstaConnect.Posts.Tests.Features.Posts.Extensions;

using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;

using Testcontainers.Kafka;
using Testcontainers.MongoDb;

namespace InstaConnect.Posts.Tests.Features.Common.Utilities;

public class PostsWebApplicationFactory : WebApplicationFactory<Program>, IAsyncLifetime
{
	private readonly KafkaContainer _kafkaContainer;
	private readonly MongoDbContainer _mongoDbContainer;

	public PostsWebApplicationFactory()
	{
		_kafkaContainer = ContainerFactory.GetKafkaContainer();
		_mongoDbContainer = ContainerFactory.GetMongoDbContainer();
	}

	protected override void ConfigureWebHost(IWebHostBuilder builder)
	{
		builder.ConfigureTestServices(serviceCollection =>
		{
			serviceCollection.AddMockImageHandler();
			serviceCollection.AddPostMockSummarizer();
			serviceCollection.AddPostCommentMockSummarizer();
			serviceCollection.AddTestEventClient((context, kafkaConfigurator, consumerOptions) => kafkaConfigurator.MapUserEventHandler(context, PostsEventHandlerUtilities.Prefix.GetTest(), consumerOptions), PostsInfrastructureReference.Assembly, PostsEventsReference.Assembly, IdentityEventsReference.Assembly);
		});

		builder.UpdateKafkaConfiguration(_kafkaContainer.GetBootstrapServers());
		builder.UpdateMongoConfiguration(_mongoDbContainer.GetConnectionString());
		builder.UpdateAccessTokenConfiguration();
		builder.UpdateCloudinaryConfiguration();
		builder.UpdateAnthropicConfiguration();
		builder.UpdateOpenTelemetryConfiguration();
		builder.UpdateCorsConfiguration();
		builder.UpdateMainConfiguration();
	}

	public async Task InitializeAsync()
	{
		await _kafkaContainer.StartAsync();
		await _mongoDbContainer.StartAsync();
	}

	public new async Task DisposeAsync()
	{
		await _kafkaContainer.DisposeAsync().AsTask();
		await _mongoDbContainer.DisposeAsync().AsTask();
	}
}
