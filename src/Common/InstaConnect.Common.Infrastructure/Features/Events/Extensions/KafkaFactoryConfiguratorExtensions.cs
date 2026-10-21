using Confluent.Kafka;

using InstaConnect.Common.Events.Features.Events.Abstractions;
using InstaConnect.Common.Infrastructure.Features.Events.Abstractions;

using MassTransit;

namespace InstaConnect.Common.Infrastructure.Features.Events.Extensions;

public static class KafkaFactoryConfiguratorExtensions
{
	extension(IKafkaFactoryConfigurator kafkaConfigurator)
	{
		public IKafkaFactoryConfigurator MapEventHandler<TEvent, TEventHandler>(IRiderRegistrationContext context, string groupId)
			where TEvent : class, IEventRequest
			where TEventHandler : class, IEventHandler<TEvent>
		{
			kafkaConfigurator.TopicEndpoint<TEvent>(
				KebabCaseEndpointNameFormatter.Instance.Message<TEvent>(),
				groupId,
				endpointConfigurator =>
				{
					endpointConfigurator.AutoOffsetReset = AutoOffsetReset.Earliest;
					endpointConfigurator.CreateIfMissing();
					endpointConfigurator.ConfigureConsumer<TEventHandler>(context);
				});

			return kafkaConfigurator;
		}
	}
}
