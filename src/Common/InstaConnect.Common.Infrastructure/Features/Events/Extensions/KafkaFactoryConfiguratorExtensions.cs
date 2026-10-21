using Confluent.Kafka;

using InstaConnect.Common.Events.Features.Events.Abstractions;
using InstaConnect.Common.Infrastructure.Features.Events.Abstractions;

using MassTransit;

namespace InstaConnect.Common.Infrastructure.Features.Events.Extensions;

public static class KafkaFactoryConfiguratorExtensions
{
	extension(IKafkaFactoryConfigurator kafkaConfigurator)
	{
		public IKafkaFactoryConfigurator MapEventHandler<TEvent, TEventHandler>(IRiderRegistrationContext context, string prefix)
			where TEvent : class, IEventRequest
			where TEventHandler : class, IEventHandler<TEvent>
		{
			const string GroupIdFormat = "{0}-{1}";
			const int RetryLimit = 5;

			var topicName = KebabCaseEndpointNameFormatter.Instance.Message<TEvent>();

			kafkaConfigurator.TopicEndpoint<TEvent>(
				topicName,
				GroupIdFormat.FormatCurrentCulture(prefix, topicName),
				endpointConfigurator =>
				{
					endpointConfigurator.AutoOffsetReset = AutoOffsetReset.Earliest;
					endpointConfigurator.CreateIfMissing();

					endpointConfigurator.UseMessageRetry(retryConfigurator =>
					{
						retryConfigurator.Exponential(RetryLimit, TimeSpan.FromMilliseconds(200), TimeSpan.FromSeconds(10), TimeSpan.FromMilliseconds(200));
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
