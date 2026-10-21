using System.Reflection;

using Confluent.Kafka;

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
			Action<IRiderRegistrationContext, IKafkaFactoryConfigurator>? mapEventHandlers,
			params Assembly[] assemblies)
		{
			busConfigurator.UsingInMemory();

			busConfigurator.AddRider(riderConfigurator =>
			{
				riderConfigurator.AddConsumers(assemblies);

				riderConfigurator.UsingKafka((context, kafkaConfigurator) =>
				{
					kafkaConfigurator.Host(options.ConnectionString, hostConfigurator => hostConfigurator.UseSasl(saslConfigurator =>
					{
						saslConfigurator.Mechanism = SaslMechanism.Plain;
						saslConfigurator.SecurityProtocol = SecurityProtocol.SaslPlaintext;
						saslConfigurator.Username = options.Username;
						saslConfigurator.Password = options.Password;
					}));

					mapEventHandlers?.Invoke(context, kafkaConfigurator);
				});
			});

			return busConfigurator;
		}
	}
}
