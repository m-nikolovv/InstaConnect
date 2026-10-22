using System.Reflection;

using InstaConnect.Common.Events.Features.Events.Abstractions;
using InstaConnect.Common.Infrastructure.Features.Events.Abstractions;
using InstaConnect.Common.Infrastructure.Features.Events.Helpers;
using InstaConnect.Common.Infrastructure.Features.Events.Models;

using MassTransit;

namespace InstaConnect.Common.Infrastructure.Features.Events.Extensions;

public static class ServiceCollectionExtensions
{
	extension(IServiceCollection serviceCollection)
	{
		public IServiceCollection AddEvents(
			IConfiguration configuration,
			Action<IRiderRegistrationContext, IKafkaFactoryConfigurator, IDictionary<string, KafkaConsumerOptions>>? mapEventHandlers,
			params Assembly[] assemblies)
		{
			serviceCollection.AddValidatedOptions<KafkaOptions>(KafkaOptions.SectionName);
			var options = configuration.GetOptions<KafkaOptions>(KafkaOptions.SectionName);

			serviceCollection.AddMassTransit(busConfigurator =>
			{
				busConfigurator.AddMongoDbOutbox();

				busConfigurator.AddKafka(options, mapEventHandlers, assemblies);
			});

			serviceCollection.AddImplementationsOf(typeof(IEventKeySelector<>), assemblies);
			serviceCollection.AddSingleton<IEventKeySelectorProvider, EventKeySelectorProvider>();
			serviceCollection.AddScoped<IEventPublisher, EventPublisher>();

			return serviceCollection;
		}
	}
}
