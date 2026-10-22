using Confluent.Kafka;

using InstaConnect.Common.Events.Features.Events.Abstractions;
using InstaConnect.Common.Infrastructure.Features.Events.Abstractions;
using InstaConnect.Common.Infrastructure.Features.Events.Models;

using MassTransit;

namespace InstaConnect.Common.Infrastructure.Features.Events.Extensions;

public static class KafkaFactoryConfiguratorExtensions
{
	extension(IKafkaFactoryConfigurator kafkaConfigurator)
	{
		public IKafkaFactoryConfigurator MapEventHandler<TEvent, TEventHandler>(
			IRiderRegistrationContext context,
			string prefix,
			IDictionary<string, KafkaConsumerOptions> consumerOptions)
			where TEvent : class, IEventRequest
			where TEventHandler : class, IEventHandler<TEvent>
		{
			const string GroupIdFormat = "{0}-{1}";

			var topicName = KebabCaseEndpointNameFormatter.Instance.Message<TEvent>();
			var topicConsumerOptions = consumerOptions[topicName];

			kafkaConfigurator.TopicEndpoint<string, TEvent>(
				topicName,
				GroupIdFormat.FormatCurrentCulture(prefix, topicName),
				endpointConfigurator =>
				{
					endpointConfigurator.AutoOffsetReset = AutoOffsetReset.Earliest;
					endpointConfigurator.ConcurrentMessageLimit = topicConsumerOptions.ConcurrentMessageLimit;
					endpointConfigurator.CreateIfMissing(topicOptions =>
					{
						topicOptions.NumPartitions = topicConsumerOptions.PartitionCount;
						topicOptions.ReplicationFactor = topicConsumerOptions.ReplicationFactor;
					});

					endpointConfigurator.UseMessageRetry(retryConfigurator =>
					{
						retryConfigurator.Exponential(
							topicConsumerOptions.Retry.Limit,
							topicConsumerOptions.Retry.MinInterval,
							topicConsumerOptions.Retry.MaxInterval,
							topicConsumerOptions.Retry.IntervalDelta);

						retryConfigurator.Handle<MongoException>();
						retryConfigurator.Handle<TimeoutException>();
					});

					endpointConfigurator.UseMongoDbOutbox(context);

					endpointConfigurator.ConfigureConsumer<TEventHandler>(context);
				});

			return kafkaConfigurator;
		}
	}
}
