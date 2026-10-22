using InstaConnect.Common.Events.Features.Events.Abstractions;
using InstaConnect.Common.Infrastructure.Features.Events.Abstractions;
using InstaConnect.Common.Infrastructure.Features.Events.Extensions;

using MassTransit;

namespace InstaConnect.Common.Infrastructure.Features.Events.Helpers;

public class EventPublisher : IEventPublisher
{
	private readonly ITopicProducerProvider _topicProducerProvider;
	private readonly IEventKeySelectorProvider _eventKeySelectorProvider;

	public EventPublisher(ITopicProducerProvider topicProducerProvider, IEventKeySelectorProvider eventKeySelectorProvider)
	{
		_topicProducerProvider = topicProducerProvider;
		_eventKeySelectorProvider = eventKeySelectorProvider;
	}

	public async Task PublishAsync<TEvent>(TEvent message, CancellationToken cancellationToken)
		where TEvent : class, IEventRequest
	{
		var keySelector = _eventKeySelectorProvider.GetKeySelector<TEvent>();
		var producer = _topicProducerProvider.GetEventProducer(keySelector);

		await producer.Produce(message, cancellationToken);
	}

	public async Task PublishAsync<TEvent>(ICollection<TEvent> messages, CancellationToken cancellationToken)
		where TEvent : class, IEventRequest
	{
		foreach (var message in messages)
		{
			await PublishAsync(message, cancellationToken);
		}
	}
}
