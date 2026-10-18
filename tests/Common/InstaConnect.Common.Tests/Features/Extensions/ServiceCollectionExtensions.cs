using System.Reflection;

using InstaConnect.Common.Events.Features.Events.Abstractions;
using InstaConnect.Common.Tests.Features.Abstractions;
using InstaConnect.Common.Tests.Features.Helpers;
using InstaConnect.Common.Tests.Features.Utilities;

using MassTransit;

using Microsoft.Extensions.DependencyInjection;

namespace InstaConnect.Common.Tests.Features.Extensions;

public static class ServiceCollectionExtensions
{
	extension(IServiceCollection serviceCollection)
	{
		public IServiceCollection AddTestEventClient(string connectionString, params Assembly[] currentAssemblies)
		{
			serviceCollection.AddMassTransitTestEventClient(connectionString, currentAssemblies);

			serviceCollection.AddSingleton<ITestHarnessFactory>(_ => new TestHarnessFactory(connectionString, currentAssemblies));
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

		internal IServiceCollection AddMassTransitTestEventClient(string connectionString, params Assembly[] currentAssemblies)
		{
			serviceCollection.AddMassTransitTestHarness(busConfigurator =>
			{
				busConfigurator.SetKebabCaseEndpointNameFormatter();

				busConfigurator.AddConsumers(currentAssemblies);

				busConfigurator.UsingRabbitMq((context, configurator) =>
				{
					configurator.Host(connectionString);

					configurator.ConfigureEndpoints(context);
				});
			});

			return serviceCollection;
		}
	}
}
