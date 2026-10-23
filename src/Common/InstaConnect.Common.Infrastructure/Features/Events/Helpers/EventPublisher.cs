using InstaConnect.Common.Events.Features.Events.Abstractions;
using InstaConnect.Common.Infrastructure.Features.OutboxEvents.Abstractions;

namespace InstaConnect.Common.Infrastructure.Features.Events.Helpers;

public class EventPublisher : IEventPublisher
{
	private readonly IOutboxEventFactory _outboxEventFactory;
	private readonly IOutboxEventCommandRepository _outboxEventRepository;

	public EventPublisher(
		IOutboxEventFactory outboxEventFactory,
		IOutboxEventCommandRepository outboxEventRepository)
	{
		_outboxEventFactory = outboxEventFactory;
		_outboxEventRepository = outboxEventRepository;
	}

	public async Task PublishAsync<TEvent>(TEvent message, CancellationToken cancellationToken)
		where TEvent : class, IEventRequest
	{
		var outboxEvent = _outboxEventFactory.Create(message);

		await _outboxEventRepository.AddAsync(outboxEvent, cancellationToken);
	}

	public async Task PublishRangeAsync<TEvent>(ICollection<TEvent> messages, CancellationToken cancellationToken)
		where TEvent : class, IEventRequest
	{
		var outboxEvents = _outboxEventFactory.CreateRange(messages);

		await _outboxEventRepository.AddRangeAsync(outboxEvents, cancellationToken);
	}
}
