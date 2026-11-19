using Confluent.Kafka;

using InstaConnect.Common.Events.Features.Events.Abstractions;
using InstaConnect.Common.Infrastructure.Features.Events.Abstractions;
using InstaConnect.Common.Infrastructure.Features.Events.Models;
using InstaConnect.Common.Infrastructure.Features.Events.Utilities;

using MassTransit;

namespace InstaConnect.Common.Infrastructure.Features.Events.Extensions;

public static class KafkaFactoryConfiguratorExtensions
{
	extension(IKafkaFactoryConfigurator kafkaConfigurator)
	{
		public IKafkaFactoryConfigurator MapEventHandler<TEvent, TEventHandler>(
			IRiderRegistrationContext context,
			string prefix,
			KafkaConsumerOptions consumerOptions)
			where TEvent : class, IEventRequest
			where TEventHandler : class, IEventHandler<TEvent>
		{
			const string GroupIdFormat = "{0}-{1}";

			var topicName = EventUtilities.GetName<TEvent>();

			kafkaConfigurator.TopicEndpoint<string, TEvent>(
				topicName,
				GroupIdFormat.FormatCurrentCulture(prefix, topicName),
				endpointConfigurator =>
				{
					endpointConfigurator.AutoOffsetReset = AutoOffsetReset.Earliest;
					endpointConfigurator.ConcurrentMessageLimit = consumerOptions.ConcurrentMessageLimit;
					endpointConfigurator.CreateIfMissing(topicOptions =>
					{
						topicOptions.NumPartitions = consumerOptions.PartitionCount;
						topicOptions.ReplicationFactor = consumerOptions.ReplicationFactor;
					});

					endpointConfigurator.UseMessageRetry(retryConfigurator =>
					{
						retryConfigurator.Exponential(
							consumerOptions.Retry.Limit,
							consumerOptions.Retry.MinInterval,
							consumerOptions.Retry.MaxInterval,
							consumerOptions.Retry.IntervalDelta);

						retryConfigurator.Handle<MongoException>();
						retryConfigurator.Handle<TimeoutException>();
					});

					endpointConfigurator.ConfigureConsumer<TEventHandler>(context);
				});

			return kafkaConfigurator;
		}
	}
}
