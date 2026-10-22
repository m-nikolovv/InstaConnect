using System.Reflection;

using InstaConnect.Common.Infrastructure.Features.Events.Models;

using MassTransit;

namespace InstaConnect.Common.Infrastructure.Features.Events.Extensions;

public static class BusRegistrationConfiguratorExtensions
{
	extension(IBusRegistrationConfigurator busConfigurator)
	{
		public IBusRegistrationConfigurator AddMongoDbOutbox()
		{
			busConfigurator.AddMongoDbOutbox(o =>
			{
				o.ClientFactory(provider => provider.GetRequiredService<IMongoClient>());
				o.DatabaseFactory(provider => provider.GetRequiredService<IMongoDatabase>());

				o.UseBusOutbox();
			});

			return busConfigurator;
		}

		public IBusRegistrationConfigurator AddKafka(
			KafkaOptions options,
			Action<IRiderRegistrationConfigurator>? mapEventProducers,
			Action<IRiderRegistrationContext, IKafkaFactoryConfigurator, IDictionary<string, KafkaConsumerOptions>>? mapEventHandlers,
			params Assembly[] assemblies)
		{
			busConfigurator.UsingInMemory();

			busConfigurator.AddRider(riderConfigurator =>
			{
				riderConfigurator.AddConsumers(assemblies);

				mapEventProducers?.Invoke(riderConfigurator);

				riderConfigurator.UsingKafka((context, kafkaConfigurator) =>
				{
					kafkaConfigurator.Host(options.ConnectionString, hostConfigurator => hostConfigurator.UseSasl(saslConfigurator =>
					{
						saslConfigurator.Mechanism = options.SaslMechanism;
						saslConfigurator.SecurityProtocol = options.SecurityProtocol;
						saslConfigurator.Username = options.Username;
						saslConfigurator.Password = options.Password;
					}));

					mapEventHandlers?.Invoke(context, kafkaConfigurator, options.Consumers);
				});
			});

			return busConfigurator;
		}
	}
}
