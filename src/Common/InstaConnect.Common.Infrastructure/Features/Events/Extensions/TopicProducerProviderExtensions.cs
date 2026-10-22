using InstaConnect.Common.Events.Features.Events.Abstractions;

using MassTransit;

namespace InstaConnect.Common.Infrastructure.Features.Events.Extensions;

public static class TopicProducerProviderExtensions
{
	extension(ITopicProducerProvider topicProducerProvider)
	{
		public ITopicProducer<TEvent> GetEventProducer<TEvent>(IEventKeySelector<TEvent> keySelector)
			where TEvent : class, IEventRequest
		{
			const string TopicAddressFormat = "topic:{0}";

			var topicAddress = new Uri(TopicAddressFormat.FormatCurrentCulture(KebabCaseEndpointNameFormatter.Instance.Message<TEvent>()));

			return topicProducerProvider.GetProducer<string, TEvent>(topicAddress, context => keySelector.GetKey(context.Message));
		}
	}
}
