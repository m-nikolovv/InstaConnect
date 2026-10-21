using InstaConnect.Common.Events.Features.Events.Abstractions;
using InstaConnect.Common.Infrastructure.Features.Events.Extensions;

using MassTransit;

namespace InstaConnect.Common.Infrastructure.Features.Events.Helpers;

public class EventPublisher : IEventPublisher
{
	private readonly ITopicProducerProvider _topicProducerProvider;

	public EventPublisher(ITopicProducerProvider topicProducerProvider)
	{
		_topicProducerProvider = topicProducerProvider;
	}

	public async Task PublishAsync<TEvent>(TEvent message, CancellationToken cancellationToken)
		where TEvent : class, IEventRequest
	{
		await _topicProducerProvider.GetEventProducer<TEvent>().Produce(message, cancellationToken);
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
