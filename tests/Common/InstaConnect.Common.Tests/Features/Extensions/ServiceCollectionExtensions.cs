using InstaConnect.Common.Events.Features.Events.Abstractions;
using InstaConnect.Common.Infrastructure.Features.Events.Extensions;
using InstaConnect.Common.Infrastructure.Features.Events.Models;
using InstaConnect.Common.Tests.Features.Helpers;

using MassTransit;

using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace InstaConnect.Common.Tests.Features.Extensions;

public static class ServiceCollectionExtensions
{
	extension(IServiceCollection serviceCollection)
	{
		public IServiceCollection AddTestEventClient(
			Action<IRiderRegistrationContext, IKafkaFactoryConfigurator, IDictionary<string, KafkaConsumerOptions>>? mapEventHandlers,
			params Assembly[] assemblies)
		{
			serviceCollection.AddSingleton<ITestHarnessFactory>(sp =>
				new TestHarnessFactory(sp.GetRequiredService<IOptions<KafkaOptions>>().Value, mapEventHandlers, assemblies));
			serviceCollection.AddSingleton<IEventClient, EventClient>();
			serviceCollection.AddScoped<IEventPublisher, TestEventPublisher>();

			return serviceCollection;
		}

		public IServiceCollection AddMockImageHandler()
		{
			serviceCollection.AddSingleton(_ => MockFactory.CreateImageHandler());

			return serviceCollection;
		}

		public IServiceCollection AddMockEmailSender()
		{
			serviceCollection.AddScoped(_ => MockFactory.CreateEmailSender());

			return serviceCollection;
		}

		internal IServiceCollection AddMassTransitTestEventClient(
			KafkaOptions options,
			Action<IRiderRegistrationContext, IKafkaFactoryConfigurator, IDictionary<string, KafkaConsumerOptions>>? mapEventHandlers,
			params Assembly[] assemblies)
		{
			serviceCollection.AddMassTransitTestHarness(busConfigurator =>
				busConfigurator.AddKafka(options, mapEventHandlers, assemblies));

			return serviceCollection;
		}
	}
}
